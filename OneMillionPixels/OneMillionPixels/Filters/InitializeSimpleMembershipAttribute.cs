using OneMillionPixels.Models;
using System;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace OneMillionPixels.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                System.Data.Entity.Database.SetInitializer<UsersContext>(null);

                try
                {
                    string connectionString = System.AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["DatabasePath"];
                    connectionString = connectionString.Remove(connectionString.LastIndexOf('.'));
                    WebSecurity.InitializeDatabaseConnection(connectionString, "UserProfile", "UserId", "UserName", autoCreateTables: false);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to initialize the database", ex);
                }
            }
        }
    }
}
