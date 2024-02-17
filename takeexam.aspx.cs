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
using System.Text;


public partial class takeexam : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Label mess;

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion
    long timerStartValue = 1800;
    
    void Page_PreRender(object sender, EventArgs e)
    {
        StringBuilder bldr = new StringBuilder();
        bldr.AppendFormat("var Timer = new myTimer({0},{1},'{2}','timerData');", this.timerStartValue, this.TimerInterval, this.lblTimerCount.ClientID);
        bldr.Append("Timer.go()");
        ClientScript.RegisterStartupScript(this.GetType(), "TimerScript", bldr.ToString(), true);
        ClientScript.RegisterHiddenField("timerData", timerStartValue.ToString());
    }

    void Page_PreInit(object sender, EventArgs e)
    {
        string timerVal = Request.Form["timerData"];
        if (timerVal != null || timerVal == "")
        {
            timerVal = timerVal.Replace(",", String.Empty);
            timerStartValue = long.Parse(timerVal);
        }
    }

    private Int32 TimerInterval
    {
        get
        {
            object o = ViewState["timerInterval"];
            if (o != null) { return Int32.Parse(o.ToString()); }
            return 50;
        }
        set { ViewState["timerInterval"] = value; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //1800000
            this.timerStartValue = 1800000;
            this.TimerInterval = 500;
            intPageSize.Text = "10";
            intCurrIndex.Text = "0";
            Label3.Text = "60";
            DataBinds();
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into candidatesdetails values('" + Session["cno"].ToString() + "','" + Session["Domain"].ToString() + "','0','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString()+ "','null')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void DataBinds()
    {
        string domain = Convert.ToString(Session["Domain"]);
        SqlConnection objConn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
        SqlDataAdapter objDA = new SqlDataAdapter("select * from question where domain='" + domain + "'", objConn);
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
    }

    public void ShowFirst(object s, EventArgs e)
    {
        intCurrIndex.Text = "0";
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
        DataBinds();
    }

    public void ShowNext(object s, EventArgs e)
    {
        if (Convert.ToInt16(intCurrIndex.Text) + 1 < Convert.ToInt16(intRecordCount.Text))
        {


            intCurrIndex.Text = Convert.ToString(Convert.ToInt16(intCurrIndex.Text) + Convert.ToInt16(intPageSize.Text));
        }
        DataBinds();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string r1;
        string r2;
        string r3;
        string r4;
        string r5;
        int marks = 0;


        foreach (DataListItem anItem in DataList1.Items)
        {
            if (((RadioButton)anItem.FindControl("RadioButton1")).Checked)
            {
                r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r1 == r5)
                {
                    marks = marks + 1;
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
        string domainn=Session["Domain"].ToString();

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

        string m = Convert.ToString(Session["cno"]);
        con.Open();
        Session["ScoredMarks"] = Convert.ToInt32(marks);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update candidatesdetails set marks=" + marks + ", outtime='"+DateTime.Now.ToShortTimeString()+"'  where cno='" + m + "' and domain='"+domainn +"'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("ResultCand.aspx");
			

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label3.Text = ((Convert.ToInt32(Label3.Text)) - 1).ToString();
        if(Convert.ToInt32(Label3.Text)==0)
        {
            Response.Write("your time is over...");
            Timer1.Enabled = false;
             string r1;
        string r2;
        string r3;
        string r4;
        string r5;
        int marks = 0;


        foreach (DataListItem anItem in DataList1.Items)
        {
            if (((RadioButton)anItem.FindControl("RadioButton1")).Checked)
            {
                r1 = ((RadioButton)anItem.FindControl("RadioButton1")).Text;
                r5 = ((TextBox)anItem.FindControl("TextBox1")).Text;
                if (r1 == r5)
                {
                    marks = marks + 1;
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
        string domainn=Session["Domain"].ToString();

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=continuous_exam;Integrated Security=True");

        string m = Convert.ToString(Session["cno"]);
        con.Open();
        Session["ScoredMarks"] = Convert.ToInt32(marks);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update candidatesdetails set marks=" + marks + ", outtime='"+DateTime.Now.ToShortTimeString()+"'  where cno='" + m + "' and domain='"+domainn +"'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("ResultCand.aspx");
            
        }

    }
}
