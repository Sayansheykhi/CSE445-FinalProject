using System;
using System.Web;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Signup page for new user registration.
    /// Handles user input validation, captcha verification, and adds new members to Member.xml.
    /// Uses password hashing via SimpleSecurityLib DLL before storing credentials.
    /// </summary>
    public partial class Signup : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Redirects authenticated users away from signup page.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already authenticated, redirect to home page
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// Handles signup button click event.
        /// Validates inputs, verifies captcha, checks for duplicate usernames,
        /// hashes password, and adds new member to Member.xml.
        /// </summary>
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            // Clear previous error/success messages
            lblError.Visible = false;
            lblSuccess.Visible = false;

            // Get user input from form fields
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            // Validate all input fields
            if (!ValidateInputs(username, password, confirmPassword, email, fullName))
            {
                return;
            }

            // Validate captcha - user must solve math problem correctly
            if (!captchaControl.ValidateCaptcha())
            {
                ShowError("Invalid captcha. Please try again.");
                captchaControl.GenerateCaptcha(); // Generate new captcha on failure
                return;
            }

            // Check for duplicate username in both Member.xml and Staff.xml
            if (XMLManager.MemberExists(username) || XMLManager.StaffExists(username))
            {
                ShowError("Username already exists. Please choose a different username.");
                captchaControl.GenerateCaptcha(); // Generate new captcha
                return;
            }

            // Hash password using SimpleSecurityLib DLL before storing
            string hashedPassword = SimpleHasher.ComputeHash(password);

            // Add new member to Member.xml with hashed password
            bool success = XMLManager.AddMember(username, hashedPassword, email, fullName, "Member", true);

            if (success)
            {
                lblSuccess.Text = "Account created successfully! Redirecting to login page...";
                lblSuccess.Visible = true;
                Response.AddHeader("REFRESH", "2;URL=Login.aspx");
            }
            else
            {
                ShowError("Failed to create account. Please try again.");
                captchaControl.GenerateCaptcha();
            }
        }

        private bool ValidateInputs(string username, string password, string confirmPassword, string email, string fullName)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Username is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Password is required.");
                return false;
            }

            if (password.Length < 6)
            {
                ShowError("Password must be at least 6 characters long.");
                return false;
            }

            if (password != confirmPassword)
            {
                ShowError("Passwords do not match.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError("Email is required.");
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError("Please enter a valid email address.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ShowError("Full name is required.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}

