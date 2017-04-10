<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProject.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color: lightslategray;
            z-index: 1;
        }       
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="heading"> Homepage</div>
    <div  class="textbackground">
        <asp:Label ID="lblDisplayText" runat="server" Text=""></asp:Label>
        <br />
        <table>
        <asp:Button ID="btnAddAdmin" runat="server" Text="Add Admin" OnClick="btnAddAdmin_Click" Visible ="false" />
        <asp:Button ID="btnBack" runat="server" Text="Back To Login" OnClick="btnBack_Click" />
        </table>
     </div>
    </form>
</body>
</html>
