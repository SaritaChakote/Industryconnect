using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest

{
    [Binding]
    public class AddLanguageSteps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

        }

        [When(@"I fill form using (.*) and (.*)")]
        public void WhenIFillFormUsingAnd(string p0, string p1)
        {
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("string p0");
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[string p1]")).Click();
            ////*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]
          
        }
        
        //[Then(@"added language should be displayed on my listings")]
        //public void ThenAddedLanguageShouldBeDisplayedOnMyListings(Table table)
        //{
           // ScenarioContext.Current.Pending();
        //}
    }
}
