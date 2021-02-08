using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;





namespace WebForms.Models
{
    
    public class MyPage : System.Web.UI.Page
    {
        public static IRepo repo = RepoFactory.GetRepository();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (Request.Cookies["tema"] != null)
            {
                var tema = Request.Cookies["tema"].Value;
                if (tema != "0")
                {
                    this.Theme = tema;
                }
            }
            if (Request.Cookies["repozitorij"] != null)
            {
                repo = RepoFactory.GetRepository();
            }
             
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            if (Request.Cookies["culture"] != null)
            {
                var culture = Request.Cookies["culture"].Value;

                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
                catch (Exception e)
                {

                    String.Format($"{e.Message}");
                }
            }
        }
    }
}