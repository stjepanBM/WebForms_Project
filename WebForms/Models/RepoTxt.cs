using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class RepoTxt:IRepo
    {
        private const string FILE_PATH = @"D:\4.semestar\RWA\Projekt_WebForms\NOVO_WEBFORMS\WebForms\WebForms\Resources\Users.txt";

        public void AddUser(Korisnik u)
        {
            ISet<Korisnik> users = GetUsers();
            users.Add(u);
            File.WriteAllLines(FILE_PATH, users.Select(x => x.FormatForFile()));
        }

        public void DeleteUser(int idUser)
        {
            ISet<Korisnik> users = GetUsers();

            foreach (Korisnik k in users)
            {
                if (k.IDUser==idUser)
                {
                    users.Remove(k);
                    break;
                }
            }
             
            File.WriteAllLines(FILE_PATH, users.Select(x => x.FormatForFile()));
        }

        public Korisnik GetUser(int id)
        {
            return GetUsers().ToList().Find(x => x.IDUser == id);

        }

        public Korisnik GetUser(string txtEmail, string txtPass)
        {
            ISet<Korisnik> users = GetUsers();

            //if (users.Exists(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass))
            //{

            //Korisnik u = users.Where(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass) as Korisnik;

            //return u;
            //}

            foreach (Korisnik k in users)
            {
                if ((k.Mail1.ToLower() == txtEmail.ToLower() || k.Mail2.ToLower() ==txtEmail.ToLower() || k.Mail3.ToLower() ==txtEmail.ToLower()) && k.Password == txtPass)
                {
                    return k;

                }
            }
            return null;
        }

        public string GetUserFullName(int id)
        {
            Korisnik k = GetUser(id);
            if (k!=null)
            {
                return string.Format($"{k.Name} {k.Surname}");
            }
            return null;


        }

        public ISet<Korisnik> GetUsers()
        {
            ISet<Korisnik> korisnici = new HashSet<Korisnik>();
            var lines = File.ReadAllLines(FILE_PATH);
            lines.ToList().ForEach(line => korisnici.Add(Korisnik.ParseFromFile(line)));
            return korisnici; 
        }

        public bool ProvjeriLogin(string txtEmail, string txtPass)
        {
            ISet<Korisnik> users = GetUsers();


            //return users.ToList().Find(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass);

            //return users.ToList().Exists(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass);
            bool postoji = false;
            foreach (Korisnik o in users)
            {
                if ((o.Mail1.ToLower() == txtEmail.ToLower() || o.Mail2.ToLower() == txtEmail.ToLower() || o.Mail3.ToLower() == txtEmail.ToLower()) && o.Password.ToLower() == txtPass.ToLower())
                    postoji = true;
            }
            return postoji;






            //if (users.Exists(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass))
            //{
            //    //Korisnik u = users.Where(x => (x.Mail1 == txtEmail || x.Mail2 == txtEmail || x.Mail3 == txtEmail) && x.Password == txtPass) as Korisnik;

            //    return true;
            //}

            //return false;
        }

        public void UpdateMail(string mailStari, string mailNovi, int userID)
        {
            ISet<Korisnik> users = GetUsers();

            foreach (Korisnik k in users)
            {
                if (k.IDUser == userID )
                {
                    if (k.Mail1==mailStari)
                    {
                        k.Mail1 = mailNovi;
                        break;
                    }
                    if (k.Mail2 == mailStari)
                    {
                        k.Mail2 = mailNovi;
                        break;
                    }
                    if (k.Mail3 == mailStari)
                    {
                        k.Mail3 = mailNovi;
                        break;
                    }
                }
            }

            File.WriteAllLines(FILE_PATH, users.Select(x => x.FormatForFile()));

        }

        public void UpdateUser(Korisnik u)
        {
            ISet<Korisnik> users = GetUsers();

            foreach (Korisnik k in users)
            {
                if (k.IDUser==u.IDUser)
                {
                    k.Name = u.Name;
                    k.Surname = u.Surname;
                    k.Telephone = u.Telephone;
                    k.Password = u.Password;
                    k.Status = u.Status;
                    k.City = u.City;
                }
            }

            File.WriteAllLines(FILE_PATH, users.Select(x => x.FormatForFile()));




        }

        public void UpdateUserGrid(Korisnik u)
        {
            ISet<Korisnik> users = GetUsers();

            foreach (Korisnik k in users)
            {
                if (k.IDUser == u.IDUser)
                {
                    k.Name = u.Name;
                    k.Surname = u.Surname;
                    k.Mail1 = u.Mail1;
                    k.Mail2 = u.Mail2;
                    k.Mail3 = u.Mail3;
                    k.Telephone = u.Telephone;
                    k.Status = u.Status;
                }
            }

            File.WriteAllLines(FILE_PATH, users.Select(x => x.FormatForFile()));

        }
    }
}