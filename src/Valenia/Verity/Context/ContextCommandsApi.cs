using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Verity.Context
{
    [Route("/context")]
    public class ContextCommandsApi : Controller
    {
        private readonly ContextApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ContextCommandsApi>();

        public ContextCommandsApi(
            ContextApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        [Route("provision")]
        public Task<IActionResult> Post(ContextCommands.Provision request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
