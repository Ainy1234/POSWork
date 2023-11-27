using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class AddSupplier : System.Web.UI.Page
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
            if (tbName.Text!="" && tbcnic.Text!= "" && tbRegNum.Text!= "" && tbemail.Text!= ""
                && tbph.Text!= "")
            {
                var c = db.TbSuppliers.Where(x => x.SupplierCNIC == Convert.ToDecimal(tbcnic.Text)).Count();
                if (c==0) // not present 
                {
                    TbSupplier tbSupplier = new TbSupplier();
                    //var newguid = System.Guid.NewGuid();

                    //tbSupplier.SupplierId = newguid;
                    tbSupplier.SupplierName = tbName.Text;
                    tbSupplier.SupplierCNIC = Convert.ToDecimal(tbcnic.Text);
                    tbSupplier.SupplierContact= Convert.ToDecimal(tbph.Text);
                    tbSupplier.SupplierEmail = tbemail.Text;
                    tbSupplier.SupplierRegistrationNumber = tbRegNum.Text;


                    db.TbSuppliers.InsertOnSubmit(tbSupplier);
                    db.SubmitChanges();
                    tbName.Text= string.Empty;


                    tbcnic.Text = string.Empty;

                    tbph.Text = string.Empty;

                    tbemail.Text = string.Empty;
                    tbRegNum.Text = string.Empty;

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
            Response.Redirect("ListSupplier.aspx");
        }
    }

    
}
    
