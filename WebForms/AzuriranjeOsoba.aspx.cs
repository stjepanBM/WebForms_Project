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
    public partial class AzuriranjeOsoba : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrikaziUsere();
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (Request.Cookies["loginPodaci"]==null)
            {
                Response.Redirect("Login.aspx");
            }
        }



        public void PrikaziUsere()
        {

            var useri = repo.GetUsers();
            foreach (Korisnik u in useri)
            {

                Control ctrlU = LoadControl("Controls/EditOsobeCtrl.ascx");

                ((EditOsobeCtrl)ctrlU).Popuni(u);

                phUredi.Controls.Add(ctrlU);
            }

        }




    }
}