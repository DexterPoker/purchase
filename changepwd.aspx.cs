using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class changepwd : System.Web.UI.Page
{
    person per = new person();
    protected void Page_Load(object sender, EventArgs e)
    {
        txbpwd0.TextMode = TextBoxMode.Password;
        txbpwd1.TextMode = TextBoxMode.Password;
        txbpwd2.TextMode = TextBoxMode.Password;
        per = (person)Session["person"];
        if (per == null)
        {
            string mess = "您还有登录！！请先登录！！";
            string url = "login.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            lblusername.Text = per.name;
            txbid.Text = per.emp_num;
        }
    }
    protected void navbtncancel_Click(object sender, EventArgs e)
    {
        this.Session.Clear();
        Response.Redirect("login.aspx");
    }
    protected void btnchangewpd_Click(object sender, EventArgs e)
    {
        string mess;
        if (txbpwd0.Text == "" || txbpwd1.Text == "" || txbpwd2.Text == "")
        {
            mess = "请将密码填写完整！！";
            Response.Write(message.goBack(mess));
        }
        if (txbpwd2.Text != txbpwd1.Text)
        {
            mess = "两次密码不一致！！！";
            Response.Write(message.goBack(mess));
        }
        else if (per.password!=txbpwd0.Text)
        {
            mess = "原密码错误！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            per.password = txbpwd1.Text;
            person.UpdatePassword(per);
            mess = "密码修改成功！！！";
            string url = "index.aspx";
            Response.Write(message.MessageAndUrl(mess,url));
        }
    }
}
