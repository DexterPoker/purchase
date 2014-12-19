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

public partial class personManage : System.Web.UI.Page
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
        txbid.Text= GridView1.SelectedDataKey.Values[0].ToString();
        person per = new person();
        per = person.FindEmp_num(txbid.Text);
        if (per == null)
        {
            string mess = "选择数据出错！！";
            string url = "personManage.aspx";
            Response.Write( message.MessageAndUrl(mess,url));
        }
        else
        {
            txbupid.Text = per.hr_emp_num;
            txbname.Text = per.name;
            txbjob.Text = per.job;
            txbdepartment.Text = per.department;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        btnaddpost.Visible = true;
        txbid.ReadOnly = false;
        txbid.Enabled = true;
        txbid.Visible = false;
        lblid.Visible = false;
        txbid.Text = "";
        txbupid.Text = "";
        txbname.Text = "";
        txbjob.Text = "";
        txbdepartment.Text = "";
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txbname.Text == "")
        {
            string mess = "请先选择要修改的记录！！！";
            Response.Write(message.sendMessage(mess));
        }
        else
        {
            Panel1.Visible = true;
            btnupdatepost.Visible = true;
            txbid.ReadOnly = true;
            txbid.Enabled = false;
            txbid.Visible = true;
            lblid.Visible = true;
        }
    }
    protected void btnaddpost_Click(object sender, EventArgs e)
    {
        string mess;
        person per = new person();
        person findper = new person();
        per.hr_emp_num = txbupid.Text;
        per.name = txbname.Text;
        per.job = txbjob.Text;
        per.department = txbdepartment.Text;
        OleDbConnection conn = new OleDbConnection(db.constring());
        if (txbname.Text == "" || txbjob.Text == "" || txbdepartment.Text == "" || txbupid.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbupid.Text);
                if (txbjob.Text == "总经理" && txbupid.Text == "0")
                {
                    person.InsertPerson(per);
                    btnaddpost.Visible = false;
                    Panel1.Visible = false;
                    mess = "新人员添加成功！！！";
                    string url = "personManage.aspx";
                    Response.Write(message.MessageAndUrl(mess, url));
                }
                else
                {
                    person hr_per = new person();
                    hr_per = person.FindEmp_num(txbupid.Text);
                    if (hr_per != null)
                    {
                        if (txbjob.Text == "采购员" && hr_per.job == "部门经理")
                        {
                            person.InsertPerson(per);
                            btnaddpost.Visible = false;
                            Panel1.Visible = false;
                            mess = "新人员成功！！！";
                            string url = "personManage.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else if (txbjob.Text == "部门经理" && hr_per.job == "总经理")
                        {
                            person.InsertPerson(per);
                            btnaddpost.Visible = false;
                            Panel1.Visible = false;
                            mess = "新人员添加成功！！！";
                            string url = "personManage.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else
                        {
                            mess = "添加员工职称与上级员工职称不相匹配！！！";
                            Response.Write(message.goBack(mess));
                        }
                    }
                    else
                    {
                        mess = "该上级员工号不存在！！！";
                        Response.Write(message.goBack(mess));
                    }
                }
            }
            catch
            {
                mess = "上级编号只能是数字";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btnupdatepost_Click(object sender, EventArgs e)
    {
        string mess;
        person per = new person();
        per.hr_emp_num = txbupid.Text;
        per.name = txbname.Text;
        per.job = txbjob.Text;
        per.department = txbdepartment.Text;
        OleDbConnection conn = new OleDbConnection(db.constring());
        if (txbname.Text == "" || txbjob.Text == "" || txbdepartment.Text == "" || txbupid.Text == "")
        {
            mess = "请将信息填写完整！！！";
            Response.Write(message.goBack(mess));
        }
        else
        {
            try
            {
                int.Parse(txbupid.Text);
                if (txbjob.Text == "总经理" && txbupid.Text == "0")
                {
                    person.UpdatePerson(per);
                    btnaddpost.Visible = false;
                    Panel1.Visible = false;
                    mess = "人员信息修改成功！！！";
                    string url = "personManage.aspx";
                    Response.Write(message.MessageAndUrl(mess, url));
                }
                else
                {
                    person hr_per = new person();
                    hr_per = person.FindEmp_num(txbupid.Text);
                    if (hr_per != null)
                    {
                        if (txbjob.Text == "采购员" && hr_per.job == "部门经理")
                        {
                            person.UpdatePerson(per);
                            btnaddpost.Visible = false;
                            Panel1.Visible = false;
                            mess = "人员信息修改成功！！！";
                            string url = "personManage.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else if (txbjob.Text == "部门经理" && hr_per.job == "总经理")
                        {
                            person.UpdatePerson(per);
                            btnaddpost.Visible = false;
                            Panel1.Visible = false;
                            mess = "人员信息修改成功！！！";
                            string url = "personManage.aspx";
                            Response.Write(message.MessageAndUrl(mess, url));
                        }
                        else
                        {
                            mess = "添加员工职称与上级员工职称不相匹配！！！";
                            Response.Write(message.goBack(mess));
                        }
                    }
                    else
                    {
                        mess = "该上级员工号不存在！！！";
                        Response.Write(message.goBack(mess));
                    }
                }
            }
            catch
            {
                mess = "上级编号只能是数字！！！";
                Response.Write(message.goBack(mess));
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string mess;
        person find_hrper = new person();
        if (txbid.Text != "")
        {
            find_hrper = person.FindHR_Emp_num(txbid.Text);
            if (find_hrper != null)
            {
                mess = "该员工是某些员工的上级不能直接删除！！！";
                Response.Write(message.sendMessage(mess));
            }
            else
            {
                person.DeletePerson(txbid.Text);
                mess = "人员删除成功！！！";
                string url = "personManage.aspx";
                Response.Write(message.MessageAndUrl(mess, url));
            }
        }
        else
        {
            mess = "请先选择要删除的记录！！！";
            Response.Write(message.sendMessage(mess));
        }
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(db.constring());
        con.Open();
        string sql = "select * from hr_person where emp_num like '%" + txbselect.Text + "%'or hr_emp_num like '%" + txbselect.Text + "%' or name like '%" + txbselect.Text + "%' or job like '%" + txbselect.Text + "%' or department like '%" + txbselect.Text + "%'";
        OleDbCommand cmd = new OleDbCommand(sql,con);
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
    protected void btnGridshow_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        btnGridshow.Visible = false;
        txbselect.Text = "";
        GridView2.Visible = false;
    }
}
