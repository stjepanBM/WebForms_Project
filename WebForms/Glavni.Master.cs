using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class Glavni : System.Web.UI.MasterPage
    {
        public static IRepo repo = RepoFactory.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["loginPodaci"] != null)
            {
                showLogOut();
                showMailUser();
            }
            popuniInfo();
        }


        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["loginPodaci"];
            if (cookie != null)
            {
                HttpContext.Current.Response.Cookies.Remove("loginPodaci");
                cookie.Expires = DateTime.Now.AddDays(-5);
                cookie.Value = null;
                HttpContext.Current.Response.SetCookie(cookie);
                Response.Redirect("Login.aspx");
            }
        }

        public void showMailUser()
        {
            var cookie = Request.Cookies["loginPodaci"];
            int id = int.Parse(cookie["id"]);


            string mailText = repo.GetUserFullName(id);


            if (mailText!=null)
            {
                btnMailUser.Text = mailText;
            }
            else
            {
                return;
            }
            btnMailUser.Visible = true;
        }

        public void showLogOut()
        {
            btnLogout.Visible = true;
        }

        public void popuniInfo()
        {
            string value="";
            var kuki = Request.Cookies["repozitorij"];
            if (kuki==null)
            {
                value = "Database";
            }
            else
            {
                switch (kuki.Value)
                {
                    case "1":
                        value = "TextFile";
                        break;
                    case "2":
                        value = "Database";
                        break;

                }
            }
          
            lblRepoInfo.Text = "Repository-" + value;
        }

        protected void btnMailUser_Click(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["loginPodaci"];
            string Email = cookie["email"];
            if (cookie != null)
            {
                Response.Redirect(string.Format("mailto:{0}", Email));
            }
        }
    }
}