<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color: lightslategray;
            z-index: 1;
            width: auto;
            height: auto;
        }       
        div.heading{
            background: #f85f64;
            color: #fff;
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            padding: 1.5em;
            width: auto;
            height: auto;
        }
        div.textbackground{
            background: #fff;
            color: #000;
            text-align: center;
            text-transform:capitalize;
            font-weight: bold;
            padding: 1.3em;
            width: auto;
            height: auto;
        }
        tablediv{
            position: absolute;
            z-index: 2;
            top: 250px;
            left: 300px;
        }

        .auto-style1 {
            position: relative;
            left: 480px;
            top: 4px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="heading">Cloud Storage Service</div>
        <div class="textbackground">
        <h3>Sign In or Create Account</h3>
            <table class="auto-style1">
                <tr>
                    <td><asp:Label ID="lblEmail" runat="server" Text="Email Address:" Font-Bold="True"></asp:Label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" TextMode="Email" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Bold="True"></asp:Label></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblRemember" runat="server" Text="Remember Me"></asp:Label></td>
                    <td><asp:CheckBox ID="chkRemember" runat="server" Checked="True" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnSignin" runat="server" Text="Sign In" OnClick="btnSignin_Click" /></td>
                    <td><asp:Button ID="btnRegister" runat="server" Text="Sign Up" OnClick="btnRegister_Click"/></td>
                    <td><asp:Button ID="btnOtherUser" runat="server" Text="Not Me" OnClick="btnOtherUser_Click" visible ="false"/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDisplayText1" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDisplayText2" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
           </div>
    </form>
</body>
</html>