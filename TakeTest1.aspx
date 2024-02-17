<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="TakeTest1.aspx.cs" Inherits="TakeTest1" Title="Online Exam Project" %>
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
                                this.currentTimeOut = setTimeout("Timer.go()",this.interval);
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
            height: 513px;
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
    <table>
        <tr>
            <td style="width: 100px">
<table style="width: 1189px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 23px">
            </td>
            <td style="width: 100px; height: 1px;">
            </td>
            <td style="width: 100px; height: 1px;">
            </td>
            <td style="width: 100px; height: 1px;">
            </td>
            <td style="width: 100px; height: 1px;">
                <input onclick="Start()" type="button" name="start"></td>
            <td style="width: 100px; height: 1px;">
                <input onclick="Stop()" type="button" name="stop"></td>
            <td style="width: 100px; height: 1px;">
                <input onclick="Reset()" type="button" name="reset"></td>
            <td style="width: 100px; height: 1px;">
             <div class="timerCss"> <asp:Label ID="lblTimerCount" runat="server" Height="5px" Width="232px"></asp:Label>&nbsp;</div>
                </td>
        </tr>
        </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 13px; background-color: silver;">
			<table id="Table2" 
                    style="Z-INDEX: 107; LEFT: 95px; TOP: 0px; height: 820px; width: 986px;" cellspacing="0"
				cellpadding="0" border="0" >
				<TR>
					<td style="text-align: justify;" align="center" class="style1"><asp:datalist id="DataList1" 
                            runat="server" DataKeyField="idno" CellPadding="10" CellSpacing="10"
							Width="808px" style="font-family: 'Times New Roman', Times, serif">
							<FooterTemplate>
							</FooterTemplate>
							<ItemTemplate>
								<asp:Label id="Label2" runat="server">
									<%# DataBinder.Eval(Container.DataItem, "qno") %>
								</asp:Label>
								<asp:Label id="Label1" runat="server">
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
								<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ca") %>' Visible="False">
								</asp:TextBox>
								<br>
							</ItemTemplate>
						</asp:datalist></td>
				</TR>
				<TR>
					<td style="WIDTH: 412px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <input id="check" onclick="this.disabled=true; setTimeout('document.forms[0].Button1.click()',3);"
							type="button" value="Finished" name="check" style="background-color: #C0C0C0">
						<asp:button id="Button1" runat="server" BorderColor="White" BackColor="White" BorderStyle="None" onclick="Button1_Click"></asp:button></td>
				</TR>
				<TR>
					<td style="WIDTH: 412px">
  
    <div style="font-family: 'Times New Roman', Times, serif">
			<br>
			<A id="hrefFirst" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowFirst">
				</A><A id="hrefPrevious" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowPrevious">
				</A><A id="hrefLast" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowLast">
				</A><A id="hrefNext" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowNext">
				</A>
			<asp:label id="intPageSize" style="Z-INDEX: 102; LEFT: 508px; TOP: 322px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="intRecordCount" style="Z-INDEX: 103; LEFT: 737px; TOP: 319px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="intCurrIndex" style="Z-INDEX: 104; LEFT: 787px; TOP: 344px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="lblStatus" style="Z-INDEX: 105; LEFT: 179px; TOP: 365px"
				Visible="False" Runat="server" Font-Name="verdana" Font-Size="10pt"></asp:label>
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