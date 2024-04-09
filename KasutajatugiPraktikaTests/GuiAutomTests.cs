using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = Xunit.Assert;


namespace KasutajatugiPraktikaTests
{
    public class GuiAutomTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Set up the WebDriver (ChromeDriver)
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestTicketCreationSolving()
        {
            //values we will input to fields
            string testDescription = "Test ticket description";
            string testDeadline = DateTime.Now.AddDays(1).ToString("M/d/yyyy");

            driver.Navigate().GoToUrl("http://localhost:5035");

            // click "Lisa pöördumine" 
            IWebElement lisaPoordumineLink = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
            lisaPoordumineLink.Click();
            // fill description
            IWebElement descriptionInput = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionInput.SendKeys(testDescription);


            // fill deadline
            IWebElement deadlineInput = driver.FindElement(By.Id("Deadline"));
            deadlineInput.SendKeys(testDeadline);
            deadlineInput.SendKeys(Keys.ArrowRight);
            deadlineInput.SendKeys("0000"); //we will set the time to 00:00

            // Submit the form
            IWebElement submitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();


            IWebElement tableBody = driver.FindElement(By.CssSelector("table.table tbody"));
            // Find all rows 
            IList<IWebElement> rows = tableBody.FindElements(By.TagName("tr"));
            // Flag to indicate if the entry is found
            bool entryFound = false;

            // Loop through each row to look for the entry
            foreach (var row in rows)
            {
                // Check if the row contains inserted description, today's date and deadline
                string rowText = row.Text;
                if (rowText.Contains(testDescription) && rowText.Contains(DateTime.Now.ToString("M/d/yyyy")) &&
                    rowText.Contains(testDeadline))
                {
                    entryFound = true;
                    //if found, solve the ticket to delete it
                    IWebElement solveLink = row.FindElement(By.CssSelector("a[href*='/Home/Solve/']"));
                    solveLink.Click();
                    break;
                }
            }

            // Assert that the entry was found
            Assert.True(entryFound);

            //flag to indicate if the entry is not present
            bool entryNotPresent = true;
            tableBody = driver.FindElement(By.CssSelector("table.table tbody"));
            // Find all rows 
            rows = tableBody.FindElements(By.TagName("tr"));
            //check, that the row doesn't exist anymore
            foreach (var row in rows)
            {
                string rowText = row.Text;
                if (rowText.Contains(testDescription) && rowText.Contains(DateTime.Now.ToString("M/d/yyyy")) &&
                    rowText.Contains(testDeadline))
                {
                    entryNotPresent = false;
                    break;
                }
            }

            //Assert that the entry was not present in table
            Assert.True(entryNotPresent);
        }


        [TearDown]
        public void TearDown()
        {
            // Quit the WebDriver
            driver.Quit();
        }
    }
}