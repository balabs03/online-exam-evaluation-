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
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class ResultCand : System.Web.UI.Page
{
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string timetaken = "";
        Label1.Text = Convert.ToString(Session["ScoredMarks1"]);
        //select and update time of each attempt
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlConnection con1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

        string m = Convert.ToString(Session["cno"]);
        con1.Open();
        SqlCommand cmd = con1.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select intime,outtime,qno,domain from candidatesdetails1 where cno='" + m + "' order by qno asc";
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            
            double tt ;
            DateTime t1, t2;
            TimeSpan ts;
            try
            {

                 t1 = Convert.ToDateTime(reader[0].ToString());
                 t2 = Convert.ToDateTime(reader[1].ToString());
                 ts = t2.Subtract(t1);
                 tt = Convert.ToDouble(ts.TotalSeconds.ToString());
            }
            catch (Exception exg2)
            {
                tt = 0.0;

            }
            timetaken = tt.ToString();
            con.Close();
                    con.Open();
                                        SqlCommand cmd1 = new SqlCommand();
                                        cmd1.CommandText = "update candidatesdetails1 set time_taken=" + timetaken + " where cno='" + m + "' and domain='" + reader[3].ToString() + "' and qno='" + reader[2].ToString() + "' and qno!=' ' ";
                    cmd1.Connection = con;
                    cmd1.ExecuteNonQuery();
                    con.Close();

                     
        }


        reader.Close();
        con1.Close();
        updateextamtime();
    }

    public void updateextamtime()
    {
        string timetaken = "";
     //   Label1.Text = Convert.ToString(Session["ScoredMarks1"]);
        //select and update time of each attempt
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlConnection con1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

        string m = Convert.ToString(Session["cno"]);
        con1.Open();
        SqlCommand cmd = con1.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select intime,outtime,domain,exam_date,test_no from candidatesdetails where cno='" + m + "' ";
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            DateTime t1 = Convert.ToDateTime(reader[0].ToString());
            DateTime t2 = Convert.ToDateTime(DateTime.Now.ToString());
            TimeSpan ts = t2.Subtract(t1);
            double tt = Convert.ToDouble(ts.TotalSeconds.ToString());
            timetaken = tt.ToString();
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "update candidatesdetails set time_taken=" + timetaken + " where cno='" + m + "' and domain='" + reader[2].ToString() + "' and exam_date='" + reader[3].ToString() + "' and intime='" + reader[0].ToString() + "' and test_no='" + reader[4].ToString() + "' ";
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            con.Close();


        }


        reader.Close();
        con1.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataAccess ad = new DataAccess();
        intCurrIndex.Text = "0";
        ad.DBDataAdapter("select * from stureport where userid='" + Session["cno"].ToString() + "' and domain='" + Session["Domain"].ToString() + "' and complexity='" + Session["complexity"].ToString() + "'", GridView1);
        SqlConnection objConn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlDataAdapter objDA = new SqlDataAdapter("select * from cquestion", objConn);
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
    //    string timetaken = "";
    //    //   Label1.Text = Convert.ToString(Session["ScoredMarks1"]);
    //    //select and update time of each attempt
    //    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");
    //    SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");
    //    con.Open();
    //    SqlCommand cmd = con.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "delete from examreport where cno='" + Session["cno"].ToString() + "'";
    //    cmd.ExecuteNonQuery();
    //    con.Close();


    //    string m = Convert.ToString(Session["cno"]);
    //    con1.Open();
    //     cmd = con1.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = " select qno,time_taken,marks,domain from candidatesdetails1 where cno='" + m + "' ";
    //    reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {

    //        string subdomain = dscall(reader[0].ToString(), reader[3].ToString());

    //        con.Open();
    //        SqlCommand cmd1 = new SqlCommand();
    //        cmd1.CommandText = "insert into examreport values('" + m + "','" + reader[3].ToString() + "','" + subdomain + "','" + reader[1].ToString() + "','" + reader[2].ToString() + "')";
    //        cmd1.Connection = con;
    //        cmd1.ExecuteNonQuery();
    //        con.Close();


    //    }


    //    reader.Close();
    //    con1.Close();


    //    //suggestion
    //    //select subdomain,count(mark)as score from examreport where cno='yaso' group by subdomain order by count(mark) desc
    //    fuzz();
    //    fuzz1();

    //    //dscall1();

    //}
    //public void dscall1(string qno, string domain)
    //{
    //    string subdo = "";
    //    SqlConnection con3 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

    //    SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");
    //    SqlDataReader reader;
    //    SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

    //    con2.Open();
    //    SqlCommand cmd = con2.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = " select material_id,count(material_id) from training group by material_id order by  count(material_id)  desc";
    //    reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        string st = "select filename,filepath from material where filename='" + reader[0].ToString() + "'";

    //        SqlCommand comd = con1.CreateCommand();
    //        comd.CommandType = CommandType.Text;
    //        comd.CommandText = st;
    //        con1.Open();
    //        SqlDataReader reader1;
    //       reader1 = comd.ExecuteReader();
    //     if (reader1.Read())
    //        {
    //            string atta = reader1[0].ToString();
    //            string atta1 = reader1[1].ToString();
    //            mail(atta, atta1);
    //        }
    //     reader1.Close();
    //        con1.Close();
    //    }
    }

    public void mail(string emailid, string msge)
    {
        string email = Session["email"].ToString();
        string pwd;

        Random rp = new Random();
        MailMessage msg = new MailMessage();
        msg.To.Add(email);
        msg.From = new MailAddress("hasidata@gmail.com");
        msg.Subject = "Suggestion from E-Learning system..";
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(msge);
        msg.Attachments.Add(attachment);


     //   msg.Attachments.Add (System.Net.Mail.Attachment.(msge));
        pwd = rp.Next(11111, 99999).ToString();
        msg.Body = "Hi ..we have attached some materials for your reference..pls find the attachment";



        SmtpClient cli = new SmtpClient("smtp.gmail.com", 587);
        cli.EnableSsl = true;
        NetworkCredential nc = new NetworkCredential("hasidata@gmail.com", "ranji@276");
        cli.Credentials = nc;
        try
        {
            cli.Send(msg);
        }
        catch (Exception ex)
        { }
        //   Label1.Text = ("QRcode sent to user through Mail!!!!");


    }

    //public void fuzz()
    //{
    //    SqlCommand cmd;
    //    SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");
    //    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

    //    string m = Convert.ToString(Session["cno"]);
    //    con1.Open();
    //    cmd = con1.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "select subdomain,count(mark)as score from examreport where cno='" + m + "' group by subdomain order by count(mark) desc  ";
    //    reader = cmd.ExecuteReader();
    //    if (reader.Read())
    //    {

    //       // string subdomain = dscall(reader[0].ToString(), reader[3].ToString());

    //        TextBox1.Text = ("Report:" + Environment.NewLine + "Strong Area: Subdomain : " + reader[0].ToString() + Environment.NewLine + reader[1].ToString());
    //        con.Open();
    //        SqlCommand cmd1 = new SqlCommand();
    //        cmd1.CommandText = "select * from dependency where subdomain='" + reader[0].ToString() + "' or subdomain1='" + reader[0].ToString() + "' order by dependency_value desc ";
    //        cmd1.Connection = con;
    //        SqlDataReader dr = cmd1.ExecuteReader();
    //        if (dr.Read())
    //        {
    //            TextBox1.Text = ("Most useful learning areas:" + Environment.NewLine + " Subdomain : " + dr[1].ToString() + Environment.NewLine + dr[3].ToString());

    //        }





    //        con.Close();

    //    }


    //    reader.Close();
    //    con1.Close();

    //}

    //public void fuzz1()
    //{
    //    SqlCommand cmd;
    //    SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

    //    string m = Convert.ToString(Session["cno"]);
    //    con1.Open();
    //    cmd = con1.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "select subdomain,count(mark)as score from examreport where cno='" + m + "' group by subdomain order by count(mark) asc  ";
    //    reader = cmd.ExecuteReader();
    //    if (reader.Read())
    //    {

    //        // string subdomain = dscall(reader[0].ToString(), reader[3].ToString());

    //        TextBox2.Text = ("Report:" + Environment.NewLine + "Weak Area: Subdomain : " + reader[0].ToString() + Environment.NewLine + reader[1].ToString());
    //        dscall1(reader[0].ToString(), reader[1].ToString());

    //    }


    //    reader.Close();
    //    con1.Close();

    //}
    public static string  dscall(string qno,string domain)
    {
        string subdo="";
        SqlConnection con2 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlDataReader reader;
        con2.Open();
        SqlCommand cmd = con2.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select subdomain from question where qno='" + qno + "' and domain='"+ domain +"' ";
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            subdo = reader[0].ToString();
        }
        reader.Close();
        con2.Close();
        return subdo;
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
