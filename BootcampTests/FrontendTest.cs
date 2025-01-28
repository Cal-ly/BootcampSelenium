using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BootcampTests;

// Yes, it is all written in ENG, instead of DK. Why? I Can't stand Danglish..
[TestClass]
public class FrontendTest
{
    private ChromeDriver driver = null!;
    private readonly string frontendUrl = "C:/Users/Cal-l/Documents/GitHub/Bootcamp/BootcampFrontend/opgave8/index.html";

    [TestInitialize]
    public void Setup()
    {
        // Initialize Chrome WebDriver
        var options = new ChromeOptions();
        options.AddArgument("--headless"); // Optional: Run tests without opening the browser. Comment it out to see the browser open and close.
        driver = new ChromeDriver(options);
    }

    [TestCleanup]
    public void TearDown()
    {
        // Close the browser after each test
        driver.Quit();
    }

    [TestMethod]
    public void TestFilterByBeanType()
    {
        // Open the frontend
        driver.Navigate().GoToUrl(frontendUrl);

        // Wait for the page to load (basic implicit wait)
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        // Find the filter input field
        var filterInput = driver.FindElement(By.CssSelector("input[placeholder='Filter by Bean Type']"));

        // Enter a filter value (e.g., "Arabica")
        const string filterValue = "Arabica";
        filterInput.SendKeys(filterValue);

        // Wait a short time to allow the frontend to update
        Thread.Sleep(500); // Avoid this in production; use WebDriverWait instead

        // Get all visible rows in the table
        var rows = driver.FindElements(By.CssSelector("tbody tr"));

        // Verify that each row contains the filter value in the "Bean Type" column
        foreach (var row in rows)
        {
            var beanTypeCell = row.FindElement(By.CssSelector("td:nth-child(3)")); // 3rd column: Bean Type
            Assert.IsTrue(beanTypeCell.Text.Contains(filterValue, StringComparison.OrdinalIgnoreCase),
                $"Row does not match filter. Expected: {filterValue}, Found: {beanTypeCell.Text}");
        }
    }

    [TestMethod]
    public void TestSortByRoasting()
    {
        // Open the frontend
        driver.Navigate().GoToUrl(frontendUrl);

        // Wait for the page to load
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        // Find the sorting dropdown
        var sortDropdown = driver.FindElement(By.CssSelector("select[class='form-select']"));

        // Select "Sort by Roasting: Low to High"
        const string lowToHighOption = "asc"; // Value for "Low to High"
        sortDropdown.SendKeys(lowToHighOption);

        // Wait a short time to allow the frontend to update
        Thread.Sleep(500); // Avoid this in production; use WebDriverWait instead

        // Get all visible rows in the table
        var rows = driver.FindElements(By.CssSelector("tbody tr"));

        // Extract the roasting values from the rows
        var roastingValues = new List<int>();
        foreach (var row in rows)
        {
            var roastingCell = row.FindElement(By.CssSelector("td:nth-child(4)")); // 4th column: Roasting
            roastingValues.Add(int.Parse(roastingCell.Text));
        }

        // Verify the roasting values are sorted in ascending order
        var sortedRoastingValues = new List<int>(roastingValues);
        sortedRoastingValues.Sort();

        CollectionAssert.AreEqual(sortedRoastingValues, roastingValues,
            "Roasting values are not sorted in ascending order.");
    }
}
