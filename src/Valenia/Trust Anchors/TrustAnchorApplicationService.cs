using System;
using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.TrustAnchors;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using Valenia.Verity.Contexts;
using VeritySDK.Protocols.IssuerSetup;

namespace Valenia.Trust_Anchors
{
    public class TrustAnchorApplicationService : IApplicationService, IScoped
    {
        private readonly ITrustAnchorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IssuerSetupHandler _issuerSetupHandler;
        private readonly Context _context;

        public TrustAnchorApplicationService(ITrustAnchorRepository repository, IUnitOfWork unitOfWork, IssuerSetupHandler issuerSetupHandler, Context context)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _issuerSetupHandler = issuerSetupHandler;
            _context = context;
        }

        public Task Handle(object command)
            =>
                command switch
                {
                    TrustAnchorCommands.Register _ =>
                    HandleCreate(),
                    TrustAnchorCommands.UpdateConfiguration cmd =>
                    HandleUpdate(cmd.DID, t => t.UpdateConfiguration(TrustAnchorName.FromString(cmd.Name), cmd.LogoUrl)),
                    _ => Task.CompletedTask
                };

        private Task HandleCreate()
        {
            var issuerSetup = IssuerSetup.v0_6();

            _issuerSetupHandler.SetUp(issuerSetup);

            issuerSetup.create(_context.VerityContext);

            return Task.CompletedTask;
        }

        private async Task HandleUpdate(string trustAnchorDID, Action<TrustAnchor> operation)
        {
            var trustAnchor = await _repository.Load(new TrustAnchorDID(trustAnchorDID));

            if (trustAnchor == null)
                throw new InvalidOperationException(
                    $"Trust anchor with did {trustAnchorDID} cannot be found"
                );

            operation(trustAnchor);
            await _unitOfWork.Commit();
        }
    }
}
