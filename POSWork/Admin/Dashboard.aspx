<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="POSWork.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
            <div class="col-md-12">
               <!-- BEGIN PAGE TITLE & BREADCRUMB-->
               <h3 class="page-title">
                  Dashboard <small>statistics and more</small>
               </h3>
               <ul class="page-breadcrumb breadcrumb">
                  <li>
                     <i class="icon-home"></i>
                     <a href="Dashboard.aspx">Home</a> 
                     <i class="icon-angle-right"></i>
                  </li>
                  <li><a href="#">Dashboard</a></li>
                  <li class="pull-right">
                     <div id="dashboard-report-range" class="dashboard-date-range tooltips" data-placement="top" data-original-title="Change dashboard date range">
                        <i class="icon-calendar"></i>
                        <span></span>
                        <i class="icon-angle-down"></i>
                     </div>
                  </li>
               </ul>
               <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
         </div>
         <!-- END PAGE HEADER-->
         <!-- BEGIN DASHBOARD STATS -->
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat blue">
                  <div class="visual">
                     <i class="icon-comments"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                         <asp:Label ID="lbEmployees" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">                           
                        Employees
                     </div>
                  </div>
                  <a class="more" href="ListEmployees.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat green">
                  <div class="visual">
                      <i class="icon-male"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="LbCustomers" runat="server" Text=""></asp:Label></div>
                     <div class="desc">Customers</div>
                  </div>
                  <a class="more" href="ListCustomer.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat purple">
                  <div class="visual">
                     <i class="icon-shopping-cart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="LbItems" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Items</div>
                  </div>
                  <a class="more" href="ListItem.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat yellow">
                  <div class="visual">
                     <i class="icon-bar-chart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label1" Font-Size="Small" runat="server" Text="PKR"></asp:Label>
                         <asp:Label ID="LbProfit" runat="server" Text=""></asp:Label>
                         </div>
                     <div class="desc">Total Profit</div>
                  </div>
                  <a class="more" href="#">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
         </div>
        




     <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat yellow">
                  <div class="visual">
                    <i class="icon-female"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                         <asp:Label ID="LbSupplier" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">                           
                        Supplier
                     </div>
                  </div>
                  <a class="more" href="ListSupplier.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat purple">
                  <div class="visual">
                     <i class="icon-shopping-cart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="LbPurchases" runat="server" Text=""></asp:Label></div>
                     <div class="desc">Total Purchases</div>
                  </div>
                  <a class="more" href="ListPurchase.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat blue">
                  <div class="visual">
                     <i class="icon-globe"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="LbSales" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Total Sales </div>
                  </div>
                  <a class="more" href="ListSales.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat red">
                  <div class="visual">
                     <i class="icon-bar-chart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="LbSalesReturns" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Sales Returns</div>
                  </div>
                  <a class="more" href="#">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
         </div>


     <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat red">
                  <div class="visual">
                    <i class="icon-female"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">                           
                        Supplier
                     </div>
                  </div>
                  <a class="more" href="ListSupplier.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat green">
                  <div class="visual">
                     <i class="icon-shopping-cart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label3" runat="server" Text=""></asp:Label></div>
                     <div class="desc">Total Purchases</div>
                  </div>
                  <a class="more" href="ListPurchase.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat blue">
                  <div class="visual">
                     <i class="icon-globe"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Total Sales </div>
                  </div>
                  <a class="more" href="ListSales.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat yellow">
                  <div class="visual">
                     <i class="icon-bar-chart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Sales Returns</div>
                  </div>
                  <a class="more" href="#">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
         </div>


     <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat purple">
                  <div class="visual">
                    <i class="icon-female"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                         <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">                           
                        Supplier
                     </div>
                  </div>
                  <a class="more" href="ListSupplier.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat yellow">
                  <div class="visual">
                     <i class="icon-shopping-cart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label7" runat="server" Text=""></asp:Label></div>
                     <div class="desc">Total Purchases</div>
                  </div>
                  <a class="more" href="ListPurchase.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat blue">
                  <div class="visual">
                     <i class="icon-globe"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Total Sales </div>
                  </div>
                  <a class="more" href="ListSales.aspx">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
               <div class="dashboard-stat yellow">
                  <div class="visual">
                     <i class="icon-bar-chart"></i>
                  </div>
                  <div class="details">
                     <div class="number">
                          <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="desc">Sales Returns</div>
                  </div>
                  <a class="more" href="#">
                  View more <i class="m-icon-swapright m-icon-white"></i>
                  </a>                 
               </div>
            </div>
         </div>
</asp:Content>
