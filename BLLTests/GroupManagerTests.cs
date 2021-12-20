using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestClass()]
    public class GroupManagerTests
    {
        GroupManager groupManager = new GroupManager();

        [TestMethod()]
        public void AddGroupTest()
        {
            // Arrange
            string expected = "Group PI-220 added";


            // Act
            groupManager.AddGroup("PI-220", 2);

            // Assert
            string actual = groupManager.OperationResult;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeliteGroupTest()
        {
            // Arrange
            string expected = "Group PI-220 deleted";

            // Act
            groupManager.AddGroup("PI-220", 2);
            groupManager.DeliteGroup("PI-220");

            // Assert
            string actual = groupManager.OperationResult;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ChangeGroupDataTest()
        {
            // arrange
            string expected = "Group name changed to PI-221";

            string groupName = "PI-220";
            int course = 2;
            string whatChanging = "Name";
            string newData = "PI-221";

            // act
            groupManager.AddGroup(groupName, course);
            groupManager.ChangeGroupData(groupName, whatChanging, newData);
            string actuall = groupManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllGroupDataTest()
        {
            // arrange
            string expected = "Group PI-220\n" +
                    "Course: 2\n" +
                    "Count of students: 2\n" +
                    "Subjects: \tOOP\tMath";

            string groupName = "PI-220";
            int course = 2;
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup(groupName, course);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "0987654321", "87654321", groupManager);
            learningProcessManager.AddSubject(groupName, "OOP", groupManager);
            learningProcessManager.AddSubject(groupName, "Math", groupManager);

            string actuall = groupManager.GetAllGroupData(groupName);

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGroupDataOfTest()
        {
            // arrange
            string expected = "Count of students: 2";

            string groupName = "PI-220";
            int course = 2;
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, course);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "0987654321", "87654321", groupManager);
            string actuall = groupManager.GetGroupDataOf(groupName, "Count of students");

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGroupTest()
        {
            // Arrange
            string expected = "PI-220";


            // Act
            groupManager.AddGroup("PI-220", 2);
            Group group = groupManager.GetGroup("PI-220");

            // Assert
            string actual = group.Name;
            Assert.AreEqual(expected, actual);
        }
    }
}