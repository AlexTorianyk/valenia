using Valenia.Common;
using Valenia.Domain.TrustAnchors;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using VeritySDK.Handler;
using VeritySDK.Protocols;
using VeritySDK.Utils;

namespace Valenia.Trust_Anchors
{
    public class IssuerSetupHandler : ITransient
    {
        private readonly ITrustAnchorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private MessageFamily _handler;
        private MessageHandler.Handler _messageHandler;

        public IssuerSetupHandler(ITrustAnchorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual void SetUp(MessageFamily handler)
        {
            _handler = handler;
            _messageHandler = async (messageName, message) =>
            {
                if ("public-identifier-created".Equals(messageName))
                {
                    var json_identifier = message.GetValue("identifier");
                    var issuerDID = json_identifier["did"];
                    var issuerVerKey = json_identifier["verKey"];

                    var trustAnchor = new TrustAnchor(issuerDID.ToString(), issuerVerKey.ToString());
                    await _repository.Add(trustAnchor);
                    await _unitOfWork.Commit();
                }
            };
        }
    }
}
