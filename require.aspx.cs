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

public partial class require : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        btnheadaddpost.Visible = false;
        btnheadupdatepost.Visible = false;
        GridView2.Visible = false;
        Panel2.Visible = false;
        btnlineaddpost.Visible = false;
        btnlineupdatepost.Visible = false;
        btnlineadd.Visible = false;
        btnlineupdate.Visible = false;
        btnshowhead.Visible = false;
        btnlinedelete.Visible = false;
        /*
        person per = new person();
        per = (person)Session["person"];
        if (per == null)
        {
            string mess = "您还没有登录！！请先登录！！";
            string url = "login.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
            lblusername.Text = per.name;*/
    }
    protected void navbtncancel_Click(object sender, EventArgs e)
    {
        this.Session.Clear();
        Response.Redirect("login.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txbheadid.Text = GridView1.SelectedDataKey.Values[0].ToString();
        header head = new header();
        head = header.FindHeader(txbheadid.Text);
        if (head == null)
        {
            string mess = "选择数据出错！！";
            string url = "require.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            txbnumber.Text = head.number;
            txbtype.Text = head.type;
            txbvendercode.Text = head.vender_code;
            txbstatus.Text = head.status;
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txblineid.Text = GridView2.SelectedDataKey.Values[0].ToString();
        liness line = new liness();
        line = liness.FindLines(txblineid.Text);
        if (line == null)
        {
            string mess = "选择数据出错！！";
            string url = "require.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {

            GridView2.Visible = true;
            btnlineadd.Visible = true;
            btnlineupdate.Visible = true;
            btnlinedelete.Visible = true;
            btnshowhead.Visible = true;
            txbheadid2.Text = line.head_id;
            txbitemnum.Text = line.num;
            txblinenum.Text = line.code;
            txbquantity.Text = line.quantity;
            txbprice.Text = line.price;
        }
    }
    protected void btnheadadd_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        btnheadaddpost.Visible = true;
        txbheadid.Visible = false;
        txbstatus.ReadOnly = true;
        txbstatus.Enabled = false;
        Label1.Visible = false;
        txbnumber.Text = "";
        txbvendercode.Text = "";
        txbstatus.Text = "1";
    }
    protected void btnheadupdate_Click(object sender, EventArgs e)
    {
        if (txbheadid.Text != "")
        {
            Panel1.Visible = true;
            btnheadupdatepost.Visible = true;
            txbheadid.Visible = true;
            txbstatus.Enabled = true;
            txbstatus.ReadOnly = false;
            Label1.Visible = true;
        }
        else
        {
            string mess = "请先选择要修改的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnlineadd_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        btnlineaddpost.Visible = true;
        txblineid.Visible = false;
        Label2.Visible = false;
        GridView2.Visible = true;
        btnlineadd.Visible = true;
        btnlineupdate.Visible = true;
        btnlinedelete.Visible = true;
        btnshowhead.Visible = true;
        txbheadid2.Text = "";
        txbitemnum.Text = "";
        txblinenum.Text = "";
        txbquantity.Text = "";
        txbprice.Text = "";
    }
    protected void btnlineupdate_Click(object sender, EventArgs e)
    {
        if (txblineid.Text != "")
        {
            Panel2.Visible = true;
            btnlineupdatepost.Visible = true;
            txblineid.Visible = true;
            txblineid.Enabled = false;
            txblineid.ReadOnly = true;
            Label2.Visible = true;

            GridView2.Visible = true;
            btnlineadd.Visible = true;
            btnlineupdate.Visible = true;
            btnlinedelete.Visible = true;
            btnshowhead.Visible = true;
        }
        else
        {
            string mess = "请先选择要修改的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnshowhead_Click(object sender, EventArgs e)
    {
        GridView2.Visible = false;
        GridView1.Visible = true;
        btnheadadd.Visible = true;
        btnheadupdate.Visible = true;
        btnlineadd.Visible = false;
        btnlineupdate.Visible = false;
        btnshowhead.Visible = false;
        btnshowlines.Visible = true;
        btnlinedelete.Visible = false;
        GridView3.Visible = false;
        txbselect.Text = "";
    }
    protected void btnshowlines_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = true;
        btnheadadd.Visible = false;
        btnheadupdate.Visible = false;
        btnlineadd.Visible = true;
        btnlineupdate.Visible = true;
        btnshowhead.Visible = true;
        btnshowlines.Visible = false;
        btnlinedelete.Visible = true;
        GridView3.Visible = false;
        txbselect.Text = "";
    }
    protected void btnheadaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        header head = new header();
        head.number = txbnumber.Text;
        head.type = txbtype.Text;
        head.vender_code = txbvendercode.Text;
        head.status = txbstatus.Text;
        if (txbnumber.Text == "" || txbtype.Text == "" || txbvendercode.Text == "" || txbstatus.Text == "")
        {
            mess = "请把信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbnumber.Text);
                int.Parse(txbvendercode.Text);
                if (header.FindUpVender(txbvendercode.Text) == false)
                {
                    mess = "找不到该编号的供应商！！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                    header.InsertHeader(head);
                    mess = "订单头添加成功！！！";
                    string url = "require.aspx";
                    Response.Write(message.MessageAndUrl(mess, url));
                }
            }
            catch
            {
                mess = "供应商号和订单编号只能填写数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnheadupdatepost_Click(object sender, EventArgs e)
    {
        string mess;
        header head = new header();
        head.header_id = txbheadid.Text;
        head.number = txbnumber.Text;
        head.type = txbtype.Text;
        head.vender_code = txbvendercode.Text;
        head.status = txbstatus.Text;
        if (txbnumber.Text == "" || txbtype.Text == "" || txbvendercode.Text == "" || txbstatus.Text == "")
        {
            mess = "请把信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbnumber.Text);
                int.Parse(txbvendercode.Text);
                if (header.FindUpVender(txbvendercode.Text) == false)
                {
                    mess = "找不到该编号的供应商！！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                        if (txbstatus.Text == "1" || txbstatus.Text == "2" || txbstatus.Text == "3" || txbstatus.Text == "4")
                        {
                            header.UpdateHeader(head);
                            mess = "订单头修改成功！！！";
                            string url = "require.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else
                        {
                            mess = "状态栏只能填1-4之间的值！！";
                            Response.Write(message.goBack(mess));
                        }
                }
            }
                catch
                {
                    mess = "供应商号和订单编号只能填写数字！！！";
                    Response.Write(message.goBack(mess));
                }
        }
    }
    protected void btnlineaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        liness line = new liness();
        line.head_id = txbheadid2.Text;
        line.code = txbitemnum.Text;
        line.num = txblinenum.Text;
        line.quantity = txbquantity.Text;
        line.requantity = "0";
        line.price = txbprice.Text;
        if (txbheadid2.Text == "" || txbitemnum.Text == "" || txblinenum.Text == "" || txbquantity.Text == ""  || txbprice.Text == "")
        {
            mess = "请将信息填写完整！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbheadid2.Text);
                int.Parse(txbitemnum.Text);
                int.Parse(txblinenum.Text);
                int.Parse(txbquantity.Text);
                float.Parse(txbprice.Text);
                if (liness.FindUpheader(txbheadid2.Text) == false)
                {
                    mess = "订单头编号不存在！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                    if (liness.FindUpItem(txbitemnum.Text) == false)
                    {
                        mess = "物品编号不存在！！";
                        Response.Write(message.goBack(mess));
                    }
                    else
                    {
                        liness.InsertLines(line);
                        mess = "需求行添加成功！！";
                        string url = "require.aspx";
                        Response.Write(message.MessageAndUrl(mess, url));
                    }
                }
            }
            catch
            {
                mess = "每个输入框中只能输入数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnlineupdatepost_Click(object sender, EventArgs e)
    {
        string mess;
        liness line = new liness();
        line.line_id = txblineid.Text;
        line.head_id = txbheadid2.Text;
        line.code = txbitemnum.Text;
        line.num = txblinenum.Text;
        line.quantity = txbquantity.Text;
        line.requantity = "0";
        line.price = txbprice.Text;
        if (txbheadid2.Text == "" || txbitemnum.Text == "" || txblinenum.Text == "" || txbquantity.Text == "" || txbprice.Text == "")
        {
            mess = "请将信息填写完整！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbheadid2.Text);
                int.Parse(txbitemnum.Text);
                int.Parse(txblinenum.Text);
                int.Parse(txbquantity.Text);
                float.Parse(txbprice.Text);
                if (liness.FindUpheader(txbheadid2.Text) == false)
                {
                    mess = "订单头编号不存在！！";
                    Response.Write(message.goBack(mess));
                }
                else
                {
                    if (liness.FindUpItem(txbitemnum.Text) == false)
                    {
                        mess = "物品编号不存在！！";
                        Response.Write(message.goBack(mess));
                    }
                    else
                    {
                        liness.UpdateLine(line);
                        mess = "需求行修改成功！！";
                        string url = "require.aspx";
                        Response.Write(message.MessageAndUrl(mess, url));
                    }
                }
            }
            catch
            {
                mess = "每个输入框中只能输入数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnlinedelete_Click(object sender, EventArgs e)
    {
        string mess, url;
        if (txblineid.Text != "")
        {
            liness.DeleteLine(txblineid.Text);
            mess = "需求行删除成功！！！";
            url = "require.aspx";
            Response.Write(message.MessageAndUrl(mess, url));
        }
        else
        {
            mess = "请先选择要删除的记录！！！";
            Response.Write(message.goBack(mess));
        }
    }
    protected void btnselecthead_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(db.constring());
        con.Open();
        string sql = "select * from po_headers_all where po_header_id like '%" + txbselect.Text + "%'or po_number like '%" + txbselect.Text + "%' or vender_code like '%" + txbselect.Text + "%'or status like '%" + txbselect.Text + "%'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        da.SelectCommand = cmd;
        da.Fill(ds);
        GridView3.DataSource = ds;
        GridView3.DataBind();
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = true;
        btnshowhead.Visible = true;
        btnshowlines.Visible = true;
        btnheadadd.Visible = false;
        btnheadupdate.Visible = false;
        btnlineadd.Visible = false;
        btnlineupdate.Visible = false;
        btnlinedelete.Visible = false;
        con.Close();
    }
    protected void btnselectline_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(db.constring());
        con.Open();
        string sql = "select * from po_lines_all where po_line_id like '%" + txbselect.Text + "%'or po_header_id like '%" + txbselect.Text + "%' or item_num like '%" + txbselect.Text + "%'or line_num like '%" + txbselect.Text + "%'or quantity like '%" + txbselect.Text + "%'or received_quantity like '%" + txbselect.Text + "%'or price like '%" + txbselect.Text + "%'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        da.SelectCommand = cmd;
        da.Fill(ds);
        GridView3.DataSource = ds;
        GridView3.DataBind();
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = true;
        btnshowhead.Visible = true;
        btnshowlines.Visible = true;
        btnheadadd.Visible = false;
        btnheadupdate.Visible = false;
        btnlineadd.Visible = false;
        btnlineupdate.Visible = false;
        btnlinedelete.Visible = false;
        con.Close();
    }
    protected void btnbaobiao_Click(object sender, EventArgs e)
    {
        Response.Redirect("requireReport.aspx");
    }
}
