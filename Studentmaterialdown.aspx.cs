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

public partial class Studentmaterial : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");
    SqlCommand cmd;
    int Flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbuser.Text = Session["username"].ToString();
        con.Open();
        string st = "select distinct(file_category) from material";
        cmd = new SqlCommand(st, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "st");
        ddlstaffname.DataTextField = "file_category";
        ddlstaffname.DataSource = ds;
        ddlstaffname.DataBind();
        con.Close();        
    }


    protected void lbdown_Click(object sender, EventArgs e)
    {
        //admin file download
        
        Label3.Visible = false;
        ddlstaffname.Visible = false;
        Label6.Visible = false;
        ddlfname.Visible = false;
        btndownload.Visible = false;
        DataList2.Visible = false;
        Label8.Visible = false;

        DataList1.Visible = true;
        Label5.Visible = true;
        ddlfilename.Visible = true;
        btnadmindown.Visible = true;
        Label7.Visible = true;

        Flag = 0;
        con.Open();
        string st2 = "select distinct(filename) from material";
        cmd = new SqlCommand(st2, con);
        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2, "st");
        ddlfilename.DataTextField = "filename";
        ddlfilename.DataSource = ds2;
        ddlfilename.DataBind();
        con.Close();

        con.Open();
        string st = "select filename,filepath from material";
        cmd = new SqlCommand(st, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "ad");
        DataList1.DataSource = ds;
        DataList1.DataBind();
        con.Close();

    }
    protected void btndownload_Click(object sender, EventArgs e)
    {
        con.Open();
        string st = "select filename,filepath from material where file_category='" + ddlstaffname.SelectedItem.ToString() + "' and filename='" + ddlfname.SelectedItem.ToString() + "'";
        cmd = new SqlCommand(st, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "st");
        DataList2.DataSource = ds;
        DataList2.DataBind();      
        con.Close();
        Response.Redirect("~\\materials\\" + ddlfname.SelectedItem.ToString());
    }
    protected void lbstdown_Click(object sender, EventArgs e)
    {
        Label3.Visible = true;
        ddlstaffname.Visible = true;
        Label6.Visible = true;
        ddlfname.Visible = true;
        btndownload.Visible = true;
        DataList2.Visible = true;
        Label8.Visible = true;

        DataList1.Visible = false;
        Label5.Visible = false;
        ddlfilename.Visible = false;
        btnadmindown.Visible = false;
        Label7.Visible = false;

        Flag = 1;
        con.Open();
        string st1 = "select distinct(filename) from material";
        cmd = new SqlCommand(st1, con);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, "st");
        ddlfname.DataTextField = "filename";
        ddlfname.DataSource = ds1;
        ddlfname.DataBind();
        con.Close();

    }
    protected void btnadmindown_Click(object sender, EventArgs e)
    {


        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " insert into training values('" + ddlfilename.SelectedItem.ToString() + "','" + lbuser.Text + "','" + DateTime.Now.ToShortDateString() + "')";
            cmd.ExecuteNonQuery();


            con.Close();
        }
        catch  (Exception ex)
        {}

        Response.Redirect("~\\materials\\" + ddlfilename.SelectedItem.ToString());        
    }
}
