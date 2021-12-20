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
    public class StudentsManagerTests
    {
        StudentsManager studentsManager = new StudentsManager();

        [TestMethod()]
        public void AddStudentTest()
        {
            // arrange
            string expected = "Student Hlib Semeniuk added";
            GroupManager groupManager = new GroupManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            string actuall = studentsManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            // arrange
            string expected = "Student Hlib Semeniuk deleted";
            GroupManager groupManager = new GroupManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.DeleteStudent("PI-220", "Hlib", "Semeniuk", groupManager);
            string actuall = studentsManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void ChangeStudentDataTest()
        {
            // arrange
            string expected = "Student ID changed";
            GroupManager groupManager = new GroupManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.ChangeStudentData("PI-220", "Hlib", "Semeniuk", "Student ID", "87654321", groupManager);
            string actuall = studentsManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGradesInTheSubjectTest()
        {
            // arrange
            string expected = "OOP\n" +
                "Grades:\t4\t5\n" +
                "GPA: 4,5";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            string actuall = studentsManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName,groupManager);

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGPAInTheSubjectsTest()
        {
            // arrange
            string expected = "OOP\n" +
                "GPA: 4,5\n" +
                "Math\n" +
                $"There are no grades\n";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            learningProcessManager.AddSubject(groupName, "Math", groupManager);
            string actuall = studentsManager.GetGPAInTheSubjects(groupName, firstName, lastName, groupManager);

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void IsStudentExistTest()
        {
            // arrange
            bool expected = true;

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            GroupManager groupManager = new GroupManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, "Male", "1234567890", "12345678", groupManager);
            bool actuall = studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager);

            // assert
            Assert.AreEqual(expected, actuall);
        }
    }
}