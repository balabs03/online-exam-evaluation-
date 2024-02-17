using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class user : System.Web.UI.MasterPage
{
    int k;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "Welcome:" + Session["uid"].ToString();
            string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");

            if (File.Exists(simg + "/"+Session["fid"].ToString()))
            {
                // BindImage(simg);

                // ImageButton1.ImageUrl = simg + "\temp.jpg";
                image1.Src = "~/FaceC/bin/Debug/TrainedFaces" +"/"+ Session["fid"].ToString();
               // Image1.ImageUrl = simg + "\temp.jpg";
                
                //  TextBox1.Text = simg + "\temp.jpg";
                //     Timer1.Enabled = false;

            }
           // Button1.Visible = true;
        }
        catch (Exception ex)
        { }

        if (IsPostBack != true)
        {
            //Session["ltype"] = "high";
            try
            {
                Label1.Text = Session["uid"].ToString();
            }
            catch (Exception ex)
            {

                Label1.Text = "kalai";
            }
            Process[] pname1 = Process.GetProcessesByName("MultiFacRec");
            if (pname1.Length == 0)
            {
                // Process.Start(@"D:\Online_Exam\FaceC_2\bin\Debug\ContinuousMonitor.exe");
            }
            else
            {
                pname1[0].Kill();
            }

            //if (Session["ltype"].ToString() == "high")
            //{
                Process[] pname = Process.GetProcessesByName("ContinuousMonitor");
                if ((pname.Length == 0) && (pname1.Length == 0))
                {
                    Process.Start(@"D:\Online_Exam\FaceC_2\bin\Debug\ContinuousMonitor.exe");
                }
                else
                {
                    try
                    {
                        pname1[0].Kill();
                        pname[0].Kill();
                        Process.Start(@"D:\Online_Exam\FaceC_2\bin\Debug\ContinuousMonitor.exe");
                    }
                    catch (Exception ex)
                    { }
                }

              
                k = 0;
                Timer1.Enabled = true;
            //}
            //else
            //{

            //}
            // Process.Start(@"c:\webcam\bin\Debug\WinFormCharpWebCam.exe");
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        SqlConnection con43 = new SqlConnection("server=.\\sqlexpress;integrated security=true;database=continuous_exam;");
        con43.Close();
        con43.Open();
        SqlCommand cmdd = new SqlCommand("select * from t1", con43);
        SqlDataReader dr = cmdd.ExecuteReader();
        if (dr.Read())
        {
            if (dr[0].ToString().Trim() == "yes")
            {
                
                k = Convert.ToInt32(TextBox1.Text);
                k++;
                TextBox1.Text = k.ToString();
                if (Convert.ToInt32(TextBox1.Text) == 4)
                {
                    Timer1.Enabled = false;
                   // Timer2.Enabled = true;
                    Response.Redirect("Home.aspx");
                }
               
                // DisableAllControls(this);
                //DataAccess da = new DataAccess();
                //SqlDataReader drs = da.DBReaderOpen("select emailid from uregister where userid='" + Label1.Text + "'");
                //if (drs.Read())
                //{
                //    try
                //    {
                //       // mail(drs[0].ToString());
                //    }
                //    catch (Exception ex)
                //    { }
                //}

                //DisableAllControls("myprofile.aspx");
            }
            else if (dr[0].ToString().Trim() == "no")
            {

                Session["result"] = "Continue";
                // Session["result"] = "";
                //  Timer2.Enabled = false ;
                //Timer1.Enabled = true;
                Button1.Text = "Continued";

            }

        }
        con43.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
