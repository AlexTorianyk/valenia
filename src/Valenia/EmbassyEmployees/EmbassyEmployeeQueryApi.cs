using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.EmbassyEmployees
{
    [Route("/embassy")]
    public class EmbassyEmployeeQueryApi : Controller
    {
        private static readonly ILogger _log = Log.ForContext<EmbassyEmployeeQueryApi>();
        private readonly IAsyncDocumentSession _session;

        public EmbassyEmployeeQueryApi(IAsyncDocumentSession session)
            => _session = session;

        [HttpGet]
        public Task<IActionResult> Get(EmbassyEmployeeQueryModels.GetDetails request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);
    }
}
