using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork
{
    public partial class Logout : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Loginbtn_Click(object sender, EventArgs e)
        {
            int count = db.TbUsers.Where(x => x.UserName == tbusername.Text).Count();
            var usr = db.TbUsers.Where(x => x.UserName == tbusername.Text).FirstOrDefault();
            // var rolename = db.TbUsers.Where(x => x.UserName == tbusername.Text && x.UserName == tbusername.Text).FirstOrDefault().TbRole.RoleName;
            var encryptedpassword = md5Algo(tbPassword.Text.Trim());

            if (encryptedpassword == usr.UserPassword && count==1)
            {
                Session["UserID"] = usr.UserId.ToString();
                HttpCookie userCookie = new HttpCookie("userSettingsR");
                userCookie["UserID"] = usr.UserId.ToString();
                userCookie.Expires = DateTime.Now.AddDays(2d);
                Response.Cookies.Add(userCookie);
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                LBError.Text = "username not found.";
                LBError.Visible= true;
            }
        }
        public static string md5Algo(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<=data.Length-1; i++)
            {
                sb.Append(data[i]);
            }

            return sb.ToString();
        }

    }
}