using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class vendersManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        btnaddpost.Visible = false;
        btnupdatepost.Visible = false;
        btnGridshow.Visible = false;
        person per = new person();
        per = (person)Session["person"];
        if (per == null)
        {
            string mess = "您还没有登录！！请先登录！！";
            string url = "login.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
            lblusername.Text = per.name;
    }

    protected void navbtncancel_Click(object sender, EventArgs e)
    {
        this.Session.Clear();
        Response.Redirect("login.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txbcode.Text = GridView1.SelectedDataKey.Values[0].ToString();
        vender ven = new vender();
        ven = vender.FindCode(txbcode.Text);
        if (ven == null)
        {
            string mess = "选择数据出错！！";
            string url = "vendersManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            txbname.Text = ven.vender_name;
            txbaddress.Text = ven.address;
            txbcontact.Text = ven.contact;
            txbphone.Text = ven.phone;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        btnaddpost.Visible = true;
        txbcode.ReadOnly = false;
        txbcode.Enabled = true;
        txbcode.Visible = false;
        Label1.Visible = false;
        txbcode.Text = "";
        txbname.Text = "";
        txbaddress.Text = "";
        txbcontact.Text = "";
        txbphone.Text = "";
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txbcode.Text != "")
        {
            Panel1.Visible = true;
            btnupdatepost.Visible = true;
            txbcode.ReadOnly = true;
            txbcode.Enabled = false;
            txbcode.Visible = true;
            Label1.Visible = true;
        }
        else
        {
            Response.Write(message.sendMessage("请先选择要修改的记录！！！"));
        }
    }
    protected void btnaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        vender ven = new vender();
        ven.vender_code = txbcode.Text;
        ven.vender_name = txbname.Text;
        ven.address = txbaddress.Text;
        ven.contact = txbcontact.Text;
        ven.phone = txbphone.Text;
        if ( txbname.Text == "" || txbaddress.Text == "" || txbcontact.Text == "" || txbphone.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbphone.Text);
                vender.InsertVender(ven);
                mess = "新供应商添加成功！！！";
                string url = "vendersManage.aspx";
                Response.Write(message.MessageAndUrl(mess, url));
            }
            catch 
            {
                mess = "电话号码只能是数字";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string mess,url;
        if (txbcode.Text != "")
        {
            if (vender.FindUnderCode(txbcode.Text))
            {
                mess = "该供货商跟部分采购单有关联不能直接删除！！";
                Response.Write(message.sendMessage(mess));
            }
            else
            {
                vender.DeleteVender(txbcode.Text);
                mess = "供货商删除成功！！！";
                url = "vendersManage.aspx";
                Response.Write(message.MessageAndUrl(mess, url));
            }
        }
        else
        {
            mess = "请先选择要删除的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnupdatepost_Click(object sender, EventArgs e)
    {
        string mess,url;
        vender ven = new vender();
        ven.vender_code = txbcode.Text;
        ven.vender_name = txbname.Text;
        ven.address = txbaddress.Text;
        ven.contact = txbcontact.Text;
        ven.phone = txbphone.Text;
        if (txbname.Text == "" || txbaddress.Text == "" || txbcontact.Text == "" || txbphone.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbphone.Text);
                vender.UpdateVender(ven);
                mess = "供应商信息修改成功！！！";
                url = "vendersManage.aspx";
                Response.Write(message.MessageAndUrl(mess, url));
            }
            catch
            {
                mess = "电话号码只能是数字！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnGridshow_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        btnGridshow.Visible = false;
        txbselect.Text = "";
        GridView2.Visible = false;
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(db.constring());
        con.Open();
        string sql = "select * from po_venders_all where vender_code like '%" + txbselect.Text + "%'or vender_name like '%" + txbselect.Text + "%' or address like '%" + txbselect.Text + "%' or contact like '%" + txbselect.Text + "%' or phone like '%" + txbselect.Text + "%'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        da.SelectCommand = cmd;
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
        GridView1.Visible = false;
        btnGridshow.Visible = true;
        con.Close();
    }
}
