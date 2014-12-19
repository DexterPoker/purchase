<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title>采购系统——登录</title>
		
		<!--                       CSS                       -->
	  
		<!-- Reset Stylesheet -->
		<link rel="stylesheet" href="resources/css/reset.css" type="text/css" media="screen" />
	  
		<!-- Main Stylesheet -->
		<link rel="stylesheet" href="resources/css/style.css" type="text/css" media="screen" />
		
		<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
		<link rel="stylesheet" href="resources/css/invalid.css" type="text/css" media="screen" />	
		
		
	</head>
  
	<body id="login">
		
		<div id="login-wrapper" class="png_bg">
			<div id="login-top">
			
				<img id="logo" src="resources/images/logo.png" alt=" logo" />
			</div> <!-- End #logn-top -->
			
			<div id="login-content">
				
				<form id="form1" runat="server">
					
					<p>
						<label>&#21592;&#24037;&#21495;&#65306;</label>
                        <asp:TextBox ID="txbid" runat="server"></asp:TextBox></p>
					<div class="clear"></div>
					<p>
						<label>
                            &#23494;&#30721;&#65306;</label>
                        <asp:TextBox ID="txbpwd" runat="server"></asp:TextBox></p>
					<div class="clear"></div>
					<p id="remember-password">
                        &nbsp;</p>
					<div class="clear"></div>
					<p>
					<asp:Button ID="btnlogin" runat="server" Text="登录" Width="50" BackColor="Lime" OnClick="btnlogin_Click" />
					</p>
					
				</form>
			</div> <!-- End #login-content -->
			
		</div> <!-- End #login-wrapper -->
		
  </body>
</html>
