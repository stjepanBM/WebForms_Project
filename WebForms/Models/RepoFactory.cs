using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class RepoFactory : System.Web.UI.Page
    {

        public static IRepo GetRepository( )
        {
            var kuki = HttpContext.Current.Request.Cookies["repozitorij"];

            if (kuki==null)
            {
                return new Repo();
            }
            else
            {
                switch (kuki.Value)
                {
                    case "1":
                        return new RepoTxt();
                    case "2":
                        return new Repo();
                    default:
                        return null;
                }
            }
           

             
            //{
            //    case "1":
            //    case "2":
            //        return new Repo();
            //    case null:
            //        return new Repo();
            //    default:
            //        return null;
            //}
        }


        
    }
}