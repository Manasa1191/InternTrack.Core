﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using InternTrack.Core.Api.Brokers.DateTimes;
using InternTrack.Core.Api.Brokers.Loggings;
using InternTrack.Core.Api.Brokers.Storages;
using InternTrack.Core.Api.Models.Interns;
using Microsoft.Identity.Client;

namespace InternTrack.Core.Api.Services.Foundations.Interns
{
    public partial class InternService : IInternService
    {
        public readonly IStorageBroker storageBroker;
        public readonly IDateTimeBroker dateTimeBroker;
        public readonly ILoggingBroker loggingBroker;

        public InternService(IStorageBroker storageBroker, IDateTimeBroker dateTimeBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Intern> AddInternAsync(Intern intern) =>
            TryCatch(async () =>
            {
                ValidateInternOnAdd(intern);

                return await this.storageBroker.InsertInternAsync(intern);
            });

        public ValueTask<Intern> ModifyInternAsync(Intern intern) =>
        
            TryCatch(async () =>
            {
                ValidateInternOnModify(intern);

                Intern maybeIntern =
                await this.storageBroker.SelectInternByIdAsync(intern.Id);

                ValidateStorageIntern(maybeIntern, intern.Id);
                ValidateAgainstStorageInternOnModify(inputIntern: intern, storageIntern: maybeIntern);

                return await this.storageBroker.UpdateInternAsync(intern);
            });
    }
}
