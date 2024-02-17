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
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

public partial class IHeditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    string filepath;
    string filename;
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        txtvalue.Text = "";
        txtfname.Text  = "";
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        txtvalue.Enabled = false;
    }
    protected void btnjavasave_Click(object sender, EventArgs e)
    {
        if (txtvalue.Text != "")
        {
            if (txtvalue.Text != "")
            {
                string ht = txtvalue.Text;
                filename = txtfname.Text;
                filepath = Server.MapPath(@"D:/fuzzy/html/"+Label9.Text +"/");
                if (File.Exists(filepath + filename + ".html"))
                {
                    Response.Write("<script language='javascript'>alert('File already exists, so give other name')</script>");
                }
                else
                {
                    StreamWriter sw = new StreamWriter(filepath + filename + ".html");
                    sw.WriteLine(ht);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Enter Html file data')</script>");
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Enter file name')</script>");
        }
    }
    protected void btnjavarun_Click(object sender, EventArgs e)
    {
        if (txtfname.Text != "")
        {
            filename = txtfname.Text;
            filepath = Server.MapPath(@"D:/fuzzy/html/"+Label9.Text +"/");
            string f = filepath + filename + ".html";
            char[] sp = new char[] { '\\' };
            string[] path = f.Split(sp);
            string s = "";
            for (int i = 0; i < path.Length; i++)
            {
                s = s + path[i] + "/";
            }
            string runpath = "file:///" + s;

            Process.Start("IExplore.exe", runpath);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Enter file name')</script>");
        }

    }


    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (txtfname.Text  != " ")
        {
            string code = txtvalue.Text ;
            string jafile = txtfname.Text ;
            string jpath = Server.MapPath(@"D:/fuzzy/html/"+Label9.Text +"/");

            StreamReader sr = new StreamReader(jpath + jafile + ".html");
            string s = sr.ReadToEnd();
            txtvalue.Text  = s.ToString();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Enter the java file name')</script>");
        }
    }
    protected void txtjavaname_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
    protected void txtvalue_TextChanged(object sender, EventArgs e)
    {

    }
}
