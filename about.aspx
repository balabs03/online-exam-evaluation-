<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-family: "Times New Roman", Times, serif;
        }
        .style5
        {
            width: 100%;
        }
 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
span.style61
	{color:purple;
        }
span.style11
	{font-family:"Times New Roman","serif";
	}
span.style51
	{color:purple;
	font-weight:bold;
        }
span.style41
	{color:purple;
	font-weight:bold;
        }
        .style6
        {
            color: blue;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table class="style5">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="191px" ImageUrl="~/images/7.jpg" 
                    Width="919px" />
            </td>
        </tr>
        <tr>
            <td>
                <p class="MsoNormal" style="text-align:justify;text-justify:inter-ideograph;
text-indent:.5in">
                    <span class="style61"><b><span style="font-size:18.0pt;
line-height:115%">Elearning.com was started by three college students, who are preparing for their 
                    graduation. They inspire to begin search for the new opportunity, and Online 
                    Exam.com was born.Online Exam continues to expand and you will see more 
                    available resources to help you guarantee success on your upcomingventure.
                    </span></b></span><b>
                    <span style="font-size:18.0pt;line-height:
115%;color:purple">
                    <br />
                    <span class="style61">For comment or questions regarding Online Exam.com please
                    </span></span></b><span class="style11"><b>
                    <span style="font-size:18.0pt;line-height:115%;color:black"><a class="style6" 
                        href="contactpage.aspx" style="text-underline: single;">
                    <span class="style51">
                    <span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi">Contact Us</span></span></a></span></b></span><span class="style41"><span 
                        style="font-size:18.0pt;line-height:115%"> and we will respond to you 
                    promptly.<o:p></o:p></span></span></p>
            </td>
        </tr>
    </table>
</asp:Content>


