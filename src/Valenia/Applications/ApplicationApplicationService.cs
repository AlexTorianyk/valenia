using System;
using System.Threading.Tasks;
using Valenia.Common;
using Valenia.Domain.Applications;
using Valenia.Domain.Users.Applicants;
using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Domain.Visas;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Applications
{
    public class ApplicationApplicationService : IApplicationService, IScoped
    {
        private readonly IApplicationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationApplicationService(IApplicationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command)
            =>
                command switch
                {
                    ApplicationCommands.Submit cmd =>
                    HandleCreate(cmd),
                    ApplicationCommands.AssignToReviewer cmd =>
                    HandleUpdate(cmd.Id, a => a.AssignToReviewer(new EmbassyEmployeeId(cmd.ReviewerId))),
                    ApplicationCommands.AddDocument cmd =>
                    HandleUpdate(cmd.Id, a => a.AddDocument(new Uri(cmd.DocumentUrl))),
                    ApplicationCommands.RequestChanges cmd =>
                    HandleUpdate(cmd.Id, a => a.RequestChanges()),
                    ApplicationCommands.Approve cmd =>
                    HandleUpdate(cmd.Id, a => a.Approve()),
                    _ => Task.CompletedTask
                };

        private async Task HandleCreate(ApplicationCommands.Submit cmd)
        {
            var application = new Application(new ApplicantId(cmd.ApplicantId), new VisaId(cmd.VisaId), SubmissionDate.FromDateTimeOffset(cmd.SubmissionDate));

            await _repository.Add(application);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid applicationId, Action<Application> operation)
        {
            var application = await _repository.Load(applicationId.ToString());

            if (application == null)
                throw new InvalidOperationException(
                    $"Application with id {applicationId} cannot be found"
                );

            operation(application);
            await _unitOfWork.Commit();
        }
    }
}
