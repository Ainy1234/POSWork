using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListExpenses : System.Web.UI.Page
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

            var gd = (from i in db.TbExpenses

                      select new
                      {
                          

                          ExpenseID = i.ExpenseID,
                          ExpenseName =  i.ExpenseHead


                      });
            GVExpenses.DataSource = gd;
            GVExpenses.DataBind();
        }

        protected void GVExpenses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_head")
            {
                var id = Convert.ToInt32(e.CommandArgument);

                TbExpense r = db.TbExpenses.Where(x => x.ExpenseID == id).First();
                db.TbExpenses.DeleteOnSubmit(r);
                db.SubmitChanges();
                gridBind();
                lbsuccess.Text="Data deleted successfully.";
                lbsuccess.Visible= true;
                divsuccess.Visible= true;
                lberror.Visible= false;
                divdanger.Visible= false;
            }

            if (e.CommandName=="Edit_head")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditExpenses.aspx?ID=" + rowindex);

            }
        }
    }
}