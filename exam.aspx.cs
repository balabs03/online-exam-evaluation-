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


public partial class exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Domain"] = TextBox2.Text;
        Session["complexity"] = TextBox1.Text;
        DataAccess da = new DataAccess();
        da.DBCmdOpen("delete from candidatesdetails1");
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from candidatesdetails1 where cno='" + Session["cno"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("TakeTest2.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox2.Text  = Button2.Text;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox2.Text = Button3.Text;

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox2.Text = Button4.Text;

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TextBox2.Text = Button5.Text;

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        TextBox2.Text = Button6.Text;

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "Low";
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "Medium";
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "High";
    }
}
