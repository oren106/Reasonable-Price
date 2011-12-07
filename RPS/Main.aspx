<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        
        <h1>RPS</h1>
        <img alt="" src="images\logo.jpg" style="height: 79px; width: 103px" />
        <h3>Reasonable Price System</h3><br />
        <br />
        <br />
        <asp:TextBox ID="QuestionEntry" runat="server"></asp:TextBox>
        <asp:Button ID="Ask" runat="server" onclick="Ask_Click" Text="ASK" />
        
        <br />
        <br />
        <br />
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
