using System.Threading.Tasks;

namespace Valenia.Common
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
