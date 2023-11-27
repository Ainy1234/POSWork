<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="POSWork.Admin.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- END BEGIN STYLE CUSTOMIZER -->            
         <!-- BEGIN PAGE HEADER-->   
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Add new Employee 
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
                     <a href="#">Employees</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Add new employee</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
        
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN VALIDATION STATES-->
               <div class="portlet box purple">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-reorder"></i>Add new Employee</div>
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
                          <div class="col-md-9"> 
                           <div class="form-group">
                               <asp:Label ID="Label1" class="control-label col-md-3" required="" runat="server" Text="Name"></asp:Label>
                             
                              <div class="col-md-4">
                                  <asp:TextBox ID="tbName" runat="server" class="form-control" ></asp:TextBox>
                                  
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label2" runat="server" class="control-label col-md-3" Text="Father Name"></asp:Label>
                            
                              <div class="col-md-4">
                                 <asp:TextBox ID="tbfathername" runat="server" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label3" runat="server" class="control-label col-md-3" Text="CNIC"></asp:Label>
                              
                              <div class="col-md-4">
                                 <asp:TextBox ID="tbcnic" runat="server" class="form-control"></asp:TextBox>
                                 <span class="help-block">e.g: xxxxx-xxxxxxx-x</span>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label4" runat="server" class="control-label col-md-3" Text="Ph No"></asp:Label>
                             
                              <div class="col-md-4">
                                 <asp:TextBox ID="tbph" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label5" class="control-label col-md-3" runat="server" Text="Date of Birth"></asp:Label>
                             
                              <div class="col-md-4">
                                <asp:TextBox ID="tbdateOfBirth" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label6" class="control-label col-md-3" runat="server" Text="Date of Appointment"></asp:Label>
                              <div class="col-md-4">
                                 <asp:TextBox ID="tbDOA" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                                 
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label7" class="control-label col-md-3" runat="server" Text="Address"></asp:Label>
                              <div class="col-md-4">
                                <asp:TextBox ID="tbaddress" runat="server" class="form-control"></asp:TextBox>
                                
                              </div>
                           </div>
                            <div class="form-group">
                               <asp:Label ID="Label9" class="control-label col-md-3" runat="server" Text="UserName"></asp:Label>
                              <div class="col-md-4">
                                <asp:TextBox ID="tbuserName" runat="server" class="form-control"></asp:TextBox>
                                
                              </div>
                           </div>
                            <div class="form-group">
                               <asp:Label ID="Label10" class="control-label col-md-3"  runat="server" Text="Password"></asp:Label>
                              <div class="col-md-4">
                                  
                                <asp:TextBox ID="tbpassword" runat="server"  TextMode="Password" class="form-control ">
                                    
                                </asp:TextBox>
                                  
                                
                              </div>
                           </div>
                            <div class="form-group">
                               <asp:Label ID="Label11" class="control-label col-md-3"  runat="server" Text="Confirm Password"></asp:Label>
                              <div class="col-md-4">
                                <asp:TextBox ID="cptextbox" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                  <asp:Label ID="tooltiperror" runat="server" Enabled="false" ForeColor="Red" Text=""></asp:Label>
                              </div>
                           </div>
                           <div class="form-group">
                               <asp:Label ID="Label8" class="control-label col-md-3" runat="server" Text="Designation">

                               </asp:Label>
                               <div class="col-md-4">
                               <asp:DropDownList ID="DDListRoles"  runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList>
                               
                              
                                
                              </div>
                           </div>


</div>
                                <div class="col-md-3">
                       <asp:Label ID="Label12" runat="server" class="control-label " Text="Image file"></asp:Label>
                   <asp:Image ID="Image1" Height="100px" class="form-control" Width="100px" AlternateText="profilepic" BorderWidth="1" BorderColor="Black" runat="server"/>
                                    <br />
                                    <asp:FileUpload ID="FileUpload" runat="server" />
                                    <br />
                                   
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
