using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;
using Org.BouncyCastle.Asn1;

namespace POSWork.Admin
{
    public partial class PurchaseReport : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {  if (!IsPostBack)
            {
                mygrid();
            }
            
           
        }

        public void mygrid()
        {
            var gd = (from i in db.TbPurchaseOrders

                      select new
                      {
                          i.TbPurchaseInvoice.InvoiceDate,
                          i.PurchaseInvoiceId,
                          i.TbItem.ItemName,
                          i.purchaseQuantity,
                          i.UnitPrice,
                          i.TbPurchaseInvoice.TbSupplier.SupplierName,
                          i.TbPurchaseInvoice.InvoiceTotalAmount

                      });
            GridViewinvoice.DataSource=gd;
            GridViewinvoice.DataBind();
        }
        protected void Btn_PurchaseReport_Click(object sender, EventArgs e)
        {
                string companyName = "Pos Application";

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[7] {
                            new DataColumn("Date", typeof(string)),
                            new DataColumn("Order No", typeof(string)),
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Quantity", typeof(int)),
                            new DataColumn("Unit", typeof(int)),
                            new DataColumn("Supplier", typeof(string)),
                            new DataColumn("Total", typeof(int)),
                });
            foreach(var i in db.TbPurchaseOrders)
            {
                dt.Rows.Add(
                    i.TbPurchaseInvoice.InvoiceDate,
                    i.PurchaseOrderId,
                    i.TbItem.ItemName,
                    i.purchaseQuantity,
                    i.UnitPrice,
                    i.TbPurchaseInvoice.TbSupplier.SupplierName,
                    i.TbPurchaseInvoice.InvoiceTotalAmount
                    );
            }
            
            using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<font size='5' face='Courier' >");
                        sb.Append("<table width='100%' cellspacing='0' cellpadding='1'>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Point of Sale Application</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Ph:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Fax:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                       
                        sb.Append("</td><td align = 'left'><b>Date: </b>");
                        sb.Append(DateTime.Now);
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td><b>Cashier name: </b>");
                        sb.Append("xyz");
                        sb.Append(" </td></tr>");
                        sb.Append("<br />");
                        sb.Append("<tr><td align = 'right' ><b>Company Name: </b>");
                        sb.Append(companyName);
                        sb.Append("</td></tr>");
                        sb.Append("</table>");
                        sb.Append("<br />");
                    sb.Append("</Font>");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<font size='5' face='Courier' >");
                    sb.Append("<table border = '0.5'>");
                        sb.Append("<tr>");
                   

                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<th>");
                            sb.Append(column.ColumnName);
                            sb.Append("</th>");
                        }
                        sb.Append("</tr>");
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<td>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }
                            sb.Append("</tr>");
                        }
                        sb.Append("<tr><td align = 'right' colspan = '");
                        sb.Append(dt.Columns.Count - 1);
                        sb.Append("'>Total</td>");
                        sb.Append("<td>");
                        sb.Append(dt.Compute("sum(Total) ", ""));
                        sb.Append("</td>");
                        sb.Append("</tr>");

                        

                       
                        sb.Append("</tr></table>");
                    sb.Append("</Font>");

                    StringReader sr = new StringReader(sb.ToString());
                        Document pdfDoc = new Document(PageSize.LEDGER, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Invoice_" +"" + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();
                    }
                }
            }

        protected void btn_filter_Click(object sender, EventArgs e)
        {
            var fromdate = Convert.ToDateTime(tbfromdate.Text); //db.TbPurchaseInvoices.Where(x => x.InvoiceDate == Convert.ToDateTime(tbfromdate.Text)).First().InvoiceDate;
            var todate = Convert.ToDateTime(tbtodate.Text); //db.TbPurchaseInvoices.Where(x => x.InvoiceDate == Convert.ToDateTime(tbtodate.Text)).First().InvoiceDate;

            if (Convert.ToDateTime( tbfromdate.Text) < Convert.ToDateTime(tbtodate.Text))
            {
                var r = (from i in db.TbPurchaseOrders
                         where i.TbPurchaseInvoice.InvoiceDate >= fromdate
                         && i.TbPurchaseInvoice.InvoiceDate <= todate
                         select new
                         {
                             i.TbPurchaseInvoice.InvoiceDate,
                             i.PurchaseInvoiceId,
                             i.TbItem.ItemName,
                             i.purchaseQuantity,
                             i.UnitPrice,
                             i.TbPurchaseInvoice.TbSupplier.SupplierName,
                             i.TbPurchaseInvoice.InvoiceTotalAmount
                         }

                    );
                GridViewinvoice.DataSource = r;
                GridViewinvoice.DataBind();
            }
        }

        protected void btn_Specified_Date_Click(object sender, EventArgs e)
        {
           
        {
                string companyName = "Pos Application";

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[7] {
                            new DataColumn("Date", typeof(string)),
                            new DataColumn("Order No", typeof(string)),
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Quantity", typeof(int)),
                            new DataColumn("Unit", typeof(int)),
                            new DataColumn("Supplier", typeof(string)),
                            new DataColumn("Total", typeof(int)),
                });
                var fromdate = Convert.ToDateTime(tbfromdate.Text);
                var todate = Convert.ToDateTime(tbtodate.Text); 

                

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();

                        //Generate Invoice (Bill) Header.
                        sb.Append("<font size='5' face='Courier' >");
                        sb.Append("<table width='100%' cellspacing='0' cellpadding='1'>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Point of Sale Application</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Ph:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Fax:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td colspan = '2'></td></tr>");

                        sb.Append("</td><td align = 'left'><b>Date: </b>");
                        sb.Append(DateTime.Now);
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td><b>Cashier name: </b>");
                        sb.Append("xyz");
                        sb.Append(" </td></tr>");
                        sb.Append("<br />");
                        sb.Append("<tr><td align = 'right' ><b>Company Name: </b>");
                        sb.Append(companyName);
                        sb.Append("</td></tr>");
                        sb.Append("</table>");
                        sb.Append("<br />");
                        sb.Append("</Font>");

                        //Generate Invoice (Bill) Items Grid.
                        sb.Append("<font size='5' face='Courier' >");
                        sb.Append("<table border = '0.5'>");
                        sb.Append("<tr>");


                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<th>");
                            sb.Append(column.ColumnName);
                            sb.Append("</th>");
                        }
                        sb.Append("</tr>");
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<td>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }
                            sb.Append("</tr>");
                        }
                        sb.Append("<tr><td align = 'right' colspan = '");
                        sb.Append(dt.Columns.Count - 1);
                        sb.Append("'>Total</td>");
                        sb.Append("<td>");
                        sb.Append(dt.Compute("sum(Total) ", ""));
                        sb.Append("</td>");
                        sb.Append("</tr>");




                        sb.Append("</tr></table>");
                        sb.Append("</Font>");

                        StringReader sr = new StringReader(sb.ToString());
                        Document pdfDoc = new Document(PageSize.LEDGER, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Invoice_" +"" + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();
                    }
                }
            }
        }
    }
    }
    
