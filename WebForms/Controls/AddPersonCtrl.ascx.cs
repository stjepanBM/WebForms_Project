using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms.Controls
{
    public partial class AddPersonCtrl : System.Web.UI.UserControl
    {
        public static IRepo repo  = RepoFactory.GetRepository() ;
        public int BrojEmaila
        {
            get
            {
                if (Session["BrojEmaila"] == null)
                    Session["BrojEmaila"] = 0;

                return (int)Session["BrojEmaila"];
            }
            set { Session["BrojEmaila"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session["BrojEmaila"] = null;
                KreirajBoxZaEmail(++BrojEmaila);
                txtIme.Focus();
            }
            else
            {
                RekreirajSvaPoljaZaUnosBoje();
                txtIme.Focus();
            }


           // repo = RepoFactory.GetRepository(Request.Cookies["repozitorij"].ToString());



        }

        private void RekreirajSvaPoljaZaUnosBoje()
        {
            for (int i = 1; i <= BrojEmaila; i++)
            {
                KreirajBoxZaEmail(i);
            }
        }

        internal void KreirajBoxZaEmail(int index)
        {
            if (index > 3)
            {
                return;
            }
            else
            {
                IzbrisiLink();
                if (index == 3)
                {
                    TextBox text = new TextBox();
                    text.ID = String.Format("txtEmail{0}", index);
                    text.CssClass = "form-control";
                    text.Attributes.Add("style", "margin-bottom:5px;");

                    RequiredValidatior(text.ID, index);
                    RegularValidatior(text.ID, index);
                    phEmails.Controls.Add(text);
                    text.Focus();

                    return;
                }
                else
                {
                    TextBox MyTextBox = new TextBox();
                    MyTextBox.ID = String.Format("txtEmail{0}", index);
                    MyTextBox.CssClass = "form-control";
                    MyTextBox.Attributes.Add("style", "margin-bottom:5px;");

                    RequiredValidatior(MyTextBox.ID, index);
                    RegularValidatior(MyTextBox.ID, index);
                    phEmails.Controls.Add(MyTextBox);
                    MyTextBox.Focus();

                    LinkButton lb = new LinkButton();
                    lb.ID = String.Format("lbMailDodaj");
                    lb.Text = "Dodaj jos E-mail adresa...";
                    lb.Click += Lb_Click;
                    phEmails.Controls.Add(lb);


                }

            }




        }

        private void IzbrisiLink()
        {
            LinkButton btn = phEmails.FindControl("lbMailDodaj") as LinkButton;
            phEmails.Controls.Remove(btn);
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            KreirajBoxZaEmail(++BrojEmaila);
        }

        private void RegularValidatior(string textboxID, int index)
        {

            RegularExpressionValidator rev = new RegularExpressionValidator();
            rev.ID = "ExpressionMail" + index;
            rev.ControlToValidate = textboxID;
            rev.ErrorMessage = "Kriva E-mail adresa";
            if (index == 1)
            {
                rev.ForeColor = Color.Red;
                rev.Text = "*";
            }
            else
            {
                rev.ForeColor = Color.White;
                rev.Text = "*";
            }
            rev.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            rev.ValidationGroup = "grupa";
            rev.Display = ValidatorDisplay.Dynamic;
            phEmails.Controls.Add(rev);
        }

        private void RequiredValidatior(string textboxID, int index)
        {
            RequiredFieldValidator validator = new RequiredFieldValidator();
            validator.ID = "EmailValidator" + index;
            validator.ControlToValidate = textboxID;

            if (index == 1)
            {
                validator.ForeColor = Color.Red;
                validator.Text = "*";
            }
            else
            {
                validator.ForeColor = Color.White;
                validator.Text = "*";
            }
            validator.ErrorMessage = "E-mail je obavezan";
            validator.ValidationGroup = "grupa";
            validator.Display = ValidatorDisplay.Dynamic;

            phEmails.Controls.Add(validator);
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {

            TextBox email1 = phEmails.FindControl("txtEmail1") as TextBox;
            TextBox email2 = phEmails.FindControl("txtEmail2") as TextBox;
            TextBox email3 = phEmails.FindControl("txtEmail3") as TextBox;


            Korisnik u = new Korisnik();

            u.Name = txtIme.Text;
            u.Surname = txtPrezime.Text;
            u.Mail1 = email1.Text;
            if (email2 == null & email3 == null)
            {
                u.Mail2 = "";
                u.Mail3 = "";
            }
            else if (email3 == null)
            {
                u.Mail3 = "";
            }
            else
            {
                u.Mail2 = email2.Text;
                u.Mail3 = email3.Text;
            }
            u.Telephone = txtTelefon.Text;
            u.Password = txtLozinka.Text;
            u.Status = ddlUserType.SelectedItem.ToString();
            u.City = ddlGrad.SelectedItem.ToString();
            repo.AddUser(u);

            Refresh();

        }

        private void Refresh()
        {
            TextBox email1 = phEmails.FindControl("txtEmail1") as TextBox;
            TextBox email2 = phEmails.FindControl("txtEmail2") as TextBox;
            TextBox email3 = phEmails.FindControl("txtEmail3") as TextBox;
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            txtLozinka.Text = "";
            txtPotvrda.Text = "";

            if (email2 == null && email3 == null)
            {
                email1.Text = "";
            }
            else if (email3 == null)
            {
                email1.Text = "";
                email2.Text = "";
            }
            else
            {
                email1.Text = "";
                email2.Text = "";
                email3.Text = "";
            }



        }



    }
}