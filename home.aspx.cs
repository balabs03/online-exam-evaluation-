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
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Threading;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            Process.Start(@"D:\Online_Exam\tk.bat");
            DataAccess da = new DataAccess();
            da.DBCmdOpen("delete from successdb1");
            da.DBCmdOpen("delete from t1");
            da.DBCmdOpen("delete from temp1");
            da.DBCmdOpen("delete from temp");
        }
    }
    SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
    SqlDataReader reader;
    
    protected void BtnSbmt_Click1(object sender, EventArgs e)
    {

       
        if ((TxtUser.Text == "admin") && (TxtPwd.Text == "admin"))
        {
           
            
            Response.Write("<script language='javascript'> alert('Login Succeeded ..')</script>");

           // Response.Write("<script>alert('admin login successful');</script>");
            Session["uid"] = TxtUser.Text;
            Session["username"] ="admin";
            Response.Redirect("aadmin.aspx");
        }
        else
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " Select userid,username,password from regis where userid='" + TxtUser.Text + "' and password ='" + TxtPwd.Text + "'  ";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Session["uid"] = reader[0].ToString();
                Session["uname"] = reader[1].ToString();
                Session["username"] = TxtUser.Text;
                Session["cno"] = TxtUser.Text;
                DataAccess da = new DataAccess();
                da.DBCmdOpen("insert into temp values('"+ TxtUser.Text +"')");
              
                Response.Redirect("exam.aspx");
            }

            else
            {
                Response.Write("<script language='javascript'>alert('Invalid userid and password..')</script>");

              //  Response.Write("<script>alert('invaild user name or password');</script>");

            }
            reader.Close();
        }
        con.Close();


    }
    protected void TxtPwd_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //string simg = Server.MapPath("~/FaceC/bin/Debug/TrainedFaces");
        //DataAccess da = new DataAccess();
        //SqlDataReader drr = da.DBReaderOpen ("select * from temp1 where uiid!='' and uiid='"+TxtUser.Text +"'");
        //while (drr.Read())
        //{
        //    string uid = drr[0].ToString();
        //    if (File.Exists(@"D:\Online_Exam\FaceC\bin\Debug\TrainedFaces\"+drr[0].ToString() +".bmp"))
        //    {
        //        if (drr[0].ToString() == TxtUser.Text)
        //        {
        //        //    // BindImage(simg);

        //            // ImageButton1.ImageUrl = simg + "\temp.jpg";
        //            //Image1.ImageUrl = simg + "/" +drr[0].ToString();
        //            Session["fid"] = drr[0].ToString();
        //            Timer1.Enabled = false;
        //               Process.Start(@"D:\Online_Exam\tk.bat");
        //            Thread.Sleep(1000);
        //            Response.Redirect("exam.aspx");
        //   }
        //        //  TextBox1.Text = simg + "\temp.jpg";
        //        //     Timer1.Enabled = false;

        //}
        //}
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        eid();
        if (TextBox1.Text == Label3.Text)
        {
            email();
            Panel1.Visible = false;
        }
        else
        {
            Response.Write("<script>alert('Invalid Email Id')</script>");
            Panel1.Visible = false;
        }
        
    }
    private void email()
    {
        try
        {
            con.Close();
            con.Open();
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("hasidata@gmail.com", "ranji@2766");
            mail.To.Add(Label3.Text);
            mail.Subject = "Username and Password Reminder Mail";
            mail.From = new System.Net.Mail.MailAddress("hasidata@gmail.com");
            mail.IsBodyHtml = true; // Aceptamos HTML
            mail.Body = "Dear Customer:Your user name is: '" + Label4.Text  + "',and Password:'" + Label5.Text  + "'. Thank You";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred; //asignamos la credencial
            smtp.Send(mail);
            Response.Write("<script>alert('Mail Send Successfully)</script>");
            con.Close();
        }

        catch (Exception)
        {

        }
 
    }
    private void eid()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("select role,userid,password from login where userid='" + TxtUser.Text + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Label3.Text = (dr[0].ToString());
            Label4.Text = (dr[1].ToString());
            Label5.Text = (dr[2].ToString());
        }
        con.Close();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}
