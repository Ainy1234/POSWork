using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = db.TbUsers.Count();
            lbEmployees.Text = count.ToString();

            int countCustomers = db.TbCustomers.Count();
            LbCustomers.Text = countCustomers.ToString();

            int countItems = db.TbItems.Count();
            LbItems.Text = countItems.ToString();

            int countSupplier = db.TbSuppliers.Count();
            LbSupplier.Text = countSupplier.ToString();

            int CountPurchases = db.TbPurchaseOrders.Count();
            LbPurchases.Text = CountPurchases.ToString();

            int CountSales = db.TbSaleOrders.Count();
            LbSales.Text = CountSales.ToString();

            var Sum_UnitPrice = db.TbSaleOrders.Select(x=> x.UnitPrice).Sum();
            var Sum_Quantity = db.TbSaleOrders.Select(x => x.Quantity).Sum();
            int total = Convert.ToInt32( Sum_Quantity) * Convert.ToInt32(Sum_UnitPrice);
            LbProfit.Text = total.ToString("#,##0.##");

            int returns = db.TbSalesReturns.Count();
            LbSalesReturns.Text = returns.ToString();
           

        }
    }
}