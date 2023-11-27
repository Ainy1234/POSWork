using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class SalesInvoice : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var d = db.TbItems.Select(x => x.ItemName).ToList();
                DDListItems.DataSource = d.ToList();
                DDListItems.DataBind();

                var c = db.TbCustomers.Select(x => x.CustomerName).ToList();
                DDCustomer.DataSource = c.ToList();
                DDCustomer.DataBind();

                GrandTotal_amount.Text = "0";
                
                remaingQuantities.Text = "0";
                SubTotal_amount.Text = "0";

                TodayDate.Text  = DateTime.Now.ToString();

                if (ViewState["sale_records"]== null)
                {
                    dt.Columns.Add("Item");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Unit Price");
                    dt.Columns.Add("Amount");
                      
                    ViewState["sale_records"] = dt;
                }
            }
        }


        protected void btnSubmit_bill_Click(object sender, EventArgs e)
        {
            
            if (tbprice.Text!="" && DDListItems.SelectedValue!="Please Select" && tbquantity.Text!="")
            {
                if ((Convert.ToInt32(tbquantity.Text)) >= 0 )
                {
                    if ((Convert.ToDecimal(tbprice.Text) >= 0))
                        {
                        if (Convert.ToInt32(tbquantity.Text) <=  Convert.ToInt32(remaingQuantities.Text))
                        {
                            dt = ViewState["dt"] as DataTable;
                            dt=(DataTable)ViewState["sale_records"];
                            if (GridViewinvoice.Rows.Count== 0)
                            {
                                int val1 = Convert.ToInt32(tbquantity.Text);
                                int val2 = Decimal.ToInt32(Convert.ToDecimal(tbprice.Text));
                                int amount = val1 * val2;
                                dt.Rows.Add(DDListItems.SelectedValue, tbquantity.Text, tbprice.Text, amount);
                                GridViewinvoice.DataSource = dt;
                                GridViewinvoice.DataBind();
                                updatelabels();
                            }
                            else
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row["Item"].ToString() == DDListItems.SelectedItem.Text)
                                    {
                                        row["Quantity"] = (decimal.Parse(row["Quantity"].ToString()) + decimal.Parse(tbquantity.Text)).ToString();
                                        row["Unit Price"] = tbprice.Text;
                                        row["Amount"] = (decimal.Parse(row["Quantity"].ToString()) * decimal.Parse(row["Unit Price"].ToString())).ToString();
                                        GridViewinvoice.DataSource = dt;
                                        GridViewinvoice.DataBind();
                                        updatelabels();
                                        return;


                                    }
                                }


                                int val1 = Convert.ToInt32(tbquantity.Text);
                                int val2 = Decimal.ToInt32(Convert.ToDecimal(tbprice.Text));
                                int amount = val1 * val2;
                                dt.Rows.Add(DDListItems.SelectedValue, tbquantity.Text, tbprice.Text, amount);
                                GridViewinvoice.DataSource = dt;
                                GridViewinvoice.DataBind();
                                updatelabels();


                            }


                        }
                        else
                        {
                            lberror.Text="Quantity is exceeding the limit. Please enter the valid quantity.";
                            lberror.Visible= true;
                            divdanger.Visible= true;

                            lbsuccess.Visible= false;
                            divsuccess.Visible= false;

                        }

                    }
                    else
                    {
                        lberror.Text="Unit Price must be non-negative.";
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
                lberror.Text="Please fill all the fields.";
                lberror.Visible= true;
                divdanger.Visible= true;

                lbsuccess.Visible= false;
                divsuccess.Visible= false;
            }
        }

        public void updatelabels()
        {
            double total = 0; total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDouble(dr["Amount"]);
            }
            SubTotal_amount.Text =  total.ToString();
            int a = Convert.ToInt32(SubTotal_amount.Text);



            GrandTotal_amount.Text =  SubTotal_amount.Text;
            tbquantity.Text = string.Empty;
            tbprice.Text = string.Empty;
            remaingQuantities.Text = "0";
            DDListItems.SelectedIndex= -1;
            


            lberror.Visible= false;
            divdanger.Visible= false;

            lbsuccess.Visible= false;
            divsuccess.Visible= false;
        }
        protected void DDListItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            var item = db.TbItems.Where(x => x.ItemName== DDListItems.SelectedItem.ToString()).FirstOrDefault();
            remaingQuantities.Text  = item.ItemQuantity.ToString();
            tbprice.Text= item.ItemUnitPrice.ToString();
        }

        protected void btn_payamount_Click(object sender, EventArgs e)
        {
            if (GridViewinvoice.Rows.Count == 0)
            {
                lberror.Text="Please first place your order.";
                lberror.Visible= true;
                divdanger.Visible= true;

                lbsuccess.Visible= false;
                divsuccess.Visible= false;
            }
            else
            {
                if (GrandTotal_amount.Text!="" &&  tbDiscount.Text!="" && tbcashbox.Text !="" && tbChangebackAmount.Text!="" &&
                DDCustomer.SelectedItem.Text!= "Please Select")
                
                {
                    if ((Convert.ToDecimal(tbcashbox.Text) >= 0) && (Convert.ToDecimal(tbChangebackAmount.Text) >= 0) &&
                        (Convert.ToDecimal(tbDiscount.Text) >= 0))
                    {
                        if (Convert.ToDecimal(tbDiscount.Text) < Convert.ToDecimal(GrandTotal_amount.Text))
                        {
                            if (Convert.ToDecimal(tbChangebackAmount.Text) < Convert.ToDecimal(tbcashbox.Text))

                            {
                                TbSaleInvoice tbSaleInvoice = new TbSaleInvoice();
                                tbSaleInvoice.InvoiceDate = DateTime.Now;
                                tbSaleInvoice.InvoiceTotalAmount= Convert.ToDecimal(GrandTotal_amount.Text);

                                tbSaleInvoice.Cash = Convert.ToDecimal(tbcashbox.Text);
                                var discount = (Convert.ToDecimal(GrandTotal_amount.Text) * Convert.ToDecimal(tbDiscount.Text))/ 100;
                                tbSaleInvoice.Discount =discount;
                                tbSaleInvoice.AmountAfterDiscount = (Convert.ToDecimal(GrandTotal_amount.Text)) - (discount);
                                tbSaleInvoice.ChangeBackAmount = Convert.ToDecimal(tbChangebackAmount.Text);
                                tbSaleInvoice.CustomerId =db.TbCustomers.Where(x => x.CustomerName == DDCustomer.SelectedItem.ToString()).First().CustomerId;
                                db.TbSaleInvoices.InsertOnSubmit(tbSaleInvoice);

                                foreach (GridViewRow gr in GridViewinvoice.Rows)
                                {

                                    TbSaleOrder tbSaleOrder = new TbSaleOrder();
                                    tbSaleOrder.TbSaleInvoice= tbSaleInvoice; // to generate run time primary key
                                    tbSaleOrder.ItemId = db.TbItems.Where(x => x.ItemName== gr.Cells[1].Text).FirstOrDefault().ItemId;
                                    TbItem item = db.TbItems.Where(x => x.ItemId== tbSaleOrder.ItemId).FirstOrDefault();
                                    item.ItemQuantity -= Convert.ToInt32(gr.Cells[2].Text);

                                    tbSaleOrder.UnitPrice = Convert.ToDecimal(gr.Cells[3].Text);
                                    tbSaleOrder.Quantity =  Convert.ToInt32(gr.Cells[2].Text);

                                    db.TbSaleOrders.InsertOnSubmit(tbSaleOrder);


                                }

                                db.SubmitChanges();
                                GrandTotal_amount.Text = "0";
                                tbcashbox.Text = string.Empty;
                                tbChangebackAmount.Text = string.Empty;
                                tbDiscount.Text = string.Empty;
                                DDCustomer.SelectedIndex = -1;
                                remaingQuantities.Text = "0";
                                SubTotal_amount.Text = "0";




                                lbsuccess.Text="Invoice Posted Successfully.";
                                lberror.Visible= false;
                                divdanger.Visible= false;

                                lbsuccess.Visible= true;
                                divsuccess.Visible= true;

                                //GridViewinvoice.EnableViewState= false;

                                GridViewinvoice.DataSource= null;
                                GridViewinvoice.DataBind();
                            }
                            else
                            {
                                lberror.Text="Your Change back amount is exceeding the cash received amount. Please enter valid amount.";
                                lberror.Visible= true;
                                divdanger.Visible= true;

                                lbsuccess.Visible= false;
                                divsuccess.Visible= false;
                            }
                        }
                        else
                        {

                            lberror.Text="Discount is exceeding the grand total amount. Please check it again.";
                            lberror.Visible= true;
                            divdanger.Visible= true;

                            lbsuccess.Visible= false;
                            divsuccess.Visible= false;
                        }
                    }
                    else
                    {
                        lberror.Text="Value must be non-negative.";
                        lberror.Visible= true;
                        divdanger.Visible= true;

                        lbsuccess.Visible= false;
                        divsuccess.Visible= false;
                    }
                }
                else
                {
                    lberror.Text="Please fill all the fields.";
                    lberror.Visible= true;
                    divdanger.Visible= true;

                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                }

            }

        }



        protected void GridViewinvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["sale_records"];
            if (dt.Rows.Count >0)
            {
                dt.Rows[e.RowIndex].Delete();
            }
            GridViewinvoice.DataSource = dt;
            GridViewinvoice.DataBind();

        }

        protected void tbcashbox_TextChanged(object sender, EventArgs e)
        {
            int r = (Convert.ToInt32(tbcashbox.Text) - Convert.ToInt32(GrandTotal_amount.Text));
            tbChangebackAmount.Text = r.ToString();
        }

        protected void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            var discount = (Convert.ToDecimal(GrandTotal_amount.Text) * Convert.ToDecimal(tbDiscount.Text))/ 100;
          var d =  (Convert.ToDecimal(GrandTotal_amount.Text)) - (discount);
            var u = Convert.ToDecimal( tbcashbox.Text) - d;
            tbChangebackAmount.Text = u.ToString();

        }
    }
}