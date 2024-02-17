using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Windows.Forms;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

public partial class CreateUser : System.Web.UI.Page
{
    SqlConnection SqlConnectionObj = new SqlConnection("server=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True;");

    string ConnString = "server=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True;";
    public SqlConnection Conn;
    public SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
   

    protected void BtnCreateAccount_Click(object sender, EventArgs e)
    {
        //Conn = new SqlConnection(ConnString);
        //string MailId = "invalid";
        //string Genders = "Gender";

        
      

        //        if (TxtUserName.Text != "")
        //        {
        //            CheckUserName();
        //            MailId = TxtUserName.Text.Replace(" ", "");
        //        }
        //        if (RBtnMale.Checked == true)
        //        {
        //            Genders = "Male";
        //        }
        //        else
        //        {
        //            Genders = "Female";
        //        }
        //        if (Convert.ToInt32(TxtPwd.Text.Trim().Length) > 6)
        //        {
        //             string val1 = enc(txtdob.Text );
        //       string val2 = enc(TxtPwd.Text );

        //       TxtPwd.Text = val2;
        //            string insertQuery = "insert into userdetails(UserName,UserPassword,FirstName,LastName,Gender,Address,Country,PhoneNum,DateOfEntry,EmailId) values('" + TxtUserName.Text.ToLower() + "','" + TxtPwd.Text.ToLower() + "','" + TxtFirstName.Text + "','" + TxtLastName.Text + "','" + Genders + "','" + TxtAddress.Text + "','" + TxtCountry.Text + "','" + TxtPhoneNum.Text + "','" + System.DateTime.Today.ToShortDateString() + "','" + MailId + "')";
        //            cmd = new SqlCommand(insertQuery, Conn);
        //            Conn.Open();
        //            cmd.ExecuteNonQuery();
        //            Conn.Close();
        //            //insertQuery = "insert into userTable(UserName,UserPassword,uploadRights,viewRights,ForwardRights,dob,SecurityQuestion,SecurityAnswer,DateofLastAccess) values('" + TxtUserName.Text.ToLower() + "','" + TxtPwd.Text.ToLower() + "','no','no','no','" + DropSecurityQu.Text + "','" + TxtAnswer.Text + "','" + System.DateTime.Today.ToShortDateString() + "','" + txtdob.Text + "')";
        //            //cmd = new SqlCommand(insertQuery, Conn);
        //            //Conn.Open();
        //            //cmd.ExecuteNonQuery();
        //            //Conn.Close();
        //            Session["UserName"] = TxtUserName.Text;
        //            Session["TestData"] = TxtUserName.Text + " is your Login ID";
        //            Response.Redirect("login.aspx");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Password must be minimum 6 characters.");
        //            return;
        //        }
          
       

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("Admin.aspx");
    }
    protected void BtnCheck_Click(object sender, EventArgs e)
    {
       
    }
    public string enc(string strings)
    {
        String strs = strings;
        Double seed = 1;

        Double hash = 0;
        String StrHash = "";

        char[] str = strs.ToCharArray();

        for (int i = 0; i < strs.Length; i++)
        {

            int str1 = str[i];
            Double l = Convert.ToDouble(str1);
            hash = (hash * seed) + l;
            StrHash = StrHash + hash + "#";


        }

        strings = StrHash;
        return (strings);
    }
    protected void BtnCreateAccount0_Click(object sender, EventArgs e)
    {
        Response.Redirect("privacymodel.aspx");
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        string connString = "";
      //  string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
      //  string path = fileuploadExcel.PostedFile.FileName;
        //Connection String to Excel Workbook
        //if (strFileType.Trim() == ".xls")
        //{
           // connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= D:\Elearning\fuzzy\fuzzy.xls;Extended Properties=Excel 8.0";

        //}
        //else if (strFileType.Trim() == ".xlsx")
        //{
        //    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= D:\outlier.xlsx;Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //}
        string query = "SELECT * FROM [Sheet1$]";
        OleDbConnection conn = new OleDbConnection(connString);
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        OleDbCommand cmd = new OleDbCommand(query, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grvExcelData.DataSource = ds.Tables[0];
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        BulkInserSheet3Table("question", dt);

        grvExcelData.DataBind();
        da.Dispose();
        conn.Close();
        conn.Dispose();
    }
    public bool BulkInserSheet3Table(string tableName, DataTable dataTable)
    {
        bool isSuccuss;
        try
        {
            SqlConnection SqlConnectionObj = new SqlConnection("server=.\\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True;");

            SqlConnectionObj.Open();
            // SqlConnection SqlConnectionObj = GetSQLConnection();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionObj, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.WriteToServer(dataTable);
            isSuccuss = true;
            SqlConnectionObj.Close();
        }
        catch (Exception ex)
        {
            isSuccuss = false;
        }
        return isSuccuss;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("sup.aspx");

        string connString = "";
        //  string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //  string path = fileuploadExcel.PostedFile.FileName;
        //Connection String to Excel Workbook
        //if (strFileType.Trim() == ".xls")
        //{
        // connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= D:\Elearning\fuzzy\fuzzy.xls;Extended Properties=Excel 8.0";

        //}
        //else if (strFileType.Trim() == ".xlsx")
        //{
        //    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= D:\outlier.xlsx;Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //}
        string query = "SELECT * FROM [Sheet2$]";
        OleDbConnection conn = new OleDbConnection(connString);
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        OleDbCommand cmd = new OleDbCommand(query, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grvExcelData.DataSource = ds.Tables[0];
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        BulkInserSheet3Table("dependency", dt);

        grvExcelData.DataBind();
        da.Dispose();
        conn.Close();
        conn.Dispose();
    }
}
