using System;
using System.Web.Security;
using System.Web.UI;
using ChoiceCenium.Services;

namespace ChoiceCenium
{
    public partial class View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAuth = Request.IsAuthenticated;
            HotelList.Columns[0].Visible = isAuth;
            HotelList.Columns[5].Visible = isAuth;
            HotelList.Columns[6].Visible = isAuth;
            HotelList.Columns[7].Visible = isAuth;
            HotelList.Columns[8].Visible = isAuth;
            HotelList.Columns[10].Visible = isAuth; 
            HotelList.Columns[11].Visible = isAuth;
            HotelList.Columns[12].Visible = isAuth;
            lnkLogout.Visible = isAuth;
            lnkLogin.Visible = !isAuth;
        }

        protected void ValidateUser_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            var srv = new LoginService();
            var loginSuccess = srv.ValidateUser(username, password);

            if (!loginSuccess) return;
            FormsAuthentication.SetAuthCookie(username, true);
            Response.Redirect("view.aspx", false);
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("view.aspx", false);
        }
    }
}