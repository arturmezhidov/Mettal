using System.Web.Configuration;

namespace Mettal
{
    public static class AppConfig
    {
        public static string ConnectionStringName { get { return WebConfigurationManager.AppSettings["ConnectionStringName"] ?? "DefaultConnection"; } }
        public static string CategoryImagesPath { get { return "~/Images/Category/"; } }
    }
}