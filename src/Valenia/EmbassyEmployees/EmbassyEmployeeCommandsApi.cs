using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.EmbassyEmployees
{
    [Route("/embassy")]
    public class EmbassyEmployeeCommandsApi : Controller
    {
        private readonly EmbassyEmployeeApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<EmbassyEmployeeCommandsApi>();

        public EmbassyEmployeeCommandsApi(
            EmbassyEmployeeApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(EmbassyEmployeeCommands.Register request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        public Task<IActionResult> Put(EmbassyEmployeeCommands.UpdateRole request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        public Task<IActionResult> Put(EmbassyEmployeeCommands.Fire request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
