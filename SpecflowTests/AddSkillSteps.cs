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
    public class AddSkillSteps
    {
        [Given(@"I clicked on the Skills tab under the Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(1500);

            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//a[text()='Skills']")).Click();

            //Click on Add New skill button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[@class='ui teal button']")).Click();
        }

        [Given(@"i am on skill tab and ""(.*)"" is available")]
        public void GivenIAmOnSkillTabAndIsAvailable(string skill)
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(1500);

            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//a[text()='Skills']")).Click();
        }

        [When(@"Fill Form using ""(.*)"" and ""(.*)""")]
        public void WhenFillFormUsingAnd(string skill, string level)
        {

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@type='text' and @name='name']")).SendKeys(skill);

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@name='level' and @class='ui fluid dropdown']")).SendKeys(level);

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add' and @type='button']")).Click();

        }

        [When(@"i edit skill and update using ""(.*)"" or ""(.*)""")]
        public void WhenIEditSkillAndUpdateUsingOr(string skill, string level)
        {
            string beforeXpath = "//th[text()='Skills']//ancestor::thead//following-sibling::tbody";
            IList<IWebElement> Skills = Driver.driver.FindElements(By.XPath(beforeXpath + "//tr//td[1]"));

            //checking skill list for C++ or C and Updating it
            for (int i = 1; i <= Skills.Count; i++)
            {
                if (Skills[i - 1].Text.Equals("C++") || Skills[i - 1].Text.Equals("C"))
                {
                    Driver.driver.FindElement(By.XPath(beforeXpath + "[" + i + "]//i[@class='outline write icon']")).Click();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("skill");
                    Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Update')]")).Click();
                }
            }
        }


        [When(@"i user delete ""(.*)""")]
        public void WhenIUserDelete(string skill)
        {
            string beforeXpath = "//th[text()='Skills']//ancestor::thead//following-sibling::tbody[";
            string SkillXpath = "]//tr//td";
            string removeXpath = "]//i[@class='remove icon']";

            //check the list for C skill and click remove
            IList<IWebElement> Skills = Driver.driver.FindElements(By.XPath("//th[text()='Skills']//ancestor::thead//following-sibling::tbody//tr"));
            int count = Skills.Count();

            if (Skills.Count() > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    if (Driver.driver.FindElement(By.XPath(beforeXpath + i + SkillXpath)).Text == "C")
                        Driver.driver.FindElement(By.XPath(beforeXpath + i + removeXpath)).Click();
                }
            }
            else
                Console.WriteLine("There are no skills to delete");
        }


        [Then(@"added Skill should be displayed on my listings")]
        public void ThenAddedSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "skill";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Added");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [Then(@"updated skill should get displayed on my skill list")]
        public void ThenUpdatedSkillShouldGetDisplayedOnMySkillList()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "C has been updated to your skills";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, updated a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill updated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [Then(@"skill should get deleted from my skill list")]
        public void ThenSkillShouldGetDeletedFromMySkillList()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "C has been deleted";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Deleted");
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