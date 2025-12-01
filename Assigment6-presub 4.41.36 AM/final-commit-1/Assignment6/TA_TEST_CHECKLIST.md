# TA Test Checklist - Phoenix Membership Portal

**Application URL**: [Enter deployment URL here]  
**Test Date**: _______________  
**Tester**: _______________

## Pre-Test Information

### Test Accounts
- **TA Account**: Username: `TA`, Password: `Cse445!` (Role: Staff)
- **Member Account**: Username: `john.doe`, Password: `password123` (Role: Member)
- **Staff Account**: Username: `manager`, Password: `password123` (Role: Staff)

---

## 1. Home Page (Default.aspx) ✅

### 1.1 Page Access
- [ ] Default.aspx loads successfully
- [ ] All navigation buttons visible (Login, Signup, Member, Staff)
- [ ] Components Summary Table displays correctly
- [ ] All 11 components listed in table

### 1.2 Navigation Buttons
- [ ] Login button links to Login.aspx
- [ ] Signup button links to Signup.aspx
- [ ] Member Portal button links to Member.aspx
- [ ] Staff Portal button links to Staff.aspx

### 1.3 Components Summary Table
Verify all components are listed:
- [ ] PhoenixSecurity DLL
- [ ] SimpleSecurityLib DLL
- [ ] MembershipService (WCF)
- [ ] QuoteService (WCF)
- [ ] WeatherService (ASMX)
- [ ] ViewSwitcher User Control
- [ ] Captcha User Control
- [ ] XMLManager Utility
- [ ] Member.xml
- [ ] Staff.xml
- [ ] Global.asax.cs

### 1.4 TryIt Buttons
- [ ] Hash Function Try-It button works
- [ ] Both DLL hashes display correctly
- [ ] Service links open in new tabs

---

## 2. Authentication & Authorization ✅

### 2.1 Login Page (Login.aspx)
- [ ] Login page accessible without authentication
- [ ] Username and password fields present
- [ ] Login button functional

### 2.2 TA Account Login
- [ ] Login with: Username: `TA`, Password: `Cse445!`
- [ ] Successfully redirects to Staff.aspx
- [ ] No authentication errors

### 2.3 Member Account Login
- [ ] Login with: Username: `john.doe`, Password: `password123`
- [ ] Successfully redirects to Member.aspx
- [ ] No authentication errors

### 2.4 Authorization Testing
- [ ] Attempt to access Member.aspx without login → Redirects to Login.aspx
- [ ] Attempt to access Staff.aspx without login → Redirects to Login.aspx
- [ ] Login as member → Can access Member.aspx
- [ ] Login as member → Cannot access Staff.aspx (redirects)
- [ ] Login as staff → Can access Staff.aspx
- [ ] Login as staff → Cannot access Member.aspx (redirects)

### 2.5 Session Timeout
- [ ] Login successful
- [ ] Session persists for 60 minutes (or configured timeout)
- [ ] Logout button works correctly

---

## 3. Signup Page (Signup.aspx) ✅

### 3.1 Page Access
- [ ] Signup page accessible without authentication
- [ ] All form fields present (Username, Password, Confirm Password, Email, Full Name)
- [ ] Captcha control displays correctly

### 3.2 Captcha Validation
- [ ] Captcha displays math problem (e.g., "3 + 5 = ?")
- [ ] Incorrect captcha shows error message
- [ ] New captcha generated on error

### 3.3 Form Validation
- [ ] Empty fields show appropriate error messages
- [ ] Password mismatch shows error
- [ ] Email format validation works
- [ ] Duplicate username shows error

### 3.4 Successful Signup
- [ ] Complete signup form correctly
- [ ] Solve captcha correctly
- [ ] Submit form → Success message displays
- [ ] Redirects to Login.aspx after 2 seconds
- [ ] New user added to Member.xml (verify by logging in)

---

## 4. Member Portal (Member.aspx) ✅

### 4.1 Access Control
- [ ] Only accessible with "member" role
- [ ] Non-members redirected to Login.aspx

### 4.2 Profile Display
- [ ] Welcome message displays with full name
- [ ] Username displayed correctly
- [ ] Full Name displayed correctly
- [ ] Email displayed correctly
- [ ] Role displayed as badge
- [ ] Member Since date formatted correctly
- [ ] Account Status badge displays (Active/Inactive)

### 4.3 Member Tools
- [ ] All tool items visible
- [ ] "Browse Services" link works (links to Default.aspx)
- [ ] Other tools show "Coming Soon" status

### 4.4 Account Activity
- [ ] Last login time displays
- [ ] Session start time displays
- [ ] Logout button works correctly

---

## 5. Staff Portal (Staff.aspx) ✅

### 5.1 Access Control (TA Account Test)
- [ ] Login with TA account: Username: `TA`, Password: `Cse445!`
- [ ] Successfully redirects to Staff.aspx
- [ ] Staff profile information displays correctly

### 5.2 Staff Profile Display
- [ ] Welcome message displays with full name
- [ ] Username: `TA` displayed
- [ ] Full Name: "Teaching Assistant" displayed
- [ ] Email displayed correctly
- [ ] Department: "Computer Science" displayed
- [ ] Position: "Teaching Assistant" displayed
- [ ] Date Hired formatted correctly
- [ ] Status badge displays "Active"

### 5.3 Member Management (Admin Functionality)
- [ ] "Member Management" card visible
- [ ] "Refresh Member List" button works
- [ ] Member count badge displays correct number
- [ ] GridView displays all members from Member.xml
- [ ] GridView columns: ID, Username, Full Name, Email, Role, Member Since, Status
- [ ] All members from Member.xml visible in grid
- [ ] Status badges display correctly (Active/Inactive)

### 5.4 Admin Tools
- [ ] "View All Services" link works
- [ ] Other admin tools show "Coming Soon" status

### 5.5 Logout
- [ ] Logout button works correctly
- [ ] Redirects to Login.aspx after logout

---

## 6. Web Services Testing ✅

### 6.1 MembershipService (WCF)
- [ ] Service accessible at: `/MembershipService.svc`
- [ ] WSDL accessible at: `/MembershipService.svc?wsdl`
- [ ] Service test page loads
- [ ] `CheckUsernameAvailability` method available
- [ ] Test method with existing username → Returns true
- [ ] Test method with new username → Returns false

### 6.2 QuoteService (WCF)
- [ ] Service accessible at: `/Services/QuoteService.svc`
- [ ] WSDL accessible at: `/Services/QuoteService.svc?wsdl`
- [ ] Service test page loads
- [ ] `GetQuote` method available
- [ ] Test method with name parameter → Returns personalized quote

### 6.3 WeatherService (ASMX)
- [ ] Service accessible at: `/Services/WeatherService.asmx`
- [ ] WSDL accessible at: `/Services/WeatherService.asmx?wsdl`
- [ ] Service test page loads
- [ ] `GetTemperature` method available
- [ ] Test method with zipcode → Returns temperature (72)

---

## 7. DLL Components Testing ✅

### 7.1 PhoenixSecurity DLL
- [ ] Hash Function Try-It button on Default.aspx works
- [ ] Displays SHA256 hash using PhoenixSecurity.HashUtility.ComputeSha256()
- [ ] Hash format: 64-character lowercase hexadecimal string

### 7.2 SimpleSecurityLib DLL
- [ ] Hash Function Try-It displays hash from SimpleSecurityLib.SimpleHasher.ComputeHash()
- [ ] Both DLLs produce same hash for same input
- [ ] Hash format: 64-character lowercase hexadecimal string

---

## 8. User Controls Testing ✅

### 8.1 Captcha Control
- [ ] Captcha displays on Signup.aspx
- [ ] Math problem generates correctly
- [ ] Validation works (correct/incorrect answers)
- [ ] New captcha generates on validation failure

### 8.2 ViewSwitcher Control
- [ ] Control available on mobile master page
- [ ] View switching functionality works (if applicable)

---

## 9. XML Data Management ✅

### 9.1 Member.xml
- [ ] File exists in App_Data folder
- [ ] Contains all required user entries
- [ ] Password fields present with hashed values
- [ ] New signups add users to file correctly

### 9.2 Staff.xml
- [ ] File exists in App_Data folder
- [ ] Contains TA account (Username: `TA`)
- [ ] TA password hash is correct (`Cse445!`)
- [ ] All staff entries have Password fields

