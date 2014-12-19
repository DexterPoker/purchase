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

public partial class itemsManage : System.Web.UI.Page
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
        txbnum.Text = GridView1.SelectedDataKey.Values[0].ToString();
        items item = new items();
        item = items.Findnum(txbnum.Text);
        if (item == null)
        {
            string mess = "选择数据出错！！";
            string url = "itemsManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            txbdescription.Text = item.description;
            txbtype.Text = item.type;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        btnaddpost.Visible = true;
        txbnum.ReadOnly = false;
        txbnum.Enabled = true;
        lblnum.Visible = false;
        txbnum.Visible = false;
        txbnum.Text = "";
        txbdescription.Text = "";
        txbtype.Text = "";
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txbnum.Text != "")
        {
            Panel1.Visible = true;
            btnupdatepost.Visible = true;
            txbnum.ReadOnly = true;
            txbnum.Enabled = false;
            txbnum.Visible = true;
            lblnum.Visible = true;
        }
        else
        {
            Response.Write(message.sendMessage("请先选择要修改的记录！！！"));
        }
    }
    protected void btnaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        items item = new items();
        item.num = txbnum.Text;
        item.description = txbdescription.Text;
        item.type = txbtype.Text;
        if ( txbdescription.Text == "" || txbtype.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            items.InsertItems(item);
            mess = "新物品添加成功！！！";
            string url = "itemsManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
    }
    protected void btnupdatepost_Click(object sender, EventArgs e)
    {
        string mess, url;
        items item = new items();
        item.num  = txbnum.Text;
        item.description = txbdescription.Text;
        item.type = txbtype.Text;
        if ( txbdescription.Text == "" || txbtype.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            items.UpdateItems(item);
            mess = "物品信息修改成功！！！";
            url = "itemsManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string mess, url;
        if (txbnum.Text != "")
        {
            if (items.FindDownnum(txbnum.Text))
            {
                mess = "该物品跟库存物品有关联不能直接删除！！";
                Response.Write(message.sendMessage(mess));
            }
            else
            {
                items.DeleteItems(txbnum.Text);
                mess = "物品删除成功！！！";
                url = "itemsManage.aspx";
                Response.Write(message.MessageAndUrl(mess, url));
            }
        }
        else
        {
            mess = "请先选择要删除的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnGridshow_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView2.Visible = false;
        btnGridshow.Visible = false;
        txbselect.Text = "";
    }
    protected void btnselects_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(db.constring());
        con.Open();
        string sql = "select * from mtl_items_all where item_num like '%" + txbselect.Text + "%'or item_description like '%" + txbselect.Text + "%' or item_type like '%" + txbselect.Text + "%'";
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
