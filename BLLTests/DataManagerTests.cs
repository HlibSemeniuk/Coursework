using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class DataManagerTests
    {

        [TestMethod()]
        public void SetDataTest()
        {
            //arrange
            string expected = "PI-220";
            List<Group> groups = new List<Group>();
            Group group = new Group("PI-220", 2);
            DataContext<List<Group>> dataContext = new DataContext<List<Group>>(@"C:\Users\user\Desktop\UnitTest\UnitTest1.xml");
            groups.Add(group);
            dataContext.SetData(groups);

            // act
            List<Group> takenGroups = dataContext.GetData();
            string actuall = takenGroups[0].Name;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void WriteDataTest()
        {
            //arrange
            string expected = "PI-220";
            List<Group> groups = new List<Group>();
            Group group = new Group("PI-220", 2);
            DataContext<List<Group>> dataContext = new DataContext<List<Group>>(@"C:\Users\user\Desktop\UnitTest\UnitTest2.xml");
            groups.Add(group);

            // act
            dataContext.SetData(groups);
            List<Group> takenGroups = dataContext.GetData();
            string actuall = takenGroups[0].Name;

            // assert
            Assert.AreEqual(expected, actuall);
        }
    }
}