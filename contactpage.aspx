<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="contactpage.aspx.cs" Inherits="contactpage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-family: "Times New Roman", Times, serif;
            text-align: justify;
        }
    .style2
    {
        font-size: large;
    }
    .style3
    {
        color: #800080;
    }
    .style4
    {
        color: #800080;
        font-weight: bold;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table>
            <tr>
                <td width="950">
                    <center>
                        <font color="brown" size="5"><b><u>Contact Us</u>&nbsp;&nbsp; :</b></font></center>
                </td>
            </tr>
        </table>
        <br />
        <table border="2" width="center">
            <tr>
                <td class="style1" width="80%">
                    <font size="4" class="style2"><span class="style4">Online Exam exists to serve the education and testing markets, 
                    which include students, and professionals eagerly seeking to prepare for exams. 
                    Our easy-to-use advanced web technology immediately helps our users prepare for 
                    exams by providing sample tests and recognized resources to prepare. It is 
                    crucial that every one of our users are truly satisfied by getting real use from 
                    our site every time they visit.
                    </span><b>
                    <br class="style3" />
                    <br class="style3" />
                    </b><span class="style4">In order to achieve and maintain the highest customer satisfaction 
                    possible,Online Exam will be constantly innovating and improving the information 
                    and services our users want and need. This is why we invite all customers to
                    </span>
                    <a href="continuous_exam/feedback.aspx"><span class="style4">Provide Feedback</span></a><span 
                        class="style4"> via any method; so 
                    Online Exam can serve the needs and wants that will create the most 
                    comprehensive online testing community.
                    </span><b>
                    <br class="style3" />
                    <br class="style3" />
                    </b><span class="style4">WebSite Support :</span> <a href="http://www.onlineexam.com">
                    <span class="style4">OnlineExam.com</span></a>
                    <b>
                    <br class="style3" />
                    <br class="style3" />
                    </b><span class="style4">Send Mail to:</span> <a href="mailto:exam@yahoo.com">
                    <span class="style4">exam@yahoo.com </span> </a></font>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

