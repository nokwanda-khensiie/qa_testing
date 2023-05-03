using FluentAssertions;
using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class HomePage
    {
        private const string Url = "http://localhost:90";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;
        private static IWebElement SearchField => Driver.FindElement(By.Name("q"));
        private static IWebElement SearchButton => Driver.FindElement(By.Id("small-searchterms"));
        
        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            Driver.Title.Should().Be("Your store. Home page title");
            return this;
        }
        public HomePage VerifyPage()
        {
             var logo = "http://localhost:90";
             Driver.Navigate().GoToUrl(logo);
             var path = Driver.FindElement(By.XPath("//img[@alt='Your store name]'"));
             path.GetAttribute("alt").Should().Be("Your store name");
             return this;
        }

        public ResultPage SearchFor(string text)
        {
            SearchField.SendKeys(text);
            SearchButton.Click();
            return new ResultPage(text);
        }
    }

}
