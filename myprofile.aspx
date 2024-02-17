<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="myprofile.aspx.cs" Inherits="myprofile" Title="Untitled Page" %>
<%@ Register assembly="ZedGraph.Web" namespace="ZedGraph.Web" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
        <td style="width: 136px; height: 26px">
            Welcome ........</td>
        <td style="height: 26px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 136px; height: 26px">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="170px" AutoPostBack=true >
            </asp:DropDownList>
        </td>
        <td style="height: 26px">
            &nbsp;</td>
    </tr>
    <tr>
        <td>

    <table style="width: 126%; height: 66px; background-color:White;">
        <tr>
            <td bgcolor="White" class="style1" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                &nbsp;</td>
            <td bgcolor="White" class="style6" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                Student Name             </td>
            <td class="style7" bgcolor="White">
                <asp:Label ID="Label1" runat="server" Enabled="False" Text="Label"></asp:Label>
            </td>
            <td class="style3" 
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; width: 115px; height: 27px;">
                Department</td>
            <td style="width: 213px; height: 27px;">
                <asp:Label ID="Label4" runat="server" Enabled="False" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                &nbsp;</td>
            <td class="style9" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                User ID</td>
            <td class="style10">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Enabled="False" Text="Label"></asp:Label>
            </td>
            <td class="style3" 
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; width: 115px; height: 18px;">
                Email</td>
            <td style="width: 213px; height: 18px;">
                <asp:Label ID="Label8" runat="server" Enabled="False" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                &nbsp;</td>
            <td class="style6" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                College
            </td>
            <td class="style11">
                <asp:Label ID="Label3" runat="server" Enabled="False" Text="Label"></asp:Label>
            </td>
            <td class="style3" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; width: 115px; height: 19px;">
                &nbsp;</td>
            <td style="width: 213px; height: 19px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" align="left" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                &nbsp;</td>
            <td class="style6" align="left" 
                
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; ">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="style12">
                &nbsp;</td>
            <td class="style3" 
                
                
                style="font-family: 'Times New Roman', Times, serif; font-size: medium; color: #800000; width: 115px; height: 3px;">
                &nbsp;</td>
            <td style="width: 213px; height: 3px;">
                &nbsp;</td>
        </tr>
        </table>            
        </td>
    </tr>
    </table>
<table style="height: 282px; width: 1029px">
    <tr>
    <td style="width: 397px">
    
      
        <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server" Height="300" Width="400">
            <XAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="True" IsZeroLine="False" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </XAxis>
            <Y2Axis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="False" IsZeroLine="True" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="-90" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </Y2Axis>
            <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                IsItalic="False" IsUnderline="False" Size="16" StringAlignment="Center">
                <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                    IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
            </FontSpec>
            <MasterPaneFill AlignH="Center" AlignV="Center" Color="White" 
                ColorOpacity="100" IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" 
                Type="Solid" />
            <YAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="True" IsZeroLine="True" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="-180" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="90" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </YAxis>
            <Legend IsHStack="True" IsReverse="False" IsVisible="True" Position="Top">
                <Location AlignH="Left" AlignV="Center" CoordinateFrame="ChartFraction" 
                    Height="0" Width="0" X="0" Y="0">
                    <TopLeft X="0" Y="0" />
                    <BottomRight X="0" Y="0" />
                </Location>
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" 
                    IsItalic="False" IsUnderline="False" Size="12" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
                </FontSpec>
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                    IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
                <Border Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            </Legend>
            <PaneFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
            <ChartFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
            <ChartBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            <MasterPaneBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            <Margins Bottom="10" Left="10" Right="10" Top="10" />
            <PaneBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
        </cc1:ZedGraphWeb>
    
      
    </td>
    <td>
    
      
        <cc1:ZedGraphWeb ID="ZedGraphWeb2" runat="server" Height="300" Width="400">
            <XAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="True" IsZeroLine="False" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </XAxis>
            <Y2Axis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="False" IsZeroLine="True" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="-90" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </Y2Axis>
            <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" 
                IsItalic="False" IsUnderline="False" Size="16" StringAlignment="Center">
                <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                    IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
            </FontSpec>
            <MasterPaneFill AlignH="Center" AlignV="Center" Color="White" 
                ColorOpacity="100" IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" 
                Type="Solid" />
            <YAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" 
                IsPreventLabelOverlap="True" IsShowTitle="True" IsTicsBetweenLabels="True" 
                IsUseTenPower="False" IsVisible="True" IsZeroLine="True" MinSpace="0" Title="" 
                Type="Linear">
                <FontSpec Angle="-180" Family="Arial" FontColor="Black" IsBold="True" 
                    IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                </FontSpec>
                <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" 
                    PenWidth="1" />
                <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" 
                    PenWidth="1" Size="5" />
                <Scale Align="Center" Format="g" FormatAuto="True" IsReverse="False" Mag="0" 
                    MagAuto="True" MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" 
                    MaxAuto="True" MaxGrace="0.1" Min="0" MinAuto="True" MinGrace="0.1" 
                    MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
                    <FontSpec Angle="90" Family="Arial" FontColor="Black" IsBold="False" 
                        IsItalic="False" IsUnderline="False" Size="14" StringAlignment="Center">
                        <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                            IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                    </FontSpec>
                </Scale>
            </YAxis>
            <Legend IsHStack="True" IsReverse="False" IsVisible="True" Position="Top">
                <Location AlignH="Left" AlignV="Center" CoordinateFrame="ChartFraction" 
                    Height="0" Width="0" X="0" Y="0">
                    <TopLeft X="0" Y="0" />
                    <BottomRight X="0" Y="0" />
                </Location>
                <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" 
                    IsItalic="False" IsUnderline="False" Size="12" StringAlignment="Center">
                    <Border Color="Black" InflateFactor="0" IsVisible="False" Width="1" />
                    <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
                </FontSpec>
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                    IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
                <Border Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            </Legend>
            <PaneFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
            <ChartFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" 
                IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
            <ChartBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            <MasterPaneBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
            <Margins Bottom="10" Left="10" Right="10" Top="10" />
            <PaneBorder Color="Black" InflateFactor="0" IsVisible="True" Width="1" />
        </cc1:ZedGraphWeb>
    
      
    </td>
    </tr>
      
</table>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style1
    {
        height: 17px;
        width: 14px;
    }
    .style2
    {
        height: 18px;
        width: 14px;
    }
    .style3
    {
        height: 22px;
        width: 115px;
    }
    .style5
    {
        height: 22px;
        width: 14px;
    }
    .style6
    {
            width: 280px;
        }
    .style7
    {
        height: 17px;
        width: 137px;
    }
    .style8
    {
        height: 27px;
        width: 14px;
    }
    .style9
    {
        height: 18px;
        width: 280px;
    }
    .style10
    {
        height: 18px;
        width: 137px;
    }
    .style11
    {
        height: 22px;
        width: 137px;
    }
    .style12
    {
        height: 27px;
        width: 137px;
    }
</style>




</asp:Content>


