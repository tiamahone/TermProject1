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
            <asp:RadioButtonList ID="rdoStorageOptions" runat="server" Visible="false">
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
        <div>
            <p>
                <asp:Label ID="lblName" runat="server" Text="Label" Visible="false">Name:</asp:Label>
                <asp:TextBox ID="txtName" runat="server" Visible="false"></asp:TextBox>
            </p>
            <p>

                <asp:Label ID="lblAddress" runat="server" Text="Label" Visible="false">Address:</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" Visible="false"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="lblCity" runat="server" Text="Label" Visible="false">City:</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" Visible="false"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblState" runat="server" Text="Label" Visible="false">State: </asp:Label>
                <asp:DropDownList ID="ddlState" runat="server" Visible="false">
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>GA</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NH</asp:ListItem>
                    <asp:ListItem>NJ</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>TX</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
            </p>

            <p>
                <asp:Label ID="lblZipCode" runat="server" Text="Label" Visible="false">Zip Code:</asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server" Visible="false"></asp:TextBox>
            </p>
            <p>

                <asp:Label ID="lblCardType" runat="server" Text="Label" Visible="false">Card Type:</asp:Label>
                <asp:DropDownList ID="ddlCardType" runat="server" Visible="false">
                    <asp:ListItem>VISA</asp:ListItem>
                    <asp:ListItem>MC</asp:ListItem>
                    <asp:ListItem>DISC</asp:ListItem>
                    <asp:ListItem>AMEX</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>

                <asp:Label ID="lblCardNumber" runat="server" Text="Label" Visible="false">Card Number:</asp:Label>
                <asp:TextBox ID="txtCardNumber" runat="server" Visible="false"></asp:TextBox>
            </p>
            <p>

                <asp:Label ID="lblExpiration" runat="server" Text="Label" Visible="false">Expiration Date:</asp:Label>
                <asp:DropDownList ID="ddlMonth" runat="server" Visible="false">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList ID="ddlYear" runat="server" Visible="false">
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                    <asp:ListItem>2026</asp:ListItem>
                    <asp:ListItem>2027</asp:ListItem>
                    <asp:ListItem>2028</asp:ListItem>
                    <asp:ListItem>2029</asp:ListItem>
                    <asp:ListItem>2030</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>

                <asp:Label ID="lblSecurityCode" runat="server" Text="Label" Visible="false">Security Code:</asp:Label>
                <asp:TextBox ID="txtSecurityCode" runat="server" Visible="false"></asp:TextBox>

            </p>
            <p>
                <asp:Button ID ="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Visible="false" />
            </p>
        </div>






    </form>
</body>
</html>
