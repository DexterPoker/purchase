using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class reperReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        person per = new person();
        per = (person)Session["person"];
        if (per == null)
        {
            string mess = "您还没有登录！！请先登录！！";
            string url = "login.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
    }
}
