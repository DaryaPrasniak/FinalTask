using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailFinalTask.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static string END_POINT = "";

        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        private static readonly By LoginErrorMessage = By.ClassName("loginpage-message-image");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(LoginInButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void EmailInput(string email)
        {
            Driver.FindElement(EmailInputBy).SendKeys(email);
        }

        public void PswInput(string password)
        {
            Driver.FindElement(PswInputBy).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(LoginInButtonBy).Click();   
        }

        public void Login(string email, string password)
        {
            EmailInput(email);
            PswInput(password);
            ClickLoginButton();
        }

        public DashboardPage SuccessfulLogin(string email, string password)
        {
            Login(email, password);
            _logger.Info(message: "Navigate to DashboardPage");
            return new DashboardPage(Driver);
        }

        public LoginPage IncorrectLogin(string email)
        {
            EmailInput(email);
            ClickLoginButton();
            _logger.Info(message: "Navigate to LoginPage");
            return this;
        }

        public string CheckLoginErrorMessage()
        {
           return Driver.FindElement(LoginErrorMessage).Text;
        }
    }
}
