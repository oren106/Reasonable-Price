<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body onload="visible();">

    <form id="form1" runat="server">
    <div align="center">

        
        <h1>RPS</h1>
        <img alt="" src="images\logo.jpg" style="height: 79px; width: 103px" />
        <h3>Reasonable Price System</h3><br />
        <asp:TextBox ID="TextName" runat="server" text="Product"></asp:TextBox>
&nbsp;&nbsp;
        <asp:TextBox ID="TextPrice" runat="server" Text="Price" ></asp:TextBox>
        <asp:DropDownList ID="DropDownCurrncy" runat="server">
        <asp:ListItem Value = "1" Text="שח" Selected="True"/>
         <asp:ListItem Value ="2" Text = "Dollar $"  />
          <asp:ListItem Value ="-1" Text = "none"  />
        </asp:DropDownList>
        <br />
        <br />    
        <br />
        <asp:TextBox ID="TextAmount" runat="server">Amount</asp:TextBox>
&nbsp;&nbsp;<asp:DropDownList ID="DropDownMessurment" runat="server">
        <asp:ListItem Value ="1" Text = "Kg"/>
        <asp:ListItem Value ="2" text = "gr" />
        <asp:ListItem Value ="3" Text="Liter"/>
        <asp:ListItem Value ="4" Text = "miliLiter"  />
         <asp:ListItem Value ="-1" Text = "none" Selected="True" />

        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextPlace" runat="server" Text="Place"></asp:TextBox>
        &nbsp;<asp:TextBox ID="TextCity" runat="server" Text="City"></asp:TextBox>
        <br />
        <br />
    
        <asp:Button ID="send" runat="server" Text="Send" onclick="send_Click" />
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
