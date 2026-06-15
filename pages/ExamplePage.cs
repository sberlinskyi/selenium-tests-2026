using OpenQA.Selenium;

public class ExamplePage : BasePage
{
    public ExamplePage(IWebDriver driver) : base(driver) { }

    public IWebElement HeaderElement => WaitForVisible(By.CssSelector("h1"));
}