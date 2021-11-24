using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

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
    }
}