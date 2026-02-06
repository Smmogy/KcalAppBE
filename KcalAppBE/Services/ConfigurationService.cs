using Microsoft.AspNetCore.Hosting;

namespace KcalAppBE.Services
{
    public interface IConfigurationService {
        public interface IConfigurationService
        {
            public T Get<T>(string section);
        }

    }
    public class ConfigurationService : IConfigurationService
    {
        private IConfiguration configuration;
        private IWebHostEnvironment webHostEnvironment;

        public ConfigurationService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }
        public T Get<T>(string section)
        {
            if (webHostEnvironment.IsProduction())
                return GetFromEnv<T>(section);
            else
                return GetFromAppSettings<T>(section);
        }

    }
}
