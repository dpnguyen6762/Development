using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DeanConsoleUI
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _configuration;

        public GreetingService(ILogger<GreetingService> log, IConfiguration configuration)
        {
            _log = log;
            _configuration = configuration;
        }

        public IConfiguration Config { get; }

        public void Run()
        {
            for (int i = 0; i < _configuration.GetValue<int>("LoopTimes"); i++)
            {
                //this is #
                _log.LogInformation("Run Number {runnumber}" + i);
            }
        }
    }
}