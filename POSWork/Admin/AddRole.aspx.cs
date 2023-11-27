using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class AddRole : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            cookiecheck();

        }
        protected void cookiecheck()
        {
            try
            {
                if (Request.Cookies["userSettingsR"]["UserID"].Length > 0)
                {
                    Session["UserID"] = Request.Cookies["userSettingsR"]["UserID"];
                }
                else
                {
                    Session["expire"] = "True";
                    Response.Redirect("Logout.aspx");
                }
            }
            catch
            {
                Session["expire"] = "True";
                Response.Redirect("Logout.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbrolename.Text!="")
            {
                int c = db.TbRoles.Where(x => x.RoleName == tbrolename.Text).Count();
                if (c>=1)
                {
                    lbsuccess.Text="Role already exists.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
                else // not present 
                {
                    TbRole tbRole = new TbRole();


                    tbRole.RoleName = tbrolename.Text;

                    db.TbRoles.InsertOnSubmit(tbRole);
                    db.SubmitChanges();
                    tbrolename.Text=string.Empty;
                    lbsuccess.Text="data saved successfully";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
                }
            }
            else
            {
                lberror.Text="Please enter data";
                lbsuccess.Visible= false;
                divsuccess.Visible= false;
                lberror.Visible= true;
                divdanger.Visible= true;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListRoles.aspx");
        }
    }
}
