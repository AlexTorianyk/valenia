using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.Shared;
using Valenia.Domain.Users.Applicants;
using Valenia.Domain.Users.Shared;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Applicants
{
    public class ApplicantApplicationService : IApplicationService, IScoped
    {
        private readonly IApplicantRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public ApplicantApplicationService(IApplicantRepository repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public Task Handle(object command)
            =>
                command switch
                {
                    ApplicantCommands.Register cmd =>
                    HandleCreate(cmd),
                    _ => Task.CompletedTask
                };

        private async Task HandleCreate(ApplicantCommands.Register cmd)
        {
            var embassyEmployee = new Applicant(FullName.FromString(cmd.FullName),
                Email.FromString(cmd.Email),
                Password.FromString(cmd.Password, _passwordHasher));

            await _repository.Add(embassyEmployee);
            await _unitOfWork.Commit();
        }
    }
}
