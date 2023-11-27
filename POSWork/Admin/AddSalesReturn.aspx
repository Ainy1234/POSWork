<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddSalesReturn.aspx.cs" Inherits="POSWork.Admin.SalesReturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- END BEGIN STYLE CUSTOMIZER -->            
         <!-- BEGIN PAGE HEADER-->   
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Add Sales Return
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
                     <a href="#">Sales Return</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Add Sales Return</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
        
         <div class="row">
            <div class="col-md-12">
               <!-- BEGIN VALIDATION STATES-->
               <div class="portlet box purple">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-reorder"></i>Add Sales Return</div>
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
                            <div class="col-md-4">
                                <asp:DropDownList ID="DDInvoiceNo" AutoPostBack="false"  runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList>
                            
                                </div>
                           
                              <div class="col-md-4">
                            <asp:Button ID="Btn_searchReturn" runat="server" Text="Display order details" CssClass="btn btn-success" OnClick="Btn_searchReturn_Click" />
                           </div>
                                  </div>


                               
              <br />
          <asp:Label ID="lbmessage" class="control-label col-md bold"  runat="server" Text=""></asp:Label> 
   <br />
                            <%--<asp:HyperLink ID="HyperLink1" runat="server"> </asp:HyperLink>--%>
                            <asp:GridView ID="GVReturn"  AutoGenerateColumns="False"
         OnRowCommand="GVReturn_RowCommand"
                                 
        runat="server" class="table-responsive table table-bordered ">
        <Columns>
    <asp:TemplateField HeaderText="OrderId"   >
        <ItemTemplate >
            <asp:Label ID="OrderId" runat="server" Text='<%# Eval("OrderId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Product "   >
        <ItemTemplate >
            <asp:Label ID="ItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

             <asp:TemplateField HeaderText="Quantity"   >
        <ItemTemplate >
            <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
            
             

             <asp:TemplateField HeaderText="UnitPrice"  >
        <ItemTemplate >
            <asp:Label ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Amount"  >
        <ItemTemplate >
            <asp:Label ID="InvoiceTotalAmount" runat="server" Text='<%# Eval("InvoiceTotalAmount") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                

           
            </Columns>
                                </asp:GridView>

 <div class="col-md-3">
                   <asp:Label ID="Label1" class="control-label col-md bold" required="" runat="server" Text="Date"></asp:Label> 
                   <asp:TextBox ID="tbdate" runat="server"   TextMode="date" class="form-control"></asp:TextBox>
                                    
               </div>
<div class="col-md-3">
                       <asp:Label ID="Label2" class="control-label col-md bold" required="" runat="server" Text="Product"></asp:Label> 

                               <asp:DropDownList ID="DDProductName" AutoPostBack="false"  runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList>
                                   </div>

                            <div class="col-md-3">
                       <asp:Label ID="Label3" class="control-label col-md bold" required="" runat="server" Text="Customer"></asp:Label> 

                               <asp:DropDownList ID="DDCustomer" AutoPostBack="false"  runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList>
                                   </div>
     <div class="col-md-3">
                   <asp:Label ID="Label6" class="control-label col-md bold" required="" runat="server" Text="Quantity"></asp:Label> 
                   <asp:TextBox ID="tbquantity" runat="server"   TextMode="Number" class="form-control"></asp:TextBox>
                                    
               </div>
               <div class="col-md-3">
                  <asp:Label ID="Label9" class="control-label col-md bold" required=""  runat="server" Text="Unit Price"></asp:Label>
                             
                                  <asp:TextBox ID="tbunitprice" runat="server" TextMode="Number" class="form-control"></asp:TextBox>   
                                  
               </div>

                            
                                    
             

                             
                            
                        <div class="form-actions fluid">
                           <div class="col-md-offset-3 col-md-9">
                              
                               <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"   class="btn green" />
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default" />                            
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







</asp:Content>
