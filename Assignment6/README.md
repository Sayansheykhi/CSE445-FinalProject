# Phoenix Membership Portal - Team Integration README

**CSE 445 - Assignment 5 & 6**  
**Integrated Project Submission**

---

## 📋 Project Overview

This is the **final integrated project** combining components from all team members into a unified ASP.NET Web Forms application. The base project structure is from **Jaskirat Singh**, with additional components integrated from **Sajjad Sheykhi** and **Shamarah**.

---

## 👥 Team Contribution

**CSE 445 - Assignment 6**

### Team Contribution Table

| Team Member | ASURITE ID | Contribution Percentage |
|-------------|------------|------------------------|
| FULL NAME | ASURITE ID | CONTRIBUTION % |
| FULL NAME | ASURITE ID | CONTRIBUTION % |
| FULL NAME | ASURITE ID | CONTRIBUTION % |
| **Total** | | **100%** |

### Grade Scaling

The contribution percentages listed above are used to scale each team member's final grade for this assignment. According to the assignment instructions, each member's grade is calculated by multiplying the team's overall assignment score by their individual contribution percentage. This ensures that team members receive grades that accurately reflect their level of participation and contribution to the project.

### Collaborative Work Statement

This project represents a collaborative integration effort where all team members contributed individual components (DLLs, web services, and user controls) that were subsequently integrated into a unified application. While each member was responsible for developing and testing their own components, the final integration work required coordination and collaboration among all team members to ensure seamless functionality and compatibility across all integrated components.

### Submission Note

**Note:** Only one team member submitted the final project to Canvas and deployed it to WebStrar. This single submission represents the entire team's collaborative work and should be considered for grading all team members according to their respective contribution percentages.

---

## 👥 Team Members & Contributions

### 1. Jaskirat Singh (Base Project)

**Role**: Base Project Provider  
**Project Structure**: Chosen as the foundation due to its complete, production-ready structure

#### Components Integrated:

##### **DLL Component**
- **PhoenixSecurity** (Class Library)
  - **Location**: `PhoenixSecurity/PhoenixSecurity.csproj`
  - **Namespace**: `PhoenixSecurity`
  - **Key Class**: `HashUtility`
  - **Method**: `ComputeSha256(string input)`
  - **Purpose**: SHA256 password hashing utility
  - **Status**: ✅ Integrated under "DLLs" solution folder

##### **WCF Service**
- **MembershipService** (WCF Service)
  - **Location**: `PhoenixMembershipPortal/MembershipService.svc`
  - **Namespace**: `PhoenixMembershipPortal`
  - **Interface**: `IMembershipService`
  - **Method**: `CheckUsernameAvailability(string username)`
  - **Purpose**: Checks if username exists in Members.xml
  - **Status**: ✅ Integrated (existing service, kept in root)

##### **User Control**
- **ViewSwitcher.ascx**
  - **Original Location**: `PhoenixMembershipPortal/ViewSwitcher.ascx` (root level)
  - **New Location**: `PhoenixMembershipPortal/UserControls/ViewSwitcher.ascx`
  - **Namespace**: `PhoenixMembershipPortal`
  - **Purpose**: Allows users to switch between Mobile and Desktop views
  - **Used In**: `Site.Mobile.Master`
  - **Status**: ✅ Integrated (moved to UserControls folder)

##### **Base Project Infrastructure**
- **Solution File**: `PhoenixMembershipPortal.sln`
- **Project Structure**: Modern ASP.NET Web Forms structure
- **UI Framework**: Bootstrap 5.2.3
- **NuGet Packages**: Complete package management
- **Master Pages**: Site.Master and Site.Mobile.Master
- **Target Framework**: .NET Framework 4.7.2
- **Status**: ✅ Used as base structure

---

### 2. Sajjad Sheykhi

#### Components Integrated:

