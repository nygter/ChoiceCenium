namespace ChoiceCenium.Services
{
    public class LoginService
    {

        public const string CeniumUsername = "choiceadmin";
        public const string CeniumPassword = "choiceadmin123!";

        public const string DefaultUser = "defaultadmin";
        public const string DefaultPassword = "defaultadmin123!";

        public bool ValidateUser(string username, string password)
        {
            return  (username == CeniumUsername && password == CeniumPassword) || 
                    (username == DefaultUser && password == DefaultPassword);
        }
    }
}