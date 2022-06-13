using AutoMapper;
using Card.Validation.Web.App.Config.IoC;
using Card.Validation.Web.App.DataAccess.RepositoryUow.DB;
using System.Configuration;
using Unity;

namespace Card.Validation.Web.App.Config
{
    public class AppConfig
    {
        public static IDBRepositoryUow DBRepositoryUow => StandardDi.Container
            .Resolve<IDBRepositoryUow>();

        public static IMapper AutoMapper => StandardDi.Container.Resolve<IMapper>();

        public static string DatabaseConnection { get; } = ConfigurationManager.AppSettings["MySql.Connection"]
            ?? "server=127.0.0.1;database=validation;uid=dev;pwd=Devpwd@2;";

        public static string AppDescription { get; } = ConfigurationManager.AppSettings["App.Description"]
            ?? "Card Validation";
    }
}