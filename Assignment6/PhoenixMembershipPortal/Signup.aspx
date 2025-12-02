<%@ Page Title="Signup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="PhoenixMembershipPortal.Signup" %>
<%@ Register Src="~/UserControls/Captcha.ascx" TagPrefix="uc" TagName="Captcha" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sign Up</h2>
    <p>Create a new member account. Please fill in all the required fields.</p>

    <div style="margin-top:20px; max-width:450px;">
        <asp:Label ID="lblError" runat="server" Text="" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblSuccess" runat="server" Text="" Font-Size="Medium" ForeColor="Green" Visible="false"></asp:Label>
        <br /><br />

        <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" AssociatedControlID="txtConfirmPassword"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br />

        <asp:Label ID="lblFullName" runat="server" Text="Full Name:" AssociatedControlID="txtFullName"></asp:Label>
        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
        <br /><br />

        <uc:Captcha ID="captchaControl" runat="server" />
        <br />

        <asp:Button 
            ID="btnSignup" 
            runat="server" 
            Text="Sign Up"
            CssClass="btn btn-primary" 
            Width="180px" 
            OnClick="btnSignup_Click" />
        
        <br /><br />
        <p>Already have an account? <a href="Login.aspx">Login here</a></p>
    </div>

</asp:Content>

