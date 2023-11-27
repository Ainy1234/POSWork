<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="POSWork.Admin.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- END BEGIN STYLE CUSTOMIZER -->            
         <!-- BEGIN PAGE HEADER-->   
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Add new Customer 
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
                     <a href="#">Customer</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Add new Customer</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
        
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN VALIDATION STATES-->
               <div class="portlet box purple">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-reorder"></i>Add new Customer</div>
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
                           <div class="form-group">
                               <asp:Label ID="Label1" class="control-label col-md-3" required="" runat="server" Text="Customer Name"></asp:Label>
                             
                              <div class="col-md-4">
                                  <asp:TextBox ID="CustomerName" runat="server" class="form-control" ></asp:TextBox>
                                  
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label2" runat="server" class="control-label col-md-3" Text="Father Name"></asp:Label>
                            
                              <div class="col-md-4">
                                 <asp:TextBox ID="CustomerFatherName" runat="server" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           
                           <div class="form-group">
                               <asp:Label ID="Label4" runat="server" class="control-label col-md-3" Text="Ph No"></asp:Label>
                             
                              <div class="col-md-4">
                                 <asp:TextBox ID="CustomerPhNo" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label5" class="control-label col-md-3" runat="server" Text="CustomerAddress"></asp:Label>
                             
                              <div class="col-md-4">
                                <asp:TextBox ID="CustomerAddress" runat="server" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label6" class="control-label col-md-3" runat="server" Text="CustomerEmail"></asp:Label>
                              <div class="col-md-4">
                                 <asp:TextBox ID="CustomerEmail" runat="server" class="form-control"></asp:TextBox>
                                 
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label7" class="control-label col-md-3" runat="server" Text="CustomerPassword"></asp:Label>
                              <div class="col-md-4">
                                <asp:TextBox ID="CustomerPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                
                              </div>
                           </div>
                            
                           </div>
                        
                        <div class="form-actions fluid">
                           <div class="col-md-offset-3 col-md-9">
                               <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn green" />
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default" />                            
                           </div>
                        </div>
                     </form>
                     <!-- END FORM-->
                  </div>
               </div>
               <!-- END VALIDATION STATES-->
            </div>
         </div>

</asp:Content>
