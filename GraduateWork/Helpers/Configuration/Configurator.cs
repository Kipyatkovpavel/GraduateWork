using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace GraduateWork.Helpers.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        public static AppSettingsUI AppSettingsUI
        {
            get
            {
                var appSettings = new AppSettingsUI();
                var child = Configuration.GetSection("AppSettingsUI");

                appSettings.URL = child["URL"];
                appSettings.Username = child["Username"];
                appSettings.Password = child["Password"];

                return appSettings;
            }
        }

        public static AppSettingsApi AppSettingsApi
        {
            get
            {
                var appSettings = new AppSettingsApi();
                var child = Configuration.GetSection("AppSettingsApi");

                appSettings.URL = child["URL"];
                appSettings.Token = child["Token"];
                appSettings.Authorization = child["Authorization"];

                return appSettings;
            }
        }

        public static string? BrowserType => Configuration[nameof(BrowserType)];
        public static double WaitsTimeout => double.Parse(Configuration[nameof(WaitsTimeout)]);
    }
}