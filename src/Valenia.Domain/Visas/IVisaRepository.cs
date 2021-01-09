using System.Threading.Tasks;

namespace Valenia.Domain.Visas
{
    public interface IVisaRepository
    {
        Task<Visa> Load(VisaId id);
        Task Add(Visa entity);
    }
}
