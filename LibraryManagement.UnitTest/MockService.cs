﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.db;
using LibraryManagement.model;
using Moq;

namespace LibraryManagement.UnitTest
{
    class MockDbService : Mock<IDatabase>
    {

        public MockDbService MockGetAllStaffs(int staffId, string password, List<Staff> output)
        {
            Setup(x => x.getAllStaffs()).Returns(output);
            return this;
        }
        public MockDbService MockUpdateInfo(Person info)
        {
            Setup(x => x.updateInfo(
                It.IsAny<Person>()
              )).Returns(true);
            return this;
        }
        public MockDbService MockInsertImage(Person info, bool output)
        {
            Setup(x => x.insertImageData(
 It.IsAny<Person>()
              )).Returns(output);
            return this;
        }
        public MockDbService MockUpdatePassword(string staffId, string passowrd,  bool output)
        {
            Setup(x => x.updatePassword(
                It.Is<string>(i => i == staffId),
                It.Is<string>(i => i == passowrd)
              )).Returns(output);
            return this;
        }
        public MockDbService MockGetStaff(List<Staff> output)
        {
            Setup(x => x.getAllStaffs()).Returns(output);
            return this;
        }
       
        public MockDbService MockAddBlackList(int id, bool output)
        {
            Setup(x => !x.getIsInBlacklist(id)).Returns(output);
            return this;
        }
    }
}
