using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// message 的摘要说明
/// </summary>
public class message
{
	public message()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string sendMessage(string message) 
    {
        string StrScript;
        StrScript = ("<script language=javascript>");
        StrScript += ("alert('" + message + "');");
        StrScript += ("</script>");
        return StrScript;
    }
    public static string MessageAndUrl(string message, string url)
    {
        string StrScript;
        StrScript = ("<script language=javascript>");
        StrScript += ("alert('" + message + "');");
        StrScript += ("window.location='" + url + "';");
        StrScript += ("</script>");
        return StrScript;
    }
    public static string goBack(string message) 
    {
        string StrScript;
        StrScript = ("<script language=javascript>");
        StrScript += ("alert('" + message + "');");
        StrScript += ("history.go(-1);");
        StrScript += ("</script>");
        return StrScript;
    }
}
