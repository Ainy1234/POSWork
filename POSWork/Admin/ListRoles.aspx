<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListRoles.aspx.cs" Inherits="POSWork.Admin.ListRoles" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Add new Role 
               </h3>
               <ul class="page-breadcrumb breadcrumb">
                  <li class="btn-group">
                     <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                     <span>Actions</span> <i class="icon-angle-down"></i>
                     </button>
                     <ul class="dropdown-menu pull-right" role="menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Another action</a></li>
                        <li><a href="#">Something else here</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Separated link</a></li>
                     </ul>
                  </li>
              <li>
                     <i class="icon-home"></i>
                     <a href="Dashboard.aspx">Home</a> 
                     <i class="icon-angle-right"></i>
                  </li>
                  <li>
                     <a href="Roles.aspx">Role</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="ListRoles.aspx">List of Roles</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div> 
   <div class="">
                       <asp:Button ID="btn_exportToExcel" runat="server" class="btn blue" OnClick="btn_exportToExcel_Click" Text="Export to excel" />
    </div>
                       <br />
                        <form runat="server">
<div class="portlet box blue">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-cogs"></i>List of Roles</div>
                     <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                     </div>
                  </div>
                   <div class="portlet-body">
    <div class="alert alert-danger" id="divdanger" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                                <asp:Label ID="lberror" runat="server" Text="" Visible="false"  ></asp:Label>
                           </div>
                           <div class="alert alert-success" id="divsuccess" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                               <asp:Label ID="lbsuccess" runat="server" Text="" Visible="false" ></asp:Label>
                           </div>
                       
                           <asp:GridView ID="GridViewRoles"  AutoGenerateColumns="False"
         OnRowCommand="GridViewRoles_RowCommand"
        runat="server" class="table-responsive table table-bordered ">
        <Columns>
    <asp:TemplateField HeaderText="Role Id" Visible="false"  >
        <ItemTemplate >
            <asp:Label ID="lbroleid" runat="server" Text='<%# Eval("RoleId") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="tbroleid" runat="server" Text='<%# Eval("RoleId") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Role Name" >
        <ItemTemplate>
            <asp:Label ID="lbrolename" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="tbrolename" runat="server" Text='<%# Eval("RoleName") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete" >
        <ItemTemplate>
            <asp:LinkButton runat="server" ID="deletebtn"    class="btn red" CommandName="Delete_role" CommandArgument='<%#Eval("RoleId") %>'>Delete</asp:LinkButton>
        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" >
        <ItemTemplate>
            <asp:LinkButton runat="server" ID="EditButton"    class="btn green" CommandName="Edit_role" CommandArgument='<%#Eval("RoleId") %>'>Edit</asp:LinkButton>
        </ItemTemplate>
        
    </asp:TemplateField>
            
       </Columns>
    </asp:GridView>
                      </div>
    </div>
    </form>   
                     
                 
    
    
    
</asp:Content>
