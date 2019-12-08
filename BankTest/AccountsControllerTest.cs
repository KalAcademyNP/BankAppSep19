using BankUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTest
{
    [TestClass]
    public class AccountsControllerTest
    {
        [TestMethod]
        public void TestIndexViewWithNoLogin()
        {
            //AAA -> Arrange, Act and Assert
            //Arrange
            var controller = new AccountsController();

            //Act
            Assert.ThrowsException<NullReferenceException>(
                () => controller.Index());
        }

        [TestMethod]
        public void TestIndexViewWithEmptyLogin()
        {
            //AAA -> Arrange, Act and Assert
            //Arrange
            var controller = new AccountsController();
            controller.Username = string.Empty;

            //Act
            Assert.ThrowsException<ArgumentNullException>(
                () => controller.Index());
        }

    }
}
