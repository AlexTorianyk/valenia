using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;
using VeritySDK.Protocols.Provision;
using VeritySDK.Utils;

namespace Valenia.Verity.Context
{
    public class ContextApplicationService : IApplicationService, IScoped
    {
        private readonly IContextRepository _repository;

        public ContextApplicationService(IContextRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(object command)
        {
            switch (command)
            {
                case ContextCommands.Provision cmd:
                    var provisioner = Provision.v0_7(cmd.Token);
                    var ctx = ContextBuilder.fromScratch(cmd.WalletId, cmd.WalletKey, cmd.VerityApplicationEndpoint);
                    var provisioningResponse = provisioner.provision(ctx);
                    var context = new Context(provisioningResponse);
                    _repository.Add(context);
                    break;
            }
        }
    }
}
