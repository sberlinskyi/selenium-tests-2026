using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools.V146.Browser;
using Microsoft.VisualBasic;


namespace selenium_tests_2026;

[TestFixture]
public class SeleniumTests : BaseFixture
{
    private ExamplePage? examplePage;

    [Test]
    public void VerifyPageTitleTest()
    {
        Driver.Navigate().GoToUrl("https://example.com");
        examplePage = new ExamplePage(Driver);
        examplePage.WaitForVisible(By.CssSelector("h1"), 5);
        var pageTitle = Driver.Title;
        Console.WriteLine($"The page title is: {pageTitle}");
        Console.WriteLine($"The page header text is: {examplePage.HeaderElement.Text}");

        Assert.IsTrue(pageTitle.Contains("Example Domain"));
    }
}
