using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class SalesReturn : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            cookiecheck();
            if (!IsPostBack)
            {
                var r = db.TbItems.Select(x => x.ItemName).ToList();
                DDProductName.DataSource = r.ToList();
                DDProductName.DataBind();
                var d = db.TbSaleInvoices.Select(x => x.InvoiceId).ToList();
                DDInvoiceNo.DataSource = d.ToList();
                DDInvoiceNo.DataBind();

                var c = db.TbCustomers.Select(x => x.CustomerName).ToList();
                DDCustomer.DataSource = c.ToList();
                DDCustomer.DataBind();




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
            if (GVReturn.Rows.Count==0)
            {


                if (tbquantity.Text!= "" && tbunitprice.Text!= "" && DDCustomer.SelectedValue !="Please Select"
                     && DDProductName.SelectedValue !="Please Select" && tbdate.Text !="")
                {
                    if ((Convert.ToInt32(tbquantity.Text)) >= 0)
                    {
                        if ((Convert.ToDecimal(tbunitprice.Text) >= 0))
                        {

                            var compareItem = db.TbItems.Where(x => x.ItemName== DDProductName.SelectedItem.ToString()).First().ItemId;
                            int c = db.TbItems.Where(x => x.ItemId == compareItem).Count();
                            if (c==1) //  present 
                            {
                                TbSalesReturn tbSalesReturn = new TbSalesReturn();

                                tbSalesReturn.ReturnQuantity = Convert.ToInt32(tbquantity.Text);
                                tbSalesReturn.ReturnPrice = Convert.ToInt32(tbunitprice.Text);
                                tbSalesReturn.ReturnDate= Convert.ToDateTime(tbdate.Text);
                                tbSalesReturn.CustomerId = db.TbCustomers.Where(x => x.CustomerName == DDCustomer.SelectedItem.ToString()).First().CustomerId;

                                tbSalesReturn.ItemId = db.TbItems.Where(x => x.ItemName == DDProductName.SelectedItem.ToString()).First().ItemId;
                                TbItem item = db.TbItems.Where(x => x.ItemId== tbSalesReturn.ItemId).FirstOrDefault();
                                item.ItemQuantity += Convert.ToDecimal(tbquantity.Text);



                                db.TbSalesReturns.InsertOnSubmit(tbSalesReturn);
                                db.SubmitChanges();
                                tbquantity.Text= string.Empty;
                                tbunitprice.Text = string.Empty;
                                tbdate.Text = string.Empty;

                                DDProductName.SelectedIndex = -1;



                                lbsuccess.Text="data saved successfully";
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
                lberror.Text="Please Select invoice no first.";
                lbsuccess.Visible= false;
                divsuccess.Visible= false;
                lberror.Visible= true;
                divdanger.Visible= true;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSalesReturn.aspx");
        }


        protected void GVReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void Mygrid()
        {
            var gd = (from i in db.TbSaleOrders
                      where i.InvoiceId == Convert.ToInt32( DDInvoiceNo.SelectedItem.Value)
                      select new
                      {
                          OrderId = i.OrderId,

                          Quantity = i.Quantity,
                          ItemId = i.TbItem.ItemName,
                          UnitPrice = i.UnitPrice,
                          InvoiceTotalAmount = i.Quantity * i.UnitPrice


                      });
            GVReturn.DataSource = gd;
            GVReturn.DataBind();
        }
        protected void Btn_searchReturn_Click(object sender, EventArgs e)
        {

            if (DDInvoiceNo.SelectedValue!="Please Select")
            {


                int count = db.TbSaleInvoices.Where(x => x.InvoiceId.ToString() ==  DDInvoiceNo.SelectedItem.Text).Count();
                if (count==1)
                {
                    var invoice = db.TbSaleInvoices.Where(x => x.InvoiceId.ToString() == DDInvoiceNo.SelectedItem.Text).First().InvoiceId;
                    lbmessage.Text = "Invoice No:\t" + invoice.ToString();
                    //HyperLink1.Text= TbInvoiceReturnNumber.Text;
                    //HyperLink1.NavigateUrl= HyperLink1.Text;

                    Mygrid();
                    DDInvoiceNo.SelectedIndex = -1;

                }
                
            }
            else
            {
                lberror.Text="Please select invoice no.";
                lbsuccess.Visible= false;
                divsuccess.Visible= false;
                lberror.Visible= true;
                divdanger.Visible= true;
            }
        }

        
        
    }
}