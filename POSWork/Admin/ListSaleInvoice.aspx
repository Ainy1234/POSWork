<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListSaleInvoice.aspx.cs" Inherits="POSWork.ListSaleInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  List of Sales 
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
                     <a href="#">Sales</a>
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="ListEmployees.aspx">List of total Sales</a></li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div> 
   
                  
                        <form runat="server">
<div class="portlet box blue">
                  <div class="portlet-title">
                     <div class="caption"><i class="icon-cogs"></i>List of Total Sales</div>
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
                     
    <asp:GridView ID="GridViewSalesInvoice" AutoGenerateColumns="false"
           OnRowCommand="GridViewSalesInvoice_RowCommand"
         DataKeyNames="InvoiceId"
         OnRowDataBound="GridViewSalesInvoice_RowDataBound"
        runat="server" class="table-responsive table table-bordered ">
        <Columns>
    <asp:TemplateField HeaderText="Invoice No."  >
        <ItemTemplate >
            <asp:HyperLink ID="LbSalesInvoiceId" runat="server" Text='<%# Eval("InvoiceId") %>' ></asp:HyperLink>
            <%--<asp:Label ID="LbSalesInvoiceId" runat="server" Text='<%# Eval("InvoiceId") %>'></asp:Label>--%>
        </ItemTemplate>
       
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Date" >
        <ItemTemplate>
            <asp:Label ID="Date" runat="server" Text='<%# Eval("InvoiceDate") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
           
            <asp:TemplateField HeaderText=" Total Amount" >
        <ItemTemplate>
            <asp:Label ID="Amount" runat="server" Text='<%# Eval("InvoiceTotalAmount") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount Amount" >
        <ItemTemplate>
            <asp:Label ID="Discount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
            <asp:TemplateField HeaderText="Cash" >
        <ItemTemplate>
            <asp:Label ID="Cash" runat="server" Text='<%# Eval("Cash") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
                <asp:TemplateField HeaderText=" Change Back Amount " >
        <ItemTemplate>
            <asp:Label ID="empName" runat="server" Text='<%# Eval("ChangeBackAmount") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount After Discount" >
        <ItemTemplate>
            <asp:Label ID="AmountAfterDiscount" runat="server" Text='<%# Eval("AmountAfterDiscount") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer" >
        <ItemTemplate>
            <asp:Label ID="Customer" runat="server" Text='<%# Eval("CustomerId") %>'></asp:Label>
        </ItemTemplate>
       
    </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Print Invoices" >
        <ItemTemplate>
            <asp:LinkButton runat="server" ID="PrintInvoice"  Font-Size="Small" Height="30" Width="70"
                class="btn green " CommandName="PrintInvoice" CommandArgument='<%#Eval("InvoiceId") %>'>Print</asp:LinkButton>
        </ItemTemplate>
                </asp:TemplateField>
               


            
            
       </Columns>
    </asp:GridView>
                      </div>
    </div>
    </form>   
                     
</asp:Content>
