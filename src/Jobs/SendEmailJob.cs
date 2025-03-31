using Quartz;
using SchedulerWithQuartz.Services;
using Serilog;

namespace SchedulerWithQuartz.Jobs
{
    public class SendEmailJob(IMockService mockService) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("SendEmailJob executing");

            await mockService.SendEmailMock();

            Log.Information("SendEmailJob executed");
        }
    }
}