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

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["tblname"] = "material";
      Response.Redirect("report.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("uploadmaterial.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["tblname"] = "regis";
        Response.Redirect("report.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["tblname"] = "candidatesdetails1";
        Response.Redirect("report.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("myprofile.aspx");
    }
}
