<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registraion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
            text-align: center;
        }
    </style>
</head>
<body bgcolor = "#beb8b8">
    <form id="form1" runat="server">
        <div>
        </div>
        <p class="auto-style1">
            <h1 class="auto-style1"><strong>Register New Account</strong></h1>
        </p>
        <h3 style="z-index: 1; left: 175px; top: 250px; position: absolute " >All Fields Required</h3>
        <asp:Label ID="lblEmail" runat="server" Style="z-index: 1; left: 100px; top: 300px; position: absolute " Text= "Email Address:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Style="z-index: 1; left: 250px; top: 300px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Style="z-index: 1; left: 100px; top: 330px; position: absolute" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="z-index: 1; left: 250px; top: 330px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblConfirm" runat="server" Style="z-index: 1; left: 100px; top: 360px; position: absolute" Text="Confirm Password:"></asp:Label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Style="z-index: 1; left: 250px; top: 360px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblRemember" runat="server" Style="z-index: 1; left: 250px; top: 390px; position: absolute" Text="Remember Me"></asp:Label>
        <asp:CheckBox ID="chkRemember" runat="server" Style="z-index: 1; left: 350px; top: 390px; position: absolute" Checked="True" />
        <asp:Button ID="btnRegister" runat="server" style="z-index: 1; left: 300px; top: 420px; position: absolute" Text="Register For Account" />
        <asp:Button ID="btnBack" runat="server" style="z-index: 1; left: 100px; top: 500px; position: absolute" Text="Back To login" OnClick="btnRegister_Click" />


    </form>
</body>
</html>