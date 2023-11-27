using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace POSWork.Admin
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Customer_id = virtualURL();
                if (Customer_id != 0)
                {
                    TbCustomer tbcustomer= db.TbCustomers.Where(x => x.CustomerId == Customer_id).First();
                    CustomerName.Text = tbcustomer.CustomerName;
                    CustomerFatherName.Text = tbcustomer.CustomerFatherName;
                    CustomerEmail.Text = tbcustomer.CustomerEmail;
                    CustomerAddress.Text = tbcustomer.CustomerAddress;
                    CustomerPassword.Text = tbcustomer.CustomerPassword;
                    CustomerPhNo.Text = tbcustomer.CustomerPhNo.ToString();


                }
                else
                {
                    Response.Redirect("ListCustomer.aspx", false);
                }


            }




        }
        public long virtualURL()
        {
            string url = Request.QueryString["ID"];
            if (url!=null)
            {
                return long.Parse(Request.QueryString["ID"]);
            }
            return 0;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CustomerName.Text != "" &&
            CustomerFatherName.Text != "" &&
            CustomerEmail.Text != "" &&
            CustomerAddress.Text != "" &&
            CustomerPassword.Text != "" &&
            CustomerPhNo.Text != "")
            {

                var count = db.TbCustomers.Where(x => x.CustomerName ==  CustomerName.Text).Count();



                if (count >=1) // not present 
                {
                    lbsuccess.Text="Supplier already exists.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
                else
                {


                    var Customer_id = virtualURL();
                    
                    TbCustomer tbcustomer = db.TbCustomers.Where(x => x.CustomerId == Customer_id).First();

                    tbcustomer.CustomerFatherName = CustomerFatherName.Text;
                    tbcustomer.CustomerName = CustomerName.Text;
                    tbcustomer.CustomerPhNo=  Convert.ToDecimal(CustomerPhNo.Text);
                    tbcustomer.CustomerAddress = CustomerAddress.Text;
                    tbcustomer.CustomerEmail = CustomerEmail.Text;
                    tbcustomer.CustomerPassword  = CustomerPassword.Text;



                    db.SubmitChanges();

                    lbsuccess.Text="Data saved successfully.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }



            }
            else
            {
                lberror.Text="Please enter the data.";
                lberror.Visible= true;
                divdanger.Visible= true;

                lbsuccess.Visible= false;
                divsuccess.Visible= false;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCustomer.aspx");
        }
    }
}