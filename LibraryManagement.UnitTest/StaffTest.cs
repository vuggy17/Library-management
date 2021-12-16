
using LibraryManagement.model;
using NUnit.Framework;
using LibraryManagement.controller;
using LibraryManagement.db;
using Moq;

namespace LibraryManagement.UnitTest
{
    [TestFixture]
    public class StaffTest
    {

        [TestCase("invalidpassword", "7letter", "7letter", "INVALID_PASS")]
        [TestCase("validpassword", "newvalidpassword", "notmatchpassword", "NOT_MATCH")]
        [TestCase("fakepassword", "newvalidpassword", "newvalidpassword", "WRONG_PASS")]
        public void changePassWord_InvalidValue_ThrowException(string password, string newpassowrd, string confirmPassword, string expectedErrorMessage)
        {
            Mock<IDatabase> mockDatabase;
            mockDatabase = new Mock<IDatabase>(MockBehavior.Strict);
            var mockUserService = new MockDbService()
            .MockUpdatePassword("12321", password, output: false);

            Staff staff = new Staff(mockUserService.Object);
            staff.password = PasswordHash.CreateHash("validpassword");

            var ex = Assert.Throws<System.Exception>(() => staff.changePassWord1(password, newpassowrd, confirmPassword));
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }

        [TestCase("validpassword", "newvalidpassword", "newvalidpassword")]
        public void changePassWord_ValidValue_NotThrowException(string password, string newpassowrd, string confirmPassword)
        {
            Mock<IDatabase> mockDatabase;
            mockDatabase = new Mock<IDatabase>(MockBehavior.Strict);
            var mockUserService = new MockDbService()
            .MockUpdatePassword("12321", password, output: false);

            Staff staff = new Staff(mockUserService.Object);
            staff.password = PasswordHash.CreateHash("validpassword");

            Assert.DoesNotThrow(() => staff.changePassWord1(password, newpassowrd, confirmPassword));
        }

        // TEST UPDATE STAFF INFORMATION
        [TestCase("", "", "", "", "", "", "BAD_INPUT")]
        [TestCase("123456789", "Pham Minh Tam", "HCM, Q9", "0343027600", "", "", "BAD_INPUT")]
        [TestCase("123456789", "Pham Minh Tam", "HCM, Q9", "", "tanpm@gmail.com", "", "BAD_INPUT")]

