using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    public SqlConnection cn;
    public SqlCommand cmd;
    public SqlDataReader dr;
    public SqlDataAdapter da;
    public DataSet ds = new DataSet();
    public DataAccess()
    { }
    public void DBOpen()
    {
        cn = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");
        cn.Open();
    }
    public void DBClose()
    {
        cn.Close();
    }

    public void DBCmdOpen(string query)
    {
        try
        {
            DBOpen();
            cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        { }
        finally 
{
    cmd.Connection.Close();
    cmd.Connection.Dispose();
} 
    }
    public void DBCmdClose()
    {
        cmd = null;
        cn.Close();
    }
    public SqlDataReader DBReaderOpen(string query)
    {
        DBOpen();
        cmd = new SqlCommand(query, cn);
       
            dr = cmd.ExecuteReader();
       
        return dr;
    }
    public void DBReaderClose()
    {
        dr.Close();
        cmd = null;
        DBClose();
    }
    public void dataSetRead(string query, DataSet dss)
    {
        DBOpen();
        cmd = new SqlCommand(query, cn);
        da = new SqlDataAdapter(cmd);
        da.Fill(dss);
        DBClose();
    }

    public void DBDataAdapter(string query, GridView gvControl)
    {
        DBOpen();
        cmd = new SqlCommand(query ,cn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        gvControl.DataSource = ds;
        gvControl.DataBind();
        DBClose();
    }

    

}
