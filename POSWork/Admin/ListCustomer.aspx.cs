using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListCustomer : System.Web.UI.Page
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

            var gd = (from i in db.TbCustomers

                      select new
                      {
                          CustomerId = i.CustomerId,

                          CustomerName = i.CustomerName,
                          CustomerFatherName = i.CustomerFatherName,
                          CustomerAddress = i.CustomerAddress,
                          CustomerPhNo = i.CustomerPhNo,
                          CustomerEmail = i.CustomerEmail,
                          CustomerPassword = i.CustomerPassword,
                          

                      });
            GridViewCustomer.DataSource = gd;
            GridViewCustomer.DataBind();
        }


       

        protected void GridViewCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_Customer")
            {
                var id = Convert.ToInt32(e.CommandArgument);
               
                    TbCustomer r = db.TbCustomers.Where(x => x.CustomerId == id).First();
                    db.TbCustomers.DeleteOnSubmit(r);
                    db.SubmitChanges();
                    gridBind();
                    lbsuccess.Text="Data delete successfully.";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;

                
            }

            if (e.CommandName=="Edit_Customer")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);



                Response.Redirect("EditCustomer.aspx?ID=" + rowindex);

            }

        }


    }
}
       