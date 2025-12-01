# Visual Studio 2019 Setup and Run Guide

**Phoenix Membership Portal**  
**ASP.NET Web Forms Application**

---

## 📋 Prerequisites

Before running this project, ensure you have the following installed:

### Required Software
- ✅ **Visual Studio 2019** (Community, Professional, or Enterprise)
  - Download: https://visualstudio.microsoft.com/downloads/
- ✅ **.NET Framework 4.7.2** or higher
  - Usually included with Visual Studio 2019
- ✅ **IIS Express** (included with Visual Studio 2019)
- ✅ **SQL Server Express** (optional, not required for this project)

### Visual Studio Workloads Required
When installing Visual Studio 2019, ensure you have:
- ✅ **ASP.NET and web development** workload
- ✅ **.NET desktop development** workload (for DLL projects)

---

## 🚀 Step-by-Step Setup Instructions

### Step 1: Open the Solution

1. **Launch Visual Studio 2019**

2. **Open Solution File**:
   - Go to `File` → `Open` → `Project/Solution...`
   - Navigate to: `Assignment6/PhoenixMembershipPortal.sln`
   - Click **Open**

3. **Wait for Solution to Load**:
   - Visual Studio will load all projects
   - Solution Explorer should show:
     ```
     Solution 'PhoenixMembershipPortal'
     ├── PhoenixMembershipPortal (Web Application)
     └── DLLs (Solution Folder)
         ├── PhoenixSecurity
         └── SimpleSecurityLib
     ```

### Step 2: Restore NuGet Packages

1. **Automatic Restore**:
   - Visual Studio should automatically detect and restore NuGet packages
   - Check the **Output** window for package restoration status

2. **Manual Restore** (if needed):
   - Right-click the solution in Solution Explorer
   - Select **Restore NuGet Packages**
   - Wait for restoration to complete

3. **Verify Packages**:
   - Check that `packages/` folder exists in the solution root
   - Packages should include:
     - Bootstrap 5.2.3
     - jQuery 3.7.0
     - Microsoft.AspNet.* packages

### Step 3: Build the Solution

1. **Build Solution**:
   - Go to `Build` → `Build Solution` (or press `Ctrl+Shift+B`)
   - Wait for build to complete

2. **Check for Errors**:
   - Check the **Error List** window (View → Error List)
   - Should show 0 errors, 0 warnings (or minimal warnings)

3. **Common Build Issues**:
   - **If DLLs not found**: Ensure all projects are loaded in Solution Explorer
   - **If packages missing**: Restore NuGet packages again
   - **If compilation errors**: Check that all projects are targeting .NET Framework 4.7.2

### Step 4: Set Startup Project

1. **Set Startup Project**:
   - Right-click `PhoenixMembershipPortal` project in Solution Explorer
   - Select **Set as Startup Project**

2. **Verify Startup Project**:
   - `PhoenixMembershipPortal` should appear in **bold** in Solution Explorer

### Step 5: Configure IIS Express (If Needed)

1. **Project Properties**:
   - Right-click `PhoenixMembershipPortal` project
   - Select **Properties**

2. **Web Settings**:
   - Go to **Web** tab
   - Under **Servers**:
     - Select **IIS Express**
   - Under **Start Action**:
     - Select **Specific Page**: `Default.aspx`
     - Or select **Don't open a page. Wait for a request from an external application**

### Step 6: Run the Application

#### Option 1: Run with Debugging (Recommended for Development)
1. Press `F5` or click the **Start** button (green play icon)
2. Visual Studio will:
   - Build the solution
   - Start IIS Express
   - Launch the application in your default browser
3. Default URL: `http://localhost:[port]/Default.aspx`

#### Option 2: Run without Debugging
1. Press `Ctrl+F5` or go to `Debug` → `Start Without Debugging`
2. Faster startup (no debugging overhead)

### Step 7: Verify Application is Running

1. **Browser Opens Automatically**:
   - Should navigate to `Default.aspx`
   - Home page should display with:
     - Project introduction
     - Navigation buttons
     - Components Summary Table

2. **Check IIS Express**:
   - Look for IIS Express icon in system tray
   - Shows the running application URL

---

## 🔧 Troubleshooting Common Issues

### Issue 1: Solution Won't Open

**Problem**: Solution file doesn't open or shows errors.

**Solutions**:
- Ensure Visual Studio 2019 is installed
- Check that .NET Framework 4.7.2 Developer Pack is installed
- Try opening the `.csproj` file directly first
- Check file permissions on the solution folder

### Issue 2: NuGet Package Errors

**Problem**: Packages not found or restore fails.

**Solutions**:
```
1. Tools → NuGet Package Manager → Package Manager Settings
2. Check package sources (nuget.org should be enabled)
3. Tools → NuGet Package Manager → Package Manager Console
4. Run: Update-Package -reinstall
```

### Issue 3: Build Errors - DLLs Not Found

**Problem**: References to PhoenixSecurity or SimpleSecurityLib fail.

**Solutions**:
- Ensure all projects are in the solution
- Right-click solution → **Rebuild Solution**
- Check project references in PhoenixMembershipPortal project:
  - Should reference both DLL projects
- Verify DLL projects build successfully

### Issue 4: IIS Express Port Already in Use

**Problem**: Port conflict error when starting.

**Solutions**:
1. Close other instances of IIS Express
2. Change port in project properties:
   - Right-click project → Properties → Web
   - Change **Project Url** port number
   - Click **Create Virtual Directory**

### Issue 5: Services Not Accessible

**Problem**: WCF/ASMX services return 404 errors.

**Solutions**:
- Verify `Web.config` has correct service configuration
- Check that `.svc` and `.asmx` files are in correct locations
- Ensure service handlers are configured in `Web.config`
- Check IIS Express logs in Output window

### Issue 6: XML Files Not Found

**Problem**: Error accessing Member.xml or Staff.xml.

**Solutions**:
- Verify `App_Data` folder exists in project root
- Check that XML files are included in project:
  - Right-click XML file → Properties → Build Action should be "Content"
- Ensure file permissions allow read/write access

### Issue 7: Authentication Not Working

**Problem**: Login redirects fail or roles not assigned.

**Solutions**:
- Verify `Web.config` Forms Authentication is configured
- Check `Global.asax.cs` has `Application_AuthenticateRequest` handler
- Ensure password hashes in XML match DLL hash output
- Check browser cookies are enabled

---

## 📁 Project Structure Overview

```
Assignment6/
├── PhoenixMembershipPortal.sln          # Solution file - OPEN THIS
├── PhoenixMembershipPortal/             # Main Web Application
│   ├── Default.aspx                     # Home page
│   ├── Login.aspx                       # Login page
│   ├── Signup.aspx                      # Registration page
│   ├── Member.aspx                      # Member portal
│   ├── Staff.aspx                       # Staff portal
│   ├── Services/                        # Web services
│   ├── UserControls/                    # User controls
│   ├── App_Data/                        # XML data files
│   └── Web.config                       # Configuration
├── PhoenixSecurity/                     # DLL Project
└── SimpleSecurityLib/                   # DLL Project
```

---

## 🧪 Quick Test Checklist

After running the application, verify:

### ✅ Home Page
- [ ] Default.aspx loads successfully
- [ ] Navigation buttons visible
- [ ] Components Summary Table displays

### ✅ Services
- [ ] `/MembershipService.svc` accessible
- [ ] `/Services/QuoteService.svc` accessible
- [ ] `/Services/WeatherService.asmx` accessible

### ✅ Authentication
- [ ] Login page accessible
- [ ] Signup page accessible
- [ ] Can login with test accounts

### ✅ Test Accounts
- [ ] Login as Member: `john.doe` / `password123`
- [ ] Login as Staff: `TA` / `Cse445!`

---

## 🔍 Verification Steps

### 1. Check Solution Explorer
Should show:
- ✅ PhoenixMembershipPortal (Web Application) - **Startup Project**
- ✅ DLLs folder
  - ✅ PhoenixSecurity (Class Library)
  - ✅ SimpleSecurityLib (Class Library)

### 2. Check Project References
1. Expand `PhoenixMembershipPortal` → `References`
2. Should see:
   - ✅ PhoenixSecurity
   - ✅ SimpleSecurityLib
   - ✅ System.Web
   - ✅ System.Xml.Linq
   - ✅ Other system references

### 3. Check Build Output
1. Build solution (`Ctrl+Shift+B`)
2. Output window should show:
   - ✅ Build succeeded
   - ✅ 0 errors

### 4. Check Browser
1. Run application (`F5`)
2. Browser should open to:
   - ✅ Default.aspx page
   - ✅ No errors in page
   - ✅ All content displays correctly

---

## 💻 Visual Studio 2019 Features Used

### Solution Explorer
- Navigate project structure
- View files and folders
- Manage project references

### Build System
- MSBuild for compilation
- NuGet package management
- Project references

### IIS Express
- Web server for development
- Automatic port assignment
- SSL support (if configured)

### Debugging
- Breakpoints support
- Watch windows
- Call stack
- Output window

---

## 🌐 Application URLs

When running, the application will be available at:

- **Base URL**: `http://localhost:[port]/`
- **Home Page**: `http://localhost:[port]/Default.aspx`
- **Login**: `http://localhost:[port]/Login.aspx`
- **Signup**: `http://localhost:[port]/Signup.aspx`
- **Member Portal**: `http://localhost:[port]/Member.aspx`
- **Staff Portal**: `http://localhost:[port]/Staff.aspx`

**Services**:
- MembershipService: `http://localhost:[port]/MembershipService.svc`
- QuoteService: `http://localhost:[port]/Services/QuoteService.svc`
- WeatherService: `http://localhost:[port]/Services/WeatherService.asmx`

---

## 📝 Quick Start Commands

### Build Solution
```
Ctrl+Shift+B
```
Or: `Build` → `Build Solution`

### Run Application
```
F5 (with debugging)
Ctrl+F5 (without debugging)
```

### Stop Application
```
Shift+F5
```
Or: Click **Stop** button in Visual Studio

### Clean Solution
```
Build → Clean Solution
```

### Rebuild Solution
```
Build → Rebuild Solution
```

---

## ✅ Success Indicators

You'll know the project is running correctly when:

1. ✅ Solution opens without errors
2. ✅ All projects build successfully (0 errors)
3. ✅ Application launches in browser
4. ✅ Default.aspx displays correctly
5. ✅ Navigation buttons work
6. ✅ Services are accessible
7. ✅ Login/Signup pages load
8. ✅ Can authenticate with test accounts

---

## 🆘 Getting Help

If you encounter issues:

1. **Check Error List**: `View` → `Error List`
2. **Check Output Window**: `View` → `Output`
3. **Check Build Log**: Detailed build information
4. **Check Web.config**: Verify all settings
5. **Verify Files**: Ensure all files are present

### Common First Steps:
1. Clean solution: `Build` → `Clean Solution`
2. Restore packages: Right-click solution → `Restore NuGet Packages`
3. Rebuild solution: `Build` → `Rebuild Solution`
4. Delete bin/obj folders (if persistent errors)

---

## 📚 Additional Resources

- **Visual Studio 2019 Documentation**: https://docs.microsoft.com/visualstudio/
- **ASP.NET Web Forms**: https://docs.microsoft.com/aspnet/web-forms/
- **IIS Express**: Included with Visual Studio

---

## 🎯 Summary

**To Run the Project:**

1. Open `PhoenixMembershipPortal.sln` in Visual Studio 2019
2. Restore NuGet packages (automatic or manual)
3. Build the solution (`Ctrl+Shift+B`)
4. Set `PhoenixMembershipPortal` as startup project
5. Press `F5` to run
6. Browser opens automatically to Default.aspx

**That's it!** The application should now be running. 🚀

---

**Last Updated**: Current Date  
**Visual Studio Version**: 2019  
**Target Framework**: .NET Framework 4.7.2

