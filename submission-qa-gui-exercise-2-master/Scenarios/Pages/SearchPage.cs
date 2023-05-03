using FluentAssertions;
using OpenQA.Selenium;
using Scenarios.Steps;

namespace Scenarios.Pages
{
    public class SearchPage
    {
        private const string Url = "http://localhost:90";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;

        private static IWebElement SearchField => Driver.FindElement(By.Name("q"));
        private static IWebElement SearchButton => Driver.FindElement(By.Id("small-searchterms"));

        public SearchPage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            Driver.Title.Should().Be("Your store. Home page title");
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
