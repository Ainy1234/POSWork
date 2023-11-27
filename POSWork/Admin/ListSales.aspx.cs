using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListSales : System.Web.UI.Page
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

            var gd = (from i in db.TbSaleOrders

                      select new
                      {
                          OrderId = i.OrderId,
                          UnitPrice = i.UnitPrice,
                          Quantity = i.Quantity,
                          InvoiceId = db.TbSaleInvoices.Where(x => x.InvoiceId == i.InvoiceId).First().InvoiceId,
                          ItemId = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName
                      });
            GVSales.DataSource = gd;
            GVSales.DataBind();
        }

        protected void GVSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_item")
            {

                var id = Convert.ToInt32(e.CommandArgument);
                int count = db.TbPurchaseOrders.Where(x => x.ItemId== id).Count();
                int c2 = db.TbSaleOrders.Where(x => x.ItemId == id).Count();


                if (count==0 && c2 == 0)
                {
                    TbItem r = db.TbItems.Where(x => x.ItemId == id).First();
                    db.TbItems.DeleteOnSubmit(r);
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
                    lberror.Text="Assigned item cant be deleted.";
                    lberror.Visible= true;
                    divdanger.Visible= true;
                    gridBind();
                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                }

                //if (e.CommandName=="Edit_item")
                //{
                //    int rowindex = Convert.ToInt32(e.CommandArgument);
                //    Response.Redirect("EditItem.aspx?ID=" + rowindex);

                //}
            }
        }

    }
}