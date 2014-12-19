using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// person 的摘要说明
/// </summary>
public class person
{
    public string emp_num, hr_emp_num, name, job, department, password;
	public person()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//   
	}
    public static person FindEmp_num(string id) 
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from HR_PERSON where emp_num='"+id+"'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr = command.ExecuteReader();
        if (dr.Read() == false)
        {
            dr.Close();
            conn.Close();
            return null;
        }
        else
        {
            person per = new person();
            per.emp_num = id;
            per.hr_emp_num = dr[1].ToString();
            per.name = dr[2].ToString();
            per.job = dr[3].ToString();
            per.department = dr[4].ToString();
            per.password = dr[5].ToString();
            dr.Close();
            conn.Close();
            return per;
        }
    }
    public static person FindHR_Emp_num(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from HR_PERSON where HR_emp_num={0}", id);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr = command.ExecuteReader();
        if (dr.Read() == false)
        {
            dr.Close();
            conn.Close();
            return null;
        }
        else
        {
            person per = new person();
            per.emp_num = id;
            per.hr_emp_num = dr[1].ToString();
            per.name = dr[2].ToString();
            per.job = dr[3].ToString();
            per.department = dr[4].ToString();
            per.password = dr[5].ToString();
            dr.Close();
            conn.Close();
            return per;
        }
    }
    public static void InsertPerson(person per)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into hr_person(hr_emp_num,name,job,department)values('"+per.hr_emp_num+"','"+per.name+"','"+per.job+"','"+per.department+"')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdatePerson(person per)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  hr_person set hr_emp_num='"+per.hr_emp_num+"',name='"+per.name+"',job='"+per.job+"',department='"+per.department+"' where emp_num= '"+per.emp_num+"'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void DeletePerson(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("delete from hr_person where emp_num={0}",id);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdatePassword(person per) 
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update hr_person set password='" + per.password + "' where emp_num='"+per.emp_num+"'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
