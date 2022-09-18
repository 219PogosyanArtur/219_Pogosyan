using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _219_Pogosyan;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void RegistrationTestSuccess()
        {
            var page = new Registration();
            Assert.IsTrue(page.Auth("yyt6676aah", "yuuys322", "yuuys322", "Ученик", " "));
        }
    }
}
