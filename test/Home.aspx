<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="test.WebForm1" %>

<!DOCTYPE html>
<html>
 
<style>
body {background-color:white}
ul li{
  display: inline;
}
    .auto-style1 {
        float: right;
        width: 698px;
        margin-left: 341px;
         margin-right: 100px;
        height: 27px;
        margin-top: 90px;
    }
    .auto-style2 {
        height: 126px;
        width: 1611px;
        background-color:darkgray;
    }
    .auto-style5 {
        width: 666px;
        height: 841px;
        float: left;
    }
    .auto-style6 {
        float: left;
        width: 59px;
    }
    .auto-style7 {
        float: left;
        width: 39px;
    }
     .auto-style17 {
        float: left;
        width: 95px;
        height: 20px;
    }
    .auto-style8 {
        float: left;
        width: 77px;
    }
    .auto-style9 {
        float: left;
        width: 41px;
        height: 18px;
    }
    .auto-style12 {
        height: 841px;
        width: 1609px;
        margin-top: 0px;
    }
    .auto-style13 {
        height: 153px;
        width: 1610px;
        margin-left: 0px;
    }
    .auto-style15 {
         float: left;
         width: 933px;
        height: 841px;
        max-height: 841px;
    overflow-y: scroll;

    }
   li:hover { 
    background-color: yellow;
}  
    .auto-style16 {
        height: 834px;
    }
    </style>
 
