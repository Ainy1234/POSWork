using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace POSWork.Admin
{
    public partial class AddExpenses : System.Web.UI.Page
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
            if (ExpenseName.Text !="" )
            {
                var exp = db.TbExpenses.Where(x => x.ExpenseHead == ExpenseName.Text).Count();
                if (exp==0) // not present 
                {
                    TbExpense tbExpense = new TbExpense();

                    tbExpense.ExpenseHead = ExpenseName.Text;

                    db.TbExpenses.InsertOnSubmit(tbExpense);
                    db.SubmitChanges();
                    ExpenseName.Text= string.Empty;
                   

                    lbsuccess.Text="data saved successfully";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
                }
                else
                {
                    lberror.Text="Expense head already exist.";
                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                    lberror.Visible= true;
                    divdanger.Visible= true;
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

        }
    }
}