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
/// db 的摘要说明
/// </summary>
public class db
{
	public db()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string constring() {
        return @"Provider=SQLOLEDB;Data Source=226-118\YXY;Integrated Security=SSPI;Initial Catalog=Purchase";
    }
}
