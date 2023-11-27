using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class EditRole : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var role_id = virtualURL();
                if (role_id != 0)
                {
                    TbRole z = db.TbRoles.Where(x => x.RoleId == role_id).First();
                    tbrolename.Text = z.RoleName;
                }
                else
                {
                    Response.Redirect("ListRoles.aspx", false);
                }


            }
            

            

        }
        public long virtualURL()
        {
            string url = Request.QueryString["ID"];
            if (url!=null)
            {
                return long.Parse(Request.QueryString["ID"]);
            }
            return 0;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbrolename.Text!="")
            {
                
                var c = db.TbRoles.Where(x => x.RoleName == tbrolename.Text).Count();



                if (c>=1) // not present 
                {
                    lbsuccess.Text="Role already exists.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
                else
                {

                
                    var role_id = virtualURL();
                    TbRole tbRole = db.TbRoles.Where(x => x.RoleId == role_id).First();


                    tbRole.RoleName = tbrolename.Text;

                    
                    db.SubmitChanges();

                    lbsuccess.Text="Data saved successfully.";
                    lberror.Visible= false;
                    divdanger.Visible= false;
                   
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
              

                
            }
            else
            {
                lberror.Text="Please enter the data.";
                lberror.Visible= true;
                divdanger.Visible= true;
               
                lbsuccess.Visible= false;
                divsuccess.Visible= false;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListRoles.aspx");
        }
    }
}