<%@ Page Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="ResultCand.aspx.cs" Inherits="ResultCand" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" bgcolor="#f4f7f7" border="0" cellpadding="1" cellspacing="2" 
        style="Z-INDEX: 101; LEFT: 95px; TOP: 0px; height: 237px; width: 806px; font-family: 'Simplified Arabic Fixed';">
        <tr>
            <td align="center" style="HEIGHT: 78px">
                <font color="#0099ff" size="5"><strong><u>Result</u></strong></font></td>
        </tr>
        <tr>
            <td>
                <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <font color="#3300cc" size="4">You&nbsp;Have Scored</font>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="#C00000">Label</asp:Label>
&nbsp; <font size="4"><font color="#cc0000">Marks</font>&nbsp;</font>&nbsp;&nbsp;&nbsp;&nbsp;</p>
                <p>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        Text="Show Correct Answers" Width="273px" Visible="False" />
                </p>
                <p>
                    <asp:GridView ID="GridView1" runat="server" Height="16px" Visible="False" 
                        Width="16px">
                    </asp:GridView>
                </p>
                        <asp:datalist id="DataList1" 
                            runat="server" DataKeyField="idno" CellPadding="5" CellSpacing="5"
							Width="674px" style="font-family: 'Times New Roman', Times, serif; margin-right: 5px;" 
                            Font-Size="Medium" BackColor="White" Height="10px" 
                            onselectedindexchanged="DataList1_SelectedIndexChanged">
							<FooterTemplate>
							</FooterTemplate>
							<ItemTemplate>
								<asp:Label id="Label2" runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem, "qno") %>'>
									<%# DataBinder.Eval(Container.DataItem, "qno") %>
								</asp:Label>
								<asp:Label id="Label3" runat="server">
									<%# DataBinder.Eval(Container.DataItem, "question") %>
								</asp:Label><br>
								<br>
								<asp:RadioButton id=RadioButton1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "q1") %>' GroupName="radio">
								</asp:RadioButton>
								<asp:RadioButton id=RadioButton2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "q2") %>' GroupName="radio">
								</asp:RadioButton>
								<asp:RadioButton id=RadioButton3 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "q3") %>' GroupName="radio">
								</asp:RadioButton>
								<asp:RadioButton id=RadioButton4 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "q4") %>' GroupName="radio">
								</asp:RadioButton>
								<asp:TextBox id=TextBox1 runat="server" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "uans") %>' Visible="True" 
                                    Enabled=false BackColor=#e28a8a ForeColor="#33CC33" ></asp:TextBox>
                                <asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ca") %>' Visible="True" Enabled=false BackColor=#91dc91 >
								</asp:TextBox>
								<br>
							</ItemTemplate>
						</asp:datalist>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
        <asp:label id="intCurrIndex" style="Z-INDEX: 104; LEFT: 787px; TOP: 344px" 
                Runat="server"></asp:label>
			<asp:label id="intPageSize" style="Z-INDEX: 102; LEFT: 508px; TOP: 322px" 
                Runat="server"></asp:label>
        &nbsp;<asp:label id="intRecordCount" style="Z-INDEX: 103; LEFT: 737px; TOP: 319px" 
                Runat="server"></asp:label>
                </p>
                <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
            </td>
        </tr>
    </table>
</asp:Content>

