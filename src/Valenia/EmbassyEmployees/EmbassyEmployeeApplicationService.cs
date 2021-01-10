using System;
using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.Shared;
using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Domain.Users.Shared;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.EmbassyEmployees
{
    public class EmbassyEmployeeApplicationService : IApplicationService, IScoped
    {
        private readonly IEmbassyEmployeeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public EmbassyEmployeeApplicationService(IEmbassyEmployeeRepository repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public Task Handle(object command)
            =>
                command switch
                {
                    EmbassyEmployeeCommands.Register cmd =>
                    HandleCreate(cmd),
                    EmbassyEmployeeCommands.UpdateRole cmd =>
                    HandleUpdate(cmd.Id, e => e.SetRole(cmd.Role)),
                    EmbassyEmployeeCommands.Fire cmd =>
                    HandleUpdate(cmd.Id, e => e.Fire()),
                    _ => Task.CompletedTask
                };

        private async Task HandleCreate(EmbassyEmployeeCommands.Register cmd)
        {
            var embassyEmployee = new EmbassyEmployee(FullName.FromString(cmd.FullName),
                Email.FromString(cmd.Email),
                Password.FromString(cmd.Password, _passwordHasher), cmd.Role);

            await _repository.Add(embassyEmployee);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid embassyEmployeeId, Action<EmbassyEmployee> operation)
        {
            var embassyEmployee = await _repository.Load(embassyEmployeeId.ToString());

            if (embassyEmployee == null)
                throw new InvalidOperationException(
                    $"Employee with id {embassyEmployeeId} cannot be found"
                );

            operation(embassyEmployee);
            await _unitOfWork.Commit();
        }
    }
}
