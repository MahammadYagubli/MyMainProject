<%@ Page  Title="About" Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="test.Error" %>
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
              <div class="auto-style3" >
                  <asp:Image ID="Image1" runat="server" BackColor="White" Height="76px" ImageUrl="~/files/guv_logo_ang.png" Width="79px" />
              </div>
        &nbsp;<br />
              <br />
              <br />
              <br />
&nbsp;&nbsp;&nbsp; Login&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
              &nbsp;&nbsp;&nbsp; Password&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
              <br />
&nbsp;&nbsp;
              <br />
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me" TextAlign="Left" />
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button1" runat="server" Height="25px" Text="Login" Width="70px" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
