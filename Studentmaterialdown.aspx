<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="Studentmaterialdown.aspx.cs" Inherits="Studentmaterial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 28px;
        }
    .style1
    {
        width: 850px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Welcome"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="lbuser" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Basic &amp; intermediate Materials"></asp:Label>
            &nbsp;<asp:LinkButton ID="lbdown" runat="server" onclick="lbdown_Click" >Click 
                Here</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Download Materials"></asp:Label>
            &nbsp;<asp:LinkButton ID="lbstdown" runat="server" onclick="lbstdown_Click" >Click 
                Here</asp:LinkButton>
                </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label7" runat="server" 
                    Text="Basic &amp; intermediate materials " Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label5" runat="server" Text="select Filename" Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlfilename" runat="server" Visible="False">
                </asp:DropDownList>
                <asp:Button ID="btnadmindown" runat="server" onclick="btnadmindown_Click" 
                    Text="Download" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" GridLines="Both" Height="179px" 
                    Width="207px">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderTemplate>
                    <table border="2">
                    <tr>
                    <td>
                    <asp:Label ID="fname" runat="server" Text="File Name">
                    </asp:Label>
                    
                    </td>
                    <td>
                    <asp:Label ID="fpath" runat="server" Text="File Path">
                    </asp:Label>
                    
                    </td>
                    
                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <tr>
                    <td>
                    <asp:Label ID="fname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"filename")%>'>
                    </asp:Label>
                    
                    </td>
                    <td>
                    <asp:Label ID="fpath" runat="server" Text='<%#Eval("filepath")%>'>
                    </asp:Label>
                    
                    </td>
                    
                    </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                    <ItemStyle BackColor="White" />
                    <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label8" runat="server" Text="Staff Materials" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="Download Materials" 
                    Visible="False"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlstaffname" runat="server" Visible="False">
                </asp:DropDownList>
            &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label6" runat="server" Text="select Filename" Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlfname" runat="server" Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="style3">
                <asp:Button ID="btndownload" runat="server" onclick="btndownload_Click" 
                    Text="Download" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:DataList ID="DataList2" runat="server">
                <HeaderTemplate>
                <table border="2">
                <tr>
                <td>
                <asp:Label ID="filename" runat="server" Text="File Name">
                </asp:Label>
                </td>
                 <td>
                <asp:Label ID="filepath" runat="server" Text="File Path">
                </asp:Label>
                </td>
                </tr>
               
                </HeaderTemplate>
                <ItemTemplate>
                  <tr>
                <td>
                <asp:Label ID="flename" runat="server" Text='<%#Eval("filename")%>'>
                </asp:Label>
                </td>
                 <td>
                 
                <asp:Label ID="flepath" runat="server" Text='<%#Eval("filepath")%>'>
                </asp:Label>
                </td>
                </tr>
                
                </ItemTemplate>
                <FooterTemplate>
                 </table>
                </FooterTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

