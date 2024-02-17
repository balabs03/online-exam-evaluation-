<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table class="style2">
        <tr>
            <td>
                Welcome to Online Exam</td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="159px" ImageUrl="~/images/10.jpg" 
                    Width="825px" />
            </td>
        </tr>
    </table>
</asp:Content>


