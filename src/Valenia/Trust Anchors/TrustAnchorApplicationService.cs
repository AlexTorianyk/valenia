using System;
using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.TrustAnchors;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Trust_Anchors
{
    public class TrustAnchorApplicationService : IApplicationService, IScoped
    {
        private readonly ITrustAnchorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TrustAnchorApplicationService(ITrustAnchorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command)
            =>
                command switch
                {
                    TrustAnchorCommands.Register cmd =>
                    HandleCreate(cmd),
                    TrustAnchorCommands.UpdateConfiguration cmd =>
                    HandleUpdate(cmd.DID, t => t.UpdateConfiguration(TrustAnchorName.FromString(cmd.Name), cmd.Url)),
                    _ => Task.CompletedTask
                };

        private async Task HandleCreate(TrustAnchorCommands.Register cmd)
        {
           //
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
