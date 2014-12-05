using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChoiceCenium.Svc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public bool ValidateCeniumSuperUser(string uname, string pass)
        {
            var svc = new LoginService();
            return svc.ValidateCeniumSuperUser(uname, pass);
        }

    }
}