        public void updateStaffInfo1_InvalidInput_ThrowException(string id, string name, string address, string phone, string mail, string imagename, string expectedErrorMessage)
        {
            var mockUserService = new MockDbService()
            .MockUpdateInfo(new Person(name, address, mail, phone));

            Staff staff = new Staff(mockUserService.Object);

            //bad input is empty input
            var ex = Assert.Throws<System.Exception>(() => staff.updateInfo1(id, name, address, phone, mail, imagename));
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));

        }

        [TestCase("123456789", "Tan@@!!", "HCM, Q9", "0343027600", "tanpm@gmail.com", "", false)]
        [TestCase("123456789", "Tan 1234", "HCM, Q9", "0343027600", "tanpm@gmail.com", "", false)]
        public void updateStaffInfo1_NameInvalid_ReturnFalse(string id, string name, string address, string phone, string mail, string imagename, bool expectedReturnValue)
        {
            var mockUserService = new MockDbService()
            .MockUpdateInfo(new Person(name, address, mail, phone));

            Staff staff = new Staff(mockUserService.Object);

            var ex = staff.updateInfo1(id, name, address, phone, mail, imagename);
            Assert.That(ex, Is.EqualTo(expectedReturnValue));

        }

        [TestCase("123456789", "Pham Minh Tam", "HCM, Q9", "343027600", "tan1234", "", false)]

        public void updateStaffInfo_MailWrongFormat_ReturnFalse(string id, string name, string address, string phone, string mail, string imagename, bool expectedReturnValue)
        {
            Mock<IDatabase> mockDatabase;
            mockDatabase = new Mock<IDatabase>(MockBehavior.Strict);
            var mockUserService = new MockDbService()
            .MockUpdateInfo(new Person(name, address, mail, phone));

            Staff staff = new Staff(mockUserService.Object);

            var ex = staff.updateInfo1(id, name, address, phone, mail, imagename);
            Assert.That(ex, Is.EqualTo(expectedReturnValue));

        }

        [TestCase("123456789", "Pham Minh Tam", "HCM, Q9", "32515575622", "tanpm@gmail.com", "", false)]
        public void updateStaffInfo1_PhoneWrongFormat_ReturnFalse(string id, string name, string address, string phone, string mail, string imagename, bool expectedReturnValue)
        {
            Mock<IDatabase> mockDatabase;
            mockDatabase = new Mock<IDatabase>(MockBehavior.Strict);
            var mockUserService = new MockDbService()
            .MockUpdateInfo(new Person(name, address, mail, phone));

            Staff staff = new Staff(mockUserService.Object);

            var ex = staff.updateInfo1(id, name, address, phone, mail, imagename);
            Assert.That(ex, Is.EqualTo(expectedReturnValue));

        }
        [TestCase("123456789", "Pham Minh Tam", "HCM, Q9", "0343027600", "tanpm@gmail.com", "", true)]
        public void updateStaffInfo1_ValidValue_ReturnTrue(string id, string name, string address, string phone, string mail, string imagename, bool expectedReturnValue)
        {
            
            var mockUserService = new MockDbService()
            .MockUpdateInfo(new Person(name, address, mail, phone));

            Staff staff = new Staff(mockUserService.Object);

            var ex = staff.updateInfo1(id, name, address, phone, mail, imagename);

            Assert.That(ex, Is.EqualTo(expectedReturnValue));

        }

        // TEST ISVALIDEMAIL
        [TestCase("tester@gmail.com")]
        public void isValidEmail_ValidValue_ReturnTrue(string email)
        {
            Staff staff = new Staff();
            var ex = staff.isValidEmail(email);
            Assert.IsTrue(ex);
        }
        [TestCase("google@@gmail.com")]
        [TestCase("example.gmail.@com")]
        [TestCase("@gmail.com")]
        [TestCase("..@gmail.com")]
        [TestCase("1234@gmail.com")]
        public void isValidEmail_InvalidValue_ReturnFalse(string email)
        {
            Staff staff = new Staff();
            var ex = staff.isValidEmail(email);
            Assert.IsFalse(ex);
        }

        // TEST ISVALIDNAME
        [TestCase("Vũ Đặng Khương Duy")]
        public void isValidName_ValidValue_ReturnTrue(string name)
        {
            Staff staff = new Staff();
            var ex = staff.isValidName(name);
            Assert.IsTrue(ex);
        }
        [TestCase("Pham Minh Tan1")]
        [TestCase("@Pham Minh Tan")]
        [TestCase("BuiDuongDuyKhang")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long name")]
        public void isValidName_InvalidValue1_ReturnFalse(string name)
        {
            Staff staff = new Staff();
            var ex = staff.isValidEmail(name);
            Assert.IsFalse(ex);
        }

        //TEST ISVIETNAMESEPHONENUMBER
        [TestCase("0323456789")]
        public void isVietNamesePhoneNumber_ValidValue_ReturnTrue(string phonenumber)
        {
            Staff staff = new Staff();
            var ex = staff.isVietnamesePhoneNumber(phonenumber);
            Assert.IsTrue(ex);
        }
        [TestCase("Pham Minh Tan1")]
        [TestCase("03232@231")]
        [TestCase("032032030103201301032103021032103210320302103210321023023103219213973829768943678567386578678943619734")]
        [TestCase("")]
        [TestCase(".")]
        public void isVietNamesePhoneNumber_InvalidValue_ReturnFalse(string phonenumber)
        {
            Staff staff = new Staff();
            var ex = staff.isVietnamesePhoneNumber(phonenumber);
            Assert.IsFalse(ex);
        }
    }
}