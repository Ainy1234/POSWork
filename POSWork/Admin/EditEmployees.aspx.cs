using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class EditEmployees : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var d = db.TbRoles.Select(x => x.RoleName).ToList();
                DDListRoles.DataSource = d.ToList();

                DDListRoles.DataBind();
                var emp_id = virtualURL();
                if (emp_id != 0)
                {
                    TbUser z = db.TbUsers.Where(x => x.UserId == emp_id).First();
                    tbName.Text = z.UserName;
                    tbuserName.Text = z.UserName;
                    tbfathername.Text = z.UserFatherName;
                    tbcnic.Text = z.UserCNIC;
                    tbdateOfBirth.Text = z.UserDOB.ToString();
                    tbpassword.Text = z.UserPassword;
                    tbph.Text = z.UserContact;
                    tbaddress.Text = z.UserAddress;
                   tbDOA.Text= z.UserDOAppointment.ToString();
                }
                else
                {
                    Response.Redirect("ListEmployees.aspx", false);
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
            if (tbName.Text !="" && tbuserName.Text!="" && tbfathername.Text != "" && tbcnic.Text != ""
                && tbdateOfBirth.Text != "" && tbpassword.Text != "" && tbph.Text != ""  && tbaddress.Text != ""
                && tbDOA.Text != ""  && cptextbox.Text != "")
            {

                var c = db.TbUsers.Where(x => x.UserName == tbName.Text).Count();



                if (c>=1) // not present 
                {
                    lbsuccess.Text="User already exists.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
                else
                {


                    var role_id = virtualURL();
                    TbUser tbUser = db.TbUsers.Where(x => x.UserId == role_id).First();
                    tbUser.UserFullName = tbName.Text;
                    tbUser.UserName = tbuserName.Text;
                    tbUser.UserFatherName= tbfathername.Text;
                    tbUser.UserCNIC = tbcnic.Text;
                    tbUser.UserDOB = Convert.ToDateTime(tbdateOfBirth.Text);
                    tbUser.UserPassword  = tbpassword.Text;
                    tbUser.UserContact  =tbph.Text;
                    tbUser.UserAddress = tbaddress.Text;
                    tbUser.UserDOAppointment =Convert.ToDateTime(tbDOA.Text);
                    tbUser.RoleId =db.TbRoles.Where(x => x.RoleName == DDListRoles.SelectedItem.ToString()).First().RoleId;

                    db.SubmitChanges();
                    tbName.Text= string.Empty;
                    tbuserName.Text = string.Empty;
                    tbfathername.Text = string.Empty;
                    tbcnic.Text = string.Empty;
                    tbdateOfBirth.Text = string.Empty;
                    tbpassword.Text = string.Empty;
                    tbph.Text = string.Empty;
                    tbDOA.Text = string.Empty;
                    tbaddress.Text= string.Empty;
                    cptextbox.Text =string.Empty;
                    DDListRoles.SelectedIndex= -1;

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
            Response.Redirect("ListEmployees.aspx");
        }
    }
}
    