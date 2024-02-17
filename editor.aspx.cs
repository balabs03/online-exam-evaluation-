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

public partial class editor : System.Web.UI.Page
{
   
    string sturoll = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label8.Text = Session["username"].ToString();
        if (Page.IsPostBack == false )
        {
            TextBox1.Text = DateTime.Now.ToString();
           
          //   string[] stu=Label8.Text.Split('-');

            Label9.Text = Label8.Text;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        txtjavacode.Text = "";
        txtjavaname.Text = "";
    }
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=continuous_exam;integrated security=true;");
    SqlCommand cmd;
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        txtjavacode.Enabled = false;
        btnjavarun.Enabled = false;
        btnjavasave.Enabled = false;
        btnedit.Enabled = false;
        savedata();
    }
    public void savedata()
    {
        TimeSpan t1 = new TimeSpan();
        DateTime starttime = Convert.ToDateTime(TextBox1.Text);
        DateTime endtime = Convert.ToDateTime(DateTime.Now.ToString());
        string completion_time = (endtime.Subtract(starttime).TotalMinutes.ToString());
        string[] studet = Label8.Text.Split('-');
        string s = "insert into labreport values('" + Label8.Text + "','" + Label9.Text  + "','java','" + txtjavaname.Text  + "','" + TextBox1.Text  + "','" + DateTime.Now.ToString() + "','" + completion_time  + "')";
        cmd = new SqlCommand(s, con);
        con.Open();
        cmd.ExecuteNonQuery();
        Response.Write("<script language='javascript'> alert('inserted Completed..')</script>");

        Response.Write("<script language='javascript'>alert('inserted successfully')</script>");
        con.Close();
    
    }
    protected void btnjavasave_Click(object sender, EventArgs e)
    {
     if (txtjavaname.Text != " ")
        {
            if (txtjavacode.Text != "")
            {
                string javapath = @"D:\Elearning\fuzzy\java\" + Label9.Text + "\\";

                string code = txtjavacode.Text;
                string jafile = txtjavaname.Text;
                string jpath = (@"D:/Elearning/fuzzy/java/"+Label9.Text +"/");                
                StreamWriter sw1 = new StreamWriter(jpath + jafile + ".java");
                sw1.WriteLine(code);
                sw1.Flush();
                sw1.Close();

                try
                {
                    string spa = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;| D: |" + "CD " + javapath + " |  javac" + " " + jafile + ".java |java" + " " + jafile + " | pause";

                   // string spa = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;|CD" + " " + @"D:/Elearning/fuzzy/java/" + Label9.Text + "\\" + jafile + ".java" + " | D:\\fuzzy\\java\\" +Label9.Text +"\\" + "| javac" + " " + jafile + ".java |java" + " " + jafile + " | pause";
                    
                 // string spa = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;|CD" + " " + @"D:/Elearning/fuzzy/java/"+ Label9.Text + @"\"+ jafile + ".java"  | pause";
                    spa = spa.Replace("|", " " + System.Environment.NewLine);

                    StreamWriter sw2 = new StreamWriter(jpath + jafile + ".bat");
                    sw2.WriteLine(spa);
                    sw2.Flush();
                    sw2.Close();
                }
                catch
                {

                }

                //store another loc

                string code1 = txtjavacode.Text;
                string jafile1 = txtjavaname.Text;
                string jpath1 = (@"D:/Elearning/fuzzy/java/" + Label9.Text + "/");
                StreamWriter swa2 = new StreamWriter(jpath1 + jafile1 + ".java");
                swa2.WriteLine(code1);
                swa2.Flush();
                swa2.Close();
                try
                {
                    string spa1 = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;| D: |" + " CD " + javapath + " |  javac" + " " + jafile1 + ".java |java" + " " + jafile1 + " | pause";

                    // string spa = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;|CD D: |" + " " + @"D:/Elearning/fuzzy/java/" + Label9.Text + "\\" + jafile + ".java" + " | D:\\fuzzy\\java\\" +Label9.Text +"\\" + "| javac" + " " + jafile + ".java |java" + " " + jafile + " | pause";

                    // string spa = @"set path=C:\Program Files\Java\jdk1.7.0_12\bin;|CD D: |" + " " + @"D:/Elearning/fuzzy/java/"+ Label9.Text + @"\"+ jafile + ".java"  | pause";
                    spa1 = spa1.Replace("|", " " + System.Environment.NewLine);

                    StreamWriter sw3 = new StreamWriter(jpath1 + jafile1 + ".bat");
                    sw3.WriteLine(spa1);
                    sw3.Flush();
                    sw3.Close();
                }
                catch
                {

                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Enter the java code')</script>");
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Enter the java file name')</script>");
        }
    }
    protected void btnjavarun_Click(object sender, EventArgs e)
    {
        if (txtjavaname.Text != "")
        {
            string jafile = txtjavaname.Text;
            string jpath = (@"D:/Elearning/fuzzy/java/"+Label9.Text +"/");               
            string fna =jpath+jafile + ".bat";
           // Process.EnterDebugMode();
            Process.Start(fna);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Enter the java file name')</script>");
        }
    }

    string filepath;
    string filename;
    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtjavaname.Text != " ")
            {
                string code = txtjavacode.Text;
                string jafile = txtjavaname.Text;
                string jpath = (@"D:/Elearning/fuzzy/java/" + Label9.Text + "/");

                StreamReader sr = new StreamReader(jpath + jafile + ".java");
                string s = sr.ReadToEnd();
                txtjavacode.Text = s.ToString();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Enter the java file name')</script>");
            }
        }
        catch (Exception ex)
        { }


    }
    protected void txtjavaname_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
}
