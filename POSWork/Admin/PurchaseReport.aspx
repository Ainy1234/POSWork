<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PurchaseReport.aspx.cs" Inherits="POSWork.Admin.PurchaseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <form runat="server">
    <asp:Button ID="Btn_PurchaseReport" runat="server" class="btn btn-lg green" OnClick="Btn_PurchaseReport_Click" Text="Download Complete Purchase Report" />

        <br />
              <br />
        <div class="row">
               <div class="col-xs-3">
        <asp:TextBox ID="tbfromdate" TextMode="Date"  CssClass="form-control date-input" runat="server"></asp:TextBox>
                   </div>
            <div class="col-xs-3">
                <asp:TextBox ID="tbtodate" TextMode="Date"  CssClass="form-control date-input" runat="server"></asp:TextBox>
                </div>
            <div class="col-xs-3">
        <asp:Button ID="btn_filter" OnClick="btn_filter_Click" runat="server" CssClass="btn btn-small blue" Text="Filter" />
                   </div>
            </div>
         <br />
        <br />
        <asp:GridView ID="GridViewinvoice" 
                       class="table-responsive table table-bordered table-hover " 
                       AutoGenerateColumns="false" 
           
           
          runat="server">
        <Columns>
            
    <asp:TemplateField HeaderText="Order No." >
        <ItemTemplate >
            <asp:Label ID="PurchaseInvoiceId" runat="server" Text='<%# Eval("PurchaseInvoiceId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Product" >
        <ItemTemplate>
            <asp:Label ID="ItemId" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Date" >
        <ItemTemplate>
            <asp:Label ID="InvoiceDate" runat="server" Text='<%# Eval("InvoiceDate") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" >
        <ItemTemplate>
            <asp:Label ID="purchaseQuantity" runat="server" Text='<%# Eval("purchaseQuantity") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            

            <asp:TemplateField HeaderText="Unit Price" >
        <ItemTemplate>
            <asp:Label ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Supplier" >
        <ItemTemplate>
            <asp:Label ID="SupplierId" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="InvoiceTotalAmount" >
        <ItemTemplate>
            <asp:Label ID="InvoiceTotalAmount" runat="server" Text='<%# Eval("InvoiceTotalAmount") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
        </Columns>
    </asp:GridView>

        
        <asp:Button ID="btn_Specified_Date" runat="server" class="btn btn-lg green" OnClick="btn_Specified_Date_Click" Text="Download Specified date Purchase Report" />

    
    </form>
    
</asp:Content>
