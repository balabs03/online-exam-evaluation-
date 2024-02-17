using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Web.Services;



public partial class TakeTest2 : System.Web.UI.Page
{
    static string sno, tno;
    static Int32 totalQs;
    static bool IsLastQs = false;
   // ConnectToDb mydb = new ConnectToDb();
    static DataSet Questions;
    long timerStartValue = 1800;
    [WebMethod]                                 //Default.aspx.cs
    public static void DeleteItem()
    {
           
        //Your Logic
    }
     public void DataBinds()
    {
        //timercheck();
        string domain = Convert.ToString(Session["Domain"]);
         string complexity = Convert.ToString(Session["complexity"]);
        SqlConnection objConn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlDataAdapter objDA = new SqlDataAdapter("select * from question where domain='" + domain + "' and subdomain='" + complexity + "'", objConn);
        DataSet objDS = new DataSet();

        if (!Page.IsPostBack)
        {
            objDA.Fill(objDS);
            intRecordCount.Text = Convert.ToString(objDS.Tables[0].Rows.Count);
            objDS = null;
            objDS = new DataSet();
        }

        objDA.Fill(objDS, Convert.ToInt16(intCurrIndex.Text), Convert.ToInt16(intPageSize.Text), "Sales");

        DataList1.DataSource = objDS.Tables[0].DefaultView;
        DataList1.DataBind();
        objConn.Close();
        PrintStatus();

        if (intCurrIndex.Text =="0")
        {
            foreach (DataListItem anItem in DataList1.Items)
            {

               string  quessno = ((Label)anItem.FindControl("Label2")).Text;
               SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into candidatesdetails1 values('" + Session["cno"].ToString() + "','" + Session["Domain"].ToString() + "','0','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','null','" + quessno + "','null')";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    public void ShowFirst(object s, EventArgs e)
    {
        intCurrIndex.Text = "0";
       // timercheck();
        DataBinds();
    }


    public void ShowPrevious(object s, EventArgs e)
    {
        int a = Convert.ToInt16(intCurrIndex.Text);
        int b = Convert.ToInt16(intPageSize.Text);
        intCurrIndex.Text = Convert.ToString(a - b);

        if (Convert.ToInt16(intCurrIndex.Text) < 0)
        {
            intCurrIndex.Text = "0";
        }
        timercheck();
        DataBinds();
    }
    private void PrintStatus()
    {
        lblStatus.Text = "Total Records:<b>" + intRecordCount.Text;
        lblStatus.Text += "</b> - Showing Page:<b> ";
        lblStatus.Text += Convert.ToString(Convert.ToInt16(intCurrIndex.Text) / Convert.ToInt16(intPageSize.Text + 1));
        lblStatus.Text += "</b> of <b>";

        if ((Convert.ToInt16(intRecordCount.Text) % Convert.ToInt16(intPageSize.Text)) > 0)
        {
            lblStatus.Text += Convert.ToString(Convert.ToInt16(intRecordCount.Text) / Convert.ToInt16(intPageSize.Text + 1));
        }
        else
        {
            lblStatus.Text += Convert.ToString(Convert.ToInt16(intRecordCount.Text) / Convert.ToInt16(intPageSize.Text));
        }
        lblStatus.Text += "</b>";
    }
    public void ShowNext(object s, EventArgs e)
    {
        if ((Convert.ToInt16(intCurrIndex.Text) + 1).ToString() == intRecordCount.Text)
        {
            Response.Write("<script language='javascript'> alert('last Question.Click finish to get answers.')</script>");
            update_each_question(intCurrIndex.Text);
          
        }
        else
        {
         
            update_each_question(intCurrIndex.Text);
            if (Convert.ToInt16(intCurrIndex.Text) + 1 < Convert.ToInt16(intRecordCount.Text))
            {


                intCurrIndex.Text = Convert.ToString(Convert.ToInt16(intCurrIndex.Text) + Convert.ToInt16(intPageSize.Text));

            }
            timercheck();
            DataBinds();
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            string quessno = "0";
            foreach (DataListItem anItem in DataList1.Items)
            {

                quessno = ((Label)anItem.FindControl("Label2")).Text;
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into candidatesdetails1 values('" + Session["cno"].ToString() + "','" + Session["Domain"].ToString() + "','0','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','null','" + quessno + "','null')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void update_each_question(string qno)
    {
        //timercheck();
        string r1;
        string r2;
        string r3;
        string r4;
        string r5;
        int marks = 0;
        string quessno="0";

        foreach (DataListItem anItem in DataList1.Items)
        {
            quessno = ((Label)anItem.FindControl("Label2")).Text;

            if (((RadioButton)anItem.FindControl("RadioButton1")).Checked)
            {
                r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r1 == r5)
                {
                    marks = marks + 1;
                    
                }
                else
                {

                }
            }

            if (((RadioButton)anItem.FindControl("RadioButton2")).Checked)
            {
                r2 = ((RadioButton)anItem.FindControl("RadioButton2")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r2 == r5)
                {
                    marks = marks + 1;
                }
            }


            if (((RadioButton)anItem.FindControl("RadioButton3")).Checked)
            {
                r3 = ((RadioButton)anItem.FindControl("RadioButton3")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r3 == r5)
                {
                    marks = marks + 1;
                }
            }

            if (((RadioButton)anItem.FindControl("RadioButton4")).Checked)
            {

                r4 = ((RadioButton)anItem.FindControl("RadioButton4")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r4 == r5)
                {
                    marks = marks + 1;
                }
            }


        }
        string domainn = Session["Domain"].ToString();

        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

        string m = Convert.ToString(Session["cno"]);
        con.Open();
        Session["ScoredMarks"] = Convert.ToInt32(marks);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update candidatesdetails1 set marks=" + marks + ", outtime='" + DateTime.Now.ToShortTimeString() + "'  where cno='" + m + "' and domain='" + domainn + "' and qno='" + quessno + "'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void ShowLast(object s, EventArgs e)
    {
        int tmpInt;

        tmpInt = Convert.ToInt16(intRecordCount.Text) % Convert.ToInt16(intPageSize.Text);
        if (tmpInt > 0)
        {
            intCurrIndex.Text = Convert.ToString((Convert.ToInt16(intRecordCount.Text) - tmpInt));
        }
        else
        {
            intCurrIndex.Text = Convert.ToString(Convert.ToInt16(intRecordCount.Text) - Convert.ToInt16(intPageSize.Text));
        }
        timercheck();
        DataBinds();
       
    }

    int finalmark ;
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataBind();
        try
        {
            Label1.Text = "Welcome:" + Session["uid"].ToString();
            string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");
            DataAccess da = new DataAccess();
            da.DBCmdOpen("delete from cquestion");
            if (File.Exists(simg + "/" + Session["fid"].ToString()))
            {
                // BindImage(simg);

                // ImageButton1.ImageUrl = simg + "\temp.jpg";
                image1.Src = "~/FaceC/bin/Debug/TrainedFaces" + "/" + Session["fid"].ToString();
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
                DataBind();
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
       
            //1800000
            finalmark = 0;
            this.timerStartValue = 180000;
           // this.TimerInterval = 500;

            intPageSize.Text = "1";
            intCurrIndex.Text = "0";
            //Label3.Text = "60";
            DataBinds();
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into candidatesdetails values('" + Session["cno"].ToString() + "','" + Session["Domain"].ToString() + "','0','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + intCurrIndex.Text + "','null','" + intRecordCount.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

        }
        try
        {
            Label1.Text = "Welcome:" + Session["uid"].ToString();
            //string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");
            //try
            //{
            //    image1.Src = "~/FaceC/bin/Debug/TrainedFaces" + Session["fid"].ToString();
            //}
            //catch (Exception ex)
            //{ 
            
            //}

            //if (File.Exists(simg + "/" + Session["fid"].ToString()))
            //{
            //    // BindImage(simg);

            //    // ImageButton1.ImageUrl = simg + "\temp.jpg";
            //    image1.Src = "~/FaceC/bin/Debug/TrainedFaces" + "/" + Session["fid"].ToString();
            //    // Image1.ImageUrl = simg + "\temp.jpg";

            //    //  TextBox1.Text = simg + "\temp.jpg";
            //    //     Timer1.Enabled = false;

            //}
            // Button1.Visible = true;
        }
        catch (Exception ex)
        { }

        if (IsPostBack != true)
        {
            
            Timer1.Enabled = true;
           
        }
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        //StringBuilder bldr = new StringBuilder();
        //bldr.AppendFormat("var Timer = new myTimer({0},{1},'{2}','timerData');");
        //bldr.Append("Timer.go()");
        //ClientScript.RegisterStartupScript(this.GetType(), "TimerScript", bldr.ToString(), true);
        //ClientScript.RegisterHiddenField("timerData", timerStartValue.ToString());
        //timercheck();
    }

    void Page_PreInit(object sender, EventArgs e)
    {
        //string timerVal = Request.Form["timerData"];
        //if (timerVal != null || timerVal == "")
        //{
        //    timerVal = timerVal.Replace(",", String.Empty);
        //    timerStartValue = long.Parse(timerVal);
        //}
        //timercheck();
    }

    //private Int32 TimerInterval
    //{
    //    //get
    //    //{
    //    //    object o = ViewState["timerInterval"];
    //    //    if (o != null) { return Int32.Parse(o.ToString()); }
    //    //    return 50;
    //    //}
    //    //set { ViewState["timerInterval"] = value; }

    //}

    void RedirectToResults()
    {
        Response.Redirect("Results.aspx");
    }
  
  

    protected void Button1_Click(object sender, EventArgs e)
    {
       // timercheck();

        string r1;
        string r2;
        string r3;
        string r4;
        string r5;
        int marks = 0;
      

          string domain = Convert.ToString(Session["Domain"]);
         string complexity = Convert.ToString(Session["complexity"]);
                 string uid = Convert.ToString(Session["cno"]);
                 int mm = 0;
        foreach (DataListItem anItem in DataList1.Items)
        {
            timercheck();
            string qno = ((Label)anItem.FindControl("Label2")).Text;
            string ques = ((Label)anItem.FindControl("Label1")).Text;
           // string qno = ((Label)anItem.FindControl("Label2")).Text;
          string  qr1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
          string  qr2 = ((RadioButton)anItem.FindControl("RadioButton2")).Text;
          string  qr3 = ((RadioButton)anItem.FindControl("RadioButton3")).Text;
        string  qr4 = ((RadioButton)anItem.FindControl("RadioButton4")).Text;
            r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;

            if (((RadioButton)anItem.FindControl("RadioButton1")).Checked)
            {
                r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r1 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();
                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r1 + "','" + r5+ "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','"+qr1+"','"+qr2 +"','"+qr3 +"','"+qr4+"','" + r1+ "','" + r5 + "')");

            }

            if (((RadioButton)anItem.FindControl("RadioButton2")).Checked)
            {
                r2 = ((RadioButton)anItem.FindControl("RadioButton2")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r2 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r2 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r2 + "','" + r5 + "')");
            }


            if (((RadioButton)anItem.FindControl("RadioButton3")).Checked)
            {
                r3 = ((RadioButton)anItem.FindControl("RadioButton3")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r3 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r3 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r3 + "','" + r5 + "')");
            }

            if (((RadioButton)anItem.FindControl("RadioButton4")).Checked)
            {

                r4 = ((RadioButton)anItem.FindControl("RadioButton4")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r4 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r4 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r4 + "','" + r5 + "')");
            }
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

            string m = Convert.ToString(Session["cno"]);
            con.Open();
            Session["ScoredMarks"] = Convert.ToInt32(marks);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update candidatesdetails1 set marks=" + marks  + ", outtime='" + DateTime.Now.ToShortTimeString() + "'  where cno='" + m + "' and domain='" + domain  + "' and qno='" + qno + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


        }
        string domainn = Session["Domain"].ToString();
        SqlDataReader reader;
        SqlConnection con1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        int fmark=0;
        string m1 = Convert.ToString(Session["cno"]);


      // select distinct qno,marks from candidatesdetails1 where cno='yaso'
        con1.Close();
         con1.Open();
            SqlCommand cmd2 = con1.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = " select max(marks) from candidatesdetails1 where cno='" + m1 + "'";
           reader = cmd2.ExecuteReader();
            if (reader.Read())
            {
             fmark=(Convert.ToInt32(reader[0].ToString()));
            }

            
            reader.Close();
       con1.Close();
        
        con1.Open();
        Session["ScoredMarks"] = Convert.ToInt32(marks);
        Session["ScoredMarks1"] = Convert.ToInt32(fmark );

        
        SqlCommand cmdd = new SqlCommand();
        cmdd.CommandText = "update candidatesdetails set marks=" + fmark  + ", outtime='" + DateTime.Now.ToShortTimeString() + "'  where cno='" + m1 + "' and domain='" + domainn + "'";
        cmdd.Connection = con1;
        cmdd.ExecuteNonQuery();
        con1.Close();
        Response.Redirect("ResultCand.aspx");
			
    
        
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        //When Skip Button is pressed it loads the next question
       // LoadQuestion();
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        //ShowNext();
      //  LoadQuestion();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Process[] pname = Process.GetProcessesByName("ContinuousMonitor");
        if (pname.Length == 0)
        {
            Response.Redirect("Home.aspx");
            //Process.Start(@"D:\Online_Exam\FaceC_2\bin\Debug\ContinuousMonitor.exe");
        }
    }
    protected void DataList1_Click(object sender, EventArgs e)
    {
        Process[] pname = Process.GetProcessesByName("ContinuousMonitor");
        if (pname.Length == 0)
        {
            //Response.Redirect("Home.aspx");
            //Process.Start(@"D:\Online_Exam\FaceC_2\bin\Debug\ContinuousMonitor.exe");
        }
    }
    int k;
    public void timercheck()
    {
        SqlConnection con43 = new SqlConnection("server=.\\sqlexpress;integrated security=true;database=continuous_exam;");

        con43.Open();
        SqlCommand cmd = new SqlCommand("select * from t1", con43);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr[0].ToString().Trim() == "yes")
            {
                Button1.Text = "Paused...";
                Session["result"] = "Pause";
                if ((Convert.ToInt32(TextBox1.Text) < 8) && (Convert.ToInt32(TextBox1.Text) > 2))
                {
                    Button1.Text = "Paused...";
                    Session["result"] = "Pause";
                    //   Timer1.Enabled = false;
                }
                // Button1.Text = "Paused...";

                //Session["result1"] = "";
                k = Convert.ToInt32(TextBox1.Text);
                k++;
                TextBox1.Text = k.ToString();
                if (Convert.ToInt32(TextBox1.Text) > 2)
                {

                    Timer1.Enabled = false;
                    // Timer2.Enabled = true;
                    Response.Redirect("Home.aspx");
                }

                // DisableAllControls(this);


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
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //timercheck();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string r1;
        string r2;
        string r3;
        string r4;
        string r5;
        int marks = 0;


        string domain = Convert.ToString(Session["Domain"]);
        string complexity = Convert.ToString(Session["complexity"]);
        string uid = Convert.ToString(Session["cno"]);
        int mm = 0;
        foreach (DataListItem anItem in DataList1.Items)
        {
            string qno = ((Label)anItem.FindControl("Label2")).Text;
            string ques = ((Label)anItem.FindControl("Label1")).Text;
            // string qno = ((Label)anItem.FindControl("Label2")).Text;
            string qr1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
            string qr2 = ((RadioButton)anItem.FindControl("RadioButton2")).Text;
            string qr3 = ((RadioButton)anItem.FindControl("RadioButton3")).Text;
            string qr4 = ((RadioButton)anItem.FindControl("RadioButton4")).Text;
            r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;

            if (((RadioButton)anItem.FindControl("RadioButton1")).Checked)
            {
                r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r1 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();
                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r1 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r1 + "','" + r5 + "')");

            }

            if (((RadioButton)anItem.FindControl("RadioButton2")).Checked)
            {
                r2 = ((RadioButton)anItem.FindControl("RadioButton2")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r2 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r2 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r2 + "','" + r5 + "')");
            }


            if (((RadioButton)anItem.FindControl("RadioButton3")).Checked)
            {
                r3 = ((RadioButton)anItem.FindControl("RadioButton3")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r3 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r3 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r3 + "','" + r5 + "')");
            }

            if (((RadioButton)anItem.FindControl("RadioButton4")).Checked)
            {

                r4 = ((RadioButton)anItem.FindControl("RadioButton4")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r4 == r5)
                {
                    mm = 1;
                    marks = marks + 1;
                    finalmark = finalmark + 1;
                }
                DataAccess da = new DataAccess();

                da.DBCmdOpen("insert into stureport values ('" + uid + "','" + domain + "','" + complexity + "','" + r4 + "','" + r5 + "')");
                da.DBCmdOpen("insert into cquestion values ('" + uid + "','" + qno + "','" + domain + "','" + ques + "','" + qr1 + "','" + qr2 + "','" + qr3 + "','" + qr4 + "','" + r4 + "','" + r5 + "')");
            }
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

            string m = Convert.ToString(Session["cno"]);
            con.Open();
            Session["ScoredMarks"] = Convert.ToInt32(marks);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update candidatesdetails1 set marks=" + marks + ", outtime='" + DateTime.Now.ToShortTimeString() + "'  where cno='" + m + "' and domain='" + domain + "' and qno='" + qno + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


        }
        string domainn = Session["Domain"].ToString();
        SqlDataReader reader;
        SqlConnection con1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        int fmark = 0;
        string m1 = Convert.ToString(Session["cno"]);


        // select distinct qno,marks from candidatesdetails1 where cno='yaso'
        con1.Close();
        con1.Open();
        SqlCommand cmd2 = con1.CreateCommand();
        cmd2.CommandType = CommandType.Text;
        cmd2.CommandText = " select max(marks) from candidatesdetails1 where cno='" + m1 + "'";
        reader = cmd2.ExecuteReader();
        if (reader.Read())
        {
            fmark = (Convert.ToInt32(reader[0].ToString()));
        }


        reader.Close();
        con1.Close();

        con1.Open();
        Session["ScoredMarks"] = Convert.ToInt32(marks);
        Session["ScoredMarks1"] = Convert.ToInt32(fmark);


        SqlCommand cmdd = new SqlCommand();
        cmdd.CommandText = "update candidatesdetails set marks=" + fmark + ", outtime='" + DateTime.Now.ToShortTimeString() + "'  where cno='" + m1 + "' and domain='" + domainn + "'";
        cmdd.Connection = con1;
        cmdd.ExecuteNonQuery();
        con1.Close();
        Response.Redirect("ResultCand.aspx");
			
    }
}
