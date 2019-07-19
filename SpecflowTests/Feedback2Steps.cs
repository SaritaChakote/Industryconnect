using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class Feedback2Steps
    {
        //Scenario 1
        [Given(@"i am on Language tab")]
        public void GivenIAmOnLanguageTab()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(1500);
        }

        [Given(@"added Marathi language with Basic lavel")]
        public void GivenAddedMarathiLanguageWithBasicLavel()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Marathi");
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).SendKeys("Basic");
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [When(@"i am adding Marathi language again with Fluent")]
        public void WhenIAmAddingMarathiLanguageAgainWithFluent()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            Thread.Sleep(1500);
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Marathi");
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).SendKeys("Fluent");
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"it should show the message ""(.*)""")]
        public void ThenItShouldShowTheMessage(string p0)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "This language is already exist in your language list";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        //Scenario 2
        [Given(@"language is available in list")]
        public void GivenLanguageIsAvailableInList()
        {
            string lang = Driver.driver.FindElement(By.XPath("//td[text()='Marathi']")).Text;
        }

        [When(@"I try to edit and update language")]
        public void WhenITryToEditAndUpdateLanguage()
        {
            string beforeXpath = "//th[text()='Language']//ancestor::thead//following-sibling::tbody";
            IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath(beforeXpath + "//tr//td[1]"));

            for (int i = 1; i <= Languages.Count; i++)
            {
                if (Languages[i - 1].Text.Equals("Marathi"))
                {
                    Driver.driver.FindElement(By.XPath(beforeXpath + "[" + i + "]//i[@class='outline write icon']")).Click();
                    //Driver.driver.FindElement(By.XPath("//select[@name='level']")).Clear();
                    Driver.driver.FindElement(By.XPath("//select[@name='level']")).SendKeys("Basic");
                    Driver.driver.FindElement(By.XPath("//input[@type='button' and @value='Update']")).Click();
                }
            }
        }

        [Then(@"the language should get updated successfully")]
        public void ThenTheLanguageShouldGetUpdatedSuccessfully()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Marathi has been updated to your languages";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        //Scenario 3
        [When(@"(.*) languages were already added")]
        public void WhenLanguagesWereAlreadyAdded(int p0)
        {
            IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody"));
            int count = Languages.Count();
            if (count == 4)
            {
                Console.WriteLine("4 languages were added already");
            }
        }

        [Then(@"""(.*)"" button should get invisible")]
        public void ThenButtonShouldGetInvisible(string p0)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add maximum 4 languages");
                Thread.Sleep(1000);

                IWebElement AddNewBtn = Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']"));
                if (AddNewBtn.Displayed)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed in else, Maximum is four languages");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "maximum 4 Languages added");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


        //Scenario 4

        [Given(@"i am on skills tab")]
        public void GivenIAmOnSkillsTab()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(1500);

            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//a[text()='Skills']")).Click();

        }

        [Given(@"'(.*)' is already added with '(.*)' level")]
        public void GivenIsAlreadyAddedWithLevel(string p0, string p1)
        {
            //Click on Add New skill button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[@class='ui teal button']")).Click();
            Thread.Sleep(1500);

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@type='text' and @name='name']")).SendKeys("C");

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@name='level' and @class='ui fluid dropdown']")).SendKeys("Basic");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add' and @type='button']")).Click();

        }

        [When(@"i try to add '(.*)' with '(.*)' level again")]
        public void WhenITryToAddWithLevelAgain(string p0, string p1)
        {
            //Click on Add New skill button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[@class='ui teal button']")).Click();
            Thread.Sleep(1500);
            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@type='text' and @name='name']")).SendKeys("C");

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@name='level' and @class='ui fluid dropdown']")).SendKeys("Basic");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add' and @type='button']")).Click();

        }

        [Then(@"it should trough some message")]
        public void ThenItShouldTroughSomeMessage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "This skill is already exist in your skill list";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Duplicate skill didn't get added Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill not Updated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }


       

        

        

        
       

        

    }
}   

