<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="Answer.aspx.cs" %>
<%@ PreviousPageType VirtualPath="~/Main.aspx" %> 
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
        <h3>Reasonable Price System</h3>
        <asp:Label ID="answer" runat="server" Text="Label"></asp:Label>
        <br />
        <img alt="" src="images\sacle.jpg" 
            style="width: 358px; height: 120px; margin-top: 0px;" /><br />
        <asp:Image ID="Image1" runat="server"  style="width: 358px; height: 120px; margin-top: 0px;" />
    </div>
    
    
    </form>
</body>
</html>
