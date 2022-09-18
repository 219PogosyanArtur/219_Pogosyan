using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _219_Pogosyan.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new Page1();
            Assert.IsTrue(page.Auth("yyt6676aah", "yuuys322"));
        }
    }
}
