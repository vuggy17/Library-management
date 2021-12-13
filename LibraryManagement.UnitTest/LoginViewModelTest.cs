using LibraryManagement.db;
using LibraryManagement.model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.viewmodel.Login;

namespace LibraryManagement.UnitTest
{
    [TestFixture]
    class LoginViewModelTest
    {
        [TestCase("19521110", "123456789", true)]
        public void login_ValidValue_ReturnTrue(string username, string password, bool result)
        {
            var pw = new Until.UntilService().createHash("123456789");
            List<Staff> staffList = new List<Staff>();
            staffList.Add(new Staff(new Person(), "19521110", pw));

            var mockUserService = new MockDbService().MockGetStaff(staffList);
            var vm = new LoginViewModel(mockUserService.Object, new Until.UntilService());

            var ex = vm.login(username, password);

            Assert.That(ex, Is.EqualTo(result));
            mockUserService.VerifyAll();
        }

        [TestCase("19521110", "", "Please enter password")]
        [TestCase("19521110", "password", "Credential not found")]
        [TestCase("", "123456789", "Please enter username")]
        [TestCase("", "password", "Please enter username")]
        [TestCase("somebody", "123456789", "Credential not found")]
        [TestCase("somebody", "", "Please enter password")]
        [TestCase("somebody", "password", "Credential not found")]
        public void login_InvalidValue_ThrowException(string username, string password, string result)
        {
            var pw = new Until.UntilService().createHash("123456789");
            List<Staff> staffList = new List<Staff>();
            staffList.Add(new Staff(new Person(), "19521110", pw));
            var mockUserService = new MockDbService().MockGetStaff(staffList);
            var vm = new LoginViewModel(mockUserService.Object, new Until.UntilService());

            var ex = Assert.Throws<System.Exception>(() => vm.login(username, password));

            Assert.That(ex.Message, Is.EqualTo(result));
            mockUserService.VerifyAll();
        }
    }
}
