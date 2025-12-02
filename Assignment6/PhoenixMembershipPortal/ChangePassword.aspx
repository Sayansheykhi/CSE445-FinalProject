<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PhoenixMembershipPortal.ChangePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-info text-white p-4 rounded mb-4">
        <h2>Change Password</h2>
        <p class="lead mb-0">Update your account password for better security.</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>Password Change Form</h4>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="alert d-block" Visible="false"></asp:Label>
                    
                    <div class="mb-3">
                        <label for="txtCurrentPassword" class="form-label">Current Password:</label>
                        <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your current password"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label for="txtNewPassword" class="form-label">New Password:</label>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your new password"></asp:TextBox>
                        <small class="form-text text-muted">Password must be at least 6 characters long.</small>
                    </div>
                    
                    <div class="mb-3">
                        <label for="txtConfirmNewPassword" class="form-label">Confirm New Password:</label>
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm your new password"></asp:TextBox>
                    </div>
                    
                    <asp:Button ID="btnChangePassword" runat="server" 
                        Text="Change Password" 
                        CssClass="btn btn-primary" 
                        OnClick="btnChangePassword_Click" />
                    
                    <hr />
                    
                    <a href="Member.aspx" class="btn btn-secondary">Back to Member Portal</a>
                </div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    <h5>Password Requirements</h5>
                </div>
                <div class="card-body">
                    <ul>
                        <li>Password must be at least 6 characters long</li>
                        <li>New password must match the confirmation</li>
                        <li>Current password must be correct</li>
                        <li>Password is securely hashed before storage</li>
                    </ul>
                    <hr />
                    <p class="text-muted small">
                        <strong>Security Note:</strong> Your password is hashed using SHA256 
                        before being stored in the system. We never store your plain text password.
                    </p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

