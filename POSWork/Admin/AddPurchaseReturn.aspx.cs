using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class PurchaseReturn : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            cookiecheck();
            if (!IsPostBack)
            {
                var d = db.TbItems.Select(x => x.ItemName).ToList();
                DDProductName.DataSource = d.ToList();
                DDProductName.DataBind();

                var c = db.TbSuppliers.Select(x => x.SupplierName).ToList();
                DDSupplierName.DataSource = c.ToList();
                DDSupplierName.DataBind();

            }

        }
        protected void cookiecheck()
        {
            try
            {
                if (Request.Cookies["userSettingsR"]["UserID"].Length > 0)
                {
                    Session["UserID"] = Request.Cookies["userSettingsR"]["UserID"];
                }
                else
                {
                    Session["expire"] = "True";
                    Response.Redirect("Logout.aspx");
                }
            }
            catch
            {
                Session["expire"] = "True";
                Response.Redirect("Logout.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (DDSupplierName.Text!="Please Select" &&  Quantity.Text!= "" && Price.Text!= ""
                && ReturnSalesDate.Text!= "")
            {
                if ((Convert.ToInt32(Quantity.Text)) >= 0)
                {
                    if ((Convert.ToDecimal(Price.Text) >= 0))
                    {
                        

                            var compareItem = db.TbItems.Where(x => x.ItemName== DDProductName.SelectedItem.ToString()).First().ItemId;
                            int c = db.TbPurchaseReturns.Where(x => x.ItemId == compareItem).Count();
                            if (c==0) // not present 
                            {
                                TbPurchaseReturn tbPurchaseReturn = new TbPurchaseReturn();

                                tbPurchaseReturn.ReturnQuantity = Convert.ToInt32(Quantity.Text);
                                tbPurchaseReturn.ReturnPrice = Convert.ToInt32(Price.Text);
                                tbPurchaseReturn.ReturnDate= Convert.ToDateTime(ReturnSalesDate.Text);
                                tbPurchaseReturn.SupplierId = db.TbSuppliers.Where(x => x.SupplierName == DDSupplierName.SelectedItem.ToString()).First().SupplierId;

                                tbPurchaseReturn.ItemId = db.TbItems.Where(x => x.ItemName == DDProductName.SelectedItem.ToString()).First().ItemId;
                                TbItem item = db.TbItems.Where(x => x.ItemId== tbPurchaseReturn.ItemId).FirstOrDefault();
                                item.ItemQuantity -= Convert.ToDecimal(Quantity.Text);



                                db.TbPurchaseReturns.InsertOnSubmit(tbPurchaseReturn);
                                db.SubmitChanges();
                                Quantity.Text= string.Empty;
                                Price.Text = string.Empty;
                                ReturnSalesDate.Text = string.Empty;
                                DDSupplierName.SelectedIndex = -1;
                                DDProductName.SelectedIndex = -1;



                                lbsuccess.Text="Data saved successfully.";
                                lbsuccess.Visible= true;
                                divsuccess.Visible= true;
                                lberror.Visible= false;
                                divdanger.Visible= false;
                            }
                        
                        else
                        {
                            lberror.Text="Please enter data";
                            lbsuccess.Visible= false;
                            divsuccess.Visible= false;
                            lberror.Visible= true;
                            divdanger.Visible= true;
                        }

                    }
                    else
                    {
                        lberror.Text="Price must be non-negative.";
                        lberror.Visible= true;
                        divdanger.Visible= true;

                        lbsuccess.Visible= false;
                        divsuccess.Visible= false;
                    }
                }
                else
                {
                    lberror.Text="Quantity must be non-negative.";
                    lberror.Visible= true;
                    divdanger.Visible= true;

                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseReturn.aspx");
        }
    }
}
