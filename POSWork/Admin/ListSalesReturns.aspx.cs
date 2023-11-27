using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListSalesReturns : System.Web.UI.Page
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

            var gd = (from i in db.TbSalesReturns

                      select new
                      {
                          SalesReturnId = i.SalesReturnId,

                          ItemName = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName,
                          ReturnQuantity = i.ReturnQuantity,
                          ReturnPrice = i.ReturnPrice,
                          CustomerName = db.TbCustomers.Where(x => x.CustomerId == i.CustomerId).First().CustomerName,
                          ReturnDate = i.ReturnDate,
                          
                        


                      });
            GVSalesReturn.DataSource = gd;
            GVSalesReturn.DataBind();
        }

        protected void GVSalesReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName=="Delete_Return")
            {
                var id = Convert.ToInt32(e.CommandArgument);

                TbSalesReturn r = db.TbSalesReturns.Where(x => x.SalesReturnId == id).First();
                db.TbSalesReturns.DeleteOnSubmit(r);
                db.SubmitChanges();
                gridBind();
                lbsuccess.Text="Data deleted successfully.";
                lbsuccess.Visible= true;
                divsuccess.Visible= true;
                lberror.Visible= false;
                divdanger.Visible= false;
            }

            //if (e.CommandName=="Edit_Return")
            //{
            //    Response.Redirect("");
            //}
        }
    }
}