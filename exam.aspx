<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="exam.aspx.cs" Inherits="exam" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 58%;
            font-family: "Times New Roman", Times, serif;
        height: 74px;
    }
        .style4
    {
        height: 68px;
    }
        .style6
        {
            height: 74px;
        }
        .style7
        {
            width: 213px;
            height: 24px;
        }
        .style8
        {
            height: 24px;
        }
    .style9
    {
        height: 68px;
        width: 213px;
    }
    .style17
    {
        height: 24px;
        width: 121px;
    }
    .style18
    {
        height: 40px;
        width: 121px;
    }
    .style19
    {
        width: 35px;
    }
    .style20
    {
        height: 11px;
        width: 373px;
    }
    .style21
    {
        height: 11px;
        width: 121px;
    }
    .style22
    {
        width: 121px;
    }
    .style23
    {
        width: 34px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style22">
                <asp:Label ID="Label1" runat="server" Text="Select Category"></asp:Label>
            </td>
            <td class="style23">
                <asp:Button ID="Button2" runat="server" BackColor="#009900" Height="35px" 
                    Text="C" Width="79px" onclick="Button2_Click" />
            </td>
            <td class="style19">
                <asp:Button ID="Button3" runat="server" BackColor="#FF9900" Height="37px" 
                    Text="C++" Width="84px" onclick="Button3_Click" />
            </td>
            <td class="style19">
                <asp:Button ID="Button4" runat="server" BackColor="#CC0000" Height="36px" 
                    Text="Java" Width="79px" onclick="Button4_Click" />
            </td>
            <td class="style19">
                <asp:Button ID="Button5" runat="server" BackColor="#FF6699" Height="39px" 
                    Text="Dotnet" Width="75px" onclick="Button5_Click" />
            </td>
            <td class="style19">
                <asp:Button ID="Button6" runat="server" BackColor="#33CCFF" Height="36px" 
                    Text="PHP" Width="73px" onclick="Button6_Click" />
            </td>
        </tr>
        <tr>
            <td class="style21">
            &nbsp;</td>
            <td class="style20" colspan="5">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="117px" 
                    Width="355px" Visible="False">
                    <asp:ListItem>Dotnet</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>C++</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>-Select-</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style17">
                Level</td>
            <td class="style8" colspan="5">
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="a" Text="Low" 
                    AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" />
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="a" Text="Medium" 
                    AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" />
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="a" Text="High" 
                    AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" />
            &nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td colspan="5">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Start Exam" Width="131px" Height="34px" />
            </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td colspan="5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

