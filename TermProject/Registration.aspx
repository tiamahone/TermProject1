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
        .auto-style2 {
            z-index: 1;
            left: 381px;
            top: 202px;
            position: absolute;
        }
        .auto-style3 {
            z-index: 1;
            left: 420px;
            top: 272px;
            position: absolute;
        }
        .auto-style4 {
            z-index: 1;
            left: 309px;
            top: 273px;
            position: absolute;
        }
        .auto-style5 {
            z-index: 1;
            left: 420px;
            top: 309px;
            position: absolute;
        }
        .auto-style6 {
            z-index: 1;
            left: 338px;
            top: 310px;
            position: absolute;
        }
        .auto-style7 {
            z-index: 1;
            left: 420px;
            top: 346px;
            position: absolute;
        }
        .auto-style8 {
            z-index: 1;
            left: 288px;
            top: 345px;
            position: absolute;
        }
        .auto-style9 {
            z-index: 1;
            left: 350px;
            top: 402px;
            position: absolute;
        }
        .auto-style10 {
            z-index: 1;
            left: 177px;
            top: 445px;
            position: absolute;
        }
        .auto-style11 {
            position: relative;
            left: 410px;
            top: 55px;
        }
        .auto-style12{
            z-index: 1;
            left: 356px;
            top: 239px;
            position: absolute;
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
        <h3 class="auto-style2" >All Fields Required</h3>

        <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="auto-style12"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="auto-style11"></asp:TextBox>
        <asp:Label ID="lblEmail" runat="server" Text= "Email Address:" CssClass="auto-style4"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="auto-style3"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="auto-style6"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="auto-style5"></asp:TextBox>
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password:" CssClass="auto-style8"></asp:Label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="auto-style7"></asp:TextBox>
        <asp:Button ID="btnRegister" runat="server" Text="Register For Account" CssClass="auto-style9" />
        <asp:Button ID="btnBack" runat="server" Text="Back To login" OnClick="btnRegister_Click" CssClass="auto-style10" />


    </form>
</body>
</html>