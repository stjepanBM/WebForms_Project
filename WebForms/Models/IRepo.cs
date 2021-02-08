using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Models
{
    public interface IRepo
    {
        ISet<Korisnik> GetUsers();
        bool ProvjeriLogin(string txtEmail, string txtPass);
        Korisnik GetUser(int id);
        Korisnik GetUser(string email, string pass);
        void DeleteUser(int idUser);
        void UpdateUser(Korisnik u);
        void UpdateUserGrid(Korisnik u);
        void UpdateMail(string mailStari,string mailNovi,int userID);
        string GetUserFullName(int id);
        void AddUser(Korisnik u);




    }
}
