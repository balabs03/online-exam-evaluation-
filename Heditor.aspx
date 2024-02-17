<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="Heditor.aspx.cs" Inherits="Heditor"  ValidateRequest="false" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
          <div>
              <table style="width: 1059px; height: 523px;">
                  <tr>
                      <td style="width: 89px">
                          <asp:ImageButton ID="ImageButton1" runat="server" Height="55px" Width="98px" 
                              ImageUrl="~/images/2Q==.jpg" onclick="ImageButton1_Click" 
                              ToolTip="New file" />
                      </td>
                      <td style="width: 481px">
                          Welcome to HTML editor&nbsp;
                          <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td style="width: 481px">
                          Starting Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="234px"></asp:TextBox>
                          <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                      </td>
                      <td style="width: 16px">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td style="width: 89px">
                                      <asp:Label ID="Label7" runat="server" Text="File Content"></asp:Label>
                      </td>
                      <td style="width: 481px" colspan="2">
                                      <asp:TextBox ID="txtvalue" runat="server" CausesValidation="true" 
                                          Height="156px" TextMode="MultiLine" Width="865px"
                                 oncopy="return false" onpaste="return false" oncut="return false" 
                                          style="margin-left: 22px" ontextchanged="txtvalue_TextChanged"
 ></asp:TextBox>
                      </td>
                      <td style="width: 16px">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td colspan="3">
                          <br />
                          <table class="style1" style="width: 1033px">
                              <tr>
                                  <td class="style5" style="height: 6px; width: 153px;">
                                      <asp:Label ID="Label6" runat="server" Text="Enter the Filename"></asp:Label>
                                      &nbsp;</td>
                                  <td style="height: 6px">
                                      <asp:TextBox ID="txtfname" runat="server" 
                                          ontextchanged="txtjavaname_TextChanged" Width="636px" 
                                          style="margin-left: 0px"></asp:TextBox>
                                      <asp:Button ID="btnjavasave" runat="server" onclick="btnjavasave_Click" 
                                          Text="save file" />
                                      <asp:Button ID="btnedit" runat="server" onclick="btnedit_Click" 
                                          Text="Edit the program" />
                                  </td>
                              </tr>
                              <tr>
                                  <td class="style5" style="width: 153px; height: 55px">
                                  </td>
                                  <td style="height: 55px">
                                      <asp:Button ID="btnjavarun" runat="server" onclick="btnjavarun_Click" 
                                          Text="Run the Program" Height="53px" Width="437px" />
                          <asp:ImageButton ID="ImageButton2" runat="server" Height="49px" Width="223px" 
                              onclick="ImageButton2_Click" ImageUrl="~/images/Z(1).jpg" />
                                  </td>
                              </tr>
                              <tr>
                                  <td class="style5" style="width: 153px">
                                      &nbsp;</td>
                                  <td>
                                      &nbsp;&nbsp;&nbsp;&nbsp;
                                      </td>
                              </tr>
                          </table>
                      </td>
                      <td style="width: 16px">
                          &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
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
                          &nbsp;</td>
                  </tr>
              </table>
    </div>
    <script type="text/javascript">
    $(document).ready(function () {
    $('#TextBox1').bind('copy paste cut',function(e){
    e.preventDefault();
    });
    });
    </script>
</asp:Content>

