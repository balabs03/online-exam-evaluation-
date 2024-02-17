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

public partial class uploadmaterial : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
       // lbluser.Text=Session["username"].ToString();

    }
 
    protected void btnupload_Click(object sender, EventArgs e)
    {
        string fname = FileUpload1.PostedFile.FileName;
        if (FileUpload1.PostedFile.ContentLength > 0)
        {
            string fpath = Server.MapPath(@"materials/" + fname);
            FileUpload1.PostedFile.SaveAs(fpath);
            lblresult.Text = fname.ToString();
            string ftype = "";
            if(fname.EndsWith(".txt"))
            {
                ftype = "Document";
            }
            else  if (fname.EndsWith(".jpg"))
            {
                ftype = "Image";
            }
            else if (fname.EndsWith(".Avi"))
            {
                ftype = "Video";
            }
             else if (fname.EndsWith(".mp4"))
            {
                ftype = "Video";
            }
            else if (fname.EndsWith(".doc"))
            {
                ftype = "Document";
            }
            else if (fname.EndsWith(".docx"))
            {
                ftype = "Document";
            }
            else if (fname.EndsWith(".pdf"))
            {
                ftype = "PDF";
            }
            con.Open();
            string ins = "insert into material values('" + ftype + "','" + fname + "','" + fpath + "','" + TextBox1.Text + "')";
            cmd = new SqlCommand(ins, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script language='javascript'> alert('file uploaded successfully')</script>");
        }
        else
        {
            Response.Write("<script language='javascript'> alert('Cannot be read Zero Content File Length')</script>");
        }

        con.Open();
        string sel = "select FileType,filename,file_category from material";
        cmd = new SqlCommand(sel, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "mat");
        gvmaterial.DataSource = ds;
        gvmaterial.DataBind();
        con.Close();

    }
}
