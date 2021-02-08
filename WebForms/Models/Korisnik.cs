using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class Korisnik
    {
        private const char DELIMITER = ';';
        public List<KorisnikEmail> Emails { get; set; } = new List<KorisnikEmail>();


        public int IDUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }

        public string Telephone { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public string FormatForFile() => $"{IDUser};{Name};{Surname};{Mail1};{Mail2};{Mail3};{Telephone};{Status};{City};{Password}";


        public static Korisnik ParseFromFile(string line)
        {
            string[] details = line.Split(DELIMITER);


            Korisnik k = new Korisnik();

            k.IDUser =   int.Parse(details[0])  ;
            k.Name = details[1];
            k.Surname = details[2];
            k.Emails.Add(new KorisnikEmail
            {
                Email = details[3]
            });
            k.Emails.Add(new KorisnikEmail
            {
                Email = details[4]
            });
            k.Emails.Add(new KorisnikEmail
            {
                Email = details[5]
            });
            k.Mail1 = details[3];
            k.Mail2 = details[4];
            k.Mail3 = details[5];
            k.Telephone = details[6];
            k.Status = details[7];
            k.City = details[8];
            k.Password = details[9];
          
            return k;
        }

    }
}