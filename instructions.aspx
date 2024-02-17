<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="instructions.aspx.cs" Inherits="instructions" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style14
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <table class="style14">
            <tr>
                <td>
                    <asp:Image ID="Image2" runat="server" Height="160px" ImageUrl="~/images/3.jpg" 
                        Width="485px" />
                </td>
            </tr>
            <tr>
                <td>
                    Welcome:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Announce Something to Your Class</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="118px" TextMode="MultiLine" 
                        Width="485px"></asp:TextBox>
                </td>
            </tr>
        </table>
        Upload Your File
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Submit" />
    <br />
</p>
</asp:Content>

