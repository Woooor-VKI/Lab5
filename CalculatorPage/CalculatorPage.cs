using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class CalculatorPage
{
    private IWebDriver driver;
    private WebDriverWait wait;
    private IWebElement valueAInput;
    private IWebElement valueBInput;
    private IWebElement operationDropdown;
    private IWebElement calculateButton;
    private IWebElement resultLabel;
    private IWebElement buttonAPlus;
    private IWebElement buttonAMinus;
    private IWebElement buttonBPlus;
    private IWebElement buttonBMinus;

    public CalculatorPage(IWebDriver driver)
    {
        this.driver = driver;
        this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        valueAInput = this.driver.FindElement(By.CssSelector("[ng-model='a']"));
        valueBInput = this.driver.FindElement(By.CssSelector("[ng-model='b']"));
        operationDropdown = this.driver.FindElement(By.CssSelector("[ng-model='operation']"));
        resultLabel = this.driver.FindElement(By.CssSelector(".result.ng-binding"));

        buttonAPlus = this.driver.FindElement(By.CssSelector("[ng-click='inca()']"));
        buttonAMinus = this.driver.FindElement(By.CssSelector("[ng-click='deca()']"));

        buttonBPlus = this.driver.FindElement(By.CssSelector("[ng-click='incb()']"));
        buttonBMinus = this.driver.FindElement(By.CssSelector("[ng-click='decb()']"));
    }

    public void ButtonAPlus() 
    {
        buttonAPlus.Click();
    }
    public void ButtonAMinus()
    {
        buttonAMinus.Click();
    }

    public void ButtonBPlus()
    {
        buttonBPlus.Click();
    }
    public void ButtonBMinus()
    {
        buttonBMinus.Click();
    }

    public void EnterValueA(double value)
    {
        valueAInput.Clear();
        valueAInput.SendKeys(value.ToString());
    }

    public void EnterValueB(double value)
    {
        valueBInput.Clear();
        valueBInput.SendKeys(value.ToString());
    }

    public void SelectOperation(string operation)
    {
        operationDropdown.SendKeys(operation);
    }

    public string GetResult()
    {
        return resultLabel.Text;
    }
}