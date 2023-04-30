﻿// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using InternTrack.Core.Api.Infrastructure.Provision.Models.Configurations;
using Microsoft.Extensions.Configuration;

namespace InternTrack.Core.Api.Infrastructure.Provision.Brokers.Configurations
{
    public class ConfigurationBroker : IConfigurationBroker
    {
        public CloudMangamentConfiguration GetConfigurations()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(basePath: Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appSettings.json", optional: false)
                .Build();

            return configurationRoot.Get<CloudMangamentConfiguration>();
        }
    }
}
