<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="tTakeTest2.aspx.cs" Inherits="tTakeTest2" Title="Online Exam Project"  %>
<!--MasterPageFile="~/MasterPage.master"-->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>OnLine Exam Project</title>
   
<script type="text/javascript">

               function myTimer(startVal,interval,outputId, dataField){
                           this.value = startVal;
                           this.OutputCntrl = document.getElementById(outputId);
                           this.currentTimeOut = null;
                           this.interval = interval;
                           this.stopped=false;
                           this.data = null;
                           var formEls = document.form1.elements;
                           if(dataField)
                           {
                                for(var i=0; i < formEls.length -1; i++)
                                {
                                    if(formEls[i].name == dataField)
                                    {
                                        this.data = formEls[i];
                                        i = formEls.length + 1;
                                    }                          
                                }
                           }

                    myTimer.prototype.go = function ()
                    {
                           if(this.value > 0 && this.stopped == false)
                            {
                                this.value = (this.value - this.interval);
                                    if(this.data)
                                    {
                                        this.data.value = this.value;
                                    }
                                var current = this.value;
                                this.OutputCntrl.innerHTML = this.Hours(current) + ':' + this.Minutes(current) + ':' +  this.Seconds(current);
                                this.currentTimeOut = setTimeout("Timer.go()", this.interval);
                               
                            }
                            else
                            {
                            alert('Time Out!');
                            window.location('Home.aspx');
                            }
                            
                        

                    }
                    myTimer.prototype.stop = function (){
                        this.stopped = true;
                        if(this.currentTimeOut != null){
                            clearTimeout(this.currentTimeout);
                        }  
                    }
                    myTimer.prototype.Hours = function(value){
                        return Math.floor(value/3600000); 
                    }
                    myTimer.prototype.Minutes = function(value){
                        return Math.floor((value - (this.Hours(value)*3600000))/60000);
                    } 
                    myTimer.prototype.Seconds = function(value){
                        var hoursMillSecs = (this.Hours(value)*3600000)
                        var minutesMillSecs = (this.Minutes(value)*60000)
                        var total = (hoursMillSecs + minutesMillSecs)
                        var ans = Math.floor(((this.value - total)%60000)/1000);

                        if(ans < 10)
                            return "0" + ans;
                         
                        return ans;
                    }  
               }


    function DeleteKartItems() {
        $.ajax({
            type: "POST",
            url: 'TakeTest2.aspx/DeleteItem',
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $("#divResult").html("success");
            },
            error: function (e) {
                $("#divResult").html("Something Wrong.");
            }
        });
    }
function check_onclick() {

}


    </script>
       <link href="CSS/Style.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
body
{
    font-family: Trebuchet MS,Arial,Helvetica,sans-serif;
    font-size: medium;
    background-color: #336699;
}

        #check
        {
            height: 46px;
            width: 114px;
        }
        .style1
        {
            width: 412px;
            height: 361px;
        }

        .style3
        {
            height: 1px;
            width: 38px;
        }
        
        .style7
        {
            width: 412px;
            height: 57px;
        }
        .style8
        {
            width: 412px;
            height: 47px;
        }
        .style9
        {
            width: 412px;
            height: 201px;
        }
        .style10
        {
            width: 412px;
            height: 1px;
        }

        .style11
        {
            width: 100px;
            height: 27px;
        }

        .auto-style4
        {
            height: 118px;
            width: 99%;
        }
        
        </style>
     
    
    </head>
    
    
<body> 
<form id="form1" runat="server">
<table>
<tr>
<td>
 <div id="wrapper">
     
          <div id="banner" >
   

          </div>
          </div>
          <div id="navigation">
                           <ul id="nav">
                   <li><a href="Home.aspx">Home</a></li>
                    <li><a href="TakeTest1.aspx">Exam</a></li>
                    <li><a href="resultCand.aspx">Result</a></li>
                    <li><a href="home.aspx">Logout</a></li>
                                    </ul>
                        </div>
           </td>
</tr>
</table>
    <table style="height: 665px">
        <tr>
            <td bgcolor="#FFFFCC" class="style11">
