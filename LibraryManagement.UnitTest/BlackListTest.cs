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
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void addBlacklist_Testing(bool isIn, bool result)
        {         
            var vm = new MemberViewModel(isIn);                 
            var ex = vm.addInToBlacklist(isIn);
            Assert.That(ex, Is.EqualTo(result));
        }

        [TestCase(false, false)]
        [TestCase(true, true)]
        public void deleteBlacklist_Testing(bool isIn, bool result)
        {
            var vm = new MemberViewModel(isIn);
            var ex = vm.deleteFromBlacklist(isIn);
            Assert.That(ex, Is.EqualTo(result));
        }
    }
}
