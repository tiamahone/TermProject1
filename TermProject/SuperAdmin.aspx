<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperAdmin.aspx.cs" Inherits="TermProject.SuperAdmin" %>

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
    <div class="textbackground">
            <asp:Label ID="lblDisplayText" runat="server" Text=""></asp:Label>
            <br />
            <table>
                <asp:Button ID="btnAddAdmin" runat="server" Text="Add Admin" OnClick="btnAddAdmin_Click" Visible="true" />
                <asp:Button ID="btnViewTransactions" runat="server" Text="View Transactions" OnClick="btnViewTransactions_Click" Visible="true" />
                <asp:Button ID="btnViewUsers" runat="server" Visible="true" Text="View Users" CssClass="auto-style1" OnClick="btnViewUsers_Click"/>
                <asp:Button ID="btnMyFiles" runat="server" Text="My Files" OnClick="btnMyFiles_Click" Visible="true" />
                <asp:Button ID="btnDeleteFiles" runat="server" Text="Delete Files" OnClick="btnDeleteFiles_Click" Visible="true" />
                <asp:Button ID="btnAdminEditUser" runat="server" Text="Edit User" OnClick="btnAdminEditUser_Click" Visible="true" />
                <asp:Button ID="btnUserEditUser" runat="server" Text="Edit Info" OnClick="btnUserEditUser_Click" Visible="true" />
                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" Visible="true" />
                <asp:Button ID="btnStorageOptions" runat="server" Text="Storage Options" OnClick="btnStorageOptions_Click" Visible="true" />
                <asp:Button ID="btnBack" runat="server" Text="Back To Login" OnClick="btnBack_Click" />
            </table>
        </div>
    </form>
</body>
</html>
