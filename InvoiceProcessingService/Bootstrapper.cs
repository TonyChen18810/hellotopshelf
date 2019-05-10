﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;

namespace InvoiceProcessingService
{
    internal class Bootstrapper
    {
        public static IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            services.AddSingleton<IJobFactory>(provider =>
            {
                var jobFactory = new JobFactory(provider);
                return jobFactory;
            });
            services.AddSingleton<InvoiceProcessingJob>();

            services.AddSingleton<ITodoRepository, TodoRepository>();

            services.AddHttpClient<ITodoApiClient, TodoApiClient>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}