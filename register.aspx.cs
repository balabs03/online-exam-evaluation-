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
using System.Diagnostics;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces/face12.bmp");

        ////         string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");
        //DataAccess da = new DataAccess();
        //SqlDataReader drr = da.DBReaderOpen("select * from successdb1");
        //while (drr.Read())
        //{
        //    if (File.Exists(simg))
        //    {
        //        // BindImage(simg);
                
        //        // ImageButton1.ImageUrl = simg + "\temp.jpg";
        //       // Image1.Src  = "E:/Online_Exam_18/FaceC/bin/Debug/TrainedFaces/" + drr[0].ToString();
        //        Image1.Src = "~/FaceC/bin/Debug/TrainedFaces/face12.bmp";
        //        Timer1.Enabled = false;
        //        //  TextBox1.Text = simg + "\temp.jpg";
        //        //     Timer1.Enabled = false;

        //    }
        //}
    }
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txtuserid.Text != "") && (TextBox1.Text != "") && (TextBox2.Text != "") && (TextBox3.Text != "") && (TextBox4.Text != "") && (TextBox5.Text != "") && (DropDownList1.Text  != "") && (DropDownList2.Text  != ""))
            {
                if (TextBox4.Text.Length == 10)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into regis values('" + txtuserid.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','"+DropDownList2.Text  +"','"+DropDownList1.Text +"','"+txtuserid.Text +"','"+txtpass.Text +"')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //ulogin();

                  
                    Response.Write("<script language='javascript'> alert('Registration Completed..')</script>");

                    //  Response.Write("<script>alert('Register successful');</script>");
                    // Response.Write("Register Sucessfully Completed");
                    try
                    {
                        string mss="Dear.."+TextBox1.Text +"..Welcome to the online exam Application..Thank you  for registering in our website...";
                        mail(TextBox5.Text, mss);

                    }
                    catch (Exception ex)
                    {

                    }



                    Response.Redirect("home.aspx");
                }
                else
                {

                }
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Enter all details..')</script>");


            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'> alert('User id already exists...Try some other id..')</script>");
        }


    }
   
      
public void mail(string emailid, string msge)
    {
        string email = emailid;
        string pwd;

        Random rp = new Random();
        MailMessage msg = new MailMessage();
        msg.To.Add(email);
        msg.From = new MailAddress("hasidata@gmail.com");
        msg.Subject = "Greetings from E-Learning system..";
        pwd = rp.Next(11111, 99999).ToString();
        msg.Body = msge;



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

    public void ulogin()
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into login values('" + txtuserid.Text + "','" + txtpass.Text + "','"+TextBox5.Text +"')";
        cmd.ExecuteNonQuery();
       // Response.Redirect("Register Sucessfully Completed");
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        txtuserid.Text = "";
        txtpass.Text = "";
        TextBox8.Text = "";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DataAccess sd = new DataAccess();
        sd.DBCmdOpen("delete from temp");
        sd.DBCmdOpen("insert into temp values('" + txtuserid.Text + "')");
        string fpath = Server.MapPath(@"FaceC\bin\Debug\MultiFaceRec.exe");
        Process.Start(fpath);
        Timer1.Enabled = true;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");

//         string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");
        DataAccess da = new DataAccess();
        SqlDataReader drr = da.DBReaderOpen ("select * from successdb1");
        while (drr.Read())
        {
            if (File.Exists(simg + "\\" + drr[0].ToString()))
            {
                // BindImage(simg);

                // ImageButton1.ImageUrl = simg + "\temp.jpg";
                Image1.Src  = "~/FaceC/bin/Debug/TrainedFaces" + "/" +drr[0].ToString();
                Timer1.Enabled = false;
                //  TextBox1.Text = simg + "\temp.jpg";
                //     Timer1.Enabled = false;

            }
        }
       
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {

    }
   
}