<body >
    <form id="form1" runat="server">
 <div id="header" style="background-color:#636B46; " class="auto-style2"> 
     <ul class="auto-style1">  
 <li style=" margin-left:75px; background-color:#D9D2D0" class="auto-style6"> <asp:LinkButton ID="monthly" runat="server"  OnClick="LinkButton1_Click" Height="19px" BackColor="#373F27" Font-Underline="false" ForeColor="White" Width="61px"><b>Monthly</b></asp:LinkButton><li> 
 <li  style=" margin-left:75px; background-color:#D9D2D0" class="auto-style9" > <asp:LinkButton ID="view" runat="server"  OnClick="view_Click" Height="18px" BackColor="#373F27" Font-Underline="false" ForeColor="White" Width="42px"><b> View</b></asp:LinkButton><li> 
 <li  style=" margin-left:75px; background-color:#D9D2D0" class="auto-style8"> <asp:LinkButton ID="Addperson" runat="server"   OnClick="Addperson_Click" Height="21px" Width="77px" Font-Underline="false" BackColor="#373F27" ForeColor="White">Add person</asp:LinkButton>
             <li> 
 <li  style= " margin-left:75px; background-color:#D9D2D0" class="auto-style7">  <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Stuff_Click" AutoPostBack="true"  Height="21px" Visible="False" Font-Underline="false" Width="39px" BackColor="#373F27" ForeColor="White"><b>Stuff</b></asp:LinkButton><li> 
    &nbsp;&nbsp;   <li  style=" margin-left:75px; background-color:#D9D2D0" class="auto-style17"> <asp:LinkButton ID="addholidays" runat="server"  OnClick="Addholidays_Click"   Height="20px" Width="94px" Font-Underline="false" BackColor="#373F27" ForeColor="White">Add_Holidays</asp:LinkButton>
          
         &nbsp;&nbsp;</ul>
        &nbsp;
        <asp:Image ID="Image1" runat="server" Height="117px" ImageUrl="~/files/guv_logo_ang.png" Width="153px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <br />
     <br />
     <br />
     <br />
        </div>
 <div id="form"  style="background-color:#D7CEC7; " class="auto-style12"> 
     <div id="left"   style="background-color:#E9E7DA" class="auto-style5">
         <br />
        
         <br />
        
         &nbsp;
        <asp:DropDownList ID="year" runat="server"   OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True" Visible="False">
             <asp:ListItem>2010</asp:ListItem>
             <asp:ListItem>2011</asp:ListItem>
             <asp:ListItem>2012</asp:ListItem>
             <asp:ListItem>2013</asp:ListItem>
             <asp:ListItem>2014</asp:ListItem>
             <asp:ListItem>2015</asp:ListItem>
             <asp:ListItem>2016</asp:ListItem>
             <asp:ListItem>2017</asp:ListItem>
             <asp:ListItem>2018</asp:ListItem>
             <asp:ListItem>2019</asp:ListItem>
             <asp:ListItem>2020</asp:ListItem>
         </asp:DropDownList> 
         
         &nbsp;&nbsp; 
         
         <asp:DropDownList ID="month" runat="server" CssClass="auto-style3" SelectedIndexChanged="month_SelectedIndexChanged" AutoPostBack="True" Visible="False" >
             <asp:ListItem Value="1">January</asp:ListItem>
             <asp:ListItem Value="2">Febrary</asp:ListItem>
             <asp:ListItem Value="3">March</asp:ListItem>
             <asp:ListItem Value="4">April</asp:ListItem>
             <asp:ListItem Value="5">May</asp:ListItem>
             <asp:ListItem Value="6">June</asp:ListItem>
             <asp:ListItem Value="7">July</asp:ListItem>
             <asp:ListItem Value="8">August</asp:ListItem>
             <asp:ListItem Value="9">September</asp:ListItem>
             <asp:ListItem Value="10">October</asp:ListItem>
             <asp:ListItem Value="11">November</asp:ListItem>
             <asp:ListItem Value="12">December</asp:ListItem>
         </asp:DropDownList>
        
         &nbsp;&nbsp;
        
         <asp:Button ID="Button1" runat="server" Visible="false"  Text="show" OnClick="buttonclick" />
         <br />
         <br />
         <br />
         <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/files/images.jpg" OnClick="ImageButton1_Click" Width="50px" BackColor="Lime" />
         <br />
         <br />
         <br />
         <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"  SelectionMode="DayWeekMonth" SelectMonthText="This month" SelectWeekText="This week" ShowGridLines="True" Visible="False" FirstDayOfWeek="Monday" BackColor="#99CCFF" ></asp:Calendar>
     </div>
     <div id ="right" style="background-color:#E9E7DA; display:block";  class="auto-style15" >
         <div id="me" style="margin-left:10px" class="auto-style16" >
             &nbsp;&nbsp;&nbsp;  
             <asp:Table ID="Table1" runat="server" Height="24px" Width="716px" BackColor="#99CCFF" BorderColor="#CCFFCC" ForeColor="#3366FF" GridLines="Vertical" Visible="False">
                 <asp:TableRow runat="server">
                     <asp:TableCell runat="server"><b>Date</b></asp:TableCell>
                     <asp:TableCell runat="server"><b>Day</b></asp:TableCell>
                     <asp:TableCell runat="server"><b>Entry_Time</b></asp:TableCell>
                     <asp:TableCell runat="server"><b>Exit_Time</b></asp:TableCell>
                     <asp:TableCell runat="server"><b>Total_Hours</b></asp:TableCell>
                     <asp:TableCell runat="server"><b>Time_Difference</b></asp:TableCell>
                 </asp:TableRow>
             </asp:Table>
             &nbsp;<asp:Table ID="Table2" runat="server" Height="24px" Width="718px" BackColor="#99CCFF" BorderColor="#CCFFCC" ForeColor="#3366FF" GridLines="Vertical" Visible="False" BorderStyle="Dashed">
                 <asp:TableRow runat="server" Width="360px">
                     <asp:TableCell runat="server" Width="950px"></asp:TableCell>
                     <asp:TableCell runat="server" Width="362px"></asp:TableCell>
                     <asp:TableCell runat="server" BorderStyle="None" Width="487px"></asp:TableCell>
                 </asp:TableRow>
             </asp:Table>
         </div>
         <br />
            
      </div>
  </div>
 <div id="myform" style="background-color:#3fb0ac; display:block" class="auto-style13">
    
   
     <asp:LinkButton ID="LinkButton3" runat="server">Home</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <br />
     <asp:LinkButton ID="LinkButton4" runat="server">Stuff</asp:LinkButton>
     <br />
     <asp:LinkButton ID="LinkButton5" runat="server">Refresh</asp:LinkButton>
     <br />
     <asp:LinkButton ID="LinkButton6" runat="server">Login</asp:LinkButton>
     <br />
     <asp:LinkButton ID="LinkButton7" runat="server">Refresh</asp:LinkButton>
     <br />
     <asp:LinkButton ID="LinkButton8" runat="server">Exit</asp:LinkButton>
     <br />
     <br />
    
   
  
       </div> 
    </form>
</body>
</html>

