﻿using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using ChoiceCenium.Services;

namespace ChoiceCenium
{
    public partial class View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var username = HttpContext.Current.User.Identity.Name;
            bool isAuth = Request.IsAuthenticated;

            if (username == LoginService.CeniumUsername)
            {
                HotelList.Columns[0].Visible = true;
                HotelList.Columns[5].Visible = true;
                HotelList.Columns[6].Visible = true;
                HotelList.Columns[7].Visible = true;
                HotelList.Columns[8].Visible = true;
                HotelList.Columns[10].Visible = true;
                HotelList.Columns[11].Visible = true;
                HotelList.Columns[12].Visible = true;
            }
            else if (username == LoginService.DefaultUser)
            {
                HotelList.Columns[0].Visible = true;
                HotelList.Columns[5].Visible = true;
                HotelList.Columns[6].Visible = true;
                HotelList.Columns[7].Visible = true;
                HotelList.Columns[8].Visible = true;
                HotelList.Columns[9].Visible = false;
                HotelList.Columns[10].Visible = false;
                HotelList.Columns[11].Visible = false;
                HotelList.Columns[12].Visible = true;
            }

            
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