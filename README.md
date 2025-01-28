# BootcampSelenium

BootcampSelenium is a repository for Selenium-based automation tests written in C#. This project is designed to help you get started with automated testing using Selenium WebDriver and C#.

## Repository Overview

The repository contains several test files that demonstrate various Selenium WebDriver functionalities and best practices. Below is a detailed overview of each file:

### Files in the Repository

- **FrontendTest.cs**
- **MostUsedExamples.cs**
- **OpenSearchEngineTest.cs**

## Detailed File Descriptions

### FrontendTest.cs

This file contains tests for a frontend application. It includes methods to filter and sort data displayed on the frontend.

- **TestFilterByBeanType**: This test method filters rows in a table by the "Bean Type" column. It enters the filter value "Arabica" and verifies that each visible row contains the filter value.
- **TestSortByRoasting**: This test method sorts the table by the "Roasting" column in ascending order and verifies the sorting.

For more details, you can view the file [here](https://github.com/Cal-ly/BootcampSelenium/blob/main/BootcampTests/FrontendTest.cs).

### MostUsedExamples.cs

This file contains the most common Selenium C# statements with explanations as comments. It serves as a reference for various Selenium WebDriver functionalities, such as:

- Initializing the WebDriver
- Navigating to a URL
- Finding elements
- Sending text to input fields
- Clicking elements
- Submitting forms
- Waiting for elements
- Handling alerts, frames, cookies, etc.

For more details, you can view the file [here](https://github.com/Cal-ly/BootcampSelenium/blob/main/BootcampTests/MostUsedExamples.cs).

### OpenSearchEngineTest.cs

This file demonstrates how to open a browser, navigate to DuckDuckGo, wait for the search box to be visible, enter a search query, and submit the search form.

- **OpenDuckDuckGoTest_ShouldOpenBrowser_AddText**: This test method navigates to DuckDuckGo's homepage, maximizes the browser window, waits for the search box to be visible, enters the text "Selenium C# tutorial", and submits the search form.

For more details, you can view the file [here](https://github.com/Cal-ly/BootcampSelenium/blob/main/BootcampTests/OpenSearchEngineTest.cs).