##### **DLL Component**
- **SimpleSecurityLib** (Class Library)
  - **Source Location**: `Sajjad-Sheykhi-a5/SimpleSecurityLib/`
  - **New Location**: `CSE445-FinalProject-Jaskirat_Singh/SimpleSecurityLib/`
  - **Namespace**: `SimpleSecurityLib` (unchanged)
  - **Key Class**: `SimpleHasher`
  - **Method**: `ComputeHash(string input)`
  - **Purpose**: SHA256 password hashing utility (alternative implementation)
  - **Status**: ✅ Integrated under "DLLs" solution folder
  - **Integration Notes**: Both hashing DLLs kept separate due to different namespaces

##### **ASMX Web Service**
- **WeatherService** (ASMX Web Service)
  - **Source Location**: `Sajjad-Sheykhi-a5/WeatherLookupService/WeatherService.asmx`
  - **New Location**: `PhoenixMembershipPortal/Services/WeatherService.asmx`
  - **Original Namespace**: `WeatherLookupService`
  - **New Namespace**: `PhoenixMembershipPortal.Services`
  - **Method**: `GetTemperature(string zipcode)`
  - **Returns**: `int` (hard-coded 72°F)
  - **Status**: ✅ Integrated in Services folder
  - **Files Integrated**:
    - `WeatherService.asmx`
    - `WeatherService.asmx.cs`
  - **Integration Notes**: Namespace updated to match unified structure

---

### 3. Shamarah

#### Components Integrated:

##### **WCF Service**
- **QuoteService** (WCF Service)
  - **Source Location**: `Assignment5_Shamarah/UtilityDemo_Service/QuoteService.svc`
  - **New Location**: `PhoenixMembershipPortal/Services/QuoteService.svc`
  - **Original Namespace**: `QuoteServiceApp`
  - **New Namespace**: `PhoenixMembershipPortal.Services`
  - **Interface**: `IQuoteService`
  - **Method**: `GetQuote(string name)`
  - **Returns**: Personalized quote string
  - **Status**: ✅ Integrated in Services folder
  - **Files Integrated**:
    - `QuoteService.svc`
    - `QuoteService.cs`
    - `IQuoteService.cs`
  - **Integration Notes**: 
    - Namespace updated to `PhoenixMembershipPortal.Services`
    - Service configured in Web.config serviceModel section

---

## 🔧 Integrated Components Created During Integration

### Authentication & Authorization System
- **Login.aspx** - User authentication page
  - Validates credentials from Member.xml and Staff.xml
  - Uses SimpleSecurityLib for password hashing
  - Creates Forms Authentication tickets with roles
  
- **Signup.aspx** - User registration page
  - Captcha validation
  - Adds new users to Member.xml
  
- **Member.aspx** - Member-only portal
  - Role-based access control
  - Displays member profile from Member.xml
  
- **Staff.aspx** - Staff-only portal with admin functionality
  - Role-based access control
  - Displays all members from Member.xml
  - TA test account: Username `TA`, Password `Cse445!`

### User Controls
- **Captcha.ascx** - Math-based captcha control
  - **Location**: `PhoenixMembershipPortal/UserControls/Captcha.ascx`
  - **Purpose**: Prevents automated bot registrations
  - **Status**: ✅ Created during integration

### Utility Classes
- **XMLManager.cs** - XML data management utility
  - **Location**: `PhoenixMembershipPortal/App_Code/XMLManager.cs`
  - **Purpose**: Provides read/write/modify operations for Member.xml and Staff.xml
  - **Status**: ✅ Created during integration

### XML Data Files
- **Member.xml** - Member user data storage
  - **Location**: `PhoenixMembershipPortal/App_Data/Member.xml`
  - **Structure**: Contains User elements with Username, Password (hashed), Email, FullName, Role, DateCreated, IsActive
  - **Status**: ✅ Created during integration

- **Staff.xml** - Staff user data storage
  - **Location**: `PhoenixMembershipPortal/App_Data/Staff.xml`
  - **Structure**: Contains User elements with Username, Password (hashed), Email, FullName, Department, Position, DateHired, IsActive
  - **TA Account**: Username `TA`, Password `Cse445!` (hashed)
  - **Status**: ✅ Created during integration

### Global Application Events
- **Global.asax.cs** - Application and session event handlers
  - **Location**: `PhoenixMembershipPortal/Global.asax.cs`
  - **Events Merged from All Members**:
    - `Application_Start` - Initializes visit counters
    - `Session_Start` - Thread-safe visit counting
    - `Application_AuthenticateRequest` - Role assignment from Forms Authentication
  - **Status**: ✅ Merged from all team members' Global.asax.cs files

### UI Enhancements
- **Default.aspx** - Enhanced home page
  - Components Summary Table listing all integrated components
  - Navigation buttons (Login, Signup, Member, Staff)
  - Try-It buttons for all services and DLLs
  - **Status**: ✅ Enhanced during integration

---

## 📊 Complete Integration Summary Table

| Component Type | Component Name | Source Member | Original Location | Integrated Location | Status |
|----------------|---------------|---------------|-------------------|---------------------|--------|
| **DLL** | PhoenixSecurity | Jaskirat Singh | PhoenixSecurity/ | DLLs/PhoenixSecurity/ | ✅ Integrated |
| **DLL** | SimpleSecurityLib | Sajjad Sheykhi | Sajjad-Sheykhi-a5/SimpleSecurityLib/ | SimpleSecurityLib/ | ✅ Integrated |
| **WCF Service** | MembershipService | Jaskirat Singh | Root level | MembershipService.svc | ✅ Integrated |
| **WCF Service** | QuoteService | Shamarah | Assignment5_Shamarah/UtilityDemo_Service/ | Services/QuoteService.svc | ✅ Integrated |
| **ASMX Service** | WeatherService | Sajjad Sheykhi | Sajjad-Sheykhi-a5/WeatherLookupService/ | Services/WeatherService.asmx | ✅ Integrated |
| **User Control** | ViewSwitcher | Jaskirat Singh | Root level | UserControls/ViewSwitcher.ascx | ✅ Integrated |
| **User Control** | Captcha | Created | N/A | UserControls/Captcha.ascx | ✅ Created |
| **Utility Class** | XMLManager | Created | N/A | App_Code/XMLManager.cs | ✅ Created |
| **XML Data** | Member.xml | Created | N/A | App_Data/Member.xml | ✅ Created |
| **XML Data** | Staff.xml | Created | N/A | App_Data/Staff.xml | ✅ Created |
| **Global Events** | Global.asax.cs | Merged (All) | Multiple sources | Global.asax.cs | ✅ Merged |

---

## 🏗️ Project Structure

```
PhoenixMembershipPortal/
├── PhoenixMembershipPortal.sln          # Solution file (Jaskirat)
├── PhoenixMembershipPortal/             # Web Application (Jaskirat - Base)
│   ├── App_Code/
│   │   └── XMLManager.cs                # Created during integration
│   ├── App_Data/
│   │   ├── Member.xml                   # Created during integration
│   │   └── Staff.xml                    # Created during integration (with TA account)
│   ├── Services/                        # Created for service integration
│   │   ├── QuoteService.svc             # From Shamarah
│   │   ├── QuoteService.cs
│   │   ├── IQuoteService.cs
│   │   ├── WeatherService.asmx          # From Sajjad
│   │   └── WeatherService.asmx.cs
│   ├── UserControls/                    # Created for user control organization
│   │   ├── ViewSwitcher.ascx            # From Jaskirat (moved)
│   │   ├── ViewSwitcher.ascx.cs
│   │   ├── Captcha.ascx                 # Created during integration
│   │   └── Captcha.ascx.cs
│   ├── MembershipService.svc            # From Jaskirat (root level)
│   ├── MembershipService.cs
│   ├── Login.aspx                       # Created during integration
│   ├── Signup.aspx                      # Created during integration
│   ├── Member.aspx                      # Created during integration
│   ├── Staff.aspx                       # Created during integration
│   ├── Default.aspx                     # Enhanced during integration
│   └── Global.asax.cs                   # Merged from all members
├── PhoenixSecurity/                     # DLL Project (Jaskirat)
│   └── PhoenixSecurity.csproj
└── SimpleSecurityLib/                   # DLL Project (Sajjad)
    └── SimpleSecurityLib.csproj
```

---

## 🔄 Integration Process Summary

### Phase 1: Base Project Selection
- **Selected**: Jaskirat Singh's project as base (best structure)
- **Reason**: Complete solution file, modern structure, NuGet packages, Bootstrap UI

### Phase 2: DLL Integration
- Integrated `SimpleSecurityLib` from Sajjad Sheykhi
- Created "DLLs" solution folder
- Both DLLs kept separate (different namespaces)

### Phase 3: Service Integration
- Created `Services/` folder
- Integrated `QuoteService` from Shamarah (WCF)
- Integrated `WeatherService` from Sajjad (ASMX)
- Updated namespaces to `PhoenixMembershipPortal.Services`
- Merged Web.config serviceModel sections

### Phase 4: User Control Integration
- Created `UserControls/` folder
- Moved `ViewSwitcher` from root to UserControls folder
- Created `Captcha` user control for signup

### Phase 5: Authentication System
- Created Login.aspx with Forms Authentication
- Created Signup.aspx with captcha validation
- Created Member.aspx (role-based access)
- Created Staff.aspx (admin functionality)
- Created XMLManager utility class
- Created Member.xml and Staff.xml data files

### Phase 6: Global.asax Merge
- Merged Application_Start logic from all members
- Merged Session_Start logic with thread safety
- Added Application_AuthenticateRequest for role assignment

### Phase 7: UI Enhancement
- Enhanced Default.aspx with component summary table
- Added navigation buttons
- Added Try-It buttons for all components

---

## 🔐 Authentication & Authorization

### User Roles
- **"member"** - Users from Member.xml
- **"staff"** - Users from Staff.xml (including TA account)

### Test Accounts

#### Member Accounts
- Username: `john.doe`, Password: `password123`
- Username: `jane.smith`, Password: `password123`

#### Staff Accounts
- Username: `TA`, Password: `Cse445!` ⭐ (TA Test Account)
- Username: `manager`, Password: `password123`
- Username: `support.staff`, Password: `password123`

---

## 🌐 Service Endpoints

### WCF Services
1. **MembershipService**
   - URL: `/MembershipService.svc`
   - WSDL: `/MembershipService.svc?wsdl`
   - Source: Jaskirat Singh

2. **QuoteService**
   - URL: `/Services/QuoteService.svc`
   - WSDL: `/Services/QuoteService.svc?wsdl`
   - Source: Shamarah

### ASMX Services
3. **WeatherService**
   - URL: `/Services/WeatherService.asmx`
   - WSDL: `/Services/WeatherService.asmx?wsdl`
   - Source: Sajjad Sheykhi

---

## 📝 Key Integration Notes

### Namespace Updates
- All services updated to `PhoenixMembershipPortal.Services` namespace
- Original DLL namespaces preserved (PhoenixSecurity, SimpleSecurityLib)

### File Organization
- All services consolidated in `Services/` folder
- All user controls consolidated in `UserControls/` folder
- All DLLs organized under "DLLs" solution folder

### Web.config Updates
- Forms Authentication configured (60-minute timeout)
- Role-based authorization for Member.aspx and Staff.aspx
- Service model configured for all WCF services
- Handler configuration for .svc files

### Password Hashing
- Uses `SimpleSecurityLib.SimpleHasher.ComputeHash()` for authentication
- All passwords stored as SHA256 hashes in XML files
- Never stored as plain text

---

## ✅ Integration Verification

### All Components Verified
- ✅ All DLLs compile and reference correctly
- ✅ All services accessible and functional
- ✅ All user controls render correctly
- ✅ Authentication and authorization working
- ✅ XML data management functional
- ✅ All team components listed in Default.aspx

