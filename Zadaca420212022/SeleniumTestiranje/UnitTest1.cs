using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTestiranje
{

    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        [ClassInitialize]
        public static void Inicijalizacija(TestContext context)
        {
            driver = new ChromeDriver();
            string urlStranice = "https://localhost:44389/Grupa3/Create";
            driver.Navigate().GoToUrl(urlStranice);
        }


        static DateTime datumOK1 = DateTime.Now.AddYears(-10);
        static string formatDatumOK1 = datumOK1.Day + "-" + datumOK1.Month + "-" + datumOK1.Year;
        static DateTime datumOK2 = DateTime.Now.AddDays(-5);
        static string formatDatumOK2 = datumOK2.Day + "-" + datumOK2.Month + "-" + datumOK2.Year;

        static IEnumerable<object[]> slucajT1
        {
            get
            {
                return new[]
                {
                    new object[] {"Another love", "9" ,formatDatumOK1 },
                    new object[] {"Save your tears", "6" ,formatDatumOK1 },
                    new object[] {"Sandstorm", "10" ,formatDatumOK2 },
                    new object[] {"Venom", "1" ,formatDatumOK2 }
                };
            }
        }

        static IEnumerable<object[]> slucajT2
        {
            get
            {
                return new[]
                {
                    new object[] { "Tom Odell", "Another love", "9", formatDatumOK1 },
                    new object[] { "The Weeknd", "Save your tears", "6", formatDatumOK1 },
                    new object[] { "Darude", "Sandstorm", "10", formatDatumOK2 },
                    new object[] { "Eminem", "Venom", "1", formatDatumOK2 }
                };
            }
        }

        static IEnumerable<object[]> slucajT3
        {
            get
            {
                return new[]
                {
                    new object[] { "Elvis Presley, Godište: 1935", "Viva Las Vegas", "9", formatDatumOK1 },
                    new object[] { "Elvis Presley, Godište: 1935", "Hound Dog", "6", formatDatumOK1 },
                    new object[] { "Elvis Presley, Godište: 1935", "Jailhouse Rock", "10", formatDatumOK2 },
                    new object[] { "Elvis Presley, Godište: 1935", "Can't Help Falling in Love", "1", formatDatumOK2 }
                };
            }
        }

        static IEnumerable<object[]> slucajT4
        {
            get
            {
                return new[]
                {
                    new object[] { "Elvis Presley, Godište: 1935", "Just Pretend", "9", formatDatumOK1 },
                    new object[] { "The Weeknd, Godište: 1990", "Save your tears", "6", formatDatumOK1 },
                    new object[] { "Darude, Godište: 1975", "Sandstorm", "10", formatDatumOK2 },
                    new object[] { "Eminem, Godište: 1972", "Venom", "1", formatDatumOK2 }
                };
            }
        }

        [TestMethod]
        [DynamicData("slucajT1")]
        public void Test1_E1(string imePjesme, string rating, string datum)
        {
            string urlStranice = "https://localhost:44389/Grupa3/Create";
            driver.Navigate().GoToUrl(urlStranice);


            // unos pjesme
            IWebElement nazivPjesme = driver.FindElement(By.Id("naziv"));
            nazivPjesme.SendKeys(imePjesme);
            Thread.Sleep(100);

            // unos datuma pjesme
            string[] dijelovi = datum.Split("-");
            IWebElement dateTimeObjavljivanje = driver.FindElement(By.Id("DatumObjavljivanja"));
            dateTimeObjavljivanje.SendKeys(dijelovi[0]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[1]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(Keys.Tab);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[2]);
            Thread.Sleep(100);

            // unos ratinga pjesme
            IWebElement ratingPjesme = driver.FindElement(By.Id("Rating"));
            ratingPjesme.SendKeys(rating);
            Thread.Sleep(100);

            // klik na dugme Provjeri
            IWebElement buttonProvjeri = driver.FindElement(By.XPath("//button[.='Provjeri']"));
            buttonProvjeri.Click();
            Thread.Sleep(100);

            // citanje alerta i uporedjivanje sa ocekivanom porukom
            var alert_win = driver.SwitchTo().Alert();
            Thread.Sleep(100);
            String citanjeAlerta = alert_win.Text;
            alert_win.Accept();
            Thread.Sleep(100);
            String alertPoruka = "Niste unijeli izvođača - analiza ne može biti izvršena!";
            Assert.AreEqual(alertPoruka, citanjeAlerta);
        }

        [TestMethod]
        [DynamicData("slucajT2")]
        public void Test2_E2(string nazivIzvodjaca, string imePjesme, string rating, string datum)
        {
            string urlStranice = "https://localhost:44389/Grupa3/Create";
            driver.Navigate().GoToUrl(urlStranice);

            // unos izvodjaca
            IWebElement izvodjac = driver.FindElement(By.Id("izvođač"));
            izvodjac.SendKeys(nazivIzvodjaca);
            Thread.Sleep(100);

            // unos pjesme
            IWebElement nazivPjesme = driver.FindElement(By.Id("naziv"));
            nazivPjesme.SendKeys(imePjesme);
            Thread.Sleep(100);

            // unos datuma pjesme
            string[] dijelovi = datum.Split("-");
            IWebElement dateTimeObjavljivanje = driver.FindElement(By.Id("DatumObjavljivanja"));
            dateTimeObjavljivanje.SendKeys(dijelovi[0]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[1]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(Keys.Tab);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[2]);
            Thread.Sleep(100);

            // unos ratinga pjesme
            IWebElement ratingPjesme = driver.FindElement(By.Id("Rating"));
            ratingPjesme.SendKeys(rating);
            Thread.Sleep(100);

            // klik na dugme Provjeri
            IWebElement buttonProvjeri = driver.FindElement(By.XPath("//button[.='Provjeri']"));
            buttonProvjeri.Click();
            Thread.Sleep(100);

            // citanje alerta i uporedjivanje sa ocekivanom porukom
            var alert_win = driver.SwitchTo().Alert();
            Thread.Sleep(100);
            String citanjeAlerta = alert_win.Text;
            alert_win.Accept();
            Thread.Sleep(100);
            String alertPoruka = "Morate unijeti godište izvođača!";
            Assert.AreEqual(alertPoruka, citanjeAlerta);

        }

        [TestMethod]
        [DynamicData("slucajT3")]
        public void Test3_E3(string nazivIzvodjaca, string imePjesme, string rating, string datum)
        {
            string urlStranice = "https://localhost:44389/Grupa3/Create";
            driver.Navigate().GoToUrl(urlStranice);

            // unos izvodjaca
            IWebElement izvodjac = driver.FindElement(By.Id("izvođač"));
            izvodjac.SendKeys(nazivIzvodjaca);
            Thread.Sleep(100);

            // unos pjesme
            IWebElement nazivPjesme = driver.FindElement(By.Id("naziv"));
            nazivPjesme.SendKeys(imePjesme);
            Thread.Sleep(100);

            // unos datuma pjesme
            string[] dijelovi = datum.Split("-");
            IWebElement dateTimeObjavljivanje = driver.FindElement(By.Id("DatumObjavljivanja"));
            dateTimeObjavljivanje.SendKeys(dijelovi[0]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[1]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(Keys.Tab);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[2]);
            Thread.Sleep(100);

            // unos ratinga pjesme
            IWebElement ratingPjesme = driver.FindElement(By.Id("Rating"));
            ratingPjesme.SendKeys(rating);
            Thread.Sleep(100);

            // klik na dugme Provjeri
            IWebElement buttonProvjeri = driver.FindElement(By.XPath("//button[.='Provjeri']"));
            buttonProvjeri.Click();
            Thread.Sleep(100);

            // citanje alerta i uporedjivanje sa ocekivanom porukom
            var alert_win = driver.SwitchTo().Alert();
            Thread.Sleep(100);
            String citanjeAlerta = alert_win.Text;
            alert_win.Accept();
            Thread.Sleep(100);
            String alertPoruka = "Za izvođača Elvisa Presleya podržana je samo pjesma 'Just Pretend'!";
            Assert.AreEqual(alertPoruka, citanjeAlerta);

        }

        [TestMethod]
        [DynamicData("slucajT4")]
        public void Test4_E4(string nazivIzvodjaca, string imePjesme, string rating, string datum)
        {
            string urlStranice = "https://localhost:44389/Grupa3/Create";
            driver.Navigate().GoToUrl(urlStranice);

            // unos izvodjaca
            IWebElement izvodjac = driver.FindElement(By.Id("izvođač"));
            izvodjac.SendKeys(nazivIzvodjaca);
            Thread.Sleep(100);

            // unos pjesme
            IWebElement nazivPjesme = driver.FindElement(By.Id("naziv"));
            nazivPjesme.SendKeys(imePjesme);
            Thread.Sleep(100);

            // unos datuma pjesme
            string[] dijelovi = datum.Split("-");
            IWebElement dateTimeObjavljivanje = driver.FindElement(By.Id("DatumObjavljivanja"));
            dateTimeObjavljivanje.SendKeys(dijelovi[0]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[1]);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(Keys.Tab);
            Thread.Sleep(100);
            dateTimeObjavljivanje.SendKeys(dijelovi[2]);
            Thread.Sleep(100);

            // unos ratinga pjesme
            IWebElement ratingPjesme = driver.FindElement(By.Id("Rating"));
            ratingPjesme.SendKeys(rating);
            Thread.Sleep(100);

            // klik na dugme Provjeri
            IWebElement buttonProvjeri = driver.FindElement(By.XPath("//button[.='Provjeri']"));
            buttonProvjeri.Click();
            Thread.Sleep(100);

            // citanje alerta i uporedjivanje sa ocekivanom porukom
            var alert_win = driver.SwitchTo().Alert();
            Thread.Sleep(100);
            String citanjeAlerta = alert_win.Text;
            alert_win.Accept();
            Thread.Sleep(100);
            String alertPoruka = "Unesene informacije o izvođaču zadovoljavaju standarde!";
            Assert.AreEqual(alertPoruka, citanjeAlerta);
        }
    }
}
