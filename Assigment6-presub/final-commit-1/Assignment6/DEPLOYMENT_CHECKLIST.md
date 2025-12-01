# Deployment Checklist - Phoenix Membership Portal

## Pre-Deployment Verification

### 1. App_Data XML Files ✅
- [x] `App_Data/Member.xml` - Included in project
- [x] `App_Data/Staff.xml` - Included in project (with TA account)
- [x] `App_Data/Members.xml` - Included in project
- [x] All XML files have proper structure with Password fields
- [x] TA account exists: Username: `TA`, Password: `Cse445!`

### 2. Service Paths Verification ✅

#### WCF Services
- [x] `MembershipService.svc` - Root level, correct namespace
- [x] `Services/QuoteService.svc` - In Services folder, correct namespace
- [x] All service endpoints configured in `system.serviceModel`
- [x] Service handlers configured in `system.webServer`

#### ASMX Services
- [x] `Services/WeatherService.asmx` - In Services folder, correct namespace
- [x] No Web.config configuration needed (ASMX auto-configures)

**Service Endpoints:**
- MembershipService: `/MembershipService.svc`
- QuoteService: `/Services/QuoteService.svc`
- WeatherService: `/Services/WeatherService.asmx`

### 3. Forms Authentication Paths ✅
- [x] `loginUrl="Login.aspx"` - Relative path (no ~/ needed)
- [x] Timeout set to 60 minutes
- [x] All redirect paths use `~/` prefix in code-behind
- [x] Role-based authorization configured:
  - Member.aspx - `role="member"` only
  - Staff.aspx - `role="staff"` only
  - Login.aspx - Public access
  - Signup.aspx - Public access
  - Services folder - Public access

### 4. Project Structure ✅
- [x] All DLL references included
- [x] All user controls in UserControls folder
- [x] All service files in correct locations
- [x] App_Code folder with XMLManager.cs
- [x] Global.asax.cs with authentication handler

## Web.config Configuration ✅

### Authentication
```xml
<authentication mode="Forms">
  <forms loginUrl="Login.aspx" timeout="60" />
</authentication>
```

### Role-Based Authorization
- Member.aspx: `role="member"` only
- Staff.aspx: `role="staff"` only
- Public pages: Login.aspx, Signup.aspx
- Services: Public access

### Service Model
- MembershipService configured
- QuoteService configured
- Service behaviors enabled
- Metadata exchange enabled

### Handlers
- SVC handler configured
- Handler conflicts resolved

## Deployment Steps

### Option 1: Web Deploy

1. **Open Project in Visual Studio**
   - Open `PhoenixMembershipPortal.sln`
   - Build solution (Release configuration)
   - Verify no build errors

2. **Publish Profile Setup**
   - Right-click `PhoenixMembershipPortal` project
   - Select "Publish..."
   - Choose "Web Deploy" as publish method

3. **Web Deploy Settings**
   ```
   Server: [WebStar Server Address]
   Site name: [Site Name]
   Username: [WebStar Username]
   Password: [WebStar Password]
   Destination URL: [Deployment URL]
   ```

4. **Publish Settings**
   - Configuration: Release
   - Target Framework: .NET Framework 4.7.2
   - Precompile during publishing: Enabled
   - Exclude files from App_Data: **FALSE** (IMPORTANT - Must include XML files)
   - Allow precompiled site to be updatable: Enabled

5. **Deploy**
   - Click "Publish"
   - Verify deployment success
   - Check deployment log for errors

### Option 2: FTP Deployment

1. **Build Solution**
   - Set configuration to Release
   - Build entire solution
   - Verify no errors

2. **Publish to Folder**
   - Right-click `PhoenixMembershipPortal` project
   - Select "Publish..."
   - Choose "Folder" as publish method
   - Set target location (local folder)

3. **FTP Upload Settings**
   ```
   FTP Server: [WebStar FTP Server]
   Port: 21 (or custom)
   Username: [WebStar FTP Username]
   Password: [WebStar FTP Password]
   Remote Directory: / (or specific directory)
   ```

4. **Upload Files**
   - Upload all files from publish folder
   - **IMPORTANT**: Include App_Data folder with all XML files
   - Ensure file permissions are correct:
     - App_Data: Read/Write permissions
     - Other folders: Read permissions

5. **Verify Upload**
   - Check App_Data folder exists on server
   - Verify XML files are present
   - Check file permissions

## Post-Deployment Verification

### 1. File Structure Check
- [ ] App_Data folder exists
- [ ] Member.xml exists in App_Data
- [ ] Staff.xml exists in App_Data
- [ ] Services folder exists
- [ ] UserControls folder exists
- [ ] All DLLs in bin folder

### 2. Service Endpoints Check
- [ ] `http://[site]/MembershipService.svc` - Accessible
- [ ] `http://[site]/MembershipService.svc?wsdl` - WSDL available
- [ ] `http://[site]/Services/QuoteService.svc` - Accessible
- [ ] `http://[site]/Services/QuoteService.svc?wsdl` - WSDL available
- [ ] `http://[site]/Services/WeatherService.asmx` - Accessible
- [ ] `http://[site]/Services/WeatherService.asmx?wsdl` - WSDL available

### 3. Authentication Check
- [ ] Default.aspx - Accessible (public)
- [ ] Login.aspx - Accessible (public)
- [ ] Signup.aspx - Accessible (public)
- [ ] Member.aspx - Redirects to Login (when not authenticated)
- [ ] Staff.aspx - Redirects to Login (when not authenticated)

### 4. Path Verification
- [ ] All relative paths work correctly
- [ ] Images/CSS/JS load properly
- [ ] Master pages load correctly
- [ ] User controls render properly

## Critical Deployment Notes

### ⚠️ IMPORTANT: App_Data Folder
- **MUST** be included in deployment
- XML files contain user credentials
- Set appropriate file permissions (read/write for App_Data)

### ⚠️ IMPORTANT: Service Paths
- All paths are relative - no absolute paths
- Services use correct namespaces
- Handler configuration required for .svc files

### ⚠️ IMPORTANT: Authentication
- loginUrl uses relative path: "Login.aspx"
- Code-behind uses ~/ prefix for redirects
- Role-based authorization configured in Web.config

### ⚠️ IMPORTANT: DLL Dependencies
- PhoenixSecurity.dll - Must be in bin folder
- SimpleSecurityLib.dll - Must be in bin folder
- All NuGet packages included

## Web.config Validation Checklist

- [x] **Single system.web section** - No duplicates
- [x] **Authentication configured** - Forms mode, 60 min timeout
- [x] **Role-based authorization** - Member.aspx and Staff.aspx protected
- [x] **Service model configured** - Both WCF services registered
- [x] **Handlers configured** - SVC handler set up
- [x] **No conflicts** - All sections properly merged

## Deployment URL Configuration

After deployment, update these URLs in documentation:
- Base URL: `http://[your-domain]/`
- Services Base: `http://[your-domain]/Services/`
- Login URL: `http://[your-domain]/Login.aspx`

## Troubleshooting

### Issue: XML files not found
**Solution**: Ensure App_Data folder is included in deployment and has proper permissions

### Issue: Services not accessible
**Solution**: Check Web.config serviceModel section and handler configuration

### Issue: Authentication not working
**Solution**: Verify loginUrl path and role-based authorization rules

### Issue: DLLs not found
**Solution**: Ensure all DLL projects are built and copied to bin folder

## Deployment Sign-Off

- [ ] Pre-deployment verification complete
- [ ] All files uploaded successfully
- [ ] All services accessible
- [ ] Authentication working
- [ ] TA test account verified
- [ ] Post-deployment checklist complete

**Deployed By**: _______________  
**Deployment Date**: _______________  
**Deployment URL**: _______________  
**Verified By**: _______________

