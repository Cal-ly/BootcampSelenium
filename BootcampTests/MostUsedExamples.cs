using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BootcampTests;

// This file contains the most common Selenium C# statements with explanations as comments.
public class MostUsedExamples
{
    private readonly string _searchEngineUrl = "https://duckduckgo.com";

    public void RunExamples()
    {
        // Initializing the WebDriver
        ChromeDriver driver = new();

        try
        {
            // Navigating to a URL
            driver.Navigate().GoToUrl(_searchEngineUrl);

            // Maximizing the Browser Window
            driver.Manage().Window.Maximize();

            // Finding an Element by ID
            IWebElement element = driver.FindElement(By.Id("elementId"));

            // Sending Text to an Input Field
            element.SendKeys("text to input");

            // Clicking an Element
            element.Click();

            // Submitting a Form
            element.Submit();

            // Retrieving Text from an Element
            string text = element.Text;

            // Getting an Element Attribute
            string attributeValue = element.GetAttribute("attributeName");

            // Waiting for an Element to Be Visible
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            IWebElement visibleElement = wait.Until(driver =>
            {
                var elem = driver.FindElement(By.Id("elementId"));
                return (elem.Displayed) ? elem : null;
            });

            // Waiting for an Element to Be Clickable
            IWebElement clickableElement = wait.Until(driver =>
            {
                var elem = driver.FindElement(By.Id("elementId"));
                return (elem.Displayed && elem.Enabled) ? elem : null;
            });

            // Switching Between Browser Tabs or Windows
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            // Handling Alerts
            IAlert alert = wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
            alert?.Accept(); // Accepts the alert

            // Taking a Screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile("screenshot.png");

            // Clearing Text from an Input Field
            element.Clear();

            // Executing JavaScript
            driver.ExecuteScript("alert('Hello World!');");

            // Retrieving the Current URL
            string currentUrl = driver.Url;

            // Retrieving the Page Title
            string title = driver.Title;

            // Checking if an Element is Displayed
            bool isDisplayed = element.Displayed;

            // Selecting Options from a Dropdown
            SelectElement select = new(driver.FindElement(By.Id("dropdownId")));
            select.SelectByValue("value"); // Selects by the value attribute
            select.SelectByText("Visible Text"); // Selects by the displayed text

            // Mouse Hover Actions
            Actions actions = new(driver);
            actions.MoveToElement(element).Perform();

            // Handling Checkboxes
            IWebElement checkbox = driver.FindElement(By.Id("checkboxId"));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }

            // Handling Radio Buttons
            IWebElement radioButton = driver.FindElement(By.Id("radioButtonId"));
            if (!radioButton.Selected)
            {
                radioButton.Click();
            }

            // Handling Frames and iFrames
            driver.SwitchTo().Frame("frameName");
            // Perform actions inside the frame
            driver.SwitchTo().DefaultContent(); // Switch back to the main content

            // Scrolling the Page
            driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            // Handling Cookies
            Cookie cookie = new("cookieName", "cookieValue");
            driver.Manage().Cookies.AddCookie(cookie);
            Cookie? retrievedCookie = driver.Manage().Cookies.GetCookieNamed("cookieName");
            driver.Manage().Cookies.DeleteCookieNamed("cookieName");
        }
        finally
        {
            // Closing the Browser
            driver.Quit();
        }
    }
}
