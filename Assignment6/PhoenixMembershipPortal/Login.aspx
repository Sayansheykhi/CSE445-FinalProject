<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhoenixMembershipPortal.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>
    <p>Please enter your username and password to access the system.</p>

    <div style="margin-top:20px; max-width:450px;">
        <asp:Label ID="lblError" runat="server" Text="" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
        <br /><br />

        <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="350px"></asp:TextBox>
        <br /><br />

        <asp:Button 
            ID="btnLogin" 
            runat="server" 
            Text="Login"
            CssClass="btn btn-primary" 
            Width="180px" 
            OnClick="btnLogin_Click" />
    </div>

</asp:Content>