### 9.3 XMLManager Operations
- [ ] Reading members works correctly
- [ ] Reading staff works correctly
- [ ] Adding members works (via signup)
- [ ] Staff can view all members

---

## 10. Global.asax Functionality ✅

### 10.1 Application Events
- [ ] Application_Start initializes visit counters
- [ ] Session_Start increments visit counters
- [ ] Application_AuthenticateRequest assigns roles correctly

### 10.2 Visit Counting
- [ ] Visit counts display on Default.aspx
- [ ] Counters increment correctly on page loads

---

## 11. Role-Based Authorization (Detailed) ✅

### 11.1 Member Role
- [ ] Member can access Member.aspx
- [ ] Member cannot access Staff.aspx
- [ ] Member redirected to Login if trying to access Staff.aspx

### 11.2 Staff Role
- [ ] Staff can access Staff.aspx
- [ ] Staff cannot access Member.aspx
- [ ] Staff redirected to Login if trying to access Member.aspx

### 11.3 Public Pages
- [ ] Login.aspx accessible without authentication
- [ ] Signup.aspx accessible without authentication
- [ ] Default.aspx accessible without authentication
- [ ] Services accessible without authentication

---

## 12. Security Testing ✅

### 12.1 Password Hashing
- [ ] Passwords stored as hashes (not plain text) in XML
- [ ] Login validates against hashed passwords
- [ ] Hash algorithm: SHA256

### 12.2 Session Management
- [ ] Sessions timeout correctly (60 minutes)
- [ ] Logout clears session
- [ ] Session data persists correctly

### 12.3 Authorization Bypass Attempts
- [ ] Direct URL access to Member.aspx without login → Blocked
- [ ] Direct URL access to Staff.aspx without login → Blocked
- [ ] Attempt to access with wrong role → Blocked

---

## 13. UI/UX Testing ✅

### 13.1 Bootstrap Styling
- [ ] All pages use Bootstrap 5 styling consistently
- [ ] Cards, buttons, and tables styled correctly
- [ ] Responsive design works on mobile

### 13.2 Navigation
- [ ] All links work correctly
- [ ] Breadcrumbs/logout visible on protected pages
- [ ] Consistent navigation across pages

### 13.3 Error Messages
- [ ] Clear error messages for failed login
- [ ] Clear error messages for validation failures
- [ ] User-friendly captcha error messages

---

## 14. Performance Testing ✅

### 14.1 Page Load Times
- [ ] Default.aspx loads quickly
- [ ] Login page loads quickly
- [ ] Member/Staff portals load quickly

### 14.2 Service Response Times
- [ ] Services respond within reasonable time
- [ ] WSDL generation is fast
- [ ] Service methods execute quickly

---

## Test Results Summary

### Critical Issues (Must Fix)
- [ ] Issue 1: _______________
- [ ] Issue 2: _______________

### Minor Issues (Should Fix)
- [ ] Issue 1: _______________
- [ ] Issue 2: _______________

### Pass/Fail Summary
- **Home Page**: ⬜ Pass / ⬜ Fail
- **Authentication**: ⬜ Pass / ⬜ Fail
- **Signup**: ⬜ Pass / ⬜ Fail
- **Member Portal**: ⬜ Pass / ⬜ Fail
- **Staff Portal**: ⬜ Pass / ⬜ Fail
- **Web Services**: ⬜ Pass / ⬜ Fail
- **DLL Components**: ⬜ Pass / ⬜ Fail
- **User Controls**: ⬜ Pass / ⬜ Fail
- **XML Data**: ⬜ Pass / ⬜ Fail
- **Security**: ⬜ Pass / ⬜ Fail

---

## Final Verification

### TA Account Access ✅
- [ ] TA account login successful: Username: `TA`, Password: `Cse445!`
- [ ] TA account can access Staff.aspx
- [ ] TA account can view all members
- [ ] TA account profile displays correctly

### Overall Application Status
- [ ] All critical functionality working
- [ ] All services accessible
- [ ] Authentication and authorization working correctly
- [ ] Application ready for production use

---

## Test Sign-Off

**Test Completed By**: _______________  
**Test Date**: _______________  
**Overall Status**: ⬜ PASS / ⬜ FAIL  
**Notes**: 

_________________________________________________
_________________________________________________
_________________________________________________

