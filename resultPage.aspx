<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="resultPage.aspx.cs" Inherits="resultPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 193px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="User Test Report" />
            </td>
            <td class="style4" rowspan="2">
                <asp:GridView ID="GridView1" runat="server" 
                style="font-family: 'Times New Roman', Times, serif">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

