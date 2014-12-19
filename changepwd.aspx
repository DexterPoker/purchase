<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="changepwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title>采购系统——个人密码修改</title>
		
		<!--                       CSS                       -->
	  
		<!-- Reset Stylesheet -->
		<link rel="stylesheet" href="resources/css/reset.css" type="text/css" media="screen" />
	  
		<!-- Main Stylesheet -->
		<link rel="stylesheet" href="resources/css/style.css" type="text/css" media="screen" />
		
		<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
		<link rel="stylesheet" href="resources/css/invalid.css" type="text/css" media="screen" />	
		
		
		<!--                       Javascripts                       -->
  
		<!-- jQuery -->
		<script type="text/javascript" src="resources/scripts/jquery-1.3.2.min.js"></script>
		
		<!-- jQuery Configuration -->
		<script type="text/javascript" src="resources/scripts/simpla.jquery.configuration.js"></script>
		
		<!-- Facebox jQuery Plugin -->
		<script type="text/javascript" src="resources/scripts/facebox.js"></script>
		
		<!-- jQuery WYSIWYG Plugin -->
		<script type="text/javascript" src="resources/scripts/jquery.wysiwyg.js"></script>
		
		<!-- jQuery Datepicker Plugin -->
		<script type="text/javascript" src="resources/scripts/jquery.datePicker.js"></script>
		<script type="text/javascript" src="resources/scripts/jquery.date.js"></script>
		
		
	</head>
  
	<body><form id="formchangepwd" runat="server">
	<div id="body-wrapper"> <!-- Wrapper for the radial gradient background -->
		
		<div id="sidebar"><div id="sidebar-wrapper"> <!-- Sidebar with logo and menu -->
			
		  
			<!-- Logo (221px wide) -->
			<a href="#"><img id="logo" src="resources/images/logo.png" alt="logo" /></a>
		  
			       
			
			<ul id="main-nav">  <!-- Accordion Menu -->
				
				<li>
					<a href="index.aspx" class="nav-top-item no-submenu"> <!-- Add the class "no-submenu" to menu items with no sub menu -->
						主页
					</a>       
				</li>
				
				<li>
					<a href="#" class="nav-top-item">
						信息维护
					</a>
					<ul>
						<li><a href="personManage.aspx">员工信息维护</a></li>
						<li><a href="vendersManage.aspx">供应商信息维护</a></li>
						<li><a href="itemsManage.aspx">物品信息维护</a></li>
						<li><a href="repertoryManage.aspx">库存信息维护</a></li>
						<li><a href="require.aspx">需求信息维护</a></li>
						<li><a href="order.aspx">订单信息维护</a></li>
					</ul>
				</li>
				
				<li>
					<a href="#" class="nav-top-item current">
						个人信息
					</a>
					<ul>
						<li>
						<a href="changepwd.aspx" class="current">密码修改</a>
                            </li>
						<li>
                            <asp:Button ID="navbtncancel" runat="server" OnClick="navbtncancel_Click" Text="&#27880;&#38144;" BackColor="Transparent" BorderColor="Transparent" ForeColor="White" /></li>
					</ul>
				</li>      
				
			</ul><!-- End #main-nav --> <!-- End #messages -->
			
		</div></div> <!-- End #sidebar -->
		
		<div id="main-content"> <!-- Main Content Section with everything -->
			
			<noscript> <!-- Show a notification if the user has disabled javascript -->
			</noscript>
			
			<h2>Welcome <asp:Label ID="lblusername" runat="server"></asp:Label></h2>   
			<asp:Button ID="Button1" runat="server" OnClick="navbtncancel_Click" Text="&#27880;&#38144;" BackColor="Transparent" BorderColor="Transparent" />
			
			<div>
			<p>
			<label>&#21592;&#24037;&#21495;&#65306;</label>
			<asp:TextBox ID="txbid" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
			</p>
			<p>
			<label>
                &#21407;&#23494;&#30721;&#65306;</label>
                <asp:TextBox ID="txbpwd0" runat="server"></asp:TextBox>
			</p>
			<p>
			<label>
                &#26032;&#23494;&#30721;&#65306;</label>
                <asp:TextBox ID="txbpwd1" runat="server"></asp:TextBox>
			</p>
			<p>
			<label>
                &#23494;&#30721;&#30830;&#35748;&#65306;</label>
                <asp:TextBox ID="txbpwd2" runat="server"></asp:TextBox>
            </p>
            <p> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp;&nbsp;
                <asp:Button ID="btnchangewpd" runat="server" Text="&#25552;&#20132;" OnClick="btnchangewpd_Click" /></p>
			</div>
			
		</div> <!-- End #main-content -->
		
	</div></form></body>
</html>
