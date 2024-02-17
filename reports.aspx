<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="reports" Title="Untitled Page" %>

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
    .style4
    {}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" bgcolor="White">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style4" rowspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="Button3" runat="server" Height="28px" onclick="Button3_Click" 
                Text="Assignment" Width="145px" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="User Test Report" />
        </td>
        <td class="style4" rowspan="2">
            <asp:GridView ID="GridView1" runat="server" 
                style="font-family: 'Times New Roman', Times, serif" Height="92px" 
                Width="723px">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="User score report" />
        </td>
    </tr>
</table>
</asp:Content>

