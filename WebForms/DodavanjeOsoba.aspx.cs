using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class DodavanjeOsoba : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["BrojEmaila"] = null;
                PrikaziCtrl();
            }
            else
            {
                PrikaziCtrl();
            }
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);



            if (Request.Cookies["loginPodaci"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        private void PrikaziCtrl()
        {

            Control ctrlU = LoadControl("Controls/AddPersonCtrl.ascx");
            plAddCtrl.Controls.Add(ctrlU);

        }

    }
}