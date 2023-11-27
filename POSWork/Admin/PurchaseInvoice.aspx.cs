using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class PurchaseInvoice : System.Web.UI.Page
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

                var c = db.TbSuppliers.Select(x => x.SupplierName).ToList();
                DDSupplier.DataSource = c.ToList();
                DDSupplier.DataBind();

                GrandTotal_amount.Text = "0";

                TotalQuantities.Text = "0";
                SubTotal_amount.Text = "0";

                TodayDate.Text  = DateTime.Now.ToString();

                if (ViewState["Purchase_records"]== null)
                {
                    dt.Columns.Add("Item");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Unit Price");
                    dt.Columns.Add("Amount");

                    ViewState["Purchase_records"] = dt;
                }
            }
        }


        


        protected void btnSubmit_bill_Click(object sender, EventArgs e)
        {

            if (tbprice.Text!="" && DDListItems.SelectedValue!="Please Select" && tbquantity.Text!="")
            {
                if (Convert.ToInt32(tbquantity.Text) > 0 && Convert.ToInt32(tbprice.Text) > 0)
                {

                    dt = ViewState["dt"] as DataTable;
                    dt=(DataTable)ViewState["Purchase_records"];
                    if (GVPurchaseInvoice.Rows.Count== 0)
                    {
                        int val1 = Convert.ToInt32(tbquantity.Text);
                        int val2 = Decimal.ToInt32(Convert.ToDecimal(tbprice.Text));
                        int amount = val1 * val2;
                        dt.Rows.Add(DDListItems.SelectedValue, tbquantity.Text, tbprice.Text, amount);
                        GVPurchaseInvoice.DataSource = dt;
                        GVPurchaseInvoice.DataBind();
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
                                GVPurchaseInvoice.DataSource = dt;
                                GVPurchaseInvoice.DataBind();
                                updatelabels();
                                return;


                            }
                        }


                        int val1 = Convert.ToInt32(tbquantity.Text);
                        int val2 = Decimal.ToInt32(Convert.ToDecimal(tbprice.Text));
                        int amount = val1 * val2;
                        dt.Rows.Add(DDListItems.SelectedValue, tbquantity.Text, tbprice.Text, amount);
                        GVPurchaseInvoice.DataSource = dt;
                        GVPurchaseInvoice.DataBind();
                        updatelabels();


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
            TotalQuantities.Text = "0";
            DDListItems.SelectedIndex= -1;



            lberror.Visible= false;
            divdanger.Visible= false;

            lbsuccess.Visible= false;
            divsuccess.Visible= false;
        }

        protected void GVPurchaseInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Purchase_records"];
            if (dt.Rows.Count >0)
            {
                dt.Rows[e.RowIndex].Delete();
            }
            GVPurchaseInvoice.DataSource = dt;
            GVPurchaseInvoice.DataBind();
        }

        protected void DDListItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            var item = db.TbItems.Where(x => x.ItemName== DDListItems.SelectedItem.ToString()).FirstOrDefault();
            TotalQuantities.Text  = item.ItemQuantity.ToString();
           
        }

        protected void btn_payamount_Click(object sender, EventArgs e)
        {
            if(GVPurchaseInvoice.Rows.Count == 0)
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
                DDSupplier.SelectedItem.Text!= "Please Select")

                {
                    if (Convert.ToInt32(tbcashbox.Text) >= 0 && Convert.ToInt32(tbDiscount.Text) >= 0 &&
                        Convert.ToInt32(tbChangebackAmount.Text) >= 0)
                    {

                        if (Convert.ToInt32(tbChangebackAmount.Text) < Convert.ToInt32(tbcashbox.Text))

                        {
                            TbPurchaseInvoice tbPurchaseInvoice = new TbPurchaseInvoice();
                            tbPurchaseInvoice.InvoiceDate = DateTime.Now;
                            tbPurchaseInvoice.InvoiceTotalAmount= Convert.ToDecimal(GrandTotal_amount.Text);

                            tbPurchaseInvoice.Cash = Convert.ToDecimal(tbcashbox.Text);
                            var discount = (Convert.ToDecimal(GrandTotal_amount.Text) * Convert.ToDecimal(tbDiscount.Text))/ 100;
                            tbPurchaseInvoice.Discount =discount;
                            tbPurchaseInvoice.AmountAfterDiscount = (Convert.ToDecimal(GrandTotal_amount.Text)) - (discount);
                            tbPurchaseInvoice.ChangeBackAmount = Convert.ToDecimal(tbChangebackAmount.Text);
                            tbPurchaseInvoice.SupplierId =db.TbSuppliers.Where(x => x.SupplierName == DDSupplier.SelectedItem.ToString()).First().SupplierId;
                            db.TbPurchaseInvoices.InsertOnSubmit(tbPurchaseInvoice);

                            foreach (GridViewRow gr in GVPurchaseInvoice.Rows)
                            {

                                TbPurchaseOrder tbPurchaseOrder = new TbPurchaseOrder();
                                tbPurchaseOrder.TbPurchaseInvoice = tbPurchaseInvoice; // to generate run time primary key
                                tbPurchaseOrder.ItemId = db.TbItems.Where(x => x.ItemName== gr.Cells[1].Text).FirstOrDefault().ItemId;
                                TbItem item = db.TbItems.Where(x => x.ItemId== tbPurchaseOrder.ItemId).FirstOrDefault();
                                item.ItemQuantity += Convert.ToInt32(gr.Cells[2].Text);

                                tbPurchaseOrder.UnitPrice = Convert.ToDecimal(gr.Cells[3].Text);
                                tbPurchaseOrder.purchaseQuantity =  Convert.ToInt32(gr.Cells[2].Text);
                                db.TbPurchaseOrders.InsertOnSubmit(tbPurchaseOrder);



                            }

                            db.SubmitChanges();
                            GrandTotal_amount.Text = "0";
                            tbcashbox.Text = string.Empty;
                            tbChangebackAmount.Text = string.Empty;
                            tbDiscount.Text = string.Empty;
                            DDSupplier.SelectedIndex = -1;
                            TotalQuantities.Text = "0";
                            SubTotal_amount.Text = "0";




                            lbsuccess.Text="Invoice Posted Successfully.";
                            lberror.Visible= false;
                            divdanger.Visible= false;

                            lbsuccess.Visible= true;
                            divsuccess.Visible= true;

                            //GridViewinvoice.EnableViewState= false;

                            GVPurchaseInvoice.DataSource= null;
                            GVPurchaseInvoice.DataBind();
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

       

        protected void tbcashbox_TextChanged(object sender, EventArgs e)
        {
            int r = (Convert.ToInt32(tbcashbox.Text) - Convert.ToInt32(GrandTotal_amount.Text));
            tbChangebackAmount.Text = r.ToString();
        }
        protected void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            var discount = (Convert.ToDecimal(GrandTotal_amount.Text) * Convert.ToDecimal(tbDiscount.Text))/ 100;
            var d = (Convert.ToDecimal(GrandTotal_amount.Text)) - (discount);
            var u = Convert.ToDecimal(tbcashbox.Text) - d;
            tbChangebackAmount.Text = u.ToString();

        }
    }
    }
