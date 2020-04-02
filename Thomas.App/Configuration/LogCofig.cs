using KissLog;
using KissLog.Apis.v1.Listeners;
using Microsoft.Extensions.Configuration;

namespace Thomas.App.Configuration
{
    public static class LogCofig
    {
        [System.Obsolete]
        public static void RegisterLogListeners(IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new KissLogApiListener(
                        configuration["KissLog.OrganizationId"],
                        configuration["KissLog.ApplicationId"],
                        configuration["KissLog.Environment"]
            ));
        }
    }
}
