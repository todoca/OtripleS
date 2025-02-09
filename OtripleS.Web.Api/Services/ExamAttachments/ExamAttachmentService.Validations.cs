﻿//---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
//----------------------------------------------------------------

using System;
using System.Linq;
using OtripleS.Web.Api.Models.ExamAttachments;
using OtripleS.Web.Api.Models.ExamAttachments.Exceptions;

namespace OtripleS.Web.Api.Services.ExamAttachments
{
    public partial class ExamAttachmentService
    {
        public void ValidateExamAttachmentOnCreate(ExamAttachment examAttachment)
        {
            ValidateExamAttachmentIsNull(examAttachment);
            ValidateExamAttachmentIds(examAttachment.ExamId, examAttachment.AttachmentId);
        }

        private static void ValidateExamAttachmentIsNull(ExamAttachment examAttachment)
        {
            if (examAttachment is null)
            {
                throw new NullExamAttachmentException();
            }
        }

        private static void ValidateExamAttachmentIds(Guid examId, Guid attachmentId)
        {
            if (examId == default)
            {
                throw new InvalidExamAttachmentException(
                    parameterName: nameof(ExamAttachment.ExamId),
                    parameterValue: examId);
            }
            else if (attachmentId == default)
            {
                throw new InvalidExamAttachmentException(
                    parameterName: nameof(ExamAttachment.AttachmentId),
                    parameterValue: attachmentId);
            }
        }

        private static void ValidateStorageExamAttachment(
          ExamAttachment storageExamAttachment,
          Guid examId, Guid attachmentId)
        {
            if (storageExamAttachment == null)
                throw new NotFoundExamAttachmentException(examId, attachmentId);
        }

        private void ValidateStorageExamAttachments(IQueryable<ExamAttachment> storageExamAttachments)
        {
            if (!storageExamAttachments.Any())
            {
                this.loggingBroker.LogWarning("No exam attachments found in storage.");
            }
        }
    }
}