### Test Verification
- ✅ TA account login works
- ✅ Member portal access control works
- ✅ Staff portal access control works
- ✅ All services return correct responses
- ✅ All DLL hash functions work
- ✅ Signup with captcha works

---

## 📚 Additional Documentation

For more details, see:
- `DEPLOYMENT_CHECKLIST.md` - Deployment instructions
- `TA_TEST_CHECKLIST.md` - Complete test guide
- `GRADING_CHECKLIST.md` - Grading compliance checklist
- `FINAL_GRADING_REVIEW.md` - Final review summary
- `WEB_CONFIG_VALIDATION.md` - Web.config validation report

---

## 🎓 Assignment Requirements Met

### ✅ DLL Components
- PhoenixSecurity DLL (Jaskirat Singh)
- SimpleSecurityLib DLL (Sajjad Sheykhi)

### ✅ Web Services
- MembershipService WCF (Jaskirat Singh)
- QuoteService WCF (Shamarah)
- WeatherService ASMX (Sajjad Sheykhi)

### ✅ User Controls
- ViewSwitcher (Jaskirat Singh)
- Captcha (Created during integration by Sajjad Sheykhi)

### ✅ Integration Features
- Complete component integration
- Authentication and authorization
- XML data management
- Role-based access control
- Admin functionality

---

## 👨‍💻 Credits

- **Base Project**: Jaskirat Singh
- **DLL Integration**: Sajjad Sheykhi (SimpleSecurityLib)
- **Service Integration**: Shamarah (QuoteService), Sajjad Sheykhi (WeatherService)
- **User Control**: Jaskirat Singh (ViewSwitcher)
- **Integration Work**: Team collaboration

---

## 🚀 How to Run in Visual Studio 2019

### Quick Start (5 Steps)

1. **Open Solution File**:
   - Launch Visual Studio 2019
   - File → Open → Project/Solution...
   - Navigate to: `Assignment6/PhoenixMembershipPortal.sln`
   - Click **Open**

2. **Restore NuGet Packages**:
   - Right-click solution in Solution Explorer → **Restore NuGet Packages**
   - Wait for restoration (check Output window for confirmation)

3. **Build Solution**:
   - Press **`Ctrl+Shift+B`** (or Build → Build Solution)
   - Verify **0 errors** in Error List window

4. **Set Startup Project**:
   - Right-click **PhoenixMembershipPortal** project in Solution Explorer
   - Select **Set as Startup Project**
   - Project name should appear in **bold**

5. **Run Application**:
   - Press **`F5`** to run with debugging
   - Or press **`Ctrl+F5`** to run without debugging
   - Browser opens automatically to Default.aspx

### Prerequisites

Before running, ensure you have:

- ✅ **Visual Studio 2019** installed (Community, Professional, or Enterprise)
  - Download: https://visualstudio.microsoft.com/downloads/
- ✅ **.NET Framework 4.7.2** Developer Pack
  - Usually included with Visual Studio 2019
- ✅ **ASP.NET and web development** workload installed
- ✅ **IIS Express** (included with Visual Studio 2019)

### Expected Result

After running:
- Browser opens to `http://localhost:[port]/Default.aspx`
- Home page displays with:
  - Project introduction
  - Navigation buttons (Login, Signup, Member, Staff)
  - Components Summary Table
  - Try-It buttons for all services and DLLs

### Troubleshooting

**If solution won't open:**
- Ensure Visual Studio 2019 is installed with ASP.NET workload
- Check that .NET Framework 4.7.2 Developer Pack is installed

**If build errors occur:**
- Right-click solution → **Restore NuGet Packages**
- Right-click solution → **Rebuild Solution**
- Check Error List window for specific errors

**If services not accessible:**
- Verify Web.config has correct service configuration
- Check that all .svc and .asmx files are in correct locations

### Detailed Instructions

For comprehensive setup and troubleshooting guide, see:
- **`VS2019_QUICK_START.md`** - Quick reference guide
- **`VISUAL_STUDIO_2019_SETUP_GUIDE.md`** - Complete setup guide with troubleshooting

---


