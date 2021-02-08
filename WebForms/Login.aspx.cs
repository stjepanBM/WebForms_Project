using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class Login : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["loginpodaci"]!=null)
            {
                Response.Redirect("PrikazOsoba.aspx");
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //repo.ProvjeriLogin(txtEmail.Text, txtPass.Text)
            try
            {
                Korisnik u = repo.GetUser(txtEmail.Text, txtPass.Text);
                Session["User"] = u.Status;
               // Session.Timeout = 60;
                if (repo.ProvjeriLogin(txtEmail.Text, txtPass.Text))
                {
                    HttpCookie cookieLogin = new HttpCookie("loginPodaci");
                    if (this.checkboxLogin.Checked)
                    {
                        cookieLogin["email"] = Server.UrlEncode(txtEmail.Text);
                        cookieLogin["password"] = Server.UrlEncode(txtPass.Text);
                        cookieLogin["id"] = Server.UrlEncode(u.IDUser.ToString()); 
                        cookieLogin.Expires = DateTime.Now.AddDays(5);
                        Response.Cookies.Add(cookieLogin);
                        Response.Redirect("~/PrikazOsoba.aspx");
                    }
                    else
                    {
                        
                        cookieLogin["email"] = Server.UrlEncode(txtEmail.Text);
                        cookieLogin["password"] = Server.UrlEncode(txtPass.Text);
                        cookieLogin["id"] = Server.UrlEncode(u.IDUser.ToString()); 
                        Response.Cookies.Add(cookieLogin);
                        Response.Redirect("~/PrikazOsoba.aspx");
                    }

                }
            }
            catch (Exception)
            {
                lblInfo.Text = "Nepoznat korisnik";
                lblInfo.Visible = true;
            }
            //else
            //{
            //    lblInfo.Text = "Nepoznat korisnik";
            //    lblInfo.Visible = true;
            //}

        }
    }
}