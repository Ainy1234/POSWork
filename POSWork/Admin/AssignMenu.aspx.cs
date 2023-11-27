using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSWork.Admin
{
    public partial class AssignMenu : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var d = db.TbRoles.Select(x => x.RoleName).ToList();
                DDListRoles.DataSource = d.ToList();
                DDListRoles.DataBind();

            }

        }
        protected void btnMenuSelection_Click(object sender, EventArgs e)
        {
            //for (int j = 0; j< MenuCheckBoxList.Items.Count; j++)
            //{
            //    if (MenuCheckBoxList.Items[j].Selected)
            //    {

            //        TbUserAccessMenu tbUserAccessMenu = new TbUserAccessMenu();
            //        tbUserAccessMenu.MenuName = MenuCheckBoxList.Items[j].Value;

            //        //TbUserAccess tbUserAccess = new TbUserAccess();
            //        //tbUserAccess.TbUserAccessMenu = tbUserAccessMenu;
            //        //tbUserAccess.MenuName = MenuCheckBoxList.Items[j].Value;
            //        tbUserAccessMenu.RoleId = db.TbRoles.Where(x => x.RoleName == DDListRoles.SelectedItem.ToString()).FirstOrDefault().RoleId;

            //        db.TbUserAccessMenus.InsertOnSubmit(tbUserAccessMenu);
            //        db.SubmitChanges();
            //    }
            //}
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string value = "";
            TbUserAccess tbUserAccess = new TbUserAccess();

            for (int i = 0; i< MenuCheckBoxList.Items.Count; i++)
            {
                if (MenuCheckBoxList.Items[i].Selected)
                {
                    if(value == "")
                    {
                        value = MenuCheckBoxList.Items[i].Text;
                    }
                    else
                    {
                        value += "," + MenuCheckBoxList.Items[i].Text;
                    }
                   

                    tbUserAccess.MenuName = value;
                }
            }
            string value2 = ""; 
            for (int j = 0; j <PageNamesCheckboxList.Items.Count; j++)
            {
                if (PageNamesCheckboxList.Items[j].Selected)
                {
                    if (value2 == "")
                    {
                        value2 = PageNamesCheckboxList.Items[j].Value;
                    }
                    else
                    {
                        value2 += "," + PageNamesCheckboxList.Items[j].Value;
                    }


                    tbUserAccess.PageName = value2;
                }
                
                    
            }
            tbUserAccess.RoleId = db.TbRoles.Where(x => x.RoleName == DDListRoles.SelectedItem.ToString()).FirstOrDefault().RoleId;
            db.TbUserAccesses.InsertOnSubmit(tbUserAccess);
            db.SubmitChanges();
        }
            
            
            
            
            //for (int i = 0; i< CBLEmployees.Items.Count; i++)
            //{
            //    if (CBLEmployees.Items[i].Selected)
            //    {
            //        TbUserAccess tbUserAccess = new TbUserAccess();

            //        tbUserAccess.PageName =   CBLEmployees.Items[i].Value;
            //        tbUserAccess.RoleId = db.TbRoles.Where(x => x.RoleName == DDListRoles.SelectedItem.ToString()).FirstOrDefault().RoleId;
            //        tbUserAccess.TbUserAccessMenuId = db.TbUserAccessMenus.Where(x => x.RoleId ==  tbUserAccess.RoleId && x.MenuName == CBLEmployees.Items[0].Value).First().TbUserAccessMenuId;

            //        db.TbUserAccesses.InsertOnSubmit(tbUserAccess);
            //        db.SubmitChanges();

            //    }

            //}


        

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }   
}