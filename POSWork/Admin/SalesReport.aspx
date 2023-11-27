<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="POSWork.Admin.SalesReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
     <asp:Button ID="Btn_SalesReport" runat="server" class="btn btn-lg green" OnClick="Btn_SalesReport_Click" Text="Download Sales Report" />

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

        
    
    
    
    
    
    
    
    
    
    
    </form>
</asp:Content>
