using POSWork.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            cookiecheck();

            var roleid = db.TbUsers.Where(x => x.UserId.ToString() == Request.Cookies["userSettingsR"]["UserID"]).FirstOrDefault().RoleId;
            var existingRecord = db.TbUserAccesses.FirstOrDefault(x => x.RoleId == roleid);
            
            var rolename = db.TbRoles.Where(x=> x.RoleId == roleid).FirstOrDefault().RoleName;
            if (rolename == ("Admin"))
            {
                divEmployees.Visible  = true;
                SMAddEmployee.Visible= true;
                SMListEmployee.Visible= true;
                divDashboard.Visible = true;

                divRoles.Visible = true;
                SMAddRole.Visible= true;

                SMListRole.Visible= true;

                divSupplier.Visible = true;
                SMAddSupplier.Visible= true;
                SMListSupplier.Visible= true;

                divCustomer.Visible = true;

                SMAddCustomer.Visible= true;

                SMListCustomer.Visible= true;

                divItems.Visible = true;

                SMAddItem.Visible= true;
                SMListItem.Visible= true;
                divReports.Visible = true;

                SMSalesReport.Visible= true;

                SMPurchaseReport.Visible= true;

                divAssignMenu.Visible = true;


                SMAssignMenu.Visible= true;

                divExpenseMenu.Visible = true;

                SMAddExpenses.Visible= true;

            }
            if (existingRecord != null)
            {
                var pagename = db.TbUserAccesses.Where(x => x.RoleId == roleid)
                 .Select(x => new
                 {
                     x.PageName,
                     x.MenuName
                 }).ToList();



                //var ValuesToCompare = pagename.SelectMany(i => i.ToString().Split(','))
                //    .Select(v => v.Trim())
                //    .ToList();

                foreach (var page in pagename)
                {
                    if (page.MenuName =="Employees")
                    {
                        divEmployees.Visible  = true;
                        string[] pg = page.PageName.Split(',');
                        for(int i=0;i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddEmployee.aspx")
                            {
                                SMAddEmployee.Visible= true;
                            }
                            if (pg[i]== "ListEmployees.aspx")
                            {
                                SMListEmployee.Visible= true;
                            }
                            
                        }
                    }
                    if (page.MenuName ==("Dashboard"))
                    {
                        divDashboard.Visible = true;

                    }
                    if (page.MenuName ==("Roles"))
                    {
                        divRoles.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddRole.aspx")
                            {
                                SMAddRole.Visible= true;
                            }
                            if (pg[i]== "ListRoles.aspx")
                            {
                                SMListRole.Visible= true;
                            }

                        }

                    }
                    if (page.MenuName ==("Supplier"))
                    {
                        divSupplier.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddSupplier.aspx")
                            {
                                SMAddSupplier.Visible= true;
                            }
                            if (pg[i]== "ListSupplier.aspx")
                            {
                                SMListSupplier.Visible= true;
                            }

                        }
                    }
                    if (page.MenuName ==("Customer"))
                    {
                        divCustomer.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddCustomer.aspx")
                            {
                                SMAddCustomer.Visible= true;
                            }
                            if (pg[i]== "ListCustomer.aspx")
                            {
                                SMListCustomer.Visible= true;
                            }

                        }

                    }
                    if (page.MenuName ==("Items"))
                    {
                        divItems.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddItem.aspx")
                            {
                                SMAddItem.Visible= true;
                            }
                            if (pg[i]== "ListItem.aspx")
                            {
                                SMListItem.Visible= true;
                            }

                        }

                    }
                    if (page.MenuName ==("Reports"))
                    {
                        divReports.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "SalesReport.aspx")
                            {
                                SMSalesReport.Visible= true;
                            }
                            if (pg[i]== "PurchaseReport.aspx")
                            {
                                SMPurchaseReport.Visible= true;
                            }

                        }

                    }
                    if (page.MenuName ==("Assign Menu"))
                    {
                        divAssignMenu.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AssignMenu.aspx")
                            {
                                SMAssignMenu.Visible= true;
                            }
                           
                        }

                    }
                    if (page.MenuName ==("Assign Menu"))
                    {
                        divExpenseMenu.Visible = true;
                        string[] pg = page.PageName.Split(',');
                        for (int i = 0; i< pg.Count(); i++)
                        {
                            if (pg[i]== "AddExpenses.aspx")
                            {
                                SMAddExpenses.Visible= true;
                            }

                        }

                    }


                }
            }

            



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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}
