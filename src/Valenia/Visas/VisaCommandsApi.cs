using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Visas
{
    [Route("/visa")]
    public class VisaCommandsApi : Controller
    {
        private readonly VisaApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<VisaCommandsApi>();

        public VisaCommandsApi(
            VisaApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(VisaCommands.Create request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("goal")]
        public Task<IActionResult> Put(VisaCommands.SetGoal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("type")]
        public Task<IActionResult> Put(VisaCommands.UpdateType request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("processing-time")]
        public Task<IActionResult> Put(VisaCommands.SetExpectedProcessingTime request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPost]
        [Route("requirement")]
        public Task<IActionResult> Post(RequirementCommands.AddToVisa request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("requirement/name")]
        [HttpPut]
        public Task<IActionResult> Put(RequirementCommands.UpdateName request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("requirement/description")]
        [HttpPut]
        public Task<IActionResult> Put(RequirementCommands.UpdateDescription request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("requirement/example")]
        [HttpPut]
        public Task<IActionResult> Put(RequirementCommands.UpdateExample request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
