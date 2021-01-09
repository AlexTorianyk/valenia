using System.Threading.Tasks;

namespace Valenia.Domain.Users.Applicants
{
    public interface IApplicantRepository
    {
        Task<Applicant> Load(ApplicantId id);

        Task Add(Applicant entity);
    }
}
