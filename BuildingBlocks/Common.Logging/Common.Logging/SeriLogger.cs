﻿using Microsoft.Extensions.Hosting;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using Microsoft.Extensions.Configuration;
using BuildingBlocks.Common.Logging;

namespace BuildingBlocks.SeriLog
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
            (ctx, cfg) =>
            {
                cfg.Enrich.FromLogContext()
                      .Enrich.WithMachineName()
                      .WriteTo.Console()
                      .WriteTo.Elasticsearch(
                           new ElasticsearchSinkOptions(new Uri(ctx.Configuration["ElasticConfiguration:Uri"]))
                           {
                               IndexFormat = $"applogs-{ctx.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{ctx.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                               AutoRegisterTemplate = true,
                               NumberOfShards = 2,
                               NumberOfReplicas = 1
                           }
                       )
                       .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                       .Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                       .Enrich.With<LogEnricher>()
                       .ReadFrom.Configuration(ctx.Configuration);
            };
    }
}
