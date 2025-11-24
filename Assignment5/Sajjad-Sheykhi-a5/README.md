# Student Name = Sajjad Sheykhi
# Student ID =  1234359297
# Assignment 5 - Utility Web Solution

## Quick Start

1. **Open the Solution**
   - Open `UtilityWebSolution.sln` in Visual Studio

2. **Build the Solution**
   - Right-click the solution → Build Solution (or press Ctrl+Shift+B)
   - Ensure all 3 projects build successfully:
     - UtilityWebApp
     - SimpleSecurityLib
     - WeatherLookupService

3. **Run the Application**
   - Set `UtilityWebApp` as the startup project (right-click → Set as Startup Project)
   - Press F5 or click Run
   - The application will open in your default browser

4. **Test the Features**
   - **Total Visits**: Displays visit counter from Global.asax
   - **Hash TryIt**: Enter text and click "Compute Hash" to see SHA256 hash
   - **Weather TryIt**: Enter a zipcode and click "Get Temperature" (returns 72°F)
   - **Service Directory**: Shows all 3 services in a GridView
   - **Navigation**: Click "Member Page" or "Staff Page" links

## Project Structure

- **UtilityWebApp**: ASP.NET Web Forms application (main project)
- **SimpleSecurityLib**: Class library with SHA256 hashing
- **WeatherLookupService**: ASMX web service for weather lookup


## Notes

- The weather service returns a hard-coded value of 72°F
- All projects target .NET Framework 4.8
- The solution should build without errors

