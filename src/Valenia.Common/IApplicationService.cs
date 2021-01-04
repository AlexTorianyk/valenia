using System.Threading.Tasks;

namespace Valenia.Common
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
