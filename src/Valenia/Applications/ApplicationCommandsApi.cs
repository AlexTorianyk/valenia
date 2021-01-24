using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Applications
{
    [Route("/application")]
    public class ApplicationCommandsApi : Controller
    {
        private readonly ApplicationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ApplicationCommandsApi>();

        public ApplicationCommandsApi(
            ApplicationApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(ApplicationCommands.Submit request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("assign")]
        public Task<IActionResult> Put(ApplicationCommands.AssignToReviewer request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPost]
        [Route("document")]
        public Task<IActionResult> Put(ApplicationCommands.AddDocument request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("request-changes")]
        public Task<IActionResult> Put(ApplicationCommands.RequestChanges request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [HttpPut]
        [Route("approve")]
        public Task<IActionResult> Put(ApplicationCommands.Approve request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
