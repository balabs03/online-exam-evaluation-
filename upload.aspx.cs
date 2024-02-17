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

public partial class upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select max(qno) from question where domain='" + DropDownList1.Text + "' ";
        //string s="select * from login where id='" + TextBox1.Text + "' and Password='" + TextBox2.Text + " '";
        cmd.Connection = con;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            try
            {
                TextBox1.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            }
            catch (Exception ex)
            {
                TextBox1.Text = "1";

            }
        }
        else
        {
            TextBox1.Text = "1";
        }
        con.Close();
    }
    public void recall()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select max(qno) from question where domain='" + DropDownList1.Text + "' ";
        //string s="select * from login where id='" + TextBox1.Text + "' and Password='" + TextBox2.Text + " '";
        cmd.Connection = con;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            try
            {
                TextBox1.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            }
            catch (Exception ex)
            {
                TextBox1.Text = "1";

            }
        }
        else
        {
            TextBox1.Text = "1";
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ca = "";
        if (DropDownList2.Text == "Option1")
        {
            ca = TextBox3.Text;
        }
        else if (DropDownList2.Text == "Option2")
        {
            ca = TextBox4.Text;
        }
        else if (DropDownList2.Text == "Option3")
        {
            ca = TextBox5.Text;
        }
        else if (DropDownList2.Text == "Option4")
        {
            ca = TextBox6.Text;
        }
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into question values('" + TextBox1.Text + "','" + DropDownList1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + ca + "','"+DropDownList4.Text +"')";
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script language='javascript'> alert('Inserted Completed..')</script>");

       Label9.Text="Inserted Sucessfully";
       // Response.Redirect("home.aspx");
       TextBox2.Text = "";
       TextBox3.Text = "";
       TextBox4.Text = "";
       TextBox5.Text = "";
       TextBox6.Text = "";
       TextBox1.Text = "";
       recall();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox1.Text = "";
    }
}
