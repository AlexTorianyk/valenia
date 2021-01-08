using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Visas
{
    [Route("/visa")]
    public class VisaQueryApi : Controller
    {
        private static readonly ILogger _log = Log.ForContext<VisaQueryApi>();

        private readonly IAsyncDocumentSession _session;

        public VisaQueryApi(IAsyncDocumentSession session)
            => _session = session;

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetVisaDetails request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);

        [HttpGet]
        [Route("goals")]
        public Task<IActionResult> Get(QueryModels.GetVisaGoalsByType request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);


        [HttpGet]
        [Route("requirements")]
        public Task<IActionResult> Get(QueryModels.GetVisaRequirements request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);
    }
}
