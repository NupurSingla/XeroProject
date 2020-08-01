using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Project_Xero.Global;
using Project_Xero.Pages;

namespace Project_Xero.Test
{
    [TestFixture]
    class Program
    {
        
        [Test]
        public void  XeroUser()
        {
            using (Definition.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {

                Definition.driver.Manage().Window.Maximize();
                AddANZAccount AddANZUser = new AddANZAccount();
                AddANZUser.AddAccount();


                
            }
        }
 
            
     
    }
}