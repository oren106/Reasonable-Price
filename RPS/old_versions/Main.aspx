<%@ Page Language="C#" AutoEventWireup="True" Inherits="_Main" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" Codebehind="Main.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body onload="visible();">

    <form id="form2" runat="server">
    <script language = "javascript" type="text/javascript">
        
       function vald() {
            var reg = new RegExp("^[0-9]+$");
            var check = true;
            var value = document.getElementById("<%=TextPrice.ClientID %>").value;
           if(reg.test(value.toString()) == false){
           alert("Price can only be numircal");
            document.getElementById("<%=TextPrice.ClientID %>").focus();
            return false;
           }
           var val = document.getElementById("<%=TextAmount.ClientID %>").value;

           if(reg.test(val.toString()) == false){
           alert("Amount can only be numircal");
            document.getElementById("<%=TextAmount.ClientID %>").focus();
            return false;
           }

           return true;
           }
            
                            
                                         
       
          
           
        
    </script>
    <div align="center">

        
        <h1>RPS</h1>
        <img alt="" src="images\logo.jpg" style="height: 79px; width: 103px" />
        <h3>Reasonable Price System</h3><br />
        <asp:TextBox ID="TextName" runat="server" text="Product" 
            meta:resourcekey="TextNameResource1"></asp:TextBox>
&nbsp;&nbsp;
        <asp:TextBox ID="TextPrice" runat="server" Text="Price" 
            meta:resourcekey="TextPriceResource1" ></asp:TextBox>
        <asp:DropDownList ID="DropDownCurrncy" runat="server" 
            meta:resourcekey="DropDownCurrncyResource1">
        <asp:ListItem Value = "1" Text="שח" Selected="True" 
                meta:resourcekey="ListItemResource1"/>
         <asp:ListItem Value ="2" Text = "Dollar $" meta:resourcekey="ListItemResource2"  />
          <asp:ListItem Value ="-1" Text = "none" meta:resourcekey="ListItemResource3"  />
        </asp:DropDownList>
        <br />
        <br />    
        <br />
        <asp:TextBox ID="TextAmount" runat="server" Text = "Amount" 
            meta:resourcekey="TextAmountResource1"></asp:TextBox>
&nbsp;&nbsp;<asp:DropDownList ID="DropDownMessurment" runat="server" 
            meta:resourcekey="DropDownMessurmentResource1">
        <asp:ListItem Value ="1" Text = "Kg" meta:resourcekey="ListItemResource4"/>
        <asp:ListItem Value ="2" text = "gr" meta:resourcekey="ListItemResource5" />
        <asp:ListItem Value ="3" Text="Liter" meta:resourcekey="ListItemResource6"/>
        <asp:ListItem Value ="4" Text = "miliLiter" meta:resourcekey="ListItemResource7"  />
         <asp:ListItem Value ="-1" Text = "none" Selected="True" 
                meta:resourcekey="ListItemResource8" />

        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextPlace" runat="server" Text="Place" 
            meta:resourcekey="TextPlaceResource1"></asp:TextBox>
        &nbsp;<asp:TextBox ID="TextCity" runat="server" Text="City" 
            meta:resourcekey="TextCityResource1"></asp:TextBox>
        <br />
        <br />
    
        <asp:Button ID="send" runat="server" Text="Send" 
            OnClientClick = "return vald();" OnClick = "send_Click" 
            meta:resourcekey="sendResource1"/>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
