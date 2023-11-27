using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListEmployees : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridBind();
            }
        }
        public void gridBind()
        {

            var gd = (from i in db.TbUsers

                      select new
                      {
                          UserId = i.UserId,

                          UserFullName = i.UserFullName,
                          UserFatherName = i.UserFatherName,
                          UserCNIC = i.UserCNIC,
                          UserContact = i.UserContact,
                          UserDOB = i.UserDOB,
                          UserDOAppointment = i.UserDOAppointment,
                          UserAddress = i.UserAddress,
                          UserPassword = i.UserPassword,
                          UserName = i.UserName,
                         

                          RoleName = db.TbRoles.Where(x => x.RoleId == i.RoleId).First().RoleName


                      });
            GridViewEmployees.DataSource = gd;
            GridViewEmployees.DataBind();
        }

       
        protected void GridViewEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_user")
            {
                var id = Convert.ToInt32(e.CommandArgument);

                TbUser r = db.TbUsers.Where(x => x.UserId == id).First();
                db.TbUsers.DeleteOnSubmit(r);
                db.SubmitChanges();
                gridBind();
                lbsuccess.Text="Data deleted successfully.";
                lbsuccess.Visible= true;
                divsuccess.Visible= true;
                lberror.Visible= false;
                divdanger.Visible= false;
            }

            if (e.CommandName=="Edit_user")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditEmployees.aspx?ID=" + rowindex);

            }
        }

    }
}
