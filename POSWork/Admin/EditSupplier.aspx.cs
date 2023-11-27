using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork
{
    public partial class EditSupplier : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Supplier_id = virtualURL();
                if (Supplier_id != 0)
                {
                    TbSupplier tbSupplier = db.TbSuppliers.Where(x => x.SupplierId == Supplier_id).First();
                    tbcnic.Text = tbSupplier.SupplierCNIC.ToString();
                    tbemail.Text = tbSupplier.SupplierEmail;
                    tbRegNum.Text = tbSupplier.SupplierRegistrationNumber;
                    tbph.Text = tbSupplier.SupplierContact.ToString();
                    tbName.Text = tbSupplier.SupplierName;


                }
                else
                {
                    Response.Redirect("ListSupplier.aspx", false);
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
            if (tbcnic.Text!="" && tbName.Text!= "" && tbcnic.Text !="" &&
            tbemail.Text != "" &&
            tbRegNum.Text != "" &&
            tbph.Text != "" )
            {

                var count = db.TbSuppliers.Where(x => x.SupplierCNIC == Convert.ToDecimal( tbcnic.Text)).Count();



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


                    var Supplier_id = virtualURL();
                    TbSupplier tbSupplier = db.TbSuppliers.Where(x => x.SupplierId == Supplier_id).First();


                    tbSupplier.SupplierName = tbName.Text;
                    tbSupplier.SupplierCNIC = Convert.ToDecimal(tbcnic.Text);
                    tbSupplier.SupplierContact= Convert.ToDecimal(tbph.Text);
                    tbSupplier.SupplierEmail = tbemail.Text;
                    tbSupplier.SupplierRegistrationNumber = tbRegNum.Text;


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
            Response.Redirect("ListSupplier.aspx");
        }
    }
}
