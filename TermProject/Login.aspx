<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h1{
            text-align: center;
            text-justify: auto;
            text-decoration: underline;
        }
        body{
            background-color: #beb8b8;
        }
        .auto-style2 {
            z-index: 1;
            left: 375px;
            top: 137px;
            position: absolute;
        }
        .auto-style3 {
            z-index: 1;
            left: 456px;
            top: 196px;
            position: absolute;
        }
        .auto-style4 {
            z-index: 1;
            left: 350px;
            top: 196px;
            position: absolute;
            right: 502px;
        }
        .auto-style5 {
            z-index: 1;
            left: 456px;
            top: 235px;
            position: absolute;
        }
        .auto-style6 {
            z-index: 1;
            left: 379px;
            top: 236px;
            position: absolute;
        }
        .auto-style7 {
            z-index: 1;
            left: 471px;
            top: 280px;
            position: absolute;
        }
        .auto-style8 {
            z-index: 1;
            left: 362px;
            top: 281px;
            position: absolute;
        }
        .auto-style9 {
            z-index: 1;
            left: 483px;
            top: 321px;
            position: absolute;
        }
        .auto-style10 {
            z-index: 1;
            left: 400px;
            top: 321px;
            position: absolute;
            right: 483px;
        }
        .auto-style11{
            z-index: 1;
            left: 429px;
            top: 164px;
            position: absolute;
            right: 423px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <h1><strong style="position: relative">Cloud Storage Service</strong></h1>
        <hr />
        <h3 class="auto-style2" >Sign In or Create Account</h3>
        <asp:Label ID="lblDisplay" runat="server" CssClass="auto-style11"></asp:Label>
        <asp:Label ID="lblEmail" runat="server" Text="Email Address:" CssClass="auto-style4"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="auto-style3"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="auto-style6"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="auto-style5"></asp:TextBox>
        <asp:Label ID="lblRemember" runat="server" Text="Remember Me" CssClass="auto-style8"></asp:Label>
        <asp:CheckBox ID="chkRemember" runat="server" Checked="True" CssClass="auto-style7" />
        <asp:Button ID="btnSignin" runat="server" Text="Sign In" CssClass="auto-style10" OnClick="btnSignin_Click" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="auto-style9" />


    </form>
</body>
</html>
