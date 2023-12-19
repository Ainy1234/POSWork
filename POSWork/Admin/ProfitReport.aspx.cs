using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ProfitReport : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                

                mygrid();
            }

           
            }
        public void mygrid()
        {
            var SalesRevenue = db.TbSaleInvoices.Select(x => x.AmountAfterDiscount).Sum();
            var expenses = db.TbExpenses.Select(x => x.TotalPrice).Sum();

            var profit = SalesRevenue - expenses;
            lbRevenue.Text = SalesRevenue.ToString();

            LbExpenses.Text = expenses.ToString();
            Profit.Text = profit.ToString();
        }
    }
}