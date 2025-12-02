<%@ Page Title="MembershipService TryIt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembershipServiceTryIt.aspx.cs" Inherits="PhoenixMembershipPortal.MembershipServiceTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-info text-white p-4 rounded mb-4">
        <h2>MembershipService TryIt Page</h2>
        <p class="lead mb-0">Test the CheckUsernameAvailability method</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>Check Username Availability</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label for="txtUsername" class="form-label">Username:</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username to check"></asp:TextBox>
                    </div>
                    
                    <asp:Button ID="btnCheckAvailability" runat="server" 
                        Text="Check Availability" 
                        CssClass="btn btn-primary" 
                        OnClick="btnCheckAvailability_Click" />
                    
                    <hr />
                    
                    <div class="mt-3">
                        <h5>Result:</h5>
                        <asp:Label ID="lblResult" runat="server" Text="" CssClass="alert alert-info d-block"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col-md-4">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    <h5>Service Information</h5>
                </div>
                <div class="card-body">
                    <p><strong>Service:</strong> MembershipService (WCF)</p>
                    <p><strong>Method:</strong> CheckUsernameAvailability</p>
                    <p><strong>Parameter:</strong> string username</p>
                    <p><strong>Returns:</strong> bool</p>
                    <hr />
                    <p class="text-muted small">
                        Returns <strong>true</strong> if username exists, 
                        <strong>false</strong> if available.
                    </p>
                    <hr />
                    <a href="MembershipService.svc" target="_blank" class="btn btn-sm btn-outline-info">View Service</a>
                    <a href="MembershipService.svc?wsdl" target="_blank" class="btn btn-sm btn-outline-info mt-2">View WSDL</a>
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-4">
        <div class="col-md-12">
            <a href="Default.aspx" class="btn btn-secondary">Back to Home</a>
        </div>
    </div>

</asp:Content>

