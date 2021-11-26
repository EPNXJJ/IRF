using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Act
            var validation = ac.Register(email, password);

            //Assert
            Assert.AreEqual(validation.Email, email);
            Assert.AreEqual(validation.Password, password);
            Assert.AreNotEqual(Guid.Empty, validation.ID);
        }

        [
            Test,
            TestCase("irf@uni-corvinus", "Abcd1234"),
            TestCase("irf.uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABCD1234"),
            TestCase("irf@uni-corvinus.hu", "abcdABCD"),
            TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]  
        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();

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