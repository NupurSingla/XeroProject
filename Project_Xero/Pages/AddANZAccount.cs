using OpenQA.Selenium;
using Project_Xero.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using static Project_Xero.Global.Definition;

namespace Project_Xero.Pages
{
    class SignIn
    {
        #region Define SignIn Xpath

        //Find Xpath for SignUp button
        private IWebElement signInbtn => Definition.driver.FindElement(By.XPath("/html/body/div[4]/header/nav/div[2]/div/div[1]/div/div/ul/li[2]/a"));


        //Find Xpath for Email Address 
        private IWebElement email => Global.Definition.driver.FindElement(By.Id("email"));

        //Find Xpath for Password 
        private IWebElement password => Global.Definition.driver.FindElement(By.Id("password"));

        //Find Xpath for submit button
        private IWebElement join => Global.Definition.driver.FindElement(By.XPath("//*[@id='submitButton']"));

        //Find Xpath for creating new account
        private IWebElement Link => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/div[1]/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/dl/dt/a"));

        //Search for bank xpath
        private IWebElement Search => driver.FindElement(By.XPath("//input[@role='textbox']"));

        private IWebElement searchItem => driver.FindElement(By.XPath("//li[@data-recordid = '90']"));

        //Find Xpath  for Account Name
        private IWebElement AccountName => driver.FindElement(By.XPath("//*[contains(@id='accounttype')]"));
        //Find Xpath for Account number
        private IWebElement AccountType => driver.FindElement(By.XPath("//*[@id='accounttype-1219-trigger-picker']"));
        private IWebElement SelectAccountType => driver.FindElement(By.XPath("//*[@id='boundlist-1256-listEl']/li[2]"));
        private IWebElement cardnumber => driver.FindElement(By.XPath("//*[@id='accountnumber-1248-inputEl']"));
        private IWebElement Continue => driver.FindElement(By.XPath("//*[@id='common-button-submit-1015']"));

        private IWebElement Verification => driver.FindElement(By.XPath("//*[@id='bankaccounts-root']/div/main/header/h1/span"));

        #endregion


        public void AddAccount()
        {
            //Populate Excel Sheet
            Global.Definition.ExcelOperations.PopulateInCollection(Global.Definition.ReadJson().ExcelPath, "SignIn");
            Thread.Sleep(500);

            //Enter URL
            Definition.driver.Navigate().GoToUrl(Definition.ExcelOperations.ReadData(1, "URL"));
            Thread.Sleep(500);

            //Click on SignUp Button
            //signInbtn.Click();
            Thread.Sleep(500);



            //Enter Email Address
            email.Clear();
            email.SendKeys(Definition.ExcelOperations.ReadData(1, "Email"));
            Thread.Sleep(500);

            //Enter Password

            password.SendKeys(Definition.ExcelOperations.ReadData(1, "Password"));
            Thread.Sleep(500);



            //Click on submit button
            join.Click();
            Thread.Sleep(500);

            //Click on link for creating ANZ account
            Link.Click();
            Thread.Sleep(1000);

            //Search for ANZ bank 
            Search.SendKeys("ANZ");
            Thread.Sleep(200);

            //Click on the ANZ option
            searchItem.Click();

            //Enter Account Name
            AccountName.SendKeys("William Jack");

            //Select Account Type -> first open the drop down and select the option
            AccountType.Click();
            SelectAccountType.Click();

            //Enter Account Number
            cardnumber.SendKeys("4356384752894");

            //Click Continue to Exit
            Continue.Click();

            //Capture ScreenShot
            SaveScreenShotClass.SaveScreenshot(Definition.driver, "Home Page");
            Thread.Sleep(2000);

            //Verification Code

            string Expected_Message = Verification.Text;
             string Actual_Message = "Let your bank send transactions to Xero";


             try
             {

                 if (Expected_Message == Actual_Message)
                 {
                     Console.WriteLine("Thank you for creating account at Xero");
                     //Capture ScreenShot
                     SaveScreenShotClass.SaveScreenshot(Definition.driver, "Account Created Successfully");
                     Thread.Sleep(1000);
                 }
             }
             catch (Exception ex)
             {

                 Console.WriteLine(ex.Message);
             }
         

        }


    }
}
