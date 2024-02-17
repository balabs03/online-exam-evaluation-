<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 41px;
            width: 726px;
        }
        .style2
        {
            height: 13px;
            width: 84px;
        }
        .style3
        {
            width: 84px;
        }
        .style4
        {
            width: 84px;
            height: 35px;
        }
        .style5
        {
            height: 35px;
        }
        .style6
        {
            width: 84px;
            height: 22px;
        }
        .style7
        {
            height: 22px;
        }
        .auto-style4
        {
            width: 122%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" class="auto-style4">
        <tr>
            <td class="style1" height="192" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" class="style2" height="25">
                            &nbsp;</td>
                        <td align="left" class="auto-style3">
                            &nbsp;</td>
                    </tr>
                    <tr>
<!--Displaying the label as Login Name.-->
                        <td align="left" class="style2" height="25">
                            <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#0099FF" 
                                Text="Username"></asp:Label>
                            &nbsp;
                        </td>
                        <td align="left" class="auto-style3">
<!--Creating a text field for the label, Login Name. -->
                            <asp:TextBox ID="TxtUser" runat="server" Height="29px" Width="193px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                        </td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style4">
                            <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="#3399FF" 
                                Text="Password"></asp:Label>
                        </td>
                        <td align="left" class="style5">
                            <asp:TextBox ID="TxtPwd" runat="server" ontextchanged="TxtPwd_TextChanged" 
                                TextMode="Password" Height="29px" Width="191px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3" height="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
<!--Creating a button with the caption, SUBMIT.-->
                        <td align="center" class="style3">
                            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                                                          <td align="center">
                                                              <asp:Button ID="BtnSbmt" runat="server" BorderStyle="Solid" 
                                                                  OnClick="BtnSbmt_Click1" Text="SUBMIT" Width="83px" />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnSbmt0" runat="server" BorderStyle="Solid" 
                                                                  OnClick="BtnSbmt_Click1" Text="CANCEL" Width="83px" />
                                                              &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" 
                                                                  onclick="LinkButton2_Click">Forget Password</asp:LinkButton>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                          </td>
                                                      </tr>
                    <tr>
                        <td align="center" class="style3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="2000" 
                                        ontick="Timer1_Tick" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                                                          <td align="center">
                                                              <asp:Panel ID="Panel1" runat="server" Visible="False">
                                                                  Forget Password
                                                                  <br />
                                                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                  &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
    onclick="LinkButton1_Click">Click </asp:LinkButton>
                                                              </asp:Panel>
                        </td>
                                                      </tr>
                    <tr>
                        <td align="center" class="style6">
                            </td>
                                                          <td align="center" class="style7">
                                                              <font color="#3399FF" face="Arial, Helvetica, sans-serif" size="2"><u>New user</u>&nbsp;?</font><a href="register.aspx"><font color="800080" 
                                face="Arial, Helvetica, sans-serif" size="2"><b>Sign Up</b> </font></a>
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td align="left" colspan="2">
                                                              <br />
                                                              <font color="#3399FF" face="Arial, Helvetica, sans-serif" size="2">&nbsp;&nbsp;&nbsp;&nbsp;
                            </font>
                                                              <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                                                              <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <br />

 <%--<font size="2" face="Arial, Helvetica, sans-serif" color="#3399FF"><u>Forgot Password</u>&nbsp;?--%>
 <%--</font>&nbsp;<A href="getPassword.html"><font size="2" face="Arial, Helvetica, sans-serif" color="800080">Click here</font></A></TD>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style1" height="192" valign="top">
                <p>
                    <asp:Image ID="Image1" runat="server" Height="243px" 
                        ImageUrl="~/images/download.png" Width="274px" />
                </p>
            </td>
            <td align="middle" class="auto-style5" height="192" rowspan="5" width="12">
                &nbsp;</td>
            <td class="auto-style2" height="192">
                &nbsp;</td>
            <td class="auto-style5" height="192">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

