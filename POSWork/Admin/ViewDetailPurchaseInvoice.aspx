<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewDetailPurchaseInvoice.aspx.cs" Inherits="POSWork.Admin.ViewDetailPurchaseInvoice" %>
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
                  Sales  <small>Sale Invoice</small>
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
                     <a href="#">Sales</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">View detail Sale Invoice</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
         <!-- END PAGE HEADER-->
         <!-- BEGIN PAGE CONTENT-->
  </div>
         <div class="invoice">
            <div class="row">
                
               <div class="col-xs-6">
                  
 <asp:Label ID="lbiNVOICE" CssClass="bold" Font-Size="Large" runat="server" Text="Invoice Number #  "></asp:Label>
<asp:Label ID="LbInvoiceNumber" CssClass="bold" Font-Size="Large" runat="server" Text=" "></asp:Label>

               </div>
                   <div class="col-xs-6">
            <asp:Label ID="Label4" CssClass="bold" Font-Size="Large" runat="server" Text="    Date of creation: "></asp:Label>
  <asp:Label ID="TodayDate" CssClass="bold" Font-Size="Large"  runat="server" Text=" "></asp:Label>
               </div>
            </div>
            <hr />
            <div class="row">
               <div class="col-xs-4">
      
             <br />
              <br />
                   </div>
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

                   <asp:GridView ID="GridViewinvoice" 
                       class="table-responsive table table-bordered " 
                       AutoGenerateColumns="false"
          runat="server"  >
        <Columns>
            
    <asp:TemplateField HeaderText="Order No."  >
        <ItemTemplate >
            <asp:Label ID="LbSalesInvoiceId" runat="server" Text='<%# Eval("OrderId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Product" >
        <ItemTemplate>
            <asp:Label ID="ItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" >
        <ItemTemplate>
            <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            

            <asp:TemplateField HeaderText="Unit Price" >
        <ItemTemplate>
            <asp:Label ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

        </Columns>
    </asp:GridView>

                                                    </div></div>
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
                          
              

      
</form>
         </div>



</asp:Content>
