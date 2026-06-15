using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

public abstract class BaseFixture
{
    private static IWebDriver? driver;
    private static readonly object driverLock = new();

    protected IWebDriver Driver
    {
        get
        {
            if (driver == null)
            {
                lock (driverLock)
                {
                    if (driver == null)
                    {
                        driver = new ChromeDriver(new ChromeOptions());
                    }
                }
            }

            return driver;
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        try
        {
            driver?.Quit();
        }
        finally
        {
            (driver as IDisposable)?.Dispose();
            driver = null;
        }
    }
}