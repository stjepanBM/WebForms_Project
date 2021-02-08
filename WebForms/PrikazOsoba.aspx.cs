using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class PrikazOsoba : MyPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewDataBind();
                RepeaterDataBind();
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
        private void GridViewDataBind()
        {
            gvUseri.DataSource = repo.GetUsers();
            gvUseri.DataBind();
        }
        private void RepeaterDataBind()
        {
            mojRepeater.DataSource = repo.GetUsers();
            mojRepeater.DataBind();
        }

        protected void gvUseri_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUseri.EditIndex = e.NewEditIndex;
            GridViewDataBind();
        }

        protected void gvUseri_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUseri.EditIndex = -1;
            GridViewDataBind();
        }


        private T GetControl<T>(ControlCollection parent)
        {
            foreach (var ctrl in parent)
            {
                if (ctrl is T)
                {
                    return (T)ctrl;
                }

            }
            return default(T);
        }

        private List<T> GetSpecificControls<T>(Control root) where T : Control
        {
            var controls = new List<T>();

            ControlFinder(root);

            void ControlFinder(Control current)
            {
                foreach (Control ctrl in current.Controls)
                {
                    if (ctrl is T foundControl)
                        controls.Add(foundControl);

                    ControlFinder(ctrl);

                }
            }

            return controls;
        }
        protected void gvUseri_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow updateRow = gvUseri.Rows[e.RowIndex];

            TextBox tbIme = GetControl<TextBox>(updateRow.Cells[0].Controls);
            TextBox tbPrezime = GetControl<TextBox>(updateRow.Cells[1].Controls);
            TextBox tbTelefon = GetControl<TextBox>(updateRow.Cells[3].Controls);
            var repeater = updateRow.Cells[2].Controls[1];
            var emailTextBox = GetSpecificControls<TextBox>(repeater);
            DropDownList dbStatus = GetControl<DropDownList>(updateRow.Cells[4].Controls);

            DropDownList tbStatus = (DropDownList)updateRow.FindControl("ddlEdit");
            string newValue = tbStatus.SelectedValue;

            var emails = new List<KorisnikEmail>();
            for (int i = 0; i < emailTextBox.Count; i++)
            {
                var txtEmail = emailTextBox[i];
                emails.Add(new KorisnikEmail
                {
                    Email = txtEmail.Text
                });

            }

            Korisnik u = new Korisnik();
            var userId = (int)gvUseri.DataKeys[e.RowIndex].Value;
            u.IDUser = userId;
            u.Name = tbIme.Text;
            u.Surname = tbPrezime.Text;
            u.Telephone = tbTelefon.Text;
            u.Status = newValue;
            for (int i = 0; i < emails.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        u.Mail1 = emails[0].Email;
                        break;
                    case 1:
                        u.Mail2 = emails[1].Email;
                        break;
                    case 2:
                        u.Mail3 = emails[2].Email;
                        break;
                    default:
                        break;
                }
            }
            try
            {
                repo.UpdateUserGrid(u);
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            gvUseri.EditIndex = -1;
            GridViewDataBind();
            RepeaterDataBind();
        }
        protected void gvUseri_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int indexRetka = e.NewSelectedIndex;
            int kupacID = (int)gvUseri.DataKeys[indexRetka].Value;
        }



        protected void lbRepeaterUredi_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            int userID = int.Parse(btn.CommandArgument);
            Response.Redirect(string.Format($"~/UrediOsobu.aspx?IDUser={userID}"));
        }

    }
}