using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms.Controls
{
    public partial class EditOsobeCtrl : System.Web.UI.UserControl
    {
        public static IRepo repo = RepoFactory.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  repo = RepoFactory.GetRepository(Request.Cookies["repozitorij"].ToString());
        }

        internal void Popuni(Korisnik u)
        {
            hiddenID.Value = u.IDUser.ToString();
            txtName.Text = u.Name;
            txtSurname.Text = u.Surname;
            ddlMails.Items.Add(u.Mail1.ToString());

            if (u.Mail2.ToString()!="")
            {
                ddlMails.Items.Add(u.Mail2.ToString());

            }
            if (u.Mail3.ToString() != "")
            {
                ddlMails.Items.Add(u.Mail3.ToString());
            }

            txtEmail.Text = u.Mail1;
            txtPassword.Text = u.Password;
            txtTelephone.Text = u.Telephone;

            if (ddlStatusUsera.Items.FindByValue("Administrator").ToString() == u.Status.ToString())
            {
                ddlStatusUsera.Items.FindByValue("Administrator").Selected = true;
            }
            else
            {
                ddlStatusUsera.Items.FindByValue("Korisnik").Selected = true;
            }


            if (ddlCityList.Items.FindByValue("Zagreb").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Zagreb").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Varazdin").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Varazdin").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Split").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Split").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Rijeka").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Rijeka").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Pula").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Pula").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Osijek").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Osijek").Selected = true;
            }
            else if (ddlCityList.Items.FindByValue("Dubrovnik").ToString() == u.City.ToString())
            {
                ddlCityList.Items.FindByValue("Dubrovnik").Selected = true;
            }

            //ddlStatusUsera.Items.Add(u.Status.ToString());
            //ddlCityList.Items.Add(u.City.ToString());
        }

        protected void ddlMails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = ddlMails.SelectedItem.ToString();

            hiddenIndex.Value = ddlMails.SelectedItem.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button ed = (Button)sender;
            EditOsobeCtrl dinamika = (EditOsobeCtrl)ed.Parent;
            int idUser = int.Parse(hiddenID.Value);
            repo.DeleteUser(idUser);
            AzuriranjeOsoba ao= new AzuriranjeOsoba();
            ao.PrikaziUsere();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Korisnik u = new Korisnik
            {
                IDUser = int.Parse(hiddenID.Value),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Telephone = txtTelephone.Text,
                Password = txtPassword.Text,
                Status = ddlStatusUsera.SelectedItem.ToString(),
                City = ddlCityList.SelectedItem.ToString()
            };

            repo.UpdateUser(u);

        }

        protected void btnSaveMail_Click(object sender, EventArgs e)
        {
            string Email = hiddenIndex.Value.ToString();
            int id = int.Parse(hiddenID.Value);
            repo.UpdateMail(Email,txtEmail.Text,id);
    

        }
    }
}