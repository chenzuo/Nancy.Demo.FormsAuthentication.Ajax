namespace Nancy.Demo.Models
{
    public class UserModel
    {
        public string Username { get; private set; }

        public UserModel(string username)
        {
            this.Username = username;
        }
    }
}