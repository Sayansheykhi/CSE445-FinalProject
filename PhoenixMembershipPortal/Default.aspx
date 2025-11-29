<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhoenixMembershipPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Membership Username Checker</h2>
    <p>Enter a username below to check if it already exists in the membership list.</p>

    <div style="margin-top:20px; max-width:450px;">

        <asp:Label ID="lblStatus" runat="server" Text="" Font-Size="Large" Font-Bold="True"></asp:Label>
        <br /><br />

        <asp:Label ID="Label1" runat="server" Text="Enter Username:" AssociatedControlID="txtUsername"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Button 
            ID="btnCheck" 
            runat="server" 
            Text="Check Availability"
            CssClass="btn btn-primary" 
            Width="180px" 
            OnClick="btnCheck_Click" />
    </div>

    <hr />

    <!-- COOKIE DEMO SECTION -->
    <section style="margin-top:20px; max-width:450px;">
        <h3>Cookie Test</h3>
        <p>This section demonstrates storing and reading cookies.</p>

        <asp:Label ID="lblCookieStatus" runat="server" Text="" Font-Size="Medium" Font-Bold="True"></asp:Label>
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text="Save a cookie value:" AssociatedControlID="txtCookieInput"></asp:Label>
        <asp:TextBox ID="txtCookieInput" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Button 
            ID="btnSaveCookie" 
            runat="server" 
            Text="Save Cookie"
            CssClass="btn btn-secondary"
            Width="150px"
            OnClick="btnSaveCookie_Click" />
    </section>

    <hr />

    <!-- HASH FUNCTION DEMO -->
    <section style="margin-top:20px; max-width:550px;">
        <h3>Hash Function Try-It</h3>
        <p>This tests the DLL hashing function implemented in your local component layer.</p>

        <asp:Button 
            ID="btnHashTest" 
            runat="server" 
            Text="Run Hash Test"
            CssClass="btn btn-warning"
            Width="180px"
            OnClick="btnHashTest_Click" />
        <br /><br />

        <asp:Label ID="lblHashResult" runat="server" Text="" Font-Size="Small"></asp:Label>
    </section>

    <hr />

    <section style="margin-top:20px;">
        <h3>About This Web App</h3>
        <p>This demo application uses a WCF service, hashing DLL, and cookies as part of Assignment 5 requirements.</p>
    </section>

</asp:Content>
