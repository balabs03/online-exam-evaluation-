using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class VQuestions : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            domain();
          
        }
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from question ", con);
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
        SqlCommand cmd = new SqlCommand("delete from question where qno='" + DropDownList2.Text + "'", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>aler('Question Record Deleted Successfully')</script>");
        con.Close();
    }
    private void qusno()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select qno from question where domain='"+DropDownList1.Text +"'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while  (dr.Read())
        {
            DropDownList2.Items.Add(dr[0].ToString());
        }
        con.Close();
    }
    private void domain()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct(domain) from question ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DropDownList1.Items.Add(dr[0].ToString());
        }
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        qusno();
    }
}