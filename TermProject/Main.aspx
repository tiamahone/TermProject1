﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProject.Main" %>

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
        <div class="heading">Homepage</div>
        <div class="textbackground">
            <asp:Label ID="lblDisplayText" runat="server" Text=""></asp:Label>
            <br />
            <table>
                <asp:Button ID="btnAddAdmin" runat="server" Text="Add Admin" OnClick="btnAddAdmin_Click" Visible="false" />
                <asp:Button ID="btnViewTransactions" runat="server" Text="View Transactions" OnClick="btnViewTransactions_Click" Visible="false" />
                <asp:Button ID="btnMyFiles" runat="server" Text="My Files" OnClick="btnMyFiles_Click" Visible="false" />
                <asp:Button ID="btnDeleteFiles" runat="server" Text="Delete Files" OnClick="btnDeleteFiles_Click" Visible="false" />
                <asp:Button ID="btnAdminEditUser" runat="server" Text="Edit User" OnClick="btnAdminEditUser_Click" Visible="false" />
                <asp:Button ID="btnUserEditUser" runat="server" Text="Edit Info" OnClick="btnUserEditUser_Click" Visible="false" />
                <asp:Button ID="btnAskQuestion" runat="server" Text="Ask Support Questions" OnClick="btnaskQuestion_Click" Visible="false" />
                <asp:Button ID="btnAnswerQuestion" runat="server" Text="Answer Support Questions" OnClick="btnAnswerQuestion_Click" Visible="false" />

                <asp:Button ID="btnAdminViewUserFiles" runat="server" Text="View User Files" OnClick="btnViewUserFiles_Click" Visible="false" />
                <asp:Button ID="btnViewTrash" runat="server" Text="View Trash" OnClick="btnViewTrash_Click" Visible="false" />
                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" Visible="false" />
                <asp:Button ID="btnStorageOptions" runat="server" Text="Storage Options" OnClick="btnStorageOptions_Click" Visible="false" />
                <asp:Button ID="btnBack" runat="server" Text="Back To Login" OnClick="btnBack_Click" />
            </table>
        </div>

        <%--User files section--%>
        <div>
            <asp:FileUpload ID="fileUp" runat="server" Style="z-index: 1; left: 10px; top: 245px; position: absolute" Visible="false" BackColor="White" BorderStyle="None" />
            <asp:Label ID="lblFile" runat="server" Text="Upload or Update file to cloud:" Style="z-index: 1; left: 10px; top: 220px; position: absolute; font-weight: 700;" Visible="false"></asp:Label>
            <asp:Button ID="btnFile" runat="server" Style="z-index: 1; left: 260px; top: 245px; position: absolute" Text="Upload" OnClick="btnFile_Click" Visible="false" />
        </div>
        <asp:Label ID="lblFreeUserSpace" runat="server" Text="Free Space Remaining: " Style="font-weight: 700;" Visible="false"></asp:Label>
        <asp:GridView ID="gvUserFiles" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 289px" EmptyDataText="No Files Stored" HeaderText="Cloud Files" Visible="false" AllowPaging="True">
            <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
            <Columns>
                <asp:BoundField DataField="File Name" HeaderText="File Name" />
                <asp:BoundField DataField="File Type" HeaderText="File Type" />
                <asp:BoundField DataField="File Size" HeaderText="File Size" />
            </Columns>
        </asp:GridView>



        <%--Transactions Section--%>
        <asp:GridView ID="gvTransactions" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 600px" EmptyDataText="No Transactions Found" HeaderText="Transactions" Visible="false" AllowPaging="True" OnSelectedIndexChanged="gvTransactions_SelectedIndexChanged">
            <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
        </asp:GridView>

        <asp:Label ID="lblSelectUser" runat="server" Text="User:" Style="z-index: 1; left: 10px; top: 280px; position: absolute; font-weight: 700;" Visible="false"></asp:Label>
        <asp:DropDownList ID="dropUser" runat="server" Style="z-index: 1; left: 100px; top: 280px; position: absolute" Visible="false">
        </asp:DropDownList>
        <asp:Label ID="lblSelectTimePeriod" runat="server" Text="Time Period:" Style="z-index: 1; left: 300px; top: 280px; position: absolute; font-weight: 700;" Visible="false"></asp:Label>
        <asp:DropDownList ID="dropTimePeriod" runat="server" Style="z-index: 1; left: 400px; top: 280px; position: absolute" Visible="false">
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnGetTransactions" runat="server" Style="z-index: 1; left: 500px; top: 280px; position: absolute" Text="Get Transactions" OnClick="btnGetTransactions_Click" Visible="false" />

        <%--Admin view user files section--%>
        <asp:GridView ID="gvAdminUserFilesView" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 600px" EmptyDataText="No Files Found" HeaderText="Transactions" Visible="false" AllowPaging="True" OnSelectedIndexChanged="gvTransactions_SelectedIndexChanged">
            <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
        </asp:GridView>

        <asp:Label ID="lblSelectUserFA" runat="server" Text="User:" Style="z-index: 1; left: 10px; top: 280px; position: absolute; font-weight: 700;" Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlAdminUserFilesView" runat="server" Style="z-index: 1; left: 100px; top: 280px; position: absolute" Visible="false">
        </asp:DropDownList>
        <asp:Button ID="btnGetUserFilesView" runat="server" Style="z-index: 1; left: 500px; top: 280px; position: absolute" Text="View Files" OnClick="btnGetUserFiles_Click" Visible="false" />



        <%--Admin Account tools section--%>
        <asp:GridView ID="gvAdminModify" runat="server" AllowPaging="True" PageSize="10" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 289px" Visible="False"
            AutoGenerateColumns="False" OnRowCancelingEdit="gvAdminModify_RowCancelingEdit" OnRowEditing="gvAdminModify_RowEditing" OnSelectedIndexChanged="gvAdminModify_SelectedIndexChanged"
            OnRowUpdating="gvAdminModify_RowUpdating" OnPageIndexChanging="gvAdminModify_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Email" HeaderText="Email Address" ReadOnly="True" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Phone" HeaderText="Phone Number" />
                <asp:BoundField DataField="Free Storage" HeaderText="Free Storage" ReadOnly="True" />
                <asp:BoundField DataField="Total Storage" HeaderText="Total Storage" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit Account"
                    ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <%--Admin Delete Account Section--%>
        <asp:Button ID="btnDeleteSelection" runat="server" Style="z-index: 1; left: 260px; top: 245px; position: absolute" Text="Delete Selection" OnClick="btnDeleteSelection_Click" Visible="false" />
        <asp:GridView ID="gvDelete" runat="server" Style="z-index: 1; left: 10px; top: 270px; position: absolute; height: 523px; width: 975px" Visible="False" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select User">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email Address" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Phone" HeaderText="Phone Number" />
                <asp:BoundField DataField="Free Storage" HeaderText="Free Storage" />
                <asp:BoundField DataField="Total Storage" HeaderText="Total Storage" />
            </Columns>
        </asp:GridView>

        <%--User account tools section--%>
        <asp:GridView ID="gvUserModify" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 289px" Visible="False"
            AutoGenerateColumns="False" OnRowCancelingEdit="gvUserModify_RowCancelingEdit" OnRowEditing="gvUserModify_RowEditing" OnSelectedIndexChanged="gvUserModify_SelectedIndexChanged"
            OnRowUpdating="gvUserModify_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email Address" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Phone" HeaderText="Phone Number" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit Account"
                    ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <%--User delete files section--%>
        <asp:Button ID="btnDeleteFile" runat="server" Style="z-index: 1; left: 260px; top: 245px; position: absolute" Text="Delete Selection" EmptyDataText="No Files Found" OnClick="btnDeleteFile_Click" Visible="false" />
        <asp:GridView ID="gvDeleteFile" runat="server" Style="z-index: 1; left: 10px; top: 270px; position: absolute; height: 523px; width: 975px" Visible="False" AutoGenerateColumns="False" EmptyDataText="No Files Found">
            <Columns>
                <asp:TemplateField HeaderText="Select File">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectFile" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="File Name" HeaderText="File Name" />
                <asp:BoundField DataField="File Type" HeaderText="File Type" />
                <asp:BoundField DataField="File Size" HeaderText="File Size" />
            </Columns>
        </asp:GridView>

        <%--Questions--%>
        <p>
        <asp:GridView ID="gvQuestions" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; height: 180px; width: 900px" EmptyDataText="No Questions Found" HeaderText="Transactions" Visible="false" AllowPaging="True" OnSelectedIndexChanged="gvTransactions_SelectedIndexChanged">
            <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
        </asp:GridView>
        </p>
        <p>
            <asp:Label ID="lblQuestion" runat="server" />
            <asp:TextBox ID="txtQuestions" runat="server" Visible="false" ></asp:TextBox>
            <asp:Button ID="btnAsk" runat="server"  Text="Ask Question" OnClick="btnAsk_Click" Visible="false" />
            <asp:Button ID="btnAnswer" runat="server"  Text="Ask Question" OnClick="btnAnswer_Click" Visible="false" />

        </p>
        


    </form>
</body>
</html>
