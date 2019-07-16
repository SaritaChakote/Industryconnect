using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddEducationAndCertificationsSteps
    {
        [Given(@"I clicked on the Education tab on profile page")]
        public void GivenIClickedOnTheEducationTabOnProfilePage()
        {
            // Click on profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(3000);

            //Click on Education tab
            Driver.driver.FindElement(By.XPath("//a[@class='item' and text()='Education']")).Click();

        }

        [Given(@"I clicked on the Certification tab on profile page")]
        public void GivenIClickedOnTheCertificationTabOnProfilePage()
        {
            //Click on Certification
            Driver.driver.FindElement(By.XPath("//a[@class='item' and text()='Certifications']")).Click();

        }

        [When(@"I add a new Education")]
        public void WhenIAddANewEducation()
        {
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[6]//div[@class='ui teal button ']")).Click();
            // fill the add new form for education
            Driver.driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys("Monash University");
            
            //Click on Country
            Driver.driver.FindElement(By.XPath("//select[@name='country']")).SendKeys("I");

            Driver.driver.FindElement(By.XPath("//select[@name='title']")).SendKeys("B.Tech");
           
            Driver.driver.FindElement(By.XPath("//input[@name='degree']")).SendKeys("Engineer");
            Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")).SendKeys("2010");
            Driver.driver.FindElement(By.XPath("//input[@value='Add' and @type='button']")).Click();

        }

        [When(@"I add a new Certification")]
        public void WhenIAddANewCertification()
        {
            //add new button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[4]//div[@class='ui teal button ']")).Click();
            Driver.driver.FindElement(By.XPath("//input[@name='certificationName']")).SendKeys("ISTQB");
            Driver.driver.FindElement(By.XPath("//input[@name='certificationFrom']")).SendKeys("Testing");
            Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")).SendKeys("2010");
            Driver.driver.FindElement(By.XPath("//input[@value='Add' and @type='button']")).Click();

        }

        [Then(@"It should be displayed under Education on my profile")]
        public void ThenItShouldBeDisplayedUnderEducationOnMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education");

                Thread.Sleep(1000);
                string ExpectedValue = "Monash";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Added");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        
        [Then(@"It should be displayed under Certification on my profile")]
        public void ThenItShouldBeDisplayedUnderCertificationOnMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "ISTQB";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certification Added");
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

