using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListRoles : System.Web.UI.Page
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

            var gd = (from i in db.TbRoles

                      select new
                      {
                          RoleId = i.RoleId,
                          RoleName = i.RoleName

                      });
            GridViewRoles.DataSource = gd;
            GridViewRoles.DataBind();
        }

       

        protected void GridViewRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName=="Delete_role")
            {
                var id = Convert.ToInt32(e.CommandArgument);
                int count= db.TbUsers.Where(x=> x.RoleId== id).Count();
               
                if (count==0)
                {
                    TbRole r = db.TbRoles.Where(x => x.RoleId == id).First();
                    db.TbRoles.DeleteOnSubmit(r);
                    db.SubmitChanges();
                    gridBind();
                    lbsuccess.Text="Data delete successfully.";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;

                }

                else
                {

                    lberror.Text="Data cannot be deleted it is already assigned to user.";
                    lberror.Visible= true;
                    divdanger.Visible= true;
                    gridBind();
                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                    
                }
            }

            if (e.CommandName=="Edit_role")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                

                
                Response.Redirect("EditRole.aspx?ID=" + rowindex);
                
            }

        }

        protected void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            Response.Buffer= true;
            Response.ContentType="application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=roles.xls");
            Response.Charset="";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GridViewRoles.RenderControl(htmlTextWriter);
            Response.Output.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}
