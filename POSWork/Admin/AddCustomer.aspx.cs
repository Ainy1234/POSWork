using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class AddCustomer : System.Web.UI.Page
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CustomerName.Text!="" && CustomerPassword.Text!= "" && CustomerFatherName.Text!= "" && CustomerPhNo.Text!= ""
                && CustomerEmail.Text!= "" && CustomerAddress.Text!= "" )
            {
                var c = db.TbCustomers.Where(x => x.CustomerName == CustomerName.Text).Count();
                if (c==0) // not present 
                {
                    TbCustomer tbCustomer = new TbCustomer();

                    tbCustomer.CustomerFatherName = CustomerFatherName.Text;
                    tbCustomer.CustomerName = CustomerName.Text;
                    tbCustomer.CustomerPhNo=  Convert.ToDecimal( CustomerPhNo.Text);
                    tbCustomer.CustomerAddress = CustomerAddress.Text;
                    tbCustomer.CustomerEmail = CustomerEmail.Text;
                    tbCustomer.CustomerPassword  = CustomerPassword.Text;

                    
                    db.TbCustomers.InsertOnSubmit(tbCustomer);
                    db.SubmitChanges();
                    CustomerName.Text= string.Empty;
                    CustomerAddress.Text = string.Empty;
                    CustomerEmail.Text = string.Empty;
                    CustomerFatherName.Text = string.Empty;
                    CustomerPassword.Text = string.Empty;
                    CustomerPhNo.Text = string.Empty;
                    

                    lbsuccess.Text="data saved successfully";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCustomer.aspx");
        }


    }

}
