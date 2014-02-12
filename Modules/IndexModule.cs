using Nancy.Authentication.Forms;
using Nancy.Demo.Models;
using Nancy.ModelBinding;

namespace Nancy.Demo.Modules
{

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = x =>
            {
                var model = new IndexModel();

                if (this.Context.CurrentUser != null) {
                    model.IsLoggedIn = true;
                    model.User = new UserModel(this.Context.CurrentUser.UserName);
                }

                return this.View["index",model];
            };
            
            Post["/login"] = x =>
            {                
                var input = this.Bind<LoginRequestModel>();
                var guid = UserDatabase.ValidateUser((string)this.Request.Form.Username, (string)this.Request.Form.Password);

                var result = new LoginResponseModel{ Message = "Login failed" };
                var response = Response.AsJson(result);

                if(guid.HasValue) {
                    var authResponse = this.LoginWithoutRedirect(guid.Value);
                    result.IsSuccess = true;
                    result.Message = "Login successful for " + input.Username + "! Now reload the page or try viewing the secure page.";
                    result.AuthToken = authResponse.Cookies[0].Value;
                }                
                
                return response;
            };

            this.Get["/logout"] = x => this.LogoutAndRedirect("~/");
        }
    }
}