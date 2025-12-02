<%@ Application Codebehind="Global.asax.cs" Inherits="UtilityWebApp.Global" Language="C#" %>
<!-- 
    Global.asax - Application Event Handler
    This file defines the global application class that handles application-level
    and session-level events. The code-behind (Global.asax.cs) contains event handlers
    for Application_Start and Session_Start, which manage the visit counter functionality.
    
    Application_Start: Initializes Application["TotalVisits"] to 0 when the app starts.
    Session_Start: Increments Application["TotalVisits"] each time a new user session begins.
-->

