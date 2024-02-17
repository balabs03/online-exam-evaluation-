<%@ Page Language="C#" AutoEventWireup="true" CodeFile="takeexam.aspx.cs" Inherits="takeexam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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
   <%-- <script type="text/javascript">

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



    </script>--%>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<%-- <script language="JavaScript">

<!--
// please keep these lines on when you copy the source
// made by: Nicolas - http://www.javascript-page.com

var timerID = 0;
var tStart  = null;

function UpdateTimer() {
   if(timerID) {
      clearTimeout(timerID);
      clockID  = 0;
   }
   

   if(!tStart)
      tStart   = new Date();

   var   tDate = new Date();
   var   tDiff = tDate.getTime() - tStart.getTime();

   tDate.setTime(tDiff);

   document.theTimer.theTime.value = "" 
                                   + tDate.getMinutes() + ":" 
                                   + tDate.getSeconds();
                                   
                                   if (tDate.getSeconds() == 59)
                                   {
                                                               
                                   alert("Your Time Is Over Click Ok")
                                   document.theTimer.check.disabled=true   
                                   document.forms[0].Button1.click()        
                                  
                                   }    
   
   timerID = setTimeout("UpdateTimer()", 1000);
}

function Start() {
   tStart   = new Date();

   document.theTimer.theTime.value = "00.00";

   timerID  = setTimeout("UpdateTimer()", 1000);
}

function Stop() {
   if(timerID) {
      clearTimeout(timerID);
      timerID  = 0;
   }

   tStart = null;
}

function Reset() {
   tStart = null;

   document.theTimer.theTime.value = "00:00";
}

//-->

		</script>--%>
      <link href="CSS/Style.css" type="text/css" rel="stylesheet" />
      
    <style type="text/css">
     
        .auto-style1
        {
            height: 41px;
        }
        .auto-style2
        {
            height: 40px;
        }
        .auto-style3
        {
            height: 13px;
        }
    </style>
   
</head>
<body bgColor="lightgrey" onload="Start()" onunload="Stop()">
    &nbsp;<form id="form2" runat="server">
      <div id="wrapper">
     
          <div id="banner" >
   

              <input onclick="Start()" type="button" value="Start" name="start"></div>
          </div>
          <div id="navigation">
                           <ul id="nav">
                   <li><a href="Home.aspx">Home</a></li>
                    <li><a href="exam.aspx">Exam</a></li>
                    <li><a href="resultCand.aspx">Result</a></li>
                    <li><a href="home.aspx">Logout</a></li>
                                    </ul>
                        </div>
                        <div>
                        <input type="text" size="5" name="theTime"/>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <Triggers>
                               
                               <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                               
                               </Triggers>
                                <ContentTemplate>
                                
                                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="100" 
                            ontick="Timer1_Tick">
                                    </asp:Timer>
                                    <asp:Label ID="Label3" runat="server" 
                                        style="font-family: 'Times New Roman', Times, serif" Text="Label"></asp:Label>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>            
   
               


         

    <div id="content-area1">
    

        <div class="form__field">
            <table border="0"  cellpadding =0 cellspacing=0 width="100%" class="auto-style3 ">
<TBODY>
<tr>
    <td align=center  width="13" height="192" class="auto-style5">&nbsp;
    </td>
    <td align=middle width="29" height="192" class="auto-style5">&nbsp;
        <div class="timerCss">
            <asp:Label ID="lblTimerCount" runat="server" Height="40px" Width="232px"></asp:Label>
            &nbsp;</div>
    </td>
<td class=auto-style1 height="192" valign="top">
    
            <p>
			<table id="Table1" style="Z-INDEX: 107; LEFT: 95px; TOP: 0px; height: 820px; width: 986px;" cellspacing="0"
				cellpadding="0" border="0" >
				<TR>
					<td style="WIDTH: 412px; HEIGHT: 71px">&nbsp;&nbsp;&nbsp;<font 
                            size="5" color="#33ccff"><strong>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG><FONT color="#66ccff"><EM>&nbsp;
										<strong>E - TEST</strong></EM></FONT> </FONT>
					</td>
					<td style="WIDTH: 412px; HEIGHT: 71px">
    <table style="Z-INDEX: 107; LEFT: 593px; TOP: 294px">
				<tr>
					<td align="center" colSpan="3"></td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td></td>
					<td><input onclick="Stop()" type="button" value="Stop" name="stop">
					</td>
					<td><input onclick="Reset()" type="button" value="Reset" name="reset">
					</td>
				</tr>
				<tr>
					<td>
                        &nbsp;</td>
					<td>&nbsp;</td>
					<td>
                        &nbsp;</td>
					<td>
                        &nbsp;</td>
				</tr>
			</table>
					</td>
				<TR>
					<td style="WIDTH: 412px" align="center" colspan="2"><asp:datalist id="DataList1" 
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
					<td style="WIDTH: 412px" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="check" onclick="this.disabled=true; setTimeout('document.forms[0].Button1.click()',3);"
							type="button" value="Finished" name="check">
						<asp:button id="Button1" runat="server" BorderColor="White" BackColor="White" BorderStyle="None" onclick="Button1_Click"></asp:button></td>
				</TR>
			</TABLE>
			                      </p>
        
    </td>
</TR>
</TBODY>
</TABLE>
  
    <div>
			<br>
			<A id="hrefFirst" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowFirst">
				<B></B></A><A id="hrefPrevious" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowPrevious">
				<B></B></A><A id="hrefLast" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowLast">
				<B></B></A><A id="hrefNext" href="datalistpaging.aspx#this" runat="server" onserverclick="ShowNext">
				<B></B></A>
			<asp:label id="intPageSize" style="Z-INDEX: 102; LEFT: 508px; TOP: 322px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="intRecordCount" style="Z-INDEX: 103; LEFT: 737px; TOP: 319px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="intCurrIndex" style="Z-INDEX: 104; LEFT: 787px; TOP: 344px"
				Visible="False" Runat="server"></asp:label>
        <asp:label id="lblStatus" style="Z-INDEX: 105; LEFT: 179px; TOP: 365px"
				Visible="False" Runat="server" Font-Name="verdana" Font-Size="10pt"></asp:label>
    </div>
    </div> 
    </div>
    </form>
</body>
</html>
