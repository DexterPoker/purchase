<%@ Page Language="C#" AutoEventWireup="true" CodeFile="repertoryManage.aspx.cs" Inherits="repertotyManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title>采购系统——库存信息</title>
		
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
  
	<body><form id="idpersonManage" runat="server"><div id="body-wrapper"> <!-- Wrapper for the radial gradient background -->
		
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
					<a href="#" class="nav-top-item current">
						信息维护
					</a>
					<ul>
						<li><a href="personManage.aspx">员工信息维护</a></li>
						<li><a href="vendersManage.aspx">供应商信息维护</a></li>
						<li><a href="itemsManage.aspx">物品信息维护</a></li>
						<li><a href="repertoryManage.aspx" class="current">库存信息维护</a></li>
						<li><a href="require.aspx">需求信息维护</a></li>
						<li><a href="order.aspx">订单信息维护</a></li>
					</ul>
				</li>
				
				<li>
					<a href="#" class="nav-top-item">
						个人信息
					</a>
					<ul>
						<li>
						<a href="changepwd.aspx">密码修改</a>
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
			
			<!-- Page Head -->
						<h2>Welcome <asp:Label ID="lblusername" runat="server"></asp:Label></h2>   
			<asp:Button ID="Button1" runat="server" OnClick="navbtncancel_Click" Text="&#27880;&#38144;" BackColor="Transparent" BorderColor="Transparent" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" DataKeyNames="sub_inventory" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="sub_inventory" HeaderText="sub_inventory" ReadOnly="True"
                        SortExpression="sub_inventory" />
                    <asp:BoundField DataField="item_num" HeaderText="item_num" SortExpression="item_num" />
                    <asp:BoundField DataField="qty" HeaderText="qty" SortExpression="qty" />
                </Columns>
            </asp:GridView>
            &nbsp;&nbsp;
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [MTL_ON_HAND]">
            </asp:SqlDataSource>
            <asp:Button ID="btnadd" runat="server" Text="&#28155;&#21152;&#24211;&#23384;" OnClick="btnadd_Click" />
            <asp:Button ID="btnupdate" runat="server" Text="&#20462;&#25913;&#24211;&#23384;" OnClick="btnupdate_Click" />
            <asp:Button ID="btndelete" runat="server" Text="&#21024;&#38500;&#24211;&#23384;" OnClick="btndelete_Click" />
            <asp:Button ID="btnbaobiao" runat="server" Text="&#29983;&#25104;&#25253;&#34920;" OnClick="btnbaobiao_Click" />
            <asp:Button ID="btnGridshow" runat="server" Text="&#26174;&#31034;&#20840;&#37096;&#25968;&#25454;" OnClick="btnGridshow_Click" />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <p>
                <asp:TextBox ID="txbselect" runat="server"></asp:TextBox>
                <asp:Button ID="btnselect" runat="server" Text="&#26597;&#35810;" OnClick="btnselect_Click" />
            </p>
            <div>
                <p></p><p></p><p></p>
                <asp:Panel ID="Panel1" runat="server" Height="259px" Width="540px" >
                <p>
                    <asp:Label ID="Label1" runat="server" Text="库存名称："></asp:Label>
                <asp:TextBox ID="txbname" runat="server"></asp:TextBox>
                </p>
                <p>
                <label>
                    &#24211;&#23384;&#32534;&#21495;&#65306;&nbsp;&nbsp;<asp:TextBox ID="txbnum" runat="server"></asp:TextBox></label>
                </p>
                <p>
                <label>
                    &#24211;&#23384;&#25968;&#37327;&#65306;&nbsp;<asp:TextBox ID="txbqty" runat="server"></asp:TextBox></label> 
                </p>
                <p>
                    <asp:Button ID="btnaddpost" runat="server" Text="&#28155;&#21152;&#25552;&#20132;" OnClick="btnaddpost_Click"  />
                    <asp:Button ID="btnupdatepost" runat="server" Text="&#20462;&#25913;&#25552;&#20132;" OnClick="btnupdatepost_Click" />
                </p>
                </asp:Panel>
		    </div>
            </div> 
		    
	</div></form></body>
</html>
