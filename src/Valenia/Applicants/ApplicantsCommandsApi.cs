using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Applicants
{
    [Route("/applicant")]
    public class ApplicantsCommandsApi : Controller
    {
        private readonly ApplicantApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ApplicantsCommandsApi>();

        public ApplicantsCommandsApi(
            ApplicantApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(ApplicantCommands.Register request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
