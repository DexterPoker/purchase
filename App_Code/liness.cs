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
/// liness 的摘要说明
/// </summary>
public class liness
{
    public string head_id,line_id,num,code,quantity,requantity,price;
	public liness()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static liness FindLines(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_lines_all where po_line_id={0}", id);
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
            liness line = new liness();
            line.line_id = id;
            line.head_id = dr[1].ToString();
            line.num = dr[2].ToString();
            line.code = dr[3].ToString();
            line.quantity = dr[4].ToString();
            line.requantity = dr[5].ToString();
            line.price = dr[6].ToString();
            dr.Close();
            conn.Close();
            return line;
        }
    }
    public static Boolean FindUpheader(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_headers_all where po_header_id={0}", id);
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
    public static Boolean FindUpItem(string id)
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
            return false;
        }
        else
        {
            dr.Close();
            conn.Close();
            return true;
        }
    }
    public static void InsertLines(liness line)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into po_lines_all(po_header_id,line_num,item_num,Quantity,received_quantity,price)values('" + line.head_id + "','" + line.num + "','" + line.code + "','" + line.quantity + "','" + line.requantity + "','" + line.price + "')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdateLine(liness line)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  po_lines_all set po_header_id='" + line.head_id + "',line_num='" + line.num + "',item_num='" + line.code + "',Quantity='" + line.quantity + "',received_quantity='" + line.requantity + "',price='" + line.price + "' where po_line_id= '" + line.line_id + "'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void DeleteLine(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("delete from po_lines_all where po_line_id={0}", id);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
