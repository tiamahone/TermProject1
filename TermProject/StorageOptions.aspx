<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorageOptions.aspx.cs" Inherits="TermProject.StorageOptions" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: lightslategray;
            z-index: 1;
            left: 0px;
            top: 0px;
            position: absolute;
            height: 286px;
            width: 2086px;
        }

        div.heading {
            background: #f85f64;
            color: #fff;
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            padding: 1.5em;
        }

        div.textbackground {
            background: #fff;
            color: #000;
            text-align: center;
            text-transform: capitalize;
            font-weight: bold;
            padding: 1.3em;
        }

        h1 {
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
        <div class="heading">Cloud strorage options</div>
        <div class="textbackground">
            <asp:Label ID="lblDisplayText" runat="server" Text=""></asp:Label>
            <br />
            <table>
                <asp:Button ID="btnBack" runat="server" Text="Back To Main" OnClick="btnBack_Click" />
            </table>
        </div>


        <div>
        </div>


        <div>
            <asp:RadioButtonList ID="rdoStorageOptions" runat="server" Visible="false" >
                <asp:ListItem>100 MB (Free)</asp:ListItem>
                <asp:ListItem>1 GB ($0.99/Month)</asp:ListItem>
                <asp:ListItem>2 GB ($1.99/Month)</asp:ListItem>
                <asp:ListItem>5 GB ($2.99/Month)</asp:ListItem>
                <asp:ListItem>10 GB ($4.99/Month)</asp:ListItem>
                <asp:ListItem>50 GB ($9.99/Month)</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <p>
                <asp:Button ID="btnBack2" runat="server" Text="Back To Main" OnClick="btnBack_Click" />
                <asp:Button ID="btnChangePlan" runat="server" Text="Change Plan" OnClick="btnChangePlan_Click" />
            </p>
        </div>

        <div>
            <p>
                <asp:Label ID="lblDisplayText2" runat="server" Text=""></asp:Label>
            </p>
        </div>






    </form>
</body>
</html>
