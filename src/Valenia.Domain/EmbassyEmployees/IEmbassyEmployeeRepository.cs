using System.Threading.Tasks;

namespace Valenia.Domain.EmbassyEmployees
{
    public interface IEmbassyEmployeeRepository
    {
        Task<EmbassyEmployee> Load(EmbassyEmployeeId id);
        Task Add(EmbassyEmployee entity);
    }
}
