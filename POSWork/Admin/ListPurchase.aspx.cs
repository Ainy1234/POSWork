using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace POSWork.Admin
{
    public partial class ListPurchase : System.Web.UI.Page
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

            var gd = (from i in db.TbPurchaseOrders

                      select new
                      {
                          PurchaseOrderId = i.PurchaseOrderId,
                          UnitPrice = i.UnitPrice,
                          purchaseQuantity = i.purchaseQuantity,
                          PurchaseInvoiceId = db.TbPurchaseInvoices.Where(x => x.PurchaseInvoiceId == i.PurchaseInvoiceId).First().PurchaseInvoiceId,
                          ItemId = db.TbItems.Where(x => x.ItemId == i.ItemId).First().ItemName
                      });
            GVPurchases.DataSource = gd;
            GVPurchases.DataBind();
        }




        protected void GVPurchases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_Order")
            {

                var id = Convert.ToInt32(e.CommandArgument);
                int count = db.TbPurchaseOrders.Where(x => x.ItemId== id).Count();
                int c2 = db.TbPurchaseInvoices.Where(x => x.PurchaseInvoiceId == id).Count();


                if (count==0 && c2 == 0)
                {
                    TbPurchaseOrder r = db.TbPurchaseOrders.Where(x => x.ItemId == id).First();
                    db.TbPurchaseOrders.DeleteOnSubmit(r);
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

                
            }
        }
    }
    }
