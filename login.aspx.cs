using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txbpwd.TextMode = TextBoxMode.Password;
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string mess, url;
        if (txbid.Text == "" || txbpwd.Text == "")
        {
            mess = "员工号或密码不能为空！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbid.Text);
                person findper = new person();
                findper = person.FindEmp_num(txbid.Text);
                if (findper == null)
                {
                    mess = "员工号不存在！！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                    if (findper.password != txbpwd.Text)
                    {
                        mess = "密码错误！！！";
                        Response.Write(message.goBack(mess));
                    }
                    else
                    {
                        Session["person"] = findper;
                        mess = "登录成功！！！";
                        url = "index.aspx";
                        Response.Write(message.MessageAndUrl(mess, url));
                    }
                }
            }
            catch
            {
                mess = "员工号只能是数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
}
