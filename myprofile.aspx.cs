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
using ZedGraph;
using ZedGraph.Web;
using System.Drawing;


public partial class myprofile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;integrated security=true;database=continuous_exam");

    protected void Page_Load(object sender, EventArgs e)
    {
        //Label7.Text = "admin";

        if (Page.IsPostBack == false)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct userid from regis order by userid asc", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr[0].ToString());
            }
            con.Close();
        }
      

    }
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
        this.ZedGraphWeb1.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph1);
        //this.ZedGraphWeb2.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler( this.OnRenderGraph2 );
        this.ZedGraphWeb2.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph2);

    }
    #endregion

    private void OnRenderGraph1(ZedGraph.Web.ZedGraphWeb z, System.Drawing.Graphics g, ZedGraph.MasterPane masterPane)
    {
        // Get the GraphPane so we can work with it
        GraphPane myPane = masterPane[0];

        // Set the title and axis labels        
        myPane.XAxis.Title.Text = "Filename";
        myPane.YAxis.Title.Text = "Time(sec)";



        DataTable dtOrderMonitoring = new DataTable();

       
        con.Open();
        SqlCommand cmd = new SqlCommand("Select file_name,completion_time from labreport where roll_number='" +DropDownList1.Text  + "' order by file_name asc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dtOrderMonitoring);
       
        dtOrderMonitoring.AcceptChanges();

        int n = dtOrderMonitoring.Rows.Count;

        string[] labels = new string[n];
        double[] xAxis = new double[n];
        double[] Yaxis = new double[n];
        
        for (int counter = 0; counter < n; counter++)
        {
            labels[counter] = dtOrderMonitoring.Rows[counter]["file_name"].ToString();
           // xAxis[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["file_name"].ToString());
            xAxis[counter] = double.Parse(counter.ToString());
            Yaxis[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["completion_time"].ToString());
            //Rejected[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Rejected"].ToString());
            //Accepted[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Accepted"].ToString());
            //Inputs[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Inputs"].ToString());

        }

        BarItem  obarItem;
        obarItem = myPane.AddBar ("Completion Time", xAxis, Yaxis , Color.Purple);
        

        // Set the XAxis labels
        myPane.XAxis.Scale.TextLabels = labels;
        // Set the YAxis to Text type
        myPane.XAxis.Type = AxisType.Text;
        // Draw the X tics at the labels
        myPane.XAxis.MajorTic.IsBetweenLabels = false;

        // Fill the axis background with a color gradient
      //  myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 45.0F);

        masterPane.AxisChange(g);
        con.Close();
    }
    private void OnRenderGraph2(ZedGraph.Web.ZedGraphWeb z, System.Drawing.Graphics g, ZedGraph.MasterPane masterPane)
    {
        // Get the GraphPane so we can work with it
        GraphPane myPane = masterPane[0];

        // Set the title and axis labels        
        myPane.XAxis.Title.Text = "Roll Number";
        myPane.YAxis.Title.Text = "Attempts";



        DataTable dtOrderMonitoring = new DataTable();


        con.Open();
        SqlCommand cmd = new SqlCommand("Select roll_number,count(roll_number) as Freq from labreport group by roll_number ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dtOrderMonitoring);

        dtOrderMonitoring.AcceptChanges();

        int n = dtOrderMonitoring.Rows.Count;

        string[] labels = new string[n];
        double[] xAxis = new double[n];
        double[] Yaxis = new double[n];

        for (int counter = 0; counter < n; counter++)
        {
            labels[counter] = dtOrderMonitoring.Rows[counter]["roll_number"].ToString();
           // xAxis[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["roll_number"].ToString());
            xAxis[counter] = double.Parse(counter.ToString());
            Yaxis[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["freq"].ToString());
            //Rejected[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Rejected"].ToString());
            //Accepted[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Accepted"].ToString());
            //Inputs[counter] = double.Parse(dtOrderMonitoring.Rows[counter]["Inputs"].ToString());

        }

        BarItem obarItem;
        obarItem = myPane.AddBar("attempts", xAxis, Yaxis, Color.Blue  );


        // Set the XAxis labels
        myPane.XAxis.Scale.TextLabels = labels;
        // Set the YAxis to Text type
        myPane.XAxis.Type = AxisType.Text;
        // Draw the X tics at the labels
        myPane.XAxis.MajorTic.IsBetweenLabels = false;

        // Fill the axis background with a color gradient
     // myPane.Chart.Fill = new Fill(Color.Red , Color.FromArgb(255, 255, 166), 45.0F);

        masterPane.AxisChange(g);
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select regis.name,regis.userid,regis.College,regis.department,regis.emailid from regis where userid='" + DropDownList1.Text + "' ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            Label1.Text = dr[0].ToString();
            Label2.Text = dr[1].ToString();
            Label3.Text = dr[2].ToString();
            //if (Label3.Text == "Female")
            //{
            //    Image1.ImageUrl = "images/Female.jpg";
            //}
            //else
            //{
            //    Image1.ImageUrl = "images/male.jpg";

            //}
            Label4.Text = dr[3].ToString();
                       Label8.Text = dr[4].ToString();
            //Image1.ImageUrl = dr[8].ToString();
        }
        else
        {
            Response.Write("<script>alert('Invalid... ')</script>");


        }
        con.Close();
    }
}
