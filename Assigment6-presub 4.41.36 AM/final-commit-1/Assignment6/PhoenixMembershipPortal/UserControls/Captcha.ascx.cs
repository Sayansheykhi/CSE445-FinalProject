using System;
using System.Web;
using System.Web.UI;

namespace PhoenixMembershipPortal
{
    public partial class Captcha : System.Web.UI.UserControl
    {
        public string UserInput
        {
            get { return txtCaptcha.Text.Trim(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        public void GenerateCaptcha()
        {
            Random random = new Random();
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            int sum = num1 + num2;

            lblCaptcha.Text = $"{num1} + {num2} = ?";
            hdnCaptchaValue.Value = sum.ToString();
        }

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