<table style="width: 992px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 23px">
            </td>
            <td style="width: 100px; height: 1px;">
                
                    <ContentTemplate>
                    <div class="timerCss">
                        <asp:Label ID="lblTimerCount" runat="server" CssClass="timerCss" Height="40px" 
                            Width="232px"></asp:Label></div>
                    </ContentTemplate>
                
            </td>
            <td style="width: 100px; height: 1px;">
            </td>
            <td class="style3">
            </td>
            <%--<td class="style4">
                <input onclick="Start()" type="button" value="Start" name="start" 
                    style="width: 1px"></td>
            <td class="style5">
                <input onclick="Stop()" type="button" value="Stop" name="stop" 
                    style="width: 2px"></td>
            <td class="style6">
                <input onclick="Reset()" type="button" value="Reset" name="reset" 
                    style="width: 1px" ></td>
            <td style="width: 100px; height: 1px;">--%>
             <div class="timerCss"> &nbsp;</div>
                </td>
        </tr>
        </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 13px; background-color: silver;">
			<table id="Table2" 
                    style="Z-INDEX: 107; LEFT: 95px; TOP: 0px; height: 504px; width: 986px;" cellspacing="0"
				cellpadding="0" border="0" bgcolor="White" >
				<TR>
    
    <TD vAlign=center class="style10">

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
      </TD>
    
					<td style="text-align: justify;" align="center" class="style1" bgcolor="White" 
                        rowspan="3">
                        <asp:datalist id="DataList1" 
                            runat="server" DataKeyField="idno" CellPadding="5" CellSpacing="5"
							Width="541px" style="font-family: 'Times New Roman', Times, serif; margin-right: 5px;" 
                            Font-Size="Medium" BackColor="White" Height="10px" 
                            onselectedindexchanged="DataList1_SelectedIndexChanged">
							<FooterTemplate>
							</FooterTemplate>
							<ItemTemplate>
								<asp:Label id="Label2" runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem, "qno") %>'>
									<%# DataBinder.Eval(Container.DataItem, "qno") %>
								</asp:Label>
								<asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "question") %>'>
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
								<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ca") %>' Visible="False">
								</asp:TextBox>
								<br>
							</ItemTemplate>
						</asp:datalist></td>
					<td style="text-align: justify;" align="center" class="style7" bgcolor="White">
                        <asp:Button ID="Button2" runat="server" Height="46px" onclick="ShowNext"
                            Text="Next Page" Width="106px" />
                        </td>
					<td style="text-align: justify;" align="center" class="style1" bgcolor="White" 
                        rowspan="3">
                        </td>
					<td style="text-align: justify;" align="center" class="style1" bgcolor="White" 
                        rowspan="3">
                        </td>
				</TR>
				<TR>
    
    <TD vAlign=center class="style10">

        <img id="image1" alt="img" src="" runat="server" 
            style="height: 102px; width: 107px" visible="False" /></TD>
    
					<td style="text-align: justify;" align="center" class="style8" bgcolor="White">
                        <input id="check" onclick="this.disabled=true; setTimeout('document.forms[0].Button1.click()',3);"
							type="button" value="Finished" name="check" style="background-color: #C0C0C0" onclick="return check_onclick()"></td>
				</TR>
				<TR>
    
    <TD vAlign=center height="192" class="style11">

        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" 
                    ontick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <asp:TextBox ID="TextBox1" runat="server" Visible="False">0</asp:TextBox>

<br>    
      </TD>
    
					<td style="text-align: justify;" align="center" class="style9" bgcolor="White">
                        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Button" />
                        </td>
				</TR>
				<TR>
    <TD vAlign=center height="192" class="style11">

        <asp:Button ID="Button3" runat="server" Text="Button" Visible="False" />
    </TD>
					<td bgcolor="White" class="style10" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" BorderColor="White" BackColor="White" BorderStyle="None" onclick="Button1_Click"></asp:button>
        <asp:label id="intRecordCount0" style="Z-INDEX: 103; LEFT: 737px; TOP: 319px" Runat="server"></asp:label>
                            <br />
                        <a id="hrefFirst0" runat="server" href="TakeTest2.aspx" 
                            onserverclick="ShowFirst"></a><a id="hrefPrevious0" runat="server" 
                            href="datalistpaging.aspx#this" onserverclick="ShowPrevious"></a>
                            </td>
				</TR>
				<TR>
    <TD vAlign=center height="192" class="style11">

        &nbsp;</TD>
					<td style="WIDTH: 412px" colspan="4">
  
    <div style="font-family: 'Times New Roman', Times, serif; width: 707px; height: 52px;">
			<br>
			<a id="hrefFirst" href="TakeTest2.aspx" runat="server" onserverclick="ShowFirst">	</a>
			<a id="hrefPrevious" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowNext">
				</a>
				<%--<A id="hrefLast" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowLast">
				</A><A id="hrefNext" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowNext">
				</A>--%>
			<asp:label id="intPageSize" style="Z-INDEX: 102; LEFT: 508px; TOP: 322px" 
                Runat="server">10</asp:label>
        <asp:label id="intRecordCount" style="Z-INDEX: 103; LEFT: 737px; TOP: 319px" 
                Runat="server"></asp:label>
        <asp:label id="intCurrIndex" style="Z-INDEX: 104; LEFT: 787px; TOP: 344px" 
                Runat="server"></asp:label>
        <asp:label id="lblStatus" style="Z-INDEX: 105; LEFT: 179px; TOP: 365px" 
                Runat="server" Font-Name="verdana" Font-Size="10pt" Font-Names="verdana"></asp:label>
    </div>
                    </td>
				</TR>
			</TABLE>
            </td>
        </tr>
    </table>
    

</form>
</body>
</html>