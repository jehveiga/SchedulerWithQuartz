using Serilog;

namespace SchedulerWithQuartz.Services
{
    public class MockService : IMockService
    {
        public Task SendEmailMock()
        {
            Log.Information("Send email mock");
            return Task.CompletedTask;
        }
    }
}