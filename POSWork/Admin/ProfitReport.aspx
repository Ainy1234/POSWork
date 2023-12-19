<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ProfitReport.aspx.cs" Inherits="POSWork.Admin.ProfitReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="Label1" runat="server" Text="Total Revenue: "></asp:Label>
     <asp:Label ID="lbRevenue" runat="server" Text=""></asp:Label>
    <br />
     <asp:Label ID="Label2" runat="server" Text="Total Expenses: "></asp:Label>
     <asp:Label ID="LbExpenses" runat="server" Text=""></asp:Label>
   
          <br />
       <asp:Label ID="Label3" runat="server" Text="Total Profit minus expenses: "></asp:Label>
     <asp:Label ID="Profit" runat="server" Text=""></asp:Label>

</asp:Content>
