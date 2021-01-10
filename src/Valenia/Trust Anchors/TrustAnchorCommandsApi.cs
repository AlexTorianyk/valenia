using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Trust_Anchors
{
    [Route("/trust-anchor")]
    public class TrustAnchorCommandsApi : Controller
    {
        private readonly TrustAnchorApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<TrustAnchorCommandsApi>();

        public TrustAnchorCommandsApi(TrustAnchorApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(TrustAnchorCommands.Register request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("configuration")]
        [HttpPut]
        public Task<IActionResult> Put(TrustAnchorCommands.UpdateConfiguration request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
