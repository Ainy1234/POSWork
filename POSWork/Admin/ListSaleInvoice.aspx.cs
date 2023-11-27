
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static iTextSharp.text.Font;
using System.Text;
using System.Data;
using iTextSharp.text.html.simpleparser;

namespace POSWork
{
    public partial class ListSaleInvoice : System.Web.UI.Page
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

            var gd = (from i in db.TbSaleInvoices

                      select new
                      {
                          InvoiceId = i.InvoiceId,

                          InvoiceDate = i.InvoiceDate,
                          InvoiceTotalAmount = i.InvoiceTotalAmount,
                          Discount = i.Discount,
                          Cash = i.Cash,
                          ChangeBackAmount = i.ChangeBackAmount,
                          AmountAfterDiscount = i.AmountAfterDiscount,
                          CustomerId = db.TbCustomers.Where(x => x.CustomerId == i.CustomerId).First().CustomerName,
                          



                      });

            GridViewSalesInvoice.DataSource = gd;
            GridViewSalesInvoice.DataBind();
        }

        protected void GridViewSalesInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="PrintInvoice")
            {

                var r = db.TbSaleInvoices.Where(x => x.InvoiceId == Convert.ToInt32(e.CommandArgument)).First();
                string companyName = "Pos Application";
                
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] {
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Price", typeof(string)),
                            new DataColumn("Quantity", typeof(int)),
                            new DataColumn("Total", typeof(int)),
                           });
                var saleor = db.TbSaleOrders.Where(x => x.InvoiceId == r.InvoiceId);

                foreach(var item in saleor)
                {
                    dt.Rows.Add(db.TbItems.Where(x=> x.ItemId== item.ItemId).FirstOrDefault().ItemName,item.UnitPrice, item.Quantity , item.UnitPrice*item.Quantity);

                }
           
              //var Product =  db.TbSaleOrders.Where(x => x.InvoiceId == r.InvoiceId).FirstOrDefault().TbItem.ItemName;
                
               
              //  var unit_price = db.TbSaleOrders.Where(x => x.InvoiceId == r.InvoiceId).FirstOrDefault().UnitPrice;
              //  var quantity_ = db.TbSaleOrders.Where(x => x.InvoiceId == r.InvoiceId).FirstOrDefault().Quantity;
              //  var total = db.TbSaleInvoices.Where(x => x.InvoiceId == r.InvoiceId).FirstOrDefault().InvoiceTotalAmount;
               

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();

                        //Generate Invoice (Bill) Header.
                        sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Point of Sale Application</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Ph:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Fax:0000-1111111</b></td></tr>");
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td><b>Order No: </b>");
                        sb.Append(r.InvoiceId);
                        sb.Append("</td><td align = 'right'><b>Date: </b>");
                        sb.Append(r.InvoiceDate);
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td><b>Cashier name: </b>");
                        sb.Append("XYX");
                        sb.Append(" </td></tr>");
                        sb.Append("<br />");
                        sb.Append("<tr><td align = 'right' ><b>Company Name: </b>");
                        sb.Append(companyName);
                        sb.Append("</td></tr>");
                        sb.Append("</table>");
                        sb.Append("<br />");

                        //Generate Invoice (Bill) Items Grid.
                        sb.Append("<table border = '1'>");
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
                        sb.Append("'>SubTotal</td>");
                        sb.Append("<td>");
                        sb.Append(dt.Compute("sum(Total)", ""));
                        sb.Append("</td>");
                        sb.Append("</tr>");

                        sb.Append("<tr><td align = 'right' colspan = '");
                        sb.Append(dt.Columns.Count - 1);
                        sb.Append("'>Discount</td>");
                        sb.Append("<td>");
                        sb.Append(dt.Compute( Convert.ToDecimal(r.Discount).ToString(), ""));
                        sb.Append("</td>");
                        sb.Append("</tr>");

                        sb.Append("<tr><td align = 'right' colspan = '");
                        sb.Append(dt.Columns.Count - 1);
                        sb.Append("'>Total</td>");
                        sb.Append("<td>");
                        sb.Append(dt.Compute(Convert.ToDecimal(r.AmountAfterDiscount).ToString(), ""));
                        sb.Append("</td>");
                        sb.Append("</tr>");






                        sb.Append("</tr></table>");

                        sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                       
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h4>Refund or Exchange within 3 days with bill.</td></tr><h4>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h4>System provided by a software developer.</td></tr><h4>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h3>Thank You for shopping!</td></tr><h3>");
                        sb.Append("</table>");
                        sb.Append("<br />");
                        
                        StringReader sr = new StringReader(sb.ToString());
                        Document pdfDoc = new Document(PageSize.NOTE, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + r.InvoiceId + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();
                    }
                }
            }
        }

        protected void GridViewSalesInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hyperLink = e.Row.FindControl("LbSalesInvoiceId") as HyperLink;
                if (hyperLink != null)
                    hyperLink.NavigateUrl =  "ViewDetailSalesInvoice.aspx?InvoiceId="+ DataBinder.Eval(e.Row.DataItem, "InvoiceId");
            }
            
        }
    }
}

