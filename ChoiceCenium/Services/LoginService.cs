namespace ChoiceCenium.Services
{
    public class LoginService
    {

        private const string Username = "superuser";
        private const string Password = "ceniumsuperuser!";

        public bool ValidateUser(string username, string password)
        {
            if (username == Username && password == Password)
            {
                return true;
            }
            return false;
        }
    }
}