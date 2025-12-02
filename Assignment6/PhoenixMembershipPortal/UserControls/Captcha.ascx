<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Captcha.ascx.cs" Inherits="PhoenixMembershipPortal.Captcha" %>

<div>
    <asp:Label ID="lblCaptcha" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
    <br />
    <asp:Label ID="lblPrompt" runat="server" Text="Enter the number shown above:" AssociatedControlID="txtCaptcha"></asp:Label>
    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
    <asp:HiddenField ID="hdnCaptchaValue" runat="server" />
</div>

