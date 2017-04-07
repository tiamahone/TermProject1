<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProject.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblDisplayText" runat="server" style="z-index: 1; left: 10px; top: 200px; position: absolute" Text=""></asp:Label>
    
        <asp:Button ID="btnBack" runat="server" style="z-index: 1; left: 10px; top: 250px; position: absolute" Text="Back To Login" OnClick="btnBack_Click" />
    
    </div>
    </form>
</body>
</html>
