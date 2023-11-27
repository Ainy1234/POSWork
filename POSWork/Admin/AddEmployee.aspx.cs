using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.IdentityModel;
using System.Security.Policy;
using System.IO;
using System.Data.SqlClient;

namespace POSWork.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            cookiecheck();
            if (!IsPostBack)
            {
                var d = db.TbRoles.Select(x => x.RoleName).ToList();
                DDListRoles.DataSource = d.ToList();
                
                DDListRoles.DataBind();

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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbName.Text !="" && tbuserName.Text!="" && tbfathername.Text != "" && tbcnic.Text != ""    
                && tbdateOfBirth.Text != "" && tbpassword.Text != "" && tbph.Text != ""  && tbaddress.Text != "" 
                && tbDOA.Text != ""  && cptextbox.Text != "")
            {
                var c = db.TbUsers.Where(x => x.UserName == tbuserName.Text).Count();
                if (c==0) // not present 
                {
                    TbUser tbUser = new TbUser();

                    tbUser.UserFullName = tbName.Text;
                    tbUser.UserName = tbuserName.Text;
                    tbUser.UserFatherName= tbfathername.Text;
                    tbUser.UserCNIC = tbcnic.Text;
                    tbUser.UserDOB = Convert.ToDateTime(tbdateOfBirth.Text);
                    if(tbpassword.Text.Trim() == cptextbox.Text.Trim())
                    {
                        tbUser.UserPassword    =  md5Algo(tbpassword.Text);
                    }
                    else
                    {
                        lberror.Text=" password doesnt match";
                        lbsuccess.Visible= false;
                        divsuccess.Visible= false;
                        lberror.Visible= true;
                        divdanger.Visible= true;
                        return;
                    }
                    
                    tbUser.UserContact  =tbph.Text;
                    tbUser.UserAddress = tbaddress.Text;
                    tbUser.UserDOAppointment =Convert.ToDateTime(tbDOA.Text);
                    tbUser.RoleId =db.TbRoles.Where(x => x.RoleName == DDListRoles.SelectedItem.ToString()).First().RoleId;
                    if (FileUpload.HasFile)
                    {
                        try
                        {
                            // Get the uploaded file's name
                            string fileName = Path.GetFileName(FileUpload.FileName);

                            // Specify the folder where you want to save the uploaded image
                            string folderPath = Server.MapPath("~/UploadedImages/");
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Save the image to the specified folder
                            string filePath = Path.Combine(folderPath, fileName);
                            FileUpload.SaveAs(filePath);
                            tbUser.UserImage = filePath;
                        }
                        catch (Exception ex)
                        {
                            
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                







                db.TbUsers.InsertOnSubmit(tbUser);
                    db.SubmitChanges();
                    tbName.Text= string.Empty;
                    tbuserName.Text = string.Empty;
                    tbfathername.Text = string.Empty;
                    tbcnic.Text = string.Empty;
                    tbdateOfBirth.Text = string.Empty;
                    tbpassword.Text = string.Empty;
                    tbph.Text = string.Empty;
                    tbDOA.Text = string.Empty;
                    tbaddress.Text= string.Empty;
                    cptextbox.Text =string.Empty;
                    DDListRoles.SelectedIndex= -1;

                    lbsuccess.Text="data saved successfully";
                    lbsuccess.Visible= true;
                    divsuccess.Visible= true;
                    lberror.Visible= false;
                    divdanger.Visible= false;
                }
                else
                {
                    lberror.Text="user already exist.";
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
            Response.Redirect("AddEmployees.aspx");
        }
        
        
        
        public static string md5Algo(string password)
        {
            MD5 md5 =  MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<=data.Length-1; i++)
            {
                sb.Append(data[i]);
            }

            return sb.ToString();
        }

       
    }
}


    

