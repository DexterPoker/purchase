<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personManage.aspx.cs" Inherits="personManage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title>采购系统——人员信息</title>
		
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
						<li><a href="personManage.aspx" class="current">员工信息维护</a></li>
						<li><a href="vendersManage.aspx">供应商信息维护</a></li>
						<li><a href="itemsManage.aspx">物品信息维护</a></li>
						<li><a href="repertoryManage.aspx">库存信息维护</a></li>
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
				
			</ul> <!-- End #main-nav --> <!-- End #messages -->
			
		</div></div> <!-- End #sidebar -->
		
		<div id="main-content"> <!-- Main Content Section with everything -->
			
			<noscript> <!-- Show a notification if the user has disabled javascript -->
			</noscript>
			
			<!-- Page Head --><h2>Welcome <asp:Label ID="lblusername" runat="server"></asp:Label></h2>   
			<asp:Button ID="Button1" runat="server" OnClick="navbtncancel_Click" Text="&#27880;&#38144;" BackColor="Transparent" BorderColor="Transparent" />
            &nbsp;&nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="emp_num" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="emp_num" HeaderText="emp_num" InsertVisible="False" ReadOnly="True"
                        SortExpression="emp_num" />
                    <asp:BoundField DataField="hr_emp_num" HeaderText="hr_emp_num" SortExpression="hr_emp_num" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="job" HeaderText="job" SortExpression="job" />
                    <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                </Columns>
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [HR_PERSON]">
            </asp:SqlDataSource>
            <asp:Button ID="btnadd" runat="server" Text="&#20154;&#21592;&#28155;&#21152;" OnClick="btnadd_Click" />
            <asp:Button ID="btnupdate" runat="server" Text="&#20449;&#24687;&#20462;&#25913;" OnClick="btnupdate_Click" />
            <asp:Button ID="btndelete" runat="server" Text="&#21024;&#38500;&#20154;&#21592;" OnClick="btndelete_Click" />
            <asp:Button ID="btnGridshow" runat="server" Text="&#23637;&#31034;&#20840;&#37096;&#25968;&#25454;" OnClick="btnGridshow_Click" />
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
                    <asp:Label ID="lblid" runat="server" Text="员工号："></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txbid" runat="server"></asp:TextBox>
                </p>
                <p>
                <label>上级员工号：&nbsp;<asp:TextBox ID="txbupid" runat="server"></asp:TextBox></label>
                    </p>
                <p>
                <label>姓名： &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txbname" runat="server"></asp:TextBox></label>&nbsp;
                </p>
                <p>
                <label>职称： &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txbjob" runat="server"></asp:TextBox></label> 
                </p>
                <p>
                <label>部门： &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                 <asp:TextBox ID="txbdepartment" runat="server"></asp:TextBox></label>
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
