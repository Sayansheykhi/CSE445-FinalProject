<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="UtilityDemoWeb._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Utility Demo App</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <h1>Utility Demo App</h1>
        <p>
            This simple web application demonstrates local components
            (Global.asax, hash function) and a remote WCF web service,
            as required for Assignment 5.
        </p>

        <!-- Member / Staff links -->
        <h2>Navigation</h2>
        <a href="Member.aspx">Member Page (Coming in Assignment 6)</a><br />
        <a href="Staff.aspx">Staff Page (Coming in Assignment 6)</a>

        <hr />

        <!-- Total visits from Global.asax -->
        <h2>Site Info</h2>
        <asp:Label ID="lblTotalVisits" runat="server" Text=""></asp:Label>

        <hr />

        <!-- Service Directory -->
        <h2>Service Directory</h2>
        <table border="1" cellpadding="4">
            <tr>
                <th>Provider</th>
                <th>Page / Component Type</th>
                <th>Description (Inputs / Outputs)</th>
                <th>Implementation & Usage</th>
                <th>TryIt</th>
            </tr>
            <tr>
                <td>YOUR NAME</td>
                <td>Class (App_Code) – PasswordHasher</td>
                <td>Input: text string; Output: SHA256 hash (Base64).</td>
                <td>Implemented in App_Code/PasswordHasher.cs, used on Default.aspx (Hash TryIt).</td>
                <td><a href="#hashSection">Go</a></td>
            </tr>
            <tr>
                <td>YOUR NAME</td>
                <td>Global.asax</td>
                <td>Tracks total visits (sessions) via Application["TotalVisits"].</td>
                <td>Implemented in App_Code/Global.cs, displayed on Default.aspx.</td>
                <td>(See Site Info)</td>
            </tr>
            <tr>
                <td>YOUR NAME</td>
                <td>WCF Service – QuoteService.svc</td>
                <td>Input: name; Output: generic greeting/quote.</td>
                <td>Deployed in page0, called from Default.aspx via QuoteServiceProxy.</td>
                <td><a href="#quoteSection">Go</a></td>
            </tr>
        </table>

        <hr />

        <!-- TryIt Hash Password -->
        <h2 id="hashSection">TryIt – Hash Text (Local Component)</h2>
        <asp:Label ID="Label1" runat="server" Text="Enter text to hash: "></asp:Label>
        <asp:TextBox ID="txtToHash" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" />
        <br />
        <asp:Label ID="lblHashResult" runat="server" Text=""></asp:Label>

        <hr />

        <!-- TryIt get quote Remote Service -->
        <h2 id="quoteSection">TryIt – Get Quote (Remote Web Service)</h2>
        <asp:Label ID="Label2" runat="server" Text="Enter your name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetQuote" runat="server" Text="Get Quote" OnClick="btnGetQuote_Click" />
        <br />
        <asp:Label ID="lblQuoteResult" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
