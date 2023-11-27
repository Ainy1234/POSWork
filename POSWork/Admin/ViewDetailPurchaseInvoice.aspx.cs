using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ViewDetailPurchaseInvoice : System.Web.UI.Page
    {
        
            DataClasses1DataContext db = new DataClasses1DataContext();
            protected void Page_Load(object sender, EventArgs e)
            {
                LbInvoiceNumber.Text = Request.QueryString["PurchaseInvoiceId"];
            TodayDate.Text = db.TbPurchaseInvoices.Where(x => x.PurchaseInvoiceId == Convert.ToInt32(LbInvoiceNumber.Text)).First().InvoiceDate.ToString();

            
            var gd = (from i in db.TbPurchaseOrders
                       where i.PurchaseInvoiceId == Convert.ToInt32( LbInvoiceNumber.Text)
                      select new
                          {
                              OrderId = i.PurchaseInvoiceId,
                              Quantity = i.purchaseQuantity,
                              UnitPrice = i.UnitPrice,
                              ItemId = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName,




                          });

                GridViewinvoice.DataSource = gd;
                GridViewinvoice.DataBind();



            }
        }
    }
    
