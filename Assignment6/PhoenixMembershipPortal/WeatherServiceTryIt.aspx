<%@ Page Title="WeatherService TryIt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeatherServiceTryIt.aspx.cs" Inherits="PhoenixMembershipPortal.WeatherServiceTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-info text-white p-4 rounded mb-4">
        <h2>WeatherService TryIt Page</h2>
        <p class="lead mb-0">Test the GetTemperature method</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>Get Temperature by Zipcode</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label for="txtZipcode" class="form-label">Zipcode:</label>
                        <asp:TextBox ID="txtZipcode" runat="server" CssClass="form-control" placeholder="Enter zipcode (e.g., 85281)"></asp:TextBox>
                    </div>
                    
                    <asp:Button ID="btnGetTemperature" runat="server" 
                        Text="Get Temperature" 
                        CssClass="btn btn-primary" 
                        OnClick="btnGetTemperature_Click" />
                    
                    <hr />
                    
                    <div class="mt-3">
                        <h5>Temperature Result:</h5>
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
                    <p><strong>Service:</strong> WeatherService (ASMX)</p>
                    <p><strong>Method:</strong> GetTemperature</p>
                    <p><strong>Parameter:</strong> string zipcode</p>
                    <p><strong>Returns:</strong> int (temperature in Fahrenheit)</p>
                    <hr />
                    <p class="text-muted small">
                        Returns the temperature for the given zipcode.
                        Currently returns a hardcoded value of 72°F.
                    </p>
                    <hr />
                    <a href="Services/WeatherService.asmx" target="_blank" class="btn btn-sm btn-outline-info">View Service</a>
                    <a href="Services/WeatherService.asmx?wsdl" target="_blank" class="btn btn-sm btn-outline-info mt-2">View WSDL</a>
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

