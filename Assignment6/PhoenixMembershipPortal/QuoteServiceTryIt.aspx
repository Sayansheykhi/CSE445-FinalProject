<%@ Page Title="QuoteService TryIt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuoteServiceTryIt.aspx.cs" Inherits="PhoenixMembershipPortal.QuoteServiceTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-info text-white p-4 rounded mb-4">
        <h2>QuoteService TryIt Page</h2>
        <p class="lead mb-0">Test the GetQuote method</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>Get Personalized Quote</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label for="txtName" class="form-label">Name:</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
                        <small class="form-text text-muted">Leave empty to use default "friend"</small>
                    </div>
                    
                    <asp:Button ID="btnGetQuote" runat="server" 
                        Text="Get Quote" 
                        CssClass="btn btn-primary" 
                        OnClick="btnGetQuote_Click" />
                    
                    <hr />
                    
                    <div class="mt-3">
                        <h5>Quote Result:</h5>
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
                    <p><strong>Service:</strong> QuoteService (WCF)</p>
                    <p><strong>Method:</strong> GetQuote</p>
                    <p><strong>Parameter:</strong> string name</p>
                    <p><strong>Returns:</strong> string</p>
                    <hr />
                    <p class="text-muted small">
                        Returns a personalized quote message 
                        with the provided name.
                    </p>
                    <hr />
                    <a href="Services/QuoteService.svc" target="_blank" class="btn btn-sm btn-outline-info">View Service</a>
                    <a href="Services/QuoteService.svc?wsdl" target="_blank" class="btn btn-sm btn-outline-info mt-2">View WSDL</a>
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

