using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Reporting.WebForms;
using System.Web.UI.HtmlControls;

public partial class orderReport : System.Web.UI.Page
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
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            int.Parse(TextBox1.Text);
            ReportParameter[] p = new ReportParameter[1];
            p[0] = new ReportParameter("number", TextBox1.Text);
            this.ReportViewer1.LocalReport.SetParameters(p);
            this.ReportViewer1.ShowParameterPrompts = false;
        }
        catch
        {
            string mess = "请输入正确的数字！！！";
            Response.Write(message.goBack(mess));
        }
    }
}
