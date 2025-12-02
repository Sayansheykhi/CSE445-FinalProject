using System;
using System.Web;
using System.Web.UI;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// User control for CAPTCHA validation using simple math problems.
    /// Generates random addition problems and validates user input to prevent automated submissions.
    /// Used in the Signup page to verify that account creation is performed by a human user.
    /// </summary>
    public partial class Captcha : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the user's input answer to the CAPTCHA challenge.
        /// </summary>
        public string UserInput
        {
            get { return txtCaptcha.Text.Trim(); }
        }

        /// <summary>
        /// Page load event handler. Generates a new CAPTCHA challenge on initial page load.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        /// <summary>
        /// Generates a new CAPTCHA challenge by creating a random addition problem.
        /// Displays the problem to the user and stores the correct answer in a hidden field.
        /// </summary>
        public void GenerateCaptcha()
        {
            Random random = new Random();
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            int sum = num1 + num2;

            lblCaptcha.Text = $"{num1} + {num2} = ?";
            hdnCaptchaValue.Value = sum.ToString();
        }

        /// <summary>
        /// Validates the user's CAPTCHA answer against the correct answer.
        /// Compares the user's input with the stored correct answer from the hidden field.
        /// </summary>
        /// <returns>True if the user's answer matches the correct answer, false otherwise</returns>
        public bool ValidateCaptcha()
        {
            string userInput = txtCaptcha.Text.Trim();
            string correctAnswer = hdnCaptchaValue.Value;

            if (string.IsNullOrWhiteSpace(userInput) || string.IsNullOrWhiteSpace(correctAnswer))
            {
                return false;
            }

            if (int.TryParse(userInput, out int userAnswer) && int.TryParse(correctAnswer, out int correct))
            {
                return userAnswer == correct;
            }

            return false;
        }
    }
}

