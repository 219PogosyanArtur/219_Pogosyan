using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _219_Pogosyan.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new Page1();
            Assert.IsTrue(page.Auth("test", "test"));
            Assert.IsFalse(page.Auth("user1", "12345"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
        }
    }
}
