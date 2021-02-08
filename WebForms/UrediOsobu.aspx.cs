using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Controls;
using WebForms.Models;

namespace WebForms
{
    public partial class UrediOsobu : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEditCtrl(int.Parse(Request.QueryString["IDUser"]));
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request.Cookies["loginPodaci"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void UserEditCtrl(int id)
        {

            Korisnik user = repo.GetUser(id);

            Control ctrlU = LoadControl("Controls/EditOsobeCtrl.ascx");

            ((EditOsobeCtrl)ctrlU).Popuni(user);


            phUredi.Controls.Add(ctrlU);
        }
    }
}