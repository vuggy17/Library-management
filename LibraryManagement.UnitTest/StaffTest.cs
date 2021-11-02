
using LibraryManagement.model;
using NUnit.Framework;
using LibraryManagement.controller;
namespace LibraryManagement.UnitTest
{
    [TestFixture]
    public class StaffTest
    {
        private Staff staff;

        [SetUp]
        public void Setup()
        {
            staff = new Staff();
            staff.password = PasswordHash.CreateHash("validpassword");
        }

        [Test]
        public void changePassWord_InvalidNewPassword_ThrowException()
        {
            var ex = Assert.Throws<System.Exception>(() => staff.changePassWord("validpassword", "7letter", "7letter"));
            Assert.That(ex.Message, Is.EqualTo("INVALID_PASS"));
        }
        [Test]
        public void changePassWord_NewpassNotMatch_ThrowException()
        {
            var ex = Assert.Throws<System.Exception>(() => staff.changePassWord("validpassword", "newvalidpassword", "notmatchpassword"));
            Assert.That(ex.Message, Is.EqualTo("NOT_MATCH"));
        }
        [Test]
        public void changePassWord_WrongOldPassword_ThrowException()
        {
            var ex = Assert.Throws<System.Exception>(() => staff.changePassWord("fakepassword", "newvalidpassword", "newvalidpassword"));
            Assert.That(ex.Message, Is.EqualTo("WRONG_PASS"));
        }
        [Test]
        public void changePassWord_ValidValue_NotThrowException()
        {
            Assert.DoesNotThrow(() => staff.changePassWord("validpassword", "newvalidpassword", "newvalidpassword"));
        }

        // TEST UPDATE STAFF INFORMATION
        [Test]
        public void updateStaffInfo_BadInput_ThrowException()
        {
            //bad input is empty input
            var ex = Assert.Throws<System.Exception>(() => staff.updateInfo("", "", "", "", "", ""));
            Assert.That(ex.Message, Is.EqualTo("BAD_INPUT"));
        }

        [Test]
        public void updateStaffInfo_MailEmpty_ThrowException()
        {
            var ex = Assert.Throws<System.Exception>(() => staff.updateInfo("123456789", "Pham Minh Tam", "HCM, Q9", "0343027600", "", ""));
            Assert.That(ex.Message, Is.EqualTo("BAD_INPUT"));

        }
        [Test]
        public void updateStaffInfo_PhoneEmpty_ReturnFalse()
        {
            var ex = Assert.Throws<System.Exception>(() => staff.updateInfo("123456789", "Pham Minh Tam", "HCM, Q9", "", "tanpm@gmail.com", ""));
            Assert.That(ex.Message, Is.EqualTo("BAD_INPUT"));
        }
        [Test]
        public void updateStaffInfo_NameContainSepecialCharacter_ReturnFalse()
        {
            // name wrong format
            var ex = staff.updateInfo("123456789", "Tan@@!!", "HCM, Q9", "0343027600", "tanpm@gmail.com", "");
            Assert.IsFalse(ex);

        }
        [Test]
        public void updateStaffInfo_NameContainNumber_ReturnFalse()
        {
            // name wrong format
            var ex = staff.updateInfo("123456789", "Tan 1234", "HCM, Q9", "0343027600", "tanpm@gmail.com", "");
            Assert.IsFalse(ex);

        }
        [Test]
        public void updateStaffInfo_MailWrongFormat_ReturnFalse()
        {
            var ex = staff.updateInfo("123456789", "Pham Minh Tam", "HCM, Q9", "343027600", "tan1234", "");
            Assert.IsFalse(ex);
        }
        [Test]
        public void updateStaffInfo_PhoneWrongFormat_ReturnFalse()
        {
            var ex = staff.updateInfo("123456789", "Pham Minh Tam", "HCM, Q9", "32515575622", "tanpm@gmail.com", "");
            Assert.IsFalse(ex);
        }
        [Test]
        public void updateStaffInfo_ValidValue_ReturnTrue()
        {
            var ex = staff.updateInfo("123456789", "Pham Minh Tam", "HCM, Q9", "0343027600", "tanpm@gmail.com", "");
            Assert.IsTrue(ex);
        }

        // TEST ISVALIDEMAIL
        [Test]
        public void isValidEmail_ValidValue_ReturnTrue()
        {
            var ex = staff.isValidEmail("tester@gmail.com");
            Assert.IsTrue(ex);
        }
        [Test]
        public void isValidEmail_InvalidValue1_ReturnFalse()
        {
            var ex = staff.isValidEmail("google@@gmail.com");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidEmail_InvalidValue2_ReturnFalse()
        {
            var ex = staff.isValidEmail("example.gmail.@com");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidEmail_InvalidValue3_ReturnFalse()
        {
            var ex = staff.isValidEmail("@gmail.com");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidEmail_InvalidValue4_ReturnFalse()
        {
            var ex = staff.isValidEmail("..@gmail.com");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidEmail_InvalidValue5_ReturnFalse()
        {
            var ex = staff.isValidEmail("1234@gmail.com");
            Assert.IsFalse(ex);
        }
        // TEST ISVALIDNAME
        [Test]
        public void isValidName_ValidValue_ReturnTrue()
        {
            var ex = staff.isValidName("Vũ Đặng Khương Duy");
            Assert.IsTrue(ex);
        }
        [Test]
        public void isValidName_InvalidValue1_ReturnFalse()
        {
            var ex = staff.isValidEmail("Pham Minh Tan1");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidName_InvalidValue2_ReturnFalse()
        {
            var ex = staff.isValidEmail("@Pham Minh Tan");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidName_InvalidValue3_ReturnFalse()
        {
            var ex = staff.isValidEmail("BuiDuongDuyKhang");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidName_InvalidValue4_ReturnFalse()
        {
            var ex = staff.isValidEmail("");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidName_InvalidValue5_ReturnFalse()
        {
            var ex = staff.isValidEmail(".");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isValidName_InvalidValue6_ReturnFalse()
        {
            var ex = staff.isValidEmail("super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long super long long long long name");
            Assert.IsFalse(ex);
        }

        //TEST ISVIETNAMESEPHONENUMBER
        [Test]
        public void isVietNamesePhoneNumber_ValidValue_ReturnTrue()
        {
            var ex = staff.isVietnamesePhoneNumber("0323456789");
            Assert.IsTrue(ex);
        }
        [Test]
        public void isVietNamesePhoneNumber_InvalidValue1_ReturnFalse()
        {
            var ex = staff.isVietnamesePhoneNumber("Pham Minh Tan1");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isVietNamesePhoneNumber_InvalidValue2_ReturnFalse()
        {
            var ex = staff.isVietnamesePhoneNumber("03232@231");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isVietNamesePhoneNumber_InvalidValue3_ReturnFalse()
        {
            var ex = staff.isVietnamesePhoneNumber("032032030103201301032103021032103210320302103210321023023103219213973829768943678567386578678943619734");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isVietNamesePhoneNumber_InvalidValue4_ReturnFalse()
        {
            var ex = staff.isVietnamesePhoneNumber("");
            Assert.IsFalse(ex);
        }
        [Test]
        public void isVietNamesePhoneNumber_InvalidValue5_ReturnFalse()
        {
            var ex = staff.isVietnamesePhoneNumber(".");
            Assert.IsFalse(ex);
        }
    }
}