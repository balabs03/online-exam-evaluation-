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
public partial class instructions : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Session["uname"].ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        string imgName = FileUpload1.FileName;
        string imgPath = "Upload/" + imgName;
        int imgSize = FileUpload1.PostedFile.ContentLength;
        FileUpload1.SaveAs(Server.MapPath(imgPath));
        Image2.ImageUrl = "~/" + imgPath;
        SqlCommand cmd = new SqlCommand("insert into upload values('" + Label2.Text + "','" + TextBox2.Text + "','" + imgName + "','" + imgPath + "','" + imgSize + "')", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('File Uploaded Successfully')</script>");
        con.Close();
    }
}
