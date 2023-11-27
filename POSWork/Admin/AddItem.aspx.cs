using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace POSWork.Admin
{
    public partial class AddItem : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            cookiecheck();
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
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (ItemName.Text!=""  && ItemBarcode.Text!= "" 
            && ItemUnitPrice.Text!= "" && ItemQuantity.Text!= ""  && tbSalePrice.Text != "" )
            {
                var count = db.TbItems.Where(x => x.ItemName == ItemName.Text).Count();
                if (count==0) // not present 
                {
                    TbItem tbItem = new TbItem();
                    tbItem.ItemName = ItemName.Text; 
                    tbItem.ItemBarcode = ItemBarcode.Text;
                    tbItem.ItemQuantity= Convert.ToDecimal(ItemQuantity.Text);
                    tbItem.ItemUnitPrice = Convert.ToDecimal( ItemUnitPrice.Text);
                    tbItem.ItemSalePrice = Convert.ToDecimal(tbSalePrice.Text);
                    db.TbItems.InsertOnSubmit(tbItem);
                    db.SubmitChanges();
                    ItemName.Text = string.Empty;
                    ItemBarcode.Text = string.Empty;
                    ItemQuantity.Text = string.Empty;
                    ItemUnitPrice.Text = string.Empty;
                    lbsuccess.Text="data saved successfully";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
                }
                else
                {
                    lberror.Text="user already exist.";
                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                    lberror.Visible= true;
                    divdanger.Visible= true;
                }


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

    
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");

        }
    }
}
