using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Serilog;
using Valenia.Infrastructure.Application;

namespace Valenia.Trust_Anchors
{
    [Route("/trust-anchor")]
    public class TrustAnchorQueryApi : Controller
    {
        private static readonly ILogger _log = Log.ForContext<TrustAnchorQueryApi>();
        private readonly IAsyncDocumentSession _session;

        public TrustAnchorQueryApi(IAsyncDocumentSession session)
            => _session = session;

        [HttpGet]
        public Task<IActionResult> Get(TrustAnchorQueryModels.GetBrandInfo request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);

        [HttpGet]
        [Route("verity")]
        public Task<IActionResult> Get(TrustAnchorQueryModels.GetVerityFieldsByName request)
            => RequestHandler.HandleQuery(() => _session.Query(request), _log);
    }
}
