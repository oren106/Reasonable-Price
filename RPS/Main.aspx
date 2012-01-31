<!--Authors Sephora Ben-Israel, Erez Najar-->
<%@ Page Language="C#" AutoEventWireup="true" Inherits="main" CodeBehind="Main.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="visible();">
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">

       
        function resetAll() {
            document.getElementById("<%=TextPrice.ClientID %>").value = " ";
            document.getElementById("<%=TextAmount.ClientID %>").value = " ";
            document.getElementById("<%=TextPlace.ClientID %>").value = " ";
            document.getElementById("<%=TextCity.ClientID %>").value = " ";
            document.getElementById("<%=TextName.ClientID %>").value = " ";
            return false;
        }
        function vald() {
            var reg = new RegExp("^[0-9]+$");
            var check = true;
            var value = document.getElementById("<%=TextPrice.ClientID %>").value;
            if (reg.test(value.toString()) == false) {
                alert("Price can only be numircal");
                document.getElementById("<%=TextPrice.ClientID %>").focus();
                return false;
            }
            var val = document.getElementById("<%=TextAmount.ClientID %>").value;
            if (reg.test(val.toString()) == false) {
                alert("Amount can only be numircal");
                document.getElementById("<%=TextAmount.ClientID %>").focus();
                return false;
            }
            return true;
        }

    </script>
    <div align="center">
        <h1>
            RPS</h1>
        <img alt="" src="images/logo.jpg" style="height: 79px; width: 103px" />
        <h3>
            Reasonable Price System</h3>
        <br />
       
       <abbr title = "Product name"><asp:TextBox ID="TextName" runat="server"></asp:TextBox></abbr>
        &nbsp;&nbsp;
        <abbr title ="Product price"><asp:TextBox ID="TextPrice" runat="server"></asp:TextBox></abbr>
      <abbr title ="Your local currency"><asp:DropDownList ID="DropDownCurrncy" runat="server">
            <asp:ListItem Value="1" Text="שח" Selected="True" />
            <asp:ListItem Value="2" Text="Dollar $" />
            <asp:ListItem Value="-1" Text="none" />
        </asp:DropDownList></abbr>
        <br />
        <br />
        <br />
        <abbr title ="The amount you are buying"><asp:TextBox ID="TextAmount"  runat="server"></asp:TextBox></abbr>
        &nbsp;&nbsp;
        <abbr title = "The measurment used (liter,mililiter,kg,gr,non)"><asp:DropDownList ID="DropDownMessurment" runat="server">
            <asp:ListItem Value="1" Text="Kg" />
            <asp:ListItem Value="2" Text="gr" />
            <asp:ListItem Value="3" Text="Liter" />
            <asp:ListItem Value="4" Text="miliLiter" />
            <asp:ListItem Value="-1" Text="none" Selected="True" />
        </asp:DropDownList></abbr>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <abbr title ="The place you are buying (supermarket,petrolstation,kiosk, etc)"><asp:TextBox ID="TextPlace" runat="server"></asp:TextBox></abbr>
        &nbsp;
        <abbr title ="The city you are buying"><asp:TextBox ID="TextCity" runat="server"></asp:TextBox></abbr>
        <br />
        <br />
      
&nbsp;&nbsp;<asp:Button ID="send" runat="server" Text="Send" OnClientClick="return vald();" OnClick="send_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" CausesValidation = "false" Text="Reset" OnClientClick="return resetAll();" />        
        <br />
        <br />
    </div>
    </form>
</body>
</html>
