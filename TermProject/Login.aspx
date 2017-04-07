<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

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
            <h1 class="auto-style1"><strong>Cloud Storage Service</strong></h1>
        </p>
        <h3 style="z-index: 1; left: 175px; top: 250px; position: absolute " >Sign In or Create Account</h3>
        <asp:Label ID="lblEmail" runat="server" Style="z-index: 1; left: 100px; top: 300px; position: absolute " Text="Email Address:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Style="z-index: 1; left: 250px; top: 300px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Style="z-index: 1; left: 100px; top: 330px; position: absolute" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="z-index: 1; left: 250px; top: 330px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblRemember" runat="server" Style="z-index: 1; left: 250px; top: 360px; position: absolute" Text="Remember Me"></asp:Label>
        <asp:CheckBox ID="chkRemember" runat="server" Style="z-index: 1; left: 350px; top: 360px; position: absolute" Checked="True" />
        <asp:Button ID="btnSignin" runat="server" style="z-index: 1; left: 250px; top: 390px; position: absolute" Text="Sign In" OnClick="btnSignin_Click" />
        <asp:Button ID="btnRegister" runat="server" style="z-index: 1; left: 350px; top: 390px; position: absolute" Text="Sign Up" OnClick="btnRegister_Click" />
        <asp:Label ID="lblDisplayText" runat="server" Style="z-index: 1; left: 100px; top: 420px; position: absolute" Text=""></asp:Label>


    </form>
</body>
</html>
