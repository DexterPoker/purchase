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
/// repertory 的摘要说明
/// </summary>
public class repertory
{
    public string name, num, qty;
	public repertory()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static repertory Findname(string name)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from mtl_on_hand where sub_inventory='"+name+"'");
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
            repertory reper = new repertory();
            reper.name = name;
            reper.num = dr[1].ToString();
            reper.qty = dr[2].ToString();
            dr.Close();
            conn.Close();
            return reper;
        }
    }
    public static Boolean FindUpnum(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from mtl_items_all where item_num='"+id+"'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr = command.ExecuteReader();
        if (dr.Read() == false)
        {
            dr.Close();
            conn.Close();
            return false;
        }
        else
        {
            dr.Close();
            conn.Close();
            return true;
        }
    }
    public static Boolean Findnum(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from mtl_on_hand where item_num='"+id+"'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr = command.ExecuteReader();
        if (dr.Read() == false)
        {
            dr.Close();
            conn.Close();
            return false;
        }
        else
        {
            dr.Close();
            conn.Close();
            return true;
        }
    }
    public static void InsertRepertory(repertory reper)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into mtl_on_hand(sub_inventory,item_num,qty)values('" + reper.name + "','" + reper.num + "','" + reper.qty + "')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdateRepertory(repertory reper)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  mtl_on_hand set item_num='" + reper.num + "',qty='" + reper.qty + "' where sub_inventory= '" + reper.name + "'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void DeleteRepertory(string name)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("delete from mtl_on_hand where sub_inventory={0}", name);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
