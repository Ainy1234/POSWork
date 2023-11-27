<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AssignMenu.aspx.cs" Inherits="POSWork.Admin.AssignMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Select Menu  
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
                     <a href="#">Home</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Select Menu</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
        
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN VALIDATION STATES-->
               <div class="portlet box purple">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-reorder"></i>Menu Selection</div>
                     <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                     </div>
                  </div>
                  <div class="portlet-body form">
                     <!-- BEGIN FORM-->
                     <form action="#" id="form_sample_1" class="form-horizontal" runat="server">
                        <div class="form-body">
                           <div class="alert alert-danger" id="divdanger" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                                <asp:Label ID="lberror" runat="server" Text="" Visible="false"  ></asp:Label>
                           </div>
                           <div class="alert alert-success" id="divsuccess" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                               <asp:Label ID="lbsuccess" runat="server" Text="" Visible="false" ></asp:Label>
                           </div>

                            <div class="row">
                                <div class="col-md-6">
                             <asp:Label ID="Label1" runat="server" Text="Select role"   ></asp:Label>
                                 <asp:DropDownList ID="DDListRoles"  runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList>
                                    </div>
                            </div>
                            <br />
                           
                             <div class="row">
                            <div class="col-md-12">
                                  <asp:Label ID="Label2" runat="server" Text="Choose menu and pages from list:"   ></asp:Label>
                          <div class="row">
                                <div class="col-md-2">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Dashboard" Value="Dashboard" />
                                        <asp:ListItem Text="Employees" Value="Employees" />
                                        <asp:ListItem Text="Roles" Value="Roles" />
                                        <asp:ListItem Text="Supplier" Value="Supplier" />
                                        <asp:ListItem Text="Customer" Value="Customer" />
                                        <asp:ListItem Text="Items" Value="Items" />
                                        <asp:ListItem Text="Sales" Value="Sales" />
                                        <asp:ListItem Text="Purchases" Value="Purchases" />
                                        <asp:ListItem Text="Reports" Value="Reports" />
                                        <asp:ListItem Text="Assign Menu" Value="Assign Menu" />
                                    </asp:DropDownList>             
                                    <asp:CheckBoxList ID="MenuCheckBoxList"  runat="server">
                                        <asp:ListItem Text="Dashboard" Value="Dashboard" />
                                        <asp:ListItem Text="Employees" Value="Employees" />
                                        <asp:ListItem Text="Roles" Value="Roles" />
                                        <asp:ListItem Text="Supplier" Value="Supplier" />
                                        <asp:ListItem Text="Customer" Value="Customer" />
                                        <asp:ListItem Text="Items" Value="Items" />
                                        <asp:ListItem Text="Sales" Value="Sales" />
                                        <asp:ListItem Text="Purchases" Value="Purchases" />
                                        <asp:ListItem Text="Reports" Value="Reports" />
                                        <asp:ListItem Text="Assign Menu" Value="Assign Menu" />
                            </asp:CheckBoxList>
                                </div>
                              
                            <div class="col-md-10">
                                 <asp:Label ID="Label4" runat="server" class="control-label bold" Text="Pages"   ></asp:Label>
                                 
                                 
                              <asp:CheckBoxList ID="PageNamesCheckboxList"  RepeatColumns="5" runat="server">
                                        <asp:ListItem Text="Add Employee" Value="AddEmployee.aspx" />
                                          <asp:ListItem Text="Edit Employee" Value="EditEmployees.aspx" />
                                          <asp:ListItem Text="List Employees" Value="ListEmployees.aspx" />
                                         <asp:ListItem Text="Add Customer" Value="AddCustomer.aspx" />
                                         <asp:ListItem Text="Add Item" Value="AddItem.aspx" />
                                         <asp:ListItem Text="Add Role" Value="AddRole.aspx" />
                                         <asp:ListItem Text="Add Supplier" Value="AddSupplier.aspx" />
                                         <asp:ListItem Text="Add SalesReturn" Value="AddSalesReturn.aspx" />
                                         <asp:ListItem Text="Add PurchaseReturn" Value="AddPurchaseReturn" />
                                         
                                         <asp:ListItem Text="Edit Cutsomer" Value="EditCustomer.aspx" />
                                         <asp:ListItem Text="Edit Item" Value="EditItem.aspx" />
                                         <asp:ListItem Text="Edit Role" Value="EditRole.aspx" />
                                         <asp:ListItem Text="Edit Supplier" Value="EditSupplier.aspx" />
                                     
                                         <asp:ListItem Text="List Customer" Value="ListCustomer.aspx" />
                                        <asp:ListItem Text="List Roles" Value="ListRoles.aspx" />
                                         <asp:ListItem Text="List Supplier" Value="ListSupplier.aspx" />
                                        <asp:ListItem Text="List Item" Value="ListItem.aspx" />
                                         <asp:ListItem Text="List Purchase" Value="ListPurchase.aspx" />
                                        <asp:ListItem Text="List Purchase Invoice" Value="ListPurchaseInvoice.aspx" />
                                         <asp:ListItem Text="List Purchase Return" Value="ListPurchaseReturn.aspx" />
                                        <asp:ListItem Text="List Sales Invoice" Value="ListSalesInvoice.aspx" />
                                         <asp:ListItem Text="List Sales" Value="ListSales.aspx" />
                                          <asp:ListItem Text="List Sales Return" Value="ListSalesReturn.aspx" />
                                          <asp:ListItem Text="List Purchase Invoice" Value="ListPurchaseInvoice.aspx" />
                                        <asp:ListItem Text="Purchase Report" Value="PurchaseReport.aspx" />
                                         <asp:ListItem Text="Sales Invoice" Value="SalesInvoice.aspx" />
                                         <asp:ListItem Text="Sales Report" Value="SalesReport.aspx" />
                                         <asp:ListItem Text="View Detail Purchase Invoice" Value="ViewDetailPurchaseInvoice.aspx" />
                                         <asp:ListItem Text="View Detail Sales Invoice" Value="ViewDetailSalesInvoice.aspx" />
                                        
                                         
                                    </asp:CheckBoxList>
                            </div>
                                
                                     </div>
                                 </div>


                        

</div>
                           
                                
        
                         
                       


                        <div class="form-actions fluid">
                           <div class="col-md-offset-3 col-md-9">
                               <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn green" />
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" class="btn default" />                            
                          
                               </div>
                        </div>
                            </div>
                     </form>
                     <!-- END FORM-->
                  </div>
               </div>
               <!-- END VALIDATION STATES-->
            </div>
         </div>
         <script src="assets/scripts/app.js"></script>
   <script src="assets/scripts/form-validation.js"></script> 
   <!-- END PAGE LEVEL STYLES -->    
   <script>
      jQuery(document).ready(function() {   
         // initiate layout and plugins
         App.init();
         FormValidation.init();
      });

   </script>


</asp:Content>
