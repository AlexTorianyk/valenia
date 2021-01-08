using System;
using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.Visas;
using Valenia.Domain.Visas.Requirements;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Visas
{
    public class VisaApplicationService : IApplicationService, IScoped
    {
        private readonly IVisaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VisaApplicationService(IVisaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command)
        =>
        command switch
        {
            VisaCommands.Create cmd =>
            HandleCreate(cmd),
            VisaCommands.SetGoal cmd =>
            HandleUpdate(cmd.Id, v => v.SetGoal(VisaGoal.FromString(cmd.Goal))),
            VisaCommands.UpdateType cmd =>
            HandleUpdate(cmd.Id, v => v.UpdateType(cmd.Type)),
            VisaCommands.SetExpectedProcessingTime cmd =>
            HandleUpdate(cmd.Id, v => v.SetExpectedProcessingTime(VisaExpectedProcessingTime.FromInt(cmd.ExceptedProcessingTime))),
            RequirementCommands.AddToVisa cmd =>
            HandleUpdate(cmd.VisaId, v => v.AddRequirement(RequirementName.FromString(cmd.Name), RequirementDescription.FromString(cmd.Description), RequirementExample.FromString(cmd.Example))),
            RequirementCommands.UpdateName cmd =>
            HandleUpdate(cmd.VisaId, v => v.UpdateRequirementName(new RequirementId(cmd.RequirementId), RequirementName.FromString(cmd.Name))),
            RequirementCommands.UpdateDescription cmd => 
            HandleUpdate(cmd.VisaId, v => v.UpdateRequirementDescription(new RequirementId(cmd.RequirementId), RequirementDescription.FromString(cmd.Description))),
            RequirementCommands.UpdateExample cmd =>
            HandleUpdate(cmd.VisaId, v => v.UpdateRequirementExample(new RequirementId(cmd.RequirementId), RequirementExample.FromString(cmd.Example))),
            _ => Task.CompletedTask
        };
        

        private async Task HandleCreate(VisaCommands.Create cmd)
        {
            var visa = new Visa(new VisaId(Guid.NewGuid()), cmd.Type);

            await _repository.Add(visa);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid visaId, Action<Visa> operation)
        {
            try
            {
                var visa = await _repository.Load(visaId.ToString());

                if (visa == null)
                    throw new InvalidOperationException(
                        $"Entity with id {visaId} cannot be found"
                    );

                operation(visa);
                await _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
