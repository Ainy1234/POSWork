using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class EditExpenses : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                var Expense_id = virtualURL();
                if (Expense_id != 0)
                {
                    TbExpense z = db.TbExpenses.Where(x => x.ExpenseID == Expense_id).First();
                    TbExpenseHead.Text = z.ExpenseHead;
                    TbExpenseHead.Text =z.TotalPrice.ToString();
                   
                }
                else
                {
                    Response.Redirect("ListExpenses.aspx", false);
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
            if (TbExpenseHead.Text !="" )
            {

                var count = db.TbExpenses.Where(x => x.ExpenseHead == TbExpenseHead.Text).Count();



                if (count>=1) // not present 
                {
                    lbsuccess.Text="Expense head already exists.";
                    lberror.Visible= false;
                    divdanger.Visible= false;

                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                }
                else
                {


                    var expenseid = virtualURL();
                    TbExpense tbExpense = db.TbExpenses.Where(x => x.ExpenseID == expenseid).First();
                    tbExpense.ExpenseHead = TbExpenseHead.Text;
                    tbExpense.TotalPrice= Convert.ToDecimal( TbTotalPrice.Text);
                    
                    db.SubmitChanges();
                    TbExpenseHead.Text= string.Empty;
                    

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
            Response.Redirect("ListExpenses.aspx");
        }
    }
}