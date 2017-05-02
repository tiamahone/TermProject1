<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trash.aspx.cs" Inherits="TermProject.Trash" %>

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

            <asp:GridView ID="gvTrash" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 600px" EmptyDataText="No Files Found" HeaderText="User Trash Can" AllowPaging="True" AutoGenerateColumns="false" OnRowCommand="gvTrash_RowCommand">
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
                <Columns>
                    <asp:ButtonField CommandName="recover" ControlStyle-CssClass="btn btn-info" ButtonType="Button" Text="Recover" HeaderText="Detailed View" />
                    <asp:BoundField DataField="Id" HeaderText="Trash Id" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="File Name" HeaderText="File Name" />
                    <asp:BoundField DataField="File Type" HeaderText="File Type" />
                    <asp:BoundField DataField="File Size" HeaderText="File Size" />
                    <asp:BoundField DataField="TimeStamp" HeaderText="Time Stamp" />
                </Columns>

            </asp:GridView>

        </div>



        <div>
            <p>
                <asp:Label ID="lblDisplayText2" runat="server" Text=""></asp:Label>
            </p>
        </div>






    </form>
</body>
</html>
