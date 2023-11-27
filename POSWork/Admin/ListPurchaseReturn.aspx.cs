using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListPurchaseReturn : System.Web.UI.Page
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

            var gd = (from i in db.TbPurchaseReturns

                      select new
                      {
                          PurchaseReturnId = i.PurchaseReturnId,

                          ItemName = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName,
                          ReturnQuantity = i.ReturnQuantity,
                          ReturnPrice = i.ReturnPrice,
                          SupplierName = db.TbSuppliers.Where(x => x.SupplierId == i.SupplierId).First().SupplierName,
                          ReturnDate = i.ReturnDate,



                      });
            GVPurchaseReturn.DataSource = gd;
            GVPurchaseReturn.DataBind();
        }

        protected void GVPurchaseReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName=="Delete_user")
            {
                var id = Convert.ToInt32(e.CommandArgument);

                TbPurchaseReturn r = db.TbPurchaseReturns.Where(x => x.PurchaseReturnId == id).First();
                db.TbPurchaseReturns.DeleteOnSubmit(r);
                db.SubmitChanges();
                gridBind();
                lbsuccess.Text="Data deleted successfully.";
                lbsuccess.Visible= true;
                divsuccess.Visible= true;
                lberror.Visible= false;
                divdanger.Visible= false;
            }
            if (e.CommandName=="Edit_Return")
            {
                Response.Redirect("");
            }




        }
    }
}