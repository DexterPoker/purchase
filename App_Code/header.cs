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
/// header 的摘要说明
/// </summary>
public class header
{
    public string header_id, number, type, vender_code, status;
	public header()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static header FindHeader(string id) 
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
            return null;
        }
        else
        {
            header  head = new header();
            head.header_id= id;
            head.number = dr[1].ToString();
            head.type = dr[2].ToString();
            head.vender_code = dr[3].ToString();
            head.status = dr[4].ToString();
            dr.Close();
            conn.Close();
            return head;
        }
    }
    public static Boolean FindUpVender(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_venders_all where vender_code='"+id+"'");
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
    public static Boolean FindDownLine(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_lines_all where po_header_id={0}", id);
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

    public static void InsertHeader(header head)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into po_headers_all(po_number,po_type,vender_code,status)values('" + head.number + "','" + head.type + "','" + head.vender_code + "','" + head.status + "')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdateHeader(header head)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  po_headers_all set po_number='" + head.number + "',po_type='" + head.type + "',vender_code='" + head.vender_code + "',status='" + head.status + "' where po_header_id= '" + head.header_id + "'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
