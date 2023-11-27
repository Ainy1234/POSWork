<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PurchaseInvoice.aspx.cs" Inherits="POSWork.Admin.PurchaseInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="portlet-body form">
                     <!-- BEGIN FORM-->
                     <form action="#" id="form_sample_1" class="form-horizontal" runat="server">
                        <div class="form-body">
                          
                             <div class="theme-panel hidden-xs hidden-sm">
            <div class="toggler"></div>
            <div class="toggler-close"></div>
            <div class="theme-options">
              
            </div>
         </div>
                             <div class="row hidden-print">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Purchases  <small>Purchase Invoice</small>
               </h3>
               <ul class="page-breadcrumb breadcrumb">
                  <li class="btn-group">
                     
                     
                  </li>
                  <li>
                     <i class="icon-home"></i>
                     <a href="index.html">Home</a> 
                     <i class="icon-angle-right"></i>
                  </li>
                  <li>
                     <a href="#">Purchases</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Purchase Invoice</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
         <!-- END PAGE HEADER-->
         <!-- BEGIN PAGE CONTENT-->
  
         <div class="invoice">
            <div class="row">
                 <div class="alert alert-danger" id="divdanger" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                                <asp:Label ID="lberror" runat="server" Text="" Visible="false"  ></asp:Label>
                           </div>
                           <div class="alert alert-success" id="divsuccess" runat="server" Visible="false">
                              <button class="close" data-dismiss="alert"></button>
                               <asp:Label ID="lbsuccess" runat="server" Text="" Visible="false" ></asp:Label>
                           </div>
               <div class="col-xs-6">
                  
                    <asp:Label ID="lbiNVOICE" CssClass="bold" Font-Size="Large" runat="server" Text="Invoice Number # 543267 "></asp:Label>

               </div>
                   <div class="col-xs-6">
            <asp:Label ID="Label4" CssClass="bold" Font-Size="Large" runat="server" Text="    Date of creation: "></asp:Label>
  <asp:Label ID="TodayDate" CssClass="bold" Font-Size="Large"  runat="server" Text=" "></asp:Label>
               </div>
            </div>
            <hr />
            <div class="row">
               <div class="col-xs-4">
                  <asp:Label ID="Label5" class="control-label bold" required="" runat="server" Text="Item"></asp:Label>
      <asp:DropDownList ID="DDListItems" AutoPostBack="true" OnSelectedIndexChanged="DDListItems_SelectedIndexChanged"  runat="server" class="form-control" AppendDataBoundItems="true" >
      <asp:ListItem Text="Please select" Value="0"></asp:ListItem> </asp:DropDownList>  
               </div>
               <div class="col-xs-3">
                   <asp:Label ID="Label6" class="control-label col-md bold" required="" runat="server" Text="Quantity"></asp:Label> 
                   <asp:TextBox ID="tbquantity" runat="server"   TextMode="Number" class="form-control"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:Label ID="rQ" class="control-label col-md bold Italic"  runat="server" Text="Total Quantities:"></asp:Label>
                                        <asp:Label ID="TotalQuantities" class="control-label col-md bold Italic"  runat="server" Text=""></asp:Label>
                                    </span>
               </div>
               <div class="col-xs-3">
                  <asp:Label ID="Label9" class="control-label col-md bold" required=""  runat="server" Text="Unit Price"></asp:Label>
                             
                                  <asp:TextBox ID="tbprice" runat="server" TextMode="Number" class="form-control"></asp:TextBox>   
                                  
               </div>
                <div class="col-xs-2"><br />
                  <asp:Button ID="btnSubmit_bill" class="btn blue" OnClick="btnSubmit_bill_Click" runat="server" Text="Submit" />  
                                  
               </div>
            </div>

 
             <br />
              <br />

            <div class="row">
               <div class="col-xs-12">
                   							<div class="portlet box blue">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-cogs"></i>List of Items</div>
                     <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                     </div>
                  </div>
                   <div class="portlet-body">

                   <asp:GridView ID="GVPurchaseInvoice" class="table-responsive table table-bordered " AutoGenerateDeleteButton="true" 
        OnRowDeleting="GVPurchaseInvoice_RowDeleting" EnableViewState="true" runat="server"  >
        <Columns> </Columns>
    </asp:GridView>

                                                    </div></div>
               </div>
            </div>


            <div class="row">
               <div class="col-md-4">
                <asp:Label ID="SubTotal" Font-Bold="true" Font-Size="Large" runat="server" Text="Sub Total:"></asp:Label>
                <asp:Label ID="SubTotal_amount" runat="server" Font-Bold="true" Font-Size="Large" Text=""></asp:Label>
             
              
          </div>
               <div class="col-md-4">
                 <asp:Label ID="GrandTotal" runat="server" Font-Bold="true" Font-Size="Large" Text="GrandTotal:"></asp:Label>
                <asp:Label ID="GrandTotal_amount" Font-Bold="true" Font-Size="Large" CssClass="FontColor1" runat="server" Text=""></asp:Label>
          </div>
            </div>
         </div>
                            
                               
                           
                            </div>
                         
                        
        

    <div class="card">
  <div class="card-body">
    <div class="container mb-5 mt-3">
        </div>                         
              
    
                      </div>
    </div>           
                         
        <hr>
                          <div class="row">
               <div class="col-xs-3">
            <asp:Label ID="lbCash" runat="server" Text="Cash Received:"></asp:Label>
                 <asp:TextBox ID="tbcashbox"  OnTextChanged="tbcashbox_TextChanged" AutoPostBack="true" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                   </div>
                              
               <div class="col-xs-3">
 <asp:Label ID="Discount" runat="server" Text="Discount(%):"></asp:Label>
                 <asp:TextBox ID="tbDiscount" AutoPostBack="true" OnTextChanged="tbDiscount_TextChanged" runat="server" TextMode="Number" class="form-control"></asp:TextBox> 
                   </div>
                               
               <div class="col-xs-3">
            <asp:Label ID="ChangebackAmount" runat="server" Text="ChangebackAmount:"></asp:Label>
                 <asp:TextBox ID="tbChangebackAmount"  runat="server" TextMode="Number" class="form-control"></asp:TextBox> 
                           </div>        
               <div class="col-xs-3">
            <asp:Label ID="Supplier" class="control-label" required="" runat="server" Text="Supplier"></asp:Label>
                             
                                  <asp:DropDownList ID="DDSupplier"    runat="server" class="form-control" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
                               </asp:DropDownList> 
                   </div>
                                        </div>
                        
                         <br />
                           <asp:Button ID="btn_payamount" class="btn btn-lg green" OnClick="btn_payamount_Click"
                  runat="server" Text="Submit Your Invoice"></asp:Button>
                                 
        
           
       

      
</form>
         </div>
</asp:Content>
