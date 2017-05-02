<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registraion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color: lightslategray;
            z-index: 1;
        }       
        /*table{
            position: absolute;
            z-index: 2;
            top: 250px;
            left: 300px;
        }*/

        div.heading{
            background: #f85f64;
            color: #fff;
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            padding: 1.5em;
        }
        div.textbackground{
            background: #fff;
            color: #000;
            text-align: center;
            text-transform:capitalize;
            font-weight: bold;
            padding: 1.3em;
        }
        h1{
            text-decoration: underline;
            text-align: center;
            z-index: 3;
            left: 300px;
            top: 100px;
            position: absolute;
        }
        /*h3{
            z-index: 3;
            left: 300px;
            top: 200px;
            position: absolute;
        }*/
        .auto-style1 {
            position: relative;
            left: 503px;
            top: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="heading">Register Account</div>
        <div class="textbackground">
        <h3>All Fields Required</h3>
        <table class="auto-style1">
            <tr>
                <td><asp:Label ID="lblName" runat="server" Text= "Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtName" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmail" runat="server" Text= "Email Address:"></asp:Label></td>
                <td><asp:TextBox ID="txtEmail" runat="server" TextMode="Email" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblConfirm" runat="server" Text="Confirm Password:"></asp:Label></td>
                <td><asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblRemember" runat="server" Text="Remember Me"></asp:Label></td>
                <td><asp:CheckBox ID="chkRemember" runat="server" Checked="True" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnRegister" runat="server" Text="Register For Account" OnClick="btnRegister_Click1" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblDisplayText" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr></tr>
            <tr>
                <td><asp:Button ID="btnBackMain" runat="server" Text="Back To Main" OnClick="btnBackMain_Click" /></td>
                <td><asp:Button ID="btnBackLogin" runat="server" Text="Back to Login" OnClick="btnBackLogin_Click" /></td>
            </tr>
        </table>
     </div>
    </form>
</body>
</html>