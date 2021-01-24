using System;
using System.Collections.Generic;
using System.Text;
using Valenia.Domain.Applications;
using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Users.Applicants;
using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Domain.Visas;
using Xunit;

namespace Valenia.Tests
{
    public class ApplicationTests
    {
        public class Submit : ApplicantTests
        {
            [Fact]
            public void Create_Called()
            {
                // Arrange
                var applicantId = new ApplicantId(Guid.NewGuid());
                var visaId = new VisaId(Guid.NewGuid());
                var submissionDate = SubmissionDate.FromDateTimeOffset(DateTimeOffset.Now.AddDays(-7));

                // Act
                var application = new Application(applicantId, visaId, submissionDate);

                // Assert
                Assert.NotNull(application.Id);
                Assert.NotNull(application.Documents);
                Assert.Equal(applicantId, application.ApplicantId);
                Assert.Equal(visaId, application.VisaId);
                Assert.Equal(submissionDate, application.SubmissionDate);
            }
        }

        public class AddDocument : ApplicantTests
        {
            [Fact]
            public void AddDocument_Called()
            {
                // Arrange
                var applicantId = new ApplicantId(Guid.NewGuid());
                var visaId = new VisaId(Guid.NewGuid());
                var submissionDate = SubmissionDate.FromDateTimeOffset(DateTimeOffset.Now.AddDays(-7));
                var application = new Application(applicantId, visaId, submissionDate);
                var documentUrl = new Uri("https://www.streamscheme.com/wp-content/uploads/2020/04/pepega.png");

                // Act
                application.AddDocument(documentUrl);

                // Assert
                Assert.NotEmpty(application.Documents);
            }
        }

        public class Approve : ApplicantTests
        {
            [Fact]
            public void ChangeStatusToApprove_Called()
            {
                // Arrange
                var applicantId = new ApplicantId(Guid.NewGuid());
                var visaId = new VisaId(Guid.NewGuid());
                var submissionDate = SubmissionDate.FromDateTimeOffset(DateTimeOffset.Now.AddDays(-7));
                var application = new Application(applicantId, visaId, submissionDate);
                var documentUrl = new Uri("https://www.streamscheme.com/wp-content/uploads/2020/04/pepega.png");
                application.AddDocument(documentUrl);
                var reviewerId = new EmbassyEmployeeId(Guid.NewGuid());
                application.AssignToReviewer(reviewerId);

                // Act
                application.Approve();

                // Assert
                Assert.Equal(ApplicationStatus.Approved, application.Status);
            }

            [Fact]
            public void ThrowException_CalledWithoutSettingTheReviewer()
            {
                // Arrange
                var applicantId = new ApplicantId(Guid.NewGuid());
                var visaId = new VisaId(Guid.NewGuid());
                var submissionDate = SubmissionDate.FromDateTimeOffset(DateTimeOffset.Now.AddDays(-7));
                var application = new Application(applicantId, visaId, submissionDate);
                var documentUrl = new Uri("https://www.streamscheme.com/wp-content/uploads/2020/04/pepega.png");
                application.AddDocument(documentUrl);

                // Act & Assert
                Assert.Throws<Exceptions.InvalidEntityState>(() => application.Approve());
            }
        }
    }
}
