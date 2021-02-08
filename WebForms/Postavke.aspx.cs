using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class Postavke : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request.Cookies["loginPodaci"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlRepozitorij_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRepozitorij.SelectedValue != "0")
            {
                var cooki = Request.Cookies["repozitorij"];
                HttpContext.Current.Response.Cookies.Remove("repozitorij");
                cooki.Expires = DateTime.Now.AddDays(-400);
                cooki.Value = null;
                HttpContext.Current.Response.SetCookie(cooki);
                

                HttpCookie kuki = new HttpCookie("repozitorij");
                kuki.Value= ddlRepozitorij.SelectedValue;
                Response.Cookies.Add(kuki);
                kuki.Expires = DateTime.Now.AddDays(400);
              //  Response.Redirect(Request.Url.AbsolutePath);
               
                var cookie = Request.Cookies["loginPodaci"];
                if (cookie != null)
                {
                    HttpContext.Current.Response.Cookies.Remove("loginPodaci");
                    cookie.Expires = DateTime.Now.AddDays(-5);
                    cookie.Value = null;
                    HttpContext.Current.Response.SetCookie(cookie);
                    Response.Redirect("~/Login.aspx");
                }
            }
           

            //HttpCookie kuki = new HttpCookie("RepolabelInfo");
            //kuki.Value = ddlRepozitorij.SelectedValue;
            //kuki.Expires = DateTime.Now.AddDays(100);
            //Response.Cookies.Add(kuki);


        }

        protected void ddlTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTema.SelectedValue !="0")
            {
                HttpCookie kuki = new HttpCookie("tema");
                kuki.Value = ddlTema.SelectedValue;
                Response.Cookies.Add(kuki);
                kuki.Expires = DateTime.Now.AddDays(400);
                Response.Redirect(Request.Url.AbsolutePath);
            }

        }

        protected void ddlJezik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJezik.SelectedValue != "0")
            {
               // string jezik = ddlJezik.SelectedValue;
                HttpCookie kukiJezik = new HttpCookie("culture");
                kukiJezik.Expires.AddDays(10);
                kukiJezik.Value = ddlJezik.SelectedValue;
                //kukiJezik["index"] = ((DropDownList)sender).SelectedIndex.ToString();
                Response.Cookies.Add(kukiJezik);
                Response.Redirect(Request.Url.LocalPath);
            }
        }
    }
}