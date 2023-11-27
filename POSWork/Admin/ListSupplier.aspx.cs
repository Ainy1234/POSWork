using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class ListSupplier : System.Web.UI.Page
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

            var gd = (from i in db.TbSuppliers

                      select new
                      {
                          SupplierId = i.SupplierId,

                          SupplierName = i.SupplierName,
                          SupplierCNIC = i.SupplierCNIC,
                          SupplierContact = i.SupplierContact,
                          SupplierRegistrationNumber = i.SupplierRegistrationNumber,
                          SupplierEmail = i.SupplierEmail,






                      });
            GridViewSupplier.DataSource = gd;
            GridViewSupplier.DataBind();
        }

        

        protected void GridViewSupplier_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Delete_Supplier")
            {
                var id = Convert.ToInt32(e.CommandArgument);
                
                int count = db.TbPurchaseInvoices.Where(x => x.SupplierId== id).Count();
                


                if (count==0 )
                {
                    TbSupplier r = db.TbSuppliers.Where(x => x.SupplierId == id).First();
                    db.TbSuppliers.DeleteOnSubmit(r);
                    db.SubmitChanges();
                    gridBind();
                    lbsuccess.Text="Data delete successfully.";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
                }
                else
                {
                    lberror.Text="Supplier is Assigned which cant be deleted.";
                    lberror.Visible= true;
                    divdanger.Visible= true;
                    gridBind();
                    lbsuccess.Visible= false;
                    divsuccess.Visible= false;
                }

                }

            if (e.CommandName=="Edit_Supplier")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);



                Response.Redirect("EditSupplier.aspx?ID=" + rowindex);

            }

        }
    }
}
