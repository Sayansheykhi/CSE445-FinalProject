📌 CSE 445 Assignment 5 Submission  
Student Name: Jaskirat Singh  
ASU ID: XXXXXXXXX  
Project Title: PhoenixMembershipPortal  

📍 Overview
This ASP.NET WebForms application demonstrates the required components for Assignment 5:
- WCF Service (MembershipService.svc)
- Local Component (Hash DLL)
- State Management using Cookies
- Global.asax event handling
- XML file storage in App_Data folder
- Try-It functional testing buttons integrated in Default.aspx

📍 How to Run
1. Open solution in Visual Studio (2019 or later)
2. Restore NuGet packages (if prompted)
3. Run using IIS Express
4. Navigate to Default.aspx to test features

📍 XML File Location
App_Data/Members.xml  
Contains stored usernames used by MembershipService.

📍 Testing Instructions

✔ Membership Username Check:
- Enter "admin" → should display ❌ Username exists
- Enter random text → should display ✔ Available

✔ Cookie Test:
- Enter value in cookie input box and click Save
- Refresh or restart browser → message should appear:
"Welcome back, <cookie_value>"

✔ Hash DLL Try-It:
- Click "Run Hash Test"
- Should display SHA256 hash output.

✔ Global.asax Test:
- Refresh browser or open new session to increase visit count
(printed internally in Application["Visits"])

📍 Files Implemented by Me
- Default.aspx + Default.aspx.cs
- MembershipService.svc + .cs
- HashUtility.cs (DLL local component)
- Cookie functionality
- Global.asax event logic

📍 No WebSTRAR deployment included (not required for Assignment 5).
Will be completed in Assignment 6.

📌 End of Document
