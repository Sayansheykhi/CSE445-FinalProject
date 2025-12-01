<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhoenixMembershipPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-primary text-white p-5 rounded mb-4">
        <h1 class="display-4">Phoenix Membership Portal</h1>
        <p class="lead">An integrated ASP.NET Web Forms application demonstrating WCF services, DLL components, XML data management, and role-based authentication.</p>
        <p>This application combines components from multiple team members into a unified, production-ready solution.</p>
    </div>

    <div class="row mb-4">
        <div class="col-md-12">
            <h2>Navigation</h2>
            <div class="btn-group" role="group">
                <a href="Login.aspx" class="btn btn-primary">Login</a>
                <a href="Signup.aspx" class="btn btn-success">Signup</a>
                <a href="Member.aspx" class="btn btn-info">Member Portal</a>
                <a href="Staff.aspx" class="btn btn-warning">Staff Portal</a>
            </div>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-12">
            <h2>Application & Components Summary</h2>
            <p>Complete listing of all integrated components from team members:</p>
            
            <div class="table-responsive">
            <table class="table table-bordered table-striped table-hover">
                <thead class="table-dark">
                    <tr>
                        <th>Component Type</th>
                        <th>Component Name</th>
                        <th>Source Member</th>
                        <th>Namespace/Class</th>
                        <th>Methods/Features</th>
                        <th>Location</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><strong>DLL</strong></td>
                        <td>PhoenixSecurity</td>
                        <td>Jaskirat Singh</td>
                        <td>PhoenixSecurity.HashUtility</td>
                        <td>ComputeSha256(string)</td>
                        <td>PhoenixSecurity.dll</td>
                    </tr>
                    <tr>
                        <td><strong>DLL</strong></td>
                        <td>SimpleSecurityLib</td>
                        <td>Sajjad Sheykhi</td>
                        <td>SimpleSecurityLib.SimpleHasher</td>
                        <td>ComputeHash(string)</td>
                        <td>SimpleSecurityLib.dll</td>
                    </tr>
                    <tr>
                        <td><strong>WCF Service</strong></td>
                        <td>MembershipService</td>
                        <td>Jaskirat Singh</td>
                        <td>PhoenixMembershipPortal.IMembershipService</td>
                        <td>CheckUsernameAvailability(string)</td>
                        <td>MembershipService.svc</td>
                    </tr>
                    <tr>
                        <td><strong>WCF Service</strong></td>
                        <td>QuoteService</td>
                        <td>Shamarah</td>
                        <td>PhoenixMembershipPortal.Services.IQuoteService</td>
                        <td>GetQuote(string)</td>
                        <td>Services/QuoteService.svc</td>
                    </tr>
                    <tr>
                        <td><strong>ASMX Service</strong></td>
                        <td>WeatherService</td>
                        <td>Sajjad Sheykhi</td>
                        <td>PhoenixMembershipPortal.Services.WeatherService</td>
                        <td>GetTemperature(string)</td>
                        <td>Services/WeatherService.asmx</td>
                    </tr>
                    <tr>
                        <td><strong>User Control</strong></td>
                        <td>ViewSwitcher</td>
                        <td>Jaskirat Singh</td>
                        <td>PhoenixMembershipPortal.ViewSwitcher</td>
                        <td>Mobile/Desktop view switching</td>
                        <td>UserControls/ViewSwitcher.ascx</td>
                    </tr>
                    <tr>
                        <td><strong>User Control</strong></td>
                        <td>Captcha</td>
                        <td>Integrated</td>
                        <td>PhoenixMembershipPortal.Captcha</td>
                        <td>GenerateCaptcha(), ValidateCaptcha()</td>
                        <td>UserControls/Captcha.ascx</td>
                    </tr>
                    <tr>
                        <td><strong>Utility Class</strong></td>
                        <td>XMLManager</td>
                        <td>Integrated</td>
                        <td>PhoenixMembershipPortal.XMLManager</td>
                        <td>Member/Staff XML operations</td>
                        <td>App_Code/XMLManager.cs</td>
                    </tr>
                    <tr>
                        <td><strong>XML Data</strong></td>
                        <td>Member.xml</td>
                        <td>Integrated</td>
                        <td>N/A</td>
                        <td>Member user data storage</td>
                        <td>App_Data/Member.xml</td>
                    </tr>
                    <tr>
                        <td><strong>XML Data</strong></td>
                        <td>Staff.xml</td>
                        <td>Integrated</td>
                        <td>N/A</td>
                        <td>Staff user data storage</td>
                        <td>App_Data/Staff.xml</td>
                    </tr>
                    <tr>
                        <td><strong>Global Events</strong></td>
                        <td>Global.asax.cs</td>
                        <td>Integrated (All Members)</td>
                        <td>PhoenixMembershipPortal.Global</td>
                        <td>Application_Start, Session_Start, Application_AuthenticateRequest</td>
                        <td>Global.asax.cs</td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-12">
            <h2>TryIt Pages</h2>
            <p>Test and interact with all integrated components:</p>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>DLL Components</h4>
                </div>
                <div class="card-body">
                    <h5>PhoenixSecurity DLL</h5>
                    <p>SHA256 hashing utility</p>
                    <button type="button" class="btn btn-primary" onclick="testPhoenixSecurity()">Try PhoenixSecurity</button>
                    <div id="phoenixSecurityResult" class="mt-2"></div>
                    
                    <hr />
                    
                    <h5>SimpleSecurityLib DLL</h5>
                    <p>SHA256 hashing utility</p>
                    <button type="button" class="btn btn-success" onclick="testSimpleSecurity()">Try SimpleSecurityLib</button>
                    <div id="simpleSecurityResult" class="mt-2"></div>
                </div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-info text-white">
                    <h4>Web Services</h4>
                </div>
                <div class="card-body">
                    <h5>MembershipService (WCF)</h5>
                    <p>Check username availability</p>
                    <a href="MembershipService.svc" target="_blank" class="btn btn-info">View Service</a>
                    <a href="MembershipService.svc?wsdl" target="_blank" class="btn btn-outline-info">View WSDL</a>
                    
                    <hr />
                    
                    <h5>QuoteService (WCF)</h5>
                    <p>Get personalized quotes</p>
                    <a href="Services/QuoteService.svc" target="_blank" class="btn btn-info">View Service</a>
                    <a href="Services/QuoteService.svc?wsdl" target="_blank" class="btn btn-outline-info">View WSDL</a>
                    
                    <hr />
                    
                    <h5>WeatherService (ASMX)</h5>
                    <p>Temperature lookup by zipcode</p>
                    <a href="Services/WeatherService.asmx" target="_blank" class="btn btn-info">View Service</a>
                    <a href="Services/WeatherService.asmx?wsdl" target="_blank" class="btn btn-outline-info">View WSDL</a>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-warning text-dark">
                    <h4>User Controls</h4>
                </div>
                <div class="card-body">
                    <h5>Captcha Control</h5>
                    <p>Math-based captcha validation</p>
                    <a href="Signup.aspx" class="btn btn-warning">View Captcha Demo</a>
                    
                    <hr />
                    
                    <h5>ViewSwitcher Control</h5>
                    <p>Mobile/Desktop view switcher</p>
                    <p class="text-muted">Available on mobile master page</p>
                </div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    <h4>Quick Tests</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label for="txtHashInput" class="form-label">Hash Input:</label>
                        <input type="text" id="txtHashInput" class="form-control" placeholder="Enter text to hash" value="Hello123" />
                        <button type="button" class="btn btn-primary mt-2" onclick="testBothHashes()">Test Both DLLs</button>
                        <div id="hashComparisonResult" class="mt-2"></div>
                    </div>
                    
                    <div class="mb-3">
                        <label for="txtUsernameCheck" class="form-label">Check Username:</label>
                        <input type="text" id="txtUsernameCheck" class="form-control" placeholder="Enter username" />
                        <button type="button" class="btn btn-info mt-2" onclick="checkUsername()">Check Availability</button>
                        <div id="usernameCheckResult" class="mt-2"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-12">
            <h3>Application Statistics</h3>
            <asp:Label ID="lblVisitCount" runat="server" Text="" CssClass="lead"></asp:Label>
        </div>
    </div>

    <script type="text/javascript">
        function testPhoenixSecurity() {
            var input = document.getElementById('txtHashInput').value || 'Hello123';
            var resultDiv = document.getElementById('phoenixSecurityResult');
            resultDiv.innerHTML = '<div class="alert alert-info">Testing PhoenixSecurity... Please check server-side implementation.</div>';
        }
        
        function testSimpleSecurity() {
            var input = document.getElementById('txtHashInput').value || 'Hello123';
            var resultDiv = document.getElementById('simpleSecurityResult');
            resultDiv.innerHTML = '<div class="alert alert-success">Testing SimpleSecurityLib... Please check server-side implementation.</div>';
        }
        
        function testBothHashes() {
            var input = document.getElementById('txtHashInput').value || 'Hello123';
            var resultDiv = document.getElementById('hashComparisonResult');
            resultDiv.innerHTML = '<div class="alert alert-info">Click "Run Hash Test" button below to test both DLLs with server-side hash comparison.</div>';
        }
        
        function checkUsername() {
            var username = document.getElementById('txtUsernameCheck').value;
            var resultDiv = document.getElementById('usernameCheckResult');
            if (!username) {
                resultDiv.innerHTML = '<div class="alert alert-warning">Please enter a username.</div>';
                return;
            }
            resultDiv.innerHTML = '<div class="alert alert-info">Click "Check Availability" button below for server-side check.</div>';
        }
    </script>

    <hr />

    <div class="row">
        <div class="col-md-12">
            <h3>Hash Function Try-It</h3>
            <p>Test the DLL hashing functions implemented in your local component layer.</p>
            <asp:Button 
                ID="btnHashTest" 
                runat="server" 
                Text="Run Hash Test"
                CssClass="btn btn-warning"
                OnClick="btnHashTest_Click" />
            <br /><br />
            <asp:Label ID="lblHashResult" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
