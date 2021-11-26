using Moq;
using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Abstractions;
using UnitTestExample.Controllers;
using UnitTestExample.Entities;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            var validation = ac.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult, validation);
        }

        [
            Test,
            TestCase("aBcdefgh", false),
            TestCase("ABCDE345", false),
            TestCase("abcd1234", false),
            TestCase("abCd123", false),
            TestCase("Abcd1234", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            var validation = ac.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, validation);
        }

        [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            ac.AccountManager = accountServiceMock.Object;

            //Act
            var validation = ac.Register(email, password);

            //Assert
            Assert.AreEqual(validation.Email, email);
            Assert.AreEqual(validation.Password, password);
            Assert.AreNotEqual(Guid.Empty, validation.ID);
            accountServiceMock.Verify(m => m.CreateAccount(validation), Times.Once);
        }

        [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234")
        ]  
        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Throws<ApplicationException>();
            ac.AccountManager = accountServiceMock.Object;

            //Act
            try
            {
                var actualResult = ac.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }
    }
}