using OpenQA.Selenium;

public class ExamplePage : BasePage
{
    public IWebElement ButtonElement => Driver.FindElement(By.CssSelector("button"));
    
    public IWebElement HeaderElement => WaitForVisible(By.CssSelector("h1"));

    public ExamplePage(IWebDriver driver) : base(driver) { }

}