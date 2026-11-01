using System.Configuration;

namespace CafeManagementSystem
{
    public static class DBHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["CafeManagementDB"].ConnectionString;
    }
}
