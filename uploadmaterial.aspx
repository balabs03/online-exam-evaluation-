<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="uploadmaterial.aspx.cs" Inherits="uploadmaterial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 687px;
    }
    .style2
    {
        width: 240px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Material Upload Process"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Select File "></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="335px" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Data Category"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="242px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnupload" runat="server" Text="Upload file" 
                    onclick="btnupload_Click" />
                <asp:Label ID="lblresult" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
            <asp:DataList ID="gvmaterial" runat="server" Width="677px" >                     
            <HeaderTemplate>
            <table border="2">   
            <tr>
            <td>
                <asp:Label ID="FileType" runat="server"  Text="FileType"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="filname" runat="server"  Text="Filename"></asp:Label>
            </td>
             <td>
                <asp:Label ID="file_category" runat="server"  Text="file_category"></asp:Label>
            </td>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
             <td>
                <asp:Label ID="FileType" runat="server"  Text='<%#Eval("FileType") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="filename" runat="server"  Text='<%#Eval("filename") %>'></asp:Label>            
            </td>
             <td>
                <asp:Label ID="filepath" runat="server"  Text='<%#Eval("file_category") %>'></asp:Label>
            </td>
            </tr>
            </ItemTemplate>
            
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:DataList> </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

