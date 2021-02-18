﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OtripleS.Web.Api.Models.ExamAttachments.Exceptions;
using OtripleS.Web.Api.Models.ExamAttachments;
using Microsoft.Data.SqlClient;

namespace OtripleS.Web.Api.Services.ExamAttachments
{
    public partial class ExamAttachmentService
    {
        private delegate ValueTask<ExamAttachment> ReturningExamEntryAttachmentFunction();

        private async ValueTask<ExamAttachment> TryCatch(
            ReturningExamEntryAttachmentFunction returningExamEntryAttachmentFunction)
        {
            try
            {
                return await returningExamEntryAttachmentFunction();
            }
            catch (InvalidExamAttachmentException invalidExamAttachmentInputException)
            {
                throw CreateAndLogValidationException(invalidExamAttachmentInputException);
            }
            catch (NotFoundExamAttachmentException notFoundExamAttachmentException)
            {
                throw CreateAndLogValidationException(notFoundExamAttachmentException);
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
        }

        private ExamAttachmentValidationException CreateAndLogValidationException(Exception exception)
        {
            var ExamAttachmentValidationException = new ExamAttachmentValidationException(exception);
            this.loggingBroker.LogError(ExamAttachmentValidationException);

            return ExamAttachmentValidationException;
        }

        private ExamAttachmentDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var examAttachmentDependencyException = new ExamAttachmentDependencyException(exception);
            this.loggingBroker.LogCritical(examAttachmentDependencyException);

            return examAttachmentDependencyException;
        }
    }
}
