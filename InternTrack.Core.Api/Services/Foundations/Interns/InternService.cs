﻿using System.Threading.Tasks;
using InternTrack.Core.Api.Brokers.Loggings;
using InternTrack.Core.Api.Brokers.Storages;
using InternTrack.Core.Api.Models.Interns;

namespace InternTrack.Core.Api.Services.Foundations.Interns
{
    public class InternService : IInternService
    {
        public readonly IStorageBroker storageBroker;
        public readonly ILoggingBroker loggingBroker;

        public InternService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Intern> CreateInternAsync(Intern intern)
        {
            throw new System.NotImplementedException();
        }
    }
}
