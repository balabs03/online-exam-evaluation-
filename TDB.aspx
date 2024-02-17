<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TDB.aspx.cs" Inherits="CreateUser" Title="Untitled Page" %>


<script runat="server">

 
</script>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
            
               <div>
                   <table class="style1">
                       <tr>
                           <td colspan="2">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
<asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" 
                       style="height: 26px" Height="31px" Width="241px" />
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                   </table>
<b>Please Select Excel File: </b>
                   &nbsp;&nbsp;
<br />
<asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label><br />
<asp:GridView ID="grvExcelData" runat="server" Width="351px">
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
                   <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                       Text="Upload Depency value data" style="height: 26px" />
                   <br />
<asp:GridView ID="grvExcelData0" runat="server" Width="351px">
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
</div>
        </tr>
        </table>
</asp:Content>



<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 649px;
        }
    </style>

</asp:Content>




