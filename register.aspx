<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 226px;
            width: 712px;
        font-family: "Times New Roman", Times, serif;
    }
        .style2
    {
        height: 25px;
    }
    .style3
    {
        height: 39px;
    }
        .style4
        {
            height: 105px;
        }
        .style5
        {
            width: 100%;
        }
        .style6
        {
            height: 24px;
            text-align: left;
        }
        .style7
        {
            width: 172px;
        }
        .style8
        {
            height: 24px;
            width: 172px;
        }
        .style9
        {
            width: 172px;
            height: 31px;
        }
        .style10
        {
            height: 31px;
            text-align: left;
        }
        .style11
        {
            width: 73px;
        }
        .style12
        {
            height: 25px;
            width: 73px;
        }
        .style13
        {
            height: 39px;
            width: 73px;
        }
        .style14
        {
            width: 79px;
        }
        .style15
        {
            height: 24px;
            width: 79px;
        }
        .style16
        {
            width: 79px;
            height: 31px;
        }
        .style17
        {
            height: 21px;
            width: 73px;
        }
        .style18
        {
            height: 21px;
        }
        .style19
        {
            width: 73px;
            height: 28px;
        }
        .style20
        {
            height: 28px;
        }
        .style21
        {
            height: 21px;
            width: 178px;
        }
        .style22
        {
            height: 28px;
            width: 178px;
        }
        .style23
        {
            height: 25px;
            width: 178px;
        }
        .style24
        {
            width: 178px;
        }
        .style25
        {
            height: 39px;
            width: 178px;
        }
        .style26
        {
            width: 73px;
            height: 29px;
        }
        .style27
        {
            width: 178px;
            height: 29px;
        }
        .style28
        {
            height: 29px;
        }
        .style29
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style5">
            <asp:Label ID="Label1" runat="server" ForeColor="#FF6600" 
                style="z-index: 1; left: -42px; top: 348px; font-size: x-large; font-style:normal;" 
                Text="Student Enrollment Form" Font-Bold="True" Font-Size="Small"></asp:Label>
        </td>
        <td class="style5">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" style="color: #0000FF">
            Personal Details</td>
        <td class="style5">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
            <table class="style5">
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style7">
            <asp:Label ID="Label3" runat="server" 
                style="z-index: 1; left: 206px; top: 461px; " Text="Register Number"></asp:Label>
                    </td>
                    <td class="style29">
            <asp:TextBox ID="TextBox1" runat="server" 
                style="z-index: 1; left: 284px; top: 778px; "></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style15">
                        &nbsp;</td>
                    <td class="style8">
            <asp:Label ID="Label2" runat="server" 
                style="z-index: 1; left: 165px; top: 774px; right: 770px" Text="Student Name"></asp:Label>
                    </td>
                    <td class="style6">
            <asp:TextBox ID="TextBox2" runat="server" 
                style="z-index: 1; left: 176px; top: 867px; "></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style7">
            <asp:Label ID="Label4" runat="server" 
                style="z-index: 1; left: 50px; top: 876px; " Text="City"></asp:Label>
                    </td>
                    <td class="style29">
            <asp:TextBox ID="TextBox3" runat="server" 
                style="z-index: 1; left: 118px; top: 833px; right: 729px;" Width="181px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style9">
            <asp:Label ID="Label5" runat="server" 
                style="z-index: 1; left: 38px; top: 887px; " Text="Contact No"></asp:Label>
                    </td>
                    <td class="style10">
            <asp:TextBox ID="TextBox4" runat="server" 
                style="z-index: 1; left: 371px; top: 590px; margin-bottom: 0px;" MaxLength="10" 
                            Width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style7">
            <asp:Label ID="Label6" runat="server" 
                style="z-index: 1; left: 209px; top: 637px; " Text="Email-Id"></asp:Label>
                    </td>
                    <td class="style29">
            <asp:TextBox ID="TextBox5" runat="server" 
                style="z-index: 1; left: 371px; top: 647px; " Width="174px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBox5" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox5" ErrorMessage="Invalid Email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style7">
            <asp:Label ID="Label9" runat="server" 
                style="z-index: 1; left: 209px; top: 637px; " Text="Gender"></asp:Label>
                    </td>
                    <td class="style29">
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="19px" Width="155px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style7">
                        Course</td>
                    <td class="style29">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="155px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>B.Sc(cs)</asp:ListItem>
                            <asp:ListItem>B.Sc(it)</asp:ListItem>
                            <asp:ListItem>Bca</asp:ListItem>
                            <asp:ListItem>B.com</asp:ListItem>
                            <asp:ListItem>B.com(ca)</asp:ListItem>
                            <asp:ListItem>B.com(it)</asp:ListItem>
                            <asp:ListItem>M.Sc(ss)</asp:ListItem>
                            <asp:ListItem>M.Sc(cs)</asp:ListItem>
                            <asp:ListItem>M.Sc(it)</asp:ListItem>
                            <asp:ListItem>Mca</asp:ListItem>
                            <asp:ListItem>M.com</asp:ListItem>
                            <asp:ListItem>M.com(it)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
        <td class="style4">
            </td>
        <td class="style4">
            </td>
    </tr>
    </table>
    <p style="color: #0000FF">
        Credential Entry</p>
    <table class="style1">
    <tr>
        <td class="style17">
        </td>
        <td class="style21">
            <asp:Label ID="Label7" runat="server" 
                style="z-index: 1; left: 165px; top: 774px; right: 770px" Text="User ID"></asp:Label>
        </td>
        <td class="style18" colspan="2">
            <asp:TextBox ID="txtuserid" runat="server" 
                style="z-index: 1; left: 284px; top: 778px; "></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style12">
            &nbsp;</td>
        <td class="style23">
            Enroll Face</td>
        <td class="style2" colspan="2">
            <asp:Button ID="Button3" runat="server" Text="Initiate Camera and Capture" 
                Width="215px" onclick="Button3_Click" />
        </td>
    </tr>
    <tr>
        <td class="style12" rowspan="3">
            </td>
        <td class="style23" rowspan="3">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" 
                        ontick="Timer1_Tick">
                    </asp:Timer>
                    Student Face<img id="Image1" alt="img" runat="server" 
                style="height: 142px; width: 157px" />
                </ContentTemplate>
            </asp:UpdatePanel>
                                              </td>
        <td style="font-size: small">
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" 
                style="z-index: 1; left: 165px; top: 774px; right: 770px" Text="Password"></asp:Label>
            </td>
        <td style="font-size: small">
            <asp:TextBox ID="txtpass" runat="server" 
                style="z-index: 1; left: 284px; top: 778px; " TextMode="Password" 
                Width="129px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="font-size: small">
            Confirm Password</td>
        <td style="font-size: small">
            <asp:TextBox ID="TextBox8" runat="server" 
                style="z-index: 1; left: 284px; top: 778px; " TextMode="Password" 
                ontextchanged="TextBox8_TextChanged"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtpass" ControlToValidate="TextBox8" ErrorMessage="**"></asp:CompareValidator>
            </td>
    </tr>
    <tr>
        <td class="style2" style="font-size: small">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
                style="z-index: 1; left: 541px; top: 891px; right: 364px; " 
                Text="Register" />
            </td>
        <td class="style2" style="font-size: small">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
                style="z-index: 1; left: 706px; top: 708px; " Text="Cancel" Width="68px" />
        </td>
    </tr>
        <tr>
        <td class="style19">
        </td>
        <td class="style22">
            &nbsp;</td>
        <td class="style20" colspan="2">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style12">
            &nbsp;</td>
        <td class="style23">
            &nbsp;</td>
        <td class="style2" colspan="2">
            &nbsp;</td>
        </tr>
    <tr>
        <td class="style12">
            &nbsp;</td>
        <td class="style23">
            &nbsp;</td>
        <td class="style2" style="font-size: small" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style26">
        </td>
        <td class="style27">
            </td>
        <td class="style28" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style25">
            </td>
        <td class="style3" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style11">
            &nbsp;</td>
        <td class="style24">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

