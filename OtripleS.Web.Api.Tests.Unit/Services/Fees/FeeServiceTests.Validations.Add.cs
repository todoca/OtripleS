﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Moq;
using OtripleS.Web.Api.Models.Fees;
using OtripleS.Web.Api.Models.Fees.Exceptions;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.Fees
{
    public partial class FeeServiceTests
    {
        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenFeeIsNullAndLogItAsync()
        {
            // given
            Fee randomFee = default;
            Fee nullFee = randomFee;
            var nullFeeException = new NullFeeException();

            var expectedFeeValidationException =
                new FeeValidationException(nullFeeException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(nullFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenFeeIdIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.Id = default;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.Id),
                parameterValue: inputFee.Id);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenCreatedByIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.CreatedBy = default;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.CreatedBy),
                parameterValue: inputFee.CreatedBy);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                 broker.InsertFeeAsync(It.IsAny<Fee>()),
                     Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenUpdatedByIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.UpdatedBy = default;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.UpdatedBy),
                parameterValue: inputFee.UpdatedBy);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenCreatedDateIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.CreatedDate = default;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.CreatedDate),
                parameterValue: inputFee.CreatedDate);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenUpdatedDateIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.UpdatedDate = default;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.UpdatedDate),
                parameterValue: inputFee.UpdatedDate);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenUpdatedDateIsNotSameToCreatedDateAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.UpdatedBy = randomFee.CreatedBy;
            inputFee.UpdatedDate = GetRandomDateTime();

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.UpdatedDate),
                parameterValue: inputFee.UpdatedDate);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidMinuteCases))]
        public async void ShouldThrowValidationExceptionOnAddWhenCreatedDateIsNotRecentAndLogItAsync
            (int minutes)
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee inputFee = randomFee;
            inputFee.UpdatedBy = inputFee.CreatedBy;
            inputFee.CreatedDate = dateTime.AddMinutes(minutes);
            inputFee.UpdatedDate = inputFee.CreatedDate;

            var invalidFeeInputException = new InvalidFeeException(
                parameterName: nameof(Fee.CreatedDate),
                parameterValue: inputFee.CreatedDate);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeInputException);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
                    .Returns(dateTime);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(inputFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowValidationExceptionOnAddWhenFeeAlreadyExistsAndLogItAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee alreadyExistsFee = randomFee;
            alreadyExistsFee.UpdatedBy = alreadyExistsFee.CreatedBy;
            string randomMessage = GetRandomMessage();
            string exceptionMessage = randomMessage;
            var duplicateKeyException = new DuplicateKeyException(exceptionMessage);

            var alreadyExistsFeeException =
                new AlreadyExistsFeeException(duplicateKeyException);

            var expectedFeeValidationException =
                new FeeValidationException(alreadyExistsFeeException);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
                    .Returns(dateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFeeAsync(alreadyExistsFee))
                    .ThrowsAsync(duplicateKeyException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(alreadyExistsFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(alreadyExistsFee),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnAddWhenFeeLabelIsInvalidAndLogItAsync
            (string invalidFeeLabel)
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Fee randomFee = CreateRandomFee(dateTime);
            Fee invalidFee = randomFee;
            invalidFee.Label = invalidFeeLabel;

            var invalidFeeException = new InvalidFeeException(
               parameterName: nameof(Fee.Label),
               parameterValue: invalidFee.Label);

            var expectedFeeValidationException =
                new FeeValidationException(invalidFeeException);

            // when
            ValueTask<Fee> createFeeTask =
                this.feeService.AddFeeAsync(invalidFee);

            // then
            await Assert.ThrowsAsync<FeeValidationException>(() =>
                createFeeTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedFeeValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFeeAsync(It.IsAny<Fee>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
