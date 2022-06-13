using System.Configuration;

namespace Card.Validation.Core.Config
{
    public class AppConfig
    {
        public static string DatabaseConnection { get; } = ConfigurationManager.AppSettings[""]
            ?? "";
    }
}