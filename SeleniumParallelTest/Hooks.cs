﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;

namespace SeleniumParallelTest
{
    //Enum for browserType
    public enum BrowerType
    {
        Chrome,
        Firefox,
        IE
    }


    //Fixture for class
    [TestFixture]
    public class Hooks : Base
    {
        private BrowerType _browserType;


        //public Hooks(BrowerType browser)
        //{
        //    _browserType = browser;
        //}


        [SetUp]
        public void InitializeTest()
        {
            var browser = TestContext.Parameters.Get("Browser");
            System.Console.WriteLine("The browser is " + browser);


            ChooseDriverInstance(_browserType);
        }

        private void ChooseDriverInstance(BrowerType browserType)
        {
            //var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);

            if (browserType == BrowerType.Chrome)
                Driver = new ChromeDriver();
            else if (browserType == BrowerType.Firefox)
            {
                //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                //service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                //service.HideCommandPromptWindow = true;
                //service.SuppressInitialDiagnosticInformation = true;
                //Driver = new FirefoxDriver(service);
                Driver = new ChromeDriver();
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }


    }
}
