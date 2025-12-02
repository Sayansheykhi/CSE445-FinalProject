<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UtilityWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Utility Web App</title>
    <!-- 
        Page Styles
        Defines the visual appearance of the page including section containers,
        form controls, and the Service Directory table.
    -->
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .section {
            margin: 20px 0;
            padding: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .section h2 {
            margin-top: 0;
        }
        input[type="text"], button {
            padding: 5px;
            margin: 5px;
        }
        button {
            cursor: pointer;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- 
                Page Header and Introduction
                Displays the application title and welcome message.
            -->
            <h1>Utility Web Application</h1>
            <p>Welcome to the Utility Web Application. This application provides various utility services including hashing and weather lookup functionality.</p>
            
            <!-- 
                Navigation Links Section
                Provides links to Member.aspx and Staff.aspx pages.
                These are placeholder pages for future functionality.
            -->
            <p>
                <a href="Member.aspx">Member Page</a> | 
                <a href="Staff.aspx">Staff Page</a>
            </p>
            
            <!-- 
                Total Visits Counter Section
                Displays the total number of user sessions since application start.
                This value is maintained in Application["TotalVisits"] and is updated
                in Global.asax Session_Start event handler.
            -->
            <div class="section">
                <h2>Total Visits</h2>
                <!-- 
                    lblVisits: Label control that displays the visit counter.
                    Populated in Default.aspx.cs Page_Load event from Application state.
                -->
                <asp:Label ID="lblVisits" runat="server" Text=""></asp:Label>
            </div>

            <!-- 
                Hash TryIt Section
                Interactive section for testing the SimpleSecurityLib DLL hashing functionality.
                Users can enter text and compute its SHA-256 hash using the integrated class library.
            -->
            <div class="section">
                <h2>Hash TryIt</h2>
                <!-- 
                    txtHashInput: TextBox for user input to be hashed.
                    btnHash: Button that triggers the hash computation.
                    lblHashOutput: Label that displays the computed SHA-256 hash result.
                -->
                <asp:TextBox ID="txtHashInput" runat="server" placeholder="Enter text to hash"></asp:TextBox>
                <asp:Button ID="btnHash" runat="server" Text="Compute Hash" OnClick="btnHash_Click" />
                <br />
                <asp:Label ID="lblHashOutput" runat="server" Text=""></asp:Label>
            </div>

            <!-- 
                Weather Service TryIt Section
                Interactive section for testing the WeatherLookupService ASMX web service.
                Users can enter a zipcode and retrieve temperature information.
            -->
            <div class="section">
                <h2>Weather Service TryIt</h2>
                <!-- 
                    txtZipcode: TextBox for zipcode input.
                    btnGetTemp: Button that triggers the weather service call.
                    lblTempOutput: Label that displays the temperature result from the web service.
                -->
                <asp:TextBox ID="txtZipcode" runat="server" placeholder="Enter zipcode"></asp:TextBox>
                <asp:Button ID="btnGetTemp" runat="server" Text="Get Temperature" OnClick="btnGetTemp_Click" />
                <br />
                <asp:Label ID="lblTempOutput" runat="server" Text=""></asp:Label>
            </div>

            <!-- 
                Service Directory Section
                Displays a table of all available services in the application.
                The GridView is populated from a DataTable built in Default.aspx.cs Page_Load.
                Contains three entries:
                1. Global.asax - Application event handler
                2. SimpleSecurityLib.dll - Class library for hashing
                3. Weather Service - ASMX web service for temperature lookup
            -->
            <div class="section">
                <h2>Service Directory</h2>
                <!-- 
                    gvServiceDirectory: GridView control that displays the service directory.
                    AutoGenerateColumns is set to false to use custom column definitions.
                    Data source is bound in Default.aspx.cs Page_Load event handler.
                -->
                <asp:GridView ID="gvServiceDirectory" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <!-- ServiceName column: Name of the service or component -->
                        <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                        <!-- ServiceType column: Category/type of service (Event Handler, DLL, Web Service) -->
                        <asp:BoundField DataField="ServiceType" HeaderText="Service Type" />
                        <!-- Description column: Brief description of what the service does -->
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

