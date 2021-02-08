using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class Repo:IRepo
    {

        public DataSet ms { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public Repo()
        {
        }

        public ISet<Korisnik> GetUsers()
        {
            ISet<Korisnik> kolekcijaUsera = new HashSet<Korisnik>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetUsers");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Korisnik u = new Korisnik();
                u.IDUser = (int)row["IDUser"];
                u.Name = row["Name"].ToString();
                u.Surname = row["Surname"].ToString();
                u.Emails.Add(new KorisnikEmail
                {
                    Email = row["Mail1"].ToString()
                });
                u.Emails.Add(new KorisnikEmail
                {
                    Email = row["Mail2"].ToString()
                });
                u.Emails.Add(new KorisnikEmail
                {
                    Email = row["Mail3"].ToString()
                });


                u.Mail1 = row["Mail1"].ToString();
                u.Mail2 = row["Mail2"].ToString();
                u.Mail3 = row["Mail3"].ToString();
                u.Telephone = row["Telephone"].ToString();
                u.Password = row["Password"].ToString();
                u.Status = row["Status"].ToString();
                u.City = row["City"].ToString();
                kolekcijaUsera.Add(u);
            }
            return kolekcijaUsera;
        }



        public bool ProvjeriLogin(string txtEmail, string txtPass)
        {
            DataSet ls = SqlHelper.ExecuteDataset(cs, "GetUsersLogin");
            int idUser = 0;
            foreach (DataRow row in ls.Tables[0].Rows)
            {
                idUser = (int)row["IDUser"];
                string mail1 = row["Mail1"].ToString();
                string mail2 = row["Mail2"].ToString();
                string mail3 = row["Mail3"].ToString();
                string password = row["Password"].ToString();
                if ((txtEmail == mail1 || txtEmail == mail2 || txtEmail == mail3) && txtPass == password)
                {

                    return true;

                }

            }


            return false;

        }

        public Korisnik GetUser(int id)
        {
            return GetUsers().Single(u => u.IDUser == id);
        }
        public Korisnik GetUser(string email, string pass)
        {
            return GetUsers().Single(u => (u.Mail1 == email || u.Mail2 == email || u.Mail3 == email) && u.Password == pass);
        }

        public void DeleteUser(int idUser)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteUser", idUser);
        }

        public void UpdateUser(Korisnik u)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateUser", u.IDUser, u.Name, u.Surname, u.Telephone, u.Password, u.Status, u.City);
        }
        public void UpdateUserGrid(Korisnik u)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateUserGrid", u.IDUser, u.Name, u.Surname, u.Mail1, u.Mail2, u.Mail3, u.Telephone, u.Status);
        }
        public void UpdateMail(string mailStari,string mailNovi,int userID)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateMail",mailStari,mailNovi,userID);
        }
        public string GetUserFullName(int id)
        {
            DataSet ls = SqlHelper.ExecuteDataset(cs, "GetFullName", id);

            foreach (DataRow row in ls.Tables[0].Rows)
            {
                string name = row["Name"].ToString();
                string surname = row["Surname"].ToString();


                return string.Format($"{name} {surname}");

            }
            return string.Format($"Nije nasao");


        }

        public void AddUser(Korisnik u)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddUser", u.Name, u.Surname, u.Mail1, u.Mail2, u.Mail3, u.Telephone, u.Password, u.Status, u.City);
        }
    }
}