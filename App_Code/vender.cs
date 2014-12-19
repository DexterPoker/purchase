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
/// vender 的摘要说明
/// </summary>
public class vender
{
    public string vender_code, vender_name, address, contact, phone;
	public vender()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static vender FindCode(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_venders_all where vender_code={0}", id);
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
            vender ven = new vender();
            ven.vender_code = id;
            ven.vender_name = dr[1].ToString();
            ven.address = dr[2].ToString();
            ven.contact= dr[3].ToString();
            ven.phone = dr[4].ToString();
            dr.Close();
            conn.Close();
            return ven;
        }
    }
    public static Boolean FindUnderCode(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("select * from po_headers_all where vender_code={0}", id);
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
    public static void InsertVender(vender ven)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("insert into po_venders_all(vender_name,address,contact,phone)values('" + ven.vender_name + "','" + ven.address + "','" + ven.contact + "','" + ven.phone + "')");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void UpdateVender(vender ven)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("update  po_venders_all set vender_name='" + ven.vender_name + "',address='" + ven.address + "',contact='" + ven.contact + "',phone='" + ven.phone + "' where vender_code= '" + ven.vender_code + "'");
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    public static void DeleteVender(string id)
    {
        string sql;
        OleDbConnection conn = new OleDbConnection(db.constring());
        sql = string.Format("delete from po_venders_all where vender_code={0}", id);
        OleDbCommand command = new OleDbCommand(sql, conn);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
}
