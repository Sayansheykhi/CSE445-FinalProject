<%@ Page Title="Member Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="PhoenixMembershipPortal.Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-info text-white p-4 rounded mb-4">
        <h2>Member Portal</h2>
        <p class="lead mb-0">Welcome back! Manage your account and access member-only features.</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4><i class="bi bi-person-circle"></i> Profile Information</h4>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblWelcome" runat="server" Text="" CssClass="h5 text-primary mb-3"></asp:Label>
                    
                    <table class="table table-borderless">
                        <tr>
                            <td><strong>Username:</strong></td>
                            <td><asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Full Name:</strong></td>
                            <td><asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Email:</strong></td>
                            <td><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Role:</strong></td>
                            <td><asp:Label ID="lblRole" runat="server" Text="" CssClass="badge bg-success"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Member Since:</strong></td>
                            <td><asp:Label ID="lblDateCreated" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Account Status:</strong></td>
                            <td><asp:Label ID="lblStatus" runat="server" Text="" CssClass="badge"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-success text-white">
                    <h4><i class="bi bi-tools"></i> Member Tools</h4>
                </div>
                <div class="card-body">
                    <div class="list-group">
                        <a href="#" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">Update Profile</h5>
                                <small class="text-muted">Coming Soon</small>
                            </div>
                            <p class="mb-1">Edit your personal information and preferences.</p>
                        </a>
                        
                        <a href="ChangePassword.aspx" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">Change Password</h5>
                                <small class="text-muted">Available</small>
                            </div>
                            <p class="mb-1">Update your account password for better security.</p>
                        </a>
                        
                        <a href="#" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">View Membership Benefits</h5>
                                <small class="text-muted">Active</small>
                            </div>
                            <p class="mb-1">Explore exclusive member benefits and features.</p>
                        </a>
                        
                        <a href="Default.aspx" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">Browse Services</h5>
                                <small class="text-muted">Available</small>
                            </div>
                            <p class="mb-1">Access all available web services and tools.</p>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-4">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    <h4><i class="bi bi-info-circle"></i> Account Activity</h4>
                </div>
                <div class="card-body">
                    <p>Last login: <asp:Label ID="lblLastLogin" runat="server" Text=""></asp:Label></p>
                    <p>Session started: <asp:Label ID="lblSessionStart" runat="server" Text=""></asp:Label></p>
                    <hr />
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
