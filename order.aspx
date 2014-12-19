<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1"  runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title>采购系统——采购订单</title>
		
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
  
	<body><form id="form1" runat="server"><div id="body-wrapper"> <!-- Wrapper for the radial gradient background -->
		
		<div id="sidebar"><div id="sidebar-wrapper"> <!-- Sidebar with logo and menu -->
			
		  
			<!-- Logo (221px wide) -->
			<a href="#"><img id="logo" src="resources/images/logo.png" alt="logo" /></a>
		  
			<!-- Sidebar Profile links -->
			       
			
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
						<li><a href="repertoryManage.aspx">库存信息维护</a></li>
						<li><a href="require.aspx">需求信息维护</a></li>
						<li><a href="order.aspx" class="current">订单信息维护</a></li>
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
			<p></p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="po_header_id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="po_header_id" HeaderText="po_header_id" InsertVisible="False"
                        ReadOnly="True" SortExpression="po_header_id" />
                    <asp:BoundField DataField="po_number" HeaderText="po_number" SortExpression="po_number" />
                    <asp:BoundField DataField="po_type" HeaderText="po_type" SortExpression="po_type" />
                    <asp:BoundField DataField="vender_code" HeaderText="vender_code" SortExpression="vender_code" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT po_header_id, po_number, po_type, vender_code, status FROM PO_HEADERS_ALL WHERE (po_type = '采购订单')">
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="po_line_id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="po_line_id" HeaderText="po_line_id" InsertVisible="False"
                        ReadOnly="True" SortExpression="po_line_id" />
                    <asp:BoundField DataField="po_header_id" HeaderText="po_header_id" SortExpression="po_header_id" />
                    <asp:BoundField DataField="item_num" HeaderText="item_num" SortExpression="item_num" />
                    <asp:BoundField DataField="line_num" HeaderText="line_num" SortExpression="line_num" />
                    <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                    <asp:BoundField DataField="received_quantity" HeaderText="received_quantity" SortExpression="received_quantity" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT PO_LINES_ALL.* FROM PO_LINES_ALL">
            </asp:SqlDataSource>
            <p></p>
            <asp:Button ID="btnheadadd" runat="server" Text="&#28155;&#21152;&#35746;&#21333;&#34920;&#22836;" OnClick="btnheadadd_Click" />
            <asp:Button ID="btnheadupdate" runat="server" Text="&#20462;&#25913;&#35746;&#21333;&#34920;&#22836;" OnClick="btnheadupdate_Click" />
            <asp:Button ID="btnlineadd" runat="server" Text="&#28155;&#21152;&#35746;&#21333;&#20855;&#20307;&#34892;" OnClick="btnlineadd_Click" />
            <asp:Button ID="btnlineupdate" runat="server" Text="&#20462;&#25913;&#35746;&#21333;&#20855;&#20307;&#34892;" OnClick="btnlineupdate_Click" />
            <asp:Button ID="btnlinedelete" runat="server" Text="&#21024;&#38500;&#35746;&#21333;&#20855;&#20307;&#34892;" OnClick="btnlinedelete_Click" />
            <asp:Button ID="btnshowhead" runat="server" Text="&#26174;&#31034;&#35746;&#21333;&#34920;&#22836;" OnClick="btnshowhead_Click" />
            <asp:Button ID="btnshowlines" runat="server" Text="&#26174;&#31034;&#35746;&#21333;&#20855;&#20307;&#34892;" OnClick="btnshowlines_Click" />
            <asp:Button ID="btnbaobiao" runat="server" Text="&#29983;&#25104;&#35746;&#21333;&#25253;&#34920;" OnClick="btnbaobiao_Click"  />
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
            <p>
                <asp:TextBox ID="txbselect" runat="server"></asp:TextBox>
                <asp:Button ID="btnselecthead" runat="server" Text="&#26597;&#35810;&#35746;&#21333;&#34920;&#22836;" OnClick="btnselecthead_Click" />
                <asp:Button ID="btnselectline" runat="server" Text="&#26597;&#35810;&#35746;&#21333;&#20855;&#20307;&#34892;" OnClick="btnselectline_Click" />
            </p>
            <asp:Panel ID="Panel1" runat="server" Width="400" Height="250">
                <p>
                    <asp:Label ID="Label1" runat="server" Text="序列号："></asp:Label> &nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="txbheadid" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </p>
                <p>
                    <label>&#35746;&#21333;&#32534;&#21495;&#65306;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txbnumber" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label title="&#31867;&#22411;&#22788;&#21482;&#33021;&#35782;&#21035;'&#37319;&#36141;&#35745;&#21010;'&#21644;'&#37319;&#36141;&#35746;&#21333;'">&#31867;&#22411;&#65306; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="txbtype" runat="server" Enabled="False" ReadOnly="True">order</asp:TextBox></label>
                </p>
                <p>
                    <label>&#20379;&#24212;&#21830;&#21495;&#65306;&nbsp; &nbsp;
                    <asp:TextBox ID="txbvendercode" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>&#29366;&#24577;&#65306; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txbstatus" runat="server"></asp:TextBox></label>
                    </p>
                <p>
                    <asp:Button ID="btnheadaddpost" runat="server" Text="&#28155;&#21152;&#25552;&#20132;" OnClick="btnheadaddpost_Click"  />
                    <asp:Button ID="btnheadupdatepost" runat="server" Text="&#20462;&#25913;&#25552;&#20132;" OnClick="btnheadupdatepost_Click" />
                </p>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Width="400" Height="350">
                <p>
                    <asp:Label ID="Label2" runat="server" Text="&#35746;&#21333;&#34892;&#21495;&#65306;"></asp:Label>&nbsp;
                    &nbsp;<asp:TextBox ID="txblineid" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label>&#35746;&#21333;&#22836;&#21495;&#65306;
                    <asp:TextBox ID="txbheadid2" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>&#29289;&#21697;&#32534;&#21495;&#65306;&nbsp;
                    <asp:TextBox ID="txbitemnum" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>&#34892;&#21495;&#65306; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="txblinenum" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>&#38656;&#27714;&#25968;&#37327;&#65306;
                    <asp:TextBox ID="txbquantity" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>
                        &#25509;&#25910;&#25968;&#37327;&#65306;
                    <asp:TextBox ID="txbrequantity" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <label>&#21333;&#20215;&#65306; &nbsp; &nbsp; &nbsp;
                    &nbsp;
                    <asp:TextBox ID="txbprice" runat="server"></asp:TextBox></label>
                </p>
                <p>
                    <asp:Button ID="btnlineaddpost" runat="server" Text="&#28155;&#21152;&#25552;&#20132;" OnClick="btnlineaddpost_Click" />
                    <asp:Button ID="btnlineupdatepost" runat="server" Text="&#20462;&#25913;&#25552;&#20132;" OnClick="btnlineupdatepost_Click" />
                </p>
                </asp:Panel>
			</div>
	</div></form></body>
</html>
