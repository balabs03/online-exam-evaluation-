<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 182px;
            width: 801px;
            font-family: "Times New Roman", Times, serif;
        }
        .style2
        {
            height: 30px;
        }
        .style3
        {
        width: 255px;
    }
        .style4
        {
            height: 30px;
            width: 255px;
        }
        .style5
        {
            width: 146px;
            height: 26px;
        }
        .style6
        {
            height: 6px;
        }
        .style7
        {
            width: 255px;
            height: 6px;
        }
    .style8
    {
        width: 255px;
        height: 32px;
    }
    .style9
    {
        height: 32px;
    }
    .style10
    {
        height: 32px;
        width: 125px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" bgcolor="White" border="3" 
        style="font-family: 'Times New Roman', Times, serif">
        <tr>
            <td class="style5" colspan="5">
                <asp:Label ID="Label1" runat="server" ForeColor="Black" 
                    style="z-index: 1; left: -42px; top: 348px; font-size: x-large; font-style: italic;" 
                    Text="Question Bank" Font-Bold="False" Font-Size="Medium"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label2" runat="server" 
                    style="z-index: 1; left: 165px; top: 774px; right: 770px" Text="Domain"></asp:Label>
            </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="144px" 
                    AutoPostBack=true 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                    <asp:ListItem>Dotnet</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>C++</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style9">
                <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="144px" 
                    AutoPostBack=true 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    Visible="False" >
                    <asp:ListItem>Introduction</asp:ListItem>
                    <asp:ListItem>DataTypes</asp:ListItem>
                    <asp:ListItem>Control Statements</asp:ListItem>
                    <asp:ListItem>Exception Handling</asp:ListItem>
                    <asp:ListItem>Array</asp:ListItem>
                    <asp:ListItem>Functions</asp:ListItem>
                    <asp:ListItem>Structure</asp:ListItem>
                    <asp:ListItem>IO</asp:ListItem>
                    <asp:ListItem>Pointers</asp:ListItem>
                    <asp:ListItem>OOPS</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style9">
                Tough Level</td>
            <td class="style9">
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Question Number</td>
            <td colspan="4">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" 
                    style="z-index: 1; left: 284px; top: 778px; "></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" 
                    style="z-index: 1; left: 206px; top: 461px;" Text="Question"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="TextBox2" runat="server" 
                    style="z-index: 1; left: 176px; top: 867px; " Width="575px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label4" runat="server" 
                    style="z-index: 1; left: 50px; top: 876px;" Text="Option1"></asp:Label>
            </td>
            <td class="style2" colspan="4">
                <asp:TextBox ID="TextBox3" runat="server" 
                    style="z-index: 1; left: 118px; top: 833px; right: 729px;" Width="574px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label5" runat="server" 
                    style="z-index: 1; left: 38px; top: 887px;" Text="Option2"></asp:Label>
            </td>
            <td class="style6" colspan="4">
                <asp:TextBox ID="TextBox4" runat="server" Height="39px" 
                    style="z-index: 1; left: 371px; top: 647px; height: 22px;" Width="573px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label6" runat="server" 
                    style="z-index: 1; left: 209px; top: 637px;" Text="Option3"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="TextBox5" runat="server" 
                    style="z-index: 1; left: 371px; top: 647px; height: 22px;" Width="576px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label7" runat="server" 
                    style="z-index: 1; left: 209px; top: 637px;" Text="Option4"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="TextBox6" runat="server" 
                    style="z-index: 1; left: 371px; top: 647px; height: 22px;" Width="576px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label8" runat="server" 
                    style="z-index: 1; left: 209px; top: 637px;" Text="Valid Answer"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="125px" AutoPostBack=true >
                    <asp:ListItem>Option1</asp:ListItem>
                    <asp:ListItem>Option2</asp:ListItem>
                    <asp:ListItem>Option3</asp:ListItem>
                    <asp:ListItem>Option4</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
                    style="z-index: 1; left: 541px; top: 891px; right: 364px; height: 26px;" 
                    Text="Register" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
                    style="z-index: 1; left: 706px; top: 708px; " Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

