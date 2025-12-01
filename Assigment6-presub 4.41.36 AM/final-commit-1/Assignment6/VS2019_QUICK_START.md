# Visual Studio 2019 - Quick Start Guide

**Project**: Phoenix Membership Portal  
**Platform**: Windows  
**IDE**: Visual Studio 2019

---

## ✅ Prerequisites Checklist

Before starting, ensure you have:

- [ ] **Visual Studio 2019** installed (Community, Professional, or Enterprise)
- [ ] **.NET Framework 4.7.2** Developer Pack
- [ ] **ASP.NET and web development** workload installed in VS 2019
- [ ] **Windows 10/11** operating system

---

## 🚀 Quick Start (5 Steps)

### Step 1: Open Solution File

1. Launch **Visual Studio 2019**
2. Click **File** → **Open** → **Project/Solution...**
3. Navigate to the project folder
4. Select: **`PhoenixMembershipPortal.sln`**
5. Click **Open**

**Expected**: Solution Explorer shows 3 projects:
- ✅ PhoenixMembershipPortal (Web Application)
- ✅ PhoenixSecurity (DLL - under DLLs folder)
- ✅ SimpleSecurityLib (DLL - under DLLs folder)

---

### Step 2: Restore NuGet Packages

**Option A - Automatic** (Usually happens automatically):
- Visual Studio will detect and restore packages
- Check Output window for confirmation

**Option B - Manual** (If needed):
1. Right-click **solution** in Solution Explorer
2. Select **Restore NuGet Packages**
3. Wait for completion (check Output window)

---

### Step 3: Build the Solution

1. Press **`Ctrl+Shift+B`** (or Build → Build Solution)
2. Wait for build to complete
3. Check **Error List** window (should show 0 errors)

**Success Indicator**: Output window shows "Build succeeded"

---

### Step 4: Set Startup Project

1. Right-click **PhoenixMembershipPortal** project in Solution Explorer
2. Select **Set as Startup Project**
3. Project name should appear in **bold**

---

### Step 5: Run the Application

1. Press **`F5`** (or click the green **Start** button)
2. Browser will open automatically
3. Application loads at: `http://localhost:[port]/Default.aspx`

**Success**: Default.aspx page displays with navigation buttons and component table

---

## 🔧 Common Issues & Quick Fixes

### Issue: Solution Won't Open
**Fix**: Ensure Visual Studio 2019 is installed with ASP.NET workload

### Issue: Build Errors - Missing References
**Fix**: 
1. Right-click solution → **Restore NuGet Packages**
2. Right-click solution → **Rebuild Solution**

### Issue: DLL Projects Not Found
**Fix**: 
1. Check that all 3 projects appear in Solution Explorer
2. Verify project references in PhoenixMembershipPortal → References

### Issue: Port Already in Use
**Fix**:
1. Close other IIS Express instances
2. Or change port: Right-click project → Properties → Web → Change Project Url port

---

## 📋 Verification Checklist

After running, verify these work:

- [ ] Default.aspx loads (home page with component table)
- [ ] Login button works (navigates to Login.aspx)
- [ ] Signup button works (navigates to Signup.aspx)
- [ ] Services accessible:
  - [ ] `/MembershipService.svc`
  - [ ] `/Services/QuoteService.svc`
  - [ ] `/Services/WeatherService.asmx`

---

## 🧪 Test Login

**Member Account**:
- Username: `john.doe`
- Password: `password123`

**Staff Account (TA)**:
- Username: `TA`
- Password: `Cse445!`

---

## 📁 Project Location

**Solution File**: `Assignment6/PhoenixMembershipPortal.sln`

**Main Web App**: `Assignment6/PhoenixMembershipPortal/`

**DLL Projects**: 
- `Assignment6/PhoenixSecurity/`
- `Assignment6/SimpleSecurityLib/`

---

## ⚡ Keyboard Shortcuts

| Action | Shortcut |
|--------|----------|
| Build Solution | `Ctrl+Shift+B` |
| Run (with debugging) | `F5` |
| Run (without debugging) | `Ctrl+F5` |
| Stop Debugging | `Shift+F5` |
| Rebuild Solution | `Ctrl+Alt+F7` |

---

## 📞 Still Having Issues?

1. **Clean and Rebuild**:
   - Build → Clean Solution
   - Build → Rebuild Solution

2. **Check Output Window**:
   - View → Output
   - Select "Build" from dropdown
   - Look for error messages

3. **Verify .NET Framework**:
   - Ensure .NET Framework 4.7.2 Developer Pack is installed
   - Tools → Get Tools and Features → Individual Components

---

## ✅ Success!

If Default.aspx loads in your browser showing the component summary table, you're all set! 🎉

---

**Need More Details?** See `VISUAL_STUDIO_2019_SETUP_GUIDE.md` for comprehensive instructions.

