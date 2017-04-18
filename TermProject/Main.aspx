<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProject.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color: lightslategray;
            z-index: 1;
            left: 0px;
            top: 0px;
            position: absolute;
            height: 286px;
            width: 2086px;
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
        .auto-style1 {
            position: relative;
            left: 356px;
            top: 27px;
            width: 97px;
            height: 21px;
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
        <asp:Button ID="btnViewTransactions" runat="server" Text="View Transactions" OnClick="btnViewTransactions_Click" Visible ="false" />
        <asp:Button ID="btnBack" runat="server" Text="Back To Login" OnClick="btnBack_Click" />
        </table>
     </div>
     <div>
        <asp:FileUpload ID="fileUp" runat="server" style="z-index: 1; left: 10px; top: 245px; position: absolute" Visible ="false" BackColor="White" BorderStyle="None" />
         <asp:Label ID="lblFile" runat="server" Text="Upload file to cloud:" style="z-index: 1; left: 10px; top: 220px; position: absolute; font-weight: 700;" Visible ="false"></asp:Label>
         <asp:Button ID="btnFile" runat="server" style="z-index: 1; left: 260px; top: 245px; position: absolute" Text="Upload" OnClick="btnFile_Click" Visible ="false" />
     </div>
             <asp:Label ID="lblFreeUserSpace" runat="server" Text="Free Space Remaining: " style="font-weight: 700;" Visible ="false"></asp:Label>
             <asp:GridView ID="gvUserFiles" runat="server" style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 289px" EmptyDataText="No Files Stored" HeaderText = "Cloud Files" Visible ="false" AllowPaging="True">
                 <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
        </asp:GridView>

        <asp:GridView ID="gvTransactions" runat="server" style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 289px" EmptyDataText="No Transactions Found" HeaderText = "Transactions" Visible ="false" AllowPaging="True" OnSelectedIndexChanged="gvTransactions_SelectedIndexChanged">
                 <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
         </asp:GridView>

        <asp:Label ID="lblSelectUser" runat="server" Text="User:" style="z-index: 1; left: 10px; top: 280px; position: absolute; font-weight: 700;" Visible ="false"></asp:Label>
        <asp:DropDownList ID="dropUser" runat="server" style="z-index: 1; left: 100px; top: 280px; position: absolute" Visible ="false">
        </asp:DropDownList>
        <asp:Label ID="lblSelectTimePeriod" runat="server" Text="Time Period:" style="z-index: 1; left: 300px; top: 280px; position: absolute; font-weight: 700;" Visible ="false"></asp:Label>
        <asp:DropDownList ID="dropTimePeriod" runat="server" style="z-index: 1; left: 400px; top: 280px; position: absolute" Visible ="false">
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
         <asp:Button ID="btnGetTransactions" runat="server" style="z-index: 1; left: 500px; top: 280px; position: absolute" Text="Get Transactions" OnClick="btnGetTransactions_Click" Visible ="false" />
        <p>
        <asp:Button ID="btnUpdateFile" runat="server" Text="Update File" CssClass="auto-style1" OnClick="btnUpdateFile_Click"  Visible="false"/>

             </p>

             </form>
</body>
</html>
