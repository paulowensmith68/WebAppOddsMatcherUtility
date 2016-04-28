<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppOddsMatcherUtility.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Height="376px" Width="787px">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-bottom: 0px; padding-left:200px" Width="171px" >
                <asp:ListItem Value="Normal"></asp:ListItem>
                <asp:ListItem Value="Free Bet SNR"></asp:ListItem>
                <asp:ListItem Value="Free Bet SR"></asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
    </form>
</body>
</html>
