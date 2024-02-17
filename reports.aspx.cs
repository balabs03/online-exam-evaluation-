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

public partial class reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand();
        con.Open();
        string p = "select distinct * from candidatesdetails";
        comm = new SqlCommand(p, con);
        SqlDataAdapter da1 = new SqlDataAdapter(comm);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, "user_registration");

        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand();
        con.Open();
        string p = "select distinct cno,domain,marks  from candidatesdetails order by marks desc ";
        comm = new SqlCommand(p, con);
        SqlDataAdapter da1 = new SqlDataAdapter(comm);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, "user_registration");
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand();
        con.Open();
        string p = "select *  from upload  ";
        comm = new SqlCommand(p, con);
        SqlDataAdapter da1 = new SqlDataAdapter(comm);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, "user_registration");
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }
}
