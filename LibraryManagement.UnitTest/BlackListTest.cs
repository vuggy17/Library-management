using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using LibraryManagement.controller;
using LibraryManagement.model;

namespace LibraryManagement.UnitTest
{
    [TestFixture]
    class BlackListTest
    {
        [TestCase(4, true)]
        public void addBlacklist_ValidValue_ReturnTrue(int id, bool result)
        {
            var mockUserService = new MockDbService().MockAddBlackList(id, output:true);
            var vm = new MemberViewModel(mockUserService.Object, new Until.UntilService(), id);
            bool isIn = false;
            List<Account> listAccount = Db.getInstace().getAllAccount();
           
            foreach (Account item in listAccount)
            {
                if (item.id == id)
                {
                    if (item.status == model.enums.AccountStatus.BLACKLISTED) isIn = true;
                    isIn = false;
                }
            }
            var ex = vm.addInToBlacklist(isIn);

            Assert.That(ex, Is.EqualTo(result));
            mockUserService.VerifyAll();
        }
    }
}
