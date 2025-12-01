# XML Files and XMLManager Utility Summary

## Completed Actions

### 1. App_Data Folder
- **Status**: Already exists
- **Location**: `PhoenixMembershipPortal/App_Data/`
- Contains XML data files for the application

### 2. Created XML Template Files

#### Member.xml
- **Location**: `App_Data/Member.xml`
- **Structure**: `<Members><User>` elements
- **Elements per User**:
  - `id` (attribute) - Unique identifier
  - `Username` - User's login name
  - `Email` - User's email address
  - `FullName` - User's full name
  - `Role` - User role (e.g., "Member", "Administrator")
  - `DateCreated` - Account creation date (YYYY-MM-DD format)
  - `IsActive` - Active status (true/false)

#### Staff.xml
- **Location**: `App_Data/Staff.xml`
- **Structure**: `<Staff><User>` elements
- **Elements per User**:
  - `id` (attribute) - Unique identifier
  - `Username` - Staff login name
  - `Email` - Staff email address
  - `FullName` - Staff full name
  - `Department` - Department assignment
  - `Position` - Job position/title
  - `DateHired` - Hire date (YYYY-MM-DD format)
  - `IsActive` - Active status (true/false)

### 3. Created XMLManager.cs Utility Class

**Location**: `App_Code/XMLManager.cs`  
**Namespace**: `PhoenixMembershipPortal`  
**Type**: Static utility class

## XMLManager Methods

### Member Operations

#### Read Operations
- `GetAllMembers()` - Returns list of all member XElement objects
- `GetMemberById(string id)` - Retrieves member by ID attribute
- `GetMemberByUsername(string username)` - Retrieves member by username (case-insensitive)
- `MemberExists(string username)` - Checks if member exists

#### Write Operations
- `AddMember(string username, string email, string fullName, string role, bool isActive)` - Adds new member with auto-generated ID
- `UpdateMember(string id, Dictionary<string, string> updates)` - Updates member fields
- `DeleteMember(string id)` - Removes member from XML

### Staff Operations

#### Read Operations
- `GetAllStaff()` - Returns list of all staff XElement objects
- `GetStaffById(string id)` - Retrieves staff by ID attribute
- `GetStaffByUsername(string username)` - Retrieves staff by username (case-insensitive)
- `StaffExists(string username)` - Checks if staff exists

#### Write Operations
- `AddStaff(string username, string email, string fullName, string department, string position, bool isActive)` - Adds new staff with auto-generated ID
- `UpdateStaff(string id, Dictionary<string, string> updates)` - Updates staff fields
- `DeleteStaff(string id)` - Removes staff from XML

## XML Structure Templates

### Member.xml Template
```xml
<?xml version="1.0" encoding="utf-8"?>
<Members>
	<User id="1">
		<Username>admin</Username>
		<Email>admin@example.com</Email>
		<FullName>Administrator</FullName>
		<Role>Administrator</Role>
		<DateCreated>2024-01-01</DateCreated>
		<IsActive>true</IsActive>
	</User>
</Members>
```

### Staff.xml Template
```xml
<?xml version="1.0" encoding="utf-8"?>
<Staff>
	<User id="1">
		<Username>manager</Username>
		<Email>manager@example.com</Email>
		<FullName>Staff Manager</FullName>
		<Department>Administration</Department>
		<Position>Manager</Position>
		<DateHired>2023-06-01</DateHired>
		<IsActive>true</IsActive>
	</User>
</Staff>
```

## Usage Examples

### Reading Members
```csharp
// Get all members
List<XElement> allMembers = XMLManager.GetAllMembers();

// Get specific member
XElement member = XMLManager.GetMemberByUsername("john.doe");
string email = member?.Element("Email")?.Value;

// Check if member exists
bool exists = XMLManager.MemberExists("admin");
```

### Adding Members
```csharp
bool success = XMLManager.AddMember(
    username: "newuser",
    email: "newuser@example.com",
    fullName: "New User",
    role: "Member",
    isActive: true
);
```

### Updating Members
```csharp
var updates = new Dictionary<string, string>
{
    { "Email", "updated@example.com" },
    { "FullName", "Updated Name" },
    { "IsActive", "false" }
};
bool success = XMLManager.UpdateMember("1", updates);
```

### Deleting Members
```csharp
bool success = XMLManager.DeleteMember("1");
```

## Features

✅ **Auto-Creation**: XML files are created automatically if they don't exist  
✅ **Auto-ID Generation**: IDs are automatically incremented when adding new entries  
✅ **Thread-Safe File Operations**: Safe file handling with proper error checking  
✅ **Case-Insensitive Search**: Username searches ignore case  
✅ **Null Safety**: Methods handle null values gracefully  
✅ **Flexible Updates**: Dictionary-based updates allow partial field modifications  
✅ **Directory Creation**: Automatically creates directories if needed  

## File Organization

```
PhoenixMembershipPortal/
├── App_Data/
│   ├── Member.xml          (Members with User elements)
│   ├── Members.xml         (Existing file - different structure)
│   └── Staff.xml           (Staff with User elements)
└── App_Code/
    └── XMLManager.cs       (Utility class for XML operations)
```

## Important Notes

- **App_Code Folder**: Files in App_Code are automatically compiled in ASP.NET
- **XML Structure**: Member.xml uses `<Members><User>`, Staff.xml uses `<Staff><User>`
- **Date Format**: Dates are stored in ISO format (YYYY-MM-DD)
- **File Paths**: Uses `Server.MapPath()` for relative path resolution
- **Error Handling**: Methods return boolean values for operation success/failure

