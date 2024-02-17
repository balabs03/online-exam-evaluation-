using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
public partial class report : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        string table_name = Session["tblname"].ToString();
        SqlCommand comm = new SqlCommand();
        con.Open();
        string p = "select distinct * from "+table_name;
        comm = new SqlCommand(p, con);
        SqlDataAdapter da1 = new SqlDataAdapter(comm);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, table_name);

        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();


    }
}
