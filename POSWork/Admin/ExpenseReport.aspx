<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" Inherits="POSWork.Admin.ExpenseReport" %>
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
        <asp:Button ID="btn_filter"  OnClick="btn_filter_Click" runat="server" CssClass="btn btn-small blue" Text="Filter" />
                   </div>
            </div>
         <br />
        <br />
        <asp:GridView ID="GVExpenseReport" 
                       class="table-responsive table table-bordered table-hover " 
                       AutoGenerateColumns="false" 
           
           
          runat="server">
        <Columns>
            
    <asp:TemplateField HeaderText="ExpenseID" Visible="false" >
        <ItemTemplate >
            <asp:Label ID="ExpenseID" runat="server" Text='<%# Eval("ExpenseID") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="Expense Head" >
        <ItemTemplate>
            <asp:Label ID="ExpenseHead" runat="server" Text='<%# Eval("ExpenseHead") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            <asp:TemplateField HeaderText="TotalPrice" >
        <ItemTemplate>
            <asp:Label ID="TotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

            
        </Columns>
    </asp:GridView>

        
        <asp:Button ID="btn_Specified_Date" runat="server" class="btn btn-lg green"  OnClick="btn_Specified_Date_Click" Text="Download Specified date Expense Report" />

    
    </form>
</asp:Content>
