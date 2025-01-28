using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace BootcampTests;

// An example on how Selenium can run. It opens the browser, maximises window, waits for the searchbox and the submits a search before closing.

[TestClass]
public class OpenSearchEngineTest
{
    private ChromeDriver driver = null!;
    private readonly string searchEngineUrl = "https://duckduckgo.com/";

    [TestInitialize]
    public void Setup()
    {
        // Initialize Chrome WebDriver
        var options = new ChromeOptions();
        //options.AddArgument("--headless"); // Optional: Run tests without opening the browser. Comment it out to see the browser open and close.
        driver = new ChromeDriver(options);
    }

    [TestCleanup]
    public void TearDown()
    {
        // Close the browser after each test
        driver.Quit();
    }

    [TestMethod]
    public void OpenDuckDuckGoTest_ShouldOpenBrowser_AddText()
    {
        // Navigate to DuckDuckGo's homepage
        driver.Navigate().GoToUrl(searchEngineUrl);

        // Maximize the browser window
        driver.Manage().Window.Maximize();

        // Wait for the search box to be visible
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(webDriver =>
        {
            try
            {
                var elementToBeDisplayed = webDriver.FindElement(By.Name("q"));
                return elementToBeDisplayed.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });

        // Find the search box using its name attribute
        IWebElement searchBox = driver.FindElement(By.Name("q"));

        // Enter text into the search box
        searchBox.SendKeys("Selenium C# tutorial");

        // Submit the search form
        searchBox.Submit();

        // Wait for the results to be visible
        Thread.Sleep(5000); // Wait for 5 seconds
    }
}