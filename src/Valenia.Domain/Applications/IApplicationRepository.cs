using System.Threading.Tasks;

namespace Valenia.Domain.Applications
{
    public interface IApplicationRepository
    {
        Task<Application> Load(ApplicationId id);
        Task Add(Application entity);
    }
}
