<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="VQuestions.aspx.cs" Inherits="VQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td style="text-align: center">
                View Uploaded Questions List</td>
    </tr>
    <tr>
        <td style="text-align: center">
            Select Domain<asp:DropDownList ID="DropDownList1" 
                runat="server" Height="20px" 
                Width="126px" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
&nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            Select Question Number<asp:DropDownList ID="DropDownList2" runat="server" 
                Height="25px" Width="145px">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Delete" 
                Width="99px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" Width="773px">
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

