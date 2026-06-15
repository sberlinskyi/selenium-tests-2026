using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class BasePage
{
    protected IWebDriver Driver { get; }

    public BasePage(IWebDriver driver) => Driver = driver ?? throw new ArgumentNullException(nameof(driver));

    public IWebElement WaitForVisible(By by, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(d =>
        {
            var element = d.FindElement(by);
            return element.Displayed ? element : null;
        });
    }

    public IWebElement WaitForClickable(By by, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(d =>
        {
            var element = d.FindElement(by);
            return element.Displayed && element.Enabled ? element : null;
        });
    }
}
