using Nancy.Demo.Models;
using Nancy.Security;

namespace Nancy.Demo.Modules
{    
    public class SecureModule : NancyModule
    {
        public SecureModule() : base("/secure")
        {
            this.RequiresAuthentication();

            this.Get["/"] = x => {
                var model = new UserModel(this.Context.CurrentUser.UserName);
                return this.View["secure.cshtml", model];
            };
        }
    }
}