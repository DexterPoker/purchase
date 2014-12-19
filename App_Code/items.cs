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
/// items 的摘要说明
/// </summary>
public class items
{
    public string num,description,type;
	public items()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static items Findnum(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from mtl_items_all where item_num={0}", id);
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
            items item = new items();
            item.num = id;
            item.description = dr[1].ToString();
            item.type = dr[2].ToString();
            dr.Close();
            conn.Close();
            return item;
        }
    }
    public static Boolean FindDownnum(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from mtl_on_hand where item_num={0}", id);
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
    public static void InsertItems(items item)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into mtl_items_all(item_description,item_type)values('" + item.description + "','" + item.type + "')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdateItems(items item)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  mtl_items_all set item_description='" + item.description + "',item_type='" + item.type + "' where item_num= '" + item.num + "'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void DeleteItems(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("delete from mtl_items_all where item_num={0}", id);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
