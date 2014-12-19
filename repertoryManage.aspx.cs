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

public partial class repertotyManage : System.Web.UI.Page
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
        txbname.Text = GridView1.SelectedDataKey.Values[0].ToString();
        repertory reper = new repertory();
        reper = repertory.Findname(txbname.Text);
        if (reper == null)
        {
            string mess = "选择数据出错！！";
            string url = "repertoryManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            txbnum.Text = reper.num;
            txbqty.Text = reper.qty;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        btnaddpost.Visible = true;
        txbname.ReadOnly = false;
        txbname.Enabled = true;
        Label1.Visible = false;
        txbname.Text = "";
        txbnum.Text = "";
        txbqty.Text = "";
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txbname.Text != "")
        {
            Panel1.Visible = true;
            btnupdatepost.Visible = true;
            txbname.ReadOnly = true;
            txbname.Enabled = false;
            Label1.Visible = true;
        }
        else
        {
            Response.Write(message.sendMessage("请先选择要修改的记录！！！"));
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string mess, url;
        if (txbname.Text != "")
        {
            repertory.DeleteRepertory(txbname.Text);
            mess = "库存删除成功！！！";
            url = "itemsManage.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            mess = "请先选择要删除的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        repertory reper = new repertory();
        reper.name = txbname.Text;
        reper.num = txbnum.Text;
        reper.qty = txbqty.Text;
        if (txbname.Text == "" || txbnum.Text == "" || txbqty.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbnum.Text);
                repertory findreper = new repertory();
                findreper = repertory.Findname(txbname.Text);
                if (findreper != null)
                {
                    mess = "库存名称已经存在！！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                    if (repertory.FindUpnum(txbnum.Text))
                    {
                        if (repertory.Findnum(txbnum.Text) == false)
                        {
                            repertory.InsertRepertory(reper);
                            mess = "新库存添加成功！！！";
                            string url = "repertoryManage.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else
                        {
                            mess = "该物品编号已经在看库存中！！！";
                            Response.Write(message.goBack(mess));
                        }
                    }
                    else
                    {
                        mess = "该编号的物品不存在不能入库！！！";
                        Response.Write(message.goBack(mess));
                    }
                }
            }
            catch
            {
                mess = "物品编号只能是数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnupdatepost_Click(object sender, EventArgs e)
    {
        string mess;
        repertory reper = new repertory();
        reper.name = txbname.Text;
        reper.num = txbnum.Text;
        reper.qty = txbqty.Text;
        if (txbname.Text == "" || txbnum.Text == "" || txbqty.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbnum.Text);
                if (repertory.FindUpnum(txbnum.Text))
                {
                    if (repertory.Findnum(txbnum.Text))
                    {
                        repertory.UpdateRepertory(reper);
                        mess = "库存信息修改成功！！！";
                        string url = "repertoryManage.aspx";
                        Response.Write(message.MessageAndUrl(mess, url));
                    }
                    else
                    {
                        mess = "该物品编号已经在看库存中！！！";
                        Response.Write(message.goBack(mess));
                    }
                }
                else
                {
                    mess = "该编号的物品不存在不能入库！！！";
                    Response.Write(message.goBack(mess));
                }
            }
            catch
            {
                mess = "物品编号只能是数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnbaobiao_Click(object sender, EventArgs e)
    {
        Response.Redirect("reperReport.aspx");
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
        string sql = "select * from mtl_on_hand where sub_inventory like '%" + txbselect.Text + "%'or item_num like '%" + txbselect.Text + "%' or qty like '%" + txbselect.Text + "%'";
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
