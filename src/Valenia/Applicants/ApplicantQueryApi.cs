using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Applicants
{
    [Route("/applicant")]
    public class ApplicantQueryApi : Controller
    {
        private readonly IAsyncDocumentSession _session;
        private static readonly ILogger _log = Log.ForContext<ApplicantQueryApi>();

        public ApplicantQueryApi(IAsyncDocumentSession session)
            => _session = session;

        [HttpGet]
        public Task<IActionResult> Get(ApplicantQueryModels.GetDetails request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);
    }
}
