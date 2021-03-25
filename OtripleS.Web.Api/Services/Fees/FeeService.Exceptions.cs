﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtripleS.Web.Api.Models.Fees;
using OtripleS.Web.Api.Models.Fees.Exceptions;

namespace OtripleS.Web.Api.Services.Fees
{
    public partial class FeeService
    {
        private delegate IQueryable<Fee> ReturningQueryableFeeFunction();

        private IQueryable<Fee> TryCatch(ReturningQueryableFeeFunction returningQueryableFeeFunction)
        {
            try
            {
                return returningQueryableFeeFunction();
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
        }

        private FeeDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var feeDependencyException = new FeeDependencyException(exception);
            this.loggingBroker.LogCritical(feeDependencyException);

            return feeDependencyException;
        }

        private FeeDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var feeDependencyException = new FeeDependencyException(exception);
            this.loggingBroker.LogError(feeDependencyException);

            return feeDependencyException;
        }

    }
}
