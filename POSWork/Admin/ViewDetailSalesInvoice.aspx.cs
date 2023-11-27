using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ViewDetailSalesInvoice : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LbInvoiceNumber.Text = Request.QueryString["InvoiceId"];
            TodayDate.Text  = db.TbSaleInvoices.Where(x => x.InvoiceId == Convert.ToInt32(LbInvoiceNumber.Text)).First().InvoiceDate.ToString();

            
            var gd = (from i in db.TbSaleOrders
                      join j in db.TbSaleInvoices on i.InvoiceId equals j.InvoiceId
                      
                      select new
                      {
                          OrderId = i.OrderId,
                          Quantity = i.Quantity,
                          UnitPrice = i.UnitPrice,
                          ItemId = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName,




                      });

            GridViewinvoice.DataSource = gd;
            GridViewinvoice.DataBind();



        }
    }
}