<%@ Page Title="Staff Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="PhoenixMembershipPortal.Staff" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-warning text-dark p-4 rounded mb-4">
        <h2>Staff Portal</h2>
        <p class="lead mb-0">Administrative tools and member management dashboard.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4><i class="bi bi-person-circle"></i> Staff Information</h4>
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
                            <td><strong>Department:</strong></td>
                            <td><asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Position:</strong></td>
                            <td><asp:Label ID="lblPosition" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Date Hired:</strong></td>
                            <td><asp:Label ID="lblDateHired" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><strong>Status:</strong></td>
                            <td><asp:Label ID="lblStatus" runat="server" Text="" CssClass="badge"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <div class="col-md-8">
            <div class="card">
                <div class="card-header bg-success text-white">
                    <h4><i class="bi bi-people"></i> Member Management</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <asp:Button ID="btnRefreshMembers" runat="server" Text="Refresh Member List" CssClass="btn btn-primary" OnClick="btnRefreshMembers_Click" />
                        <span class="ms-3">
                            <strong>Total Members:</strong> <asp:Label ID="lblMemberCount" runat="server" Text="0" CssClass="badge bg-info"></asp:Label>
                        </span>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="gvMembers" runat="server" 
                            CssClass="table table-striped table-bordered table-hover"
                            AutoGenerateColumns="false"
                            EmptyDataText="No members found."
                            GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Username" HeaderText="Username" />
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Role" HeaderText="Role" />
                                <asp:BoundField DataField="DateCreated" HeaderText="Member Since" />
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <span class='badge <%# Eval("StatusClass") %>'><%# Eval("Status") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="table-dark" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-4">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    <h4><i class="bi bi-info-circle"></i> Admin Tools</h4>
                </div>
                <div class="card-body">
                    <div class="list-group">
                        <a href="Default.aspx" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">View All Services</h5>
                                <small class="text-muted">Available</small>
                            </div>
                            <p class="mb-1">Access all web services and component information.</p>
                        </a>
                        
                        <a href="#" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">Manage Staff Accounts</h5>
                                <small class="text-muted">Coming Soon</small>
                            </div>
                            <p class="mb-1">Add, edit, or remove staff accounts.</p>
                        </a>
                        
                        <a href="#" class="list-group-item list-group-item-action">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">System Reports</h5>
                                <small class="text-muted">Coming Soon</small>
                            </div>
                            <p class="mb-1">View system statistics and reports.</p>
                        </a>
                    </div>
                    
                    <hr />
                    
                    <p>Last login: <asp:Label ID="lblLastLogin" runat="server" Text=""></asp:Label></p>
                    <p>Session started: <asp:Label ID="lblSessionStart" runat="server" Text=""></asp:Label></p>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger mt-2" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
