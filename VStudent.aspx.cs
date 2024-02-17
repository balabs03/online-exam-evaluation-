using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class VStudent : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            regno();
        }
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from regis ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        System.Data.DataSet ds = new System.Data.DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from regis where userid='" + DropDownList1.Text + "'", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>aler('Student Record Deleted Successfully')</script>");
        con.Close();
    }
    private void regno()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select userid from regis", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while  (dr.Read())
        {
            DropDownList1.Items.Add(dr[0].ToString());
        }
        con.Close();
    }
}