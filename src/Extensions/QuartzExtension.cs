using Quartz;
using SchedulerWithQuartz.Jobs;

namespace SchedulerWithQuartz.Extensions
{
    public static class QuartzExtension
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            // base configuration from appsettings.json
            services.Configure<QuartzOptions>(configuration.GetSection("Quartz"));
            string? quartzConfiguration = configuration.GetSection("QuartzConfiguration:Expression").Value ?? string.Empty;

            services.AddQuartz(q =>
            {
                JobKey jobKey = new("SendEmailJob");
                q.AddJob<SendEmailJob>(j => j.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("SendEmailJob-trigger")
                    //This Cron interval can be described as "run every minute" (when second is zero)
                    .WithCronSchedule(quartzConfiguration)
                );
            });

            // Quartz.Extensions.Hosting allows you to fire background service that handles scheduler lifecycle
            services.AddQuartzHostedService(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

            return services;
        }
    }
}