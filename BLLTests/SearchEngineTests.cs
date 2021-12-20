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
    public class SearchEngineTests
    {
        [TestMethod()]
        public void GetStudentDataByFirstAndLastNameTest()
        {
            // arrange
            string expected = "\nGroup: PI-220\n" +
                "Course: 2\n" +
                "Sex: Male\n" +
                "Identification code: 1234567890\n" +
                "Student ID: 12345678\n" +
                "GPA: 4,5\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            string actuall = SearchEngine.GetStudentDataByFirstAndLastName("Hlib", "Semeniuk", groupManager.Groups);

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllStudenstInGroupTest()
        {
            // arrange
            string expected = "\nGroup: PI-220\n" +
                "Student Hlib Semeniuk\n" +
                "Course: 2\n" +
                "Sex: Male\n" +
                "Identification code: 1234567890\n" +
                "Student ID: 12345678\n" +
                "GPA: 4,5\n" +
                "\nStudent Yaroslava Sobko\n" +
                "Course: 2\n" +
                "Sex: Female\n" +
                "Identification code: 1234567890\n" +
                "Student ID: 12345678\n" +
                "GPA: 5\n\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            learningProcessManager.AddGrade("PI-220", "Yaroslava", "Sobko", "OOP", 5, groupManager);
            List<string> list = SearchEngine.GetAllStudenstInGroup("PI-220", groupManager);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s + '\n'; 
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllStudentsByGPATest()
        {
            // arrange
            string expected = "\nStudent Hlib Semeniuk\n" +
                "Group: PI-220\n" +
                "Course: 2\n" +
                "Sex: Male\n" +
                "Identification code: 1234567890\n" +
                "Student ID: 12345678\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            learningProcessManager.AddGrade("PI-220", "Yaroslava", "Sobko", "OOP", 5, groupManager);
            float gpa = 4.5F;
            List<string> list = SearchEngine.GetAllStudentsByGPA(gpa, groupManager);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s;
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllSuccessfulStudentsTest()
        {
            // arrange
            string expected = "\nStudent Hlib Semeniuk\n" +
                "Group: PI-220\n" +
                "Course: 2\n" +
                "GPA: 4,5\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            learningProcessManager.AddGrade("PI-220", "Yaroslava", "Sobko", "OOP", 2, groupManager);
            List<string> list = SearchEngine.GetAllSuccessfulStudents(groupManager);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s;
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllSuccessfulStudentsBySubjectTest()
        {
            // arrange
            string expected = "\nStudent Hlib Semeniuk\n" +
                "Group: PI-220\n" +
                "Course: 2\n" +
                "GPA: 4,5\n" +
                "\nStudent Yaroslava Sobko\n" +
                "Group: PI-221\n" +
                "Course: 2\n" +
                "GPA: 3\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            groupManager.AddGroup("PI-221", 2);
            studentsManager.AddStudent("PI-221", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            learningProcessManager.AddSubject("PI-221", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-221", "Yaroslava", "Sobko", "OOP", 3, groupManager);
            List<string> list = SearchEngine.GetAllSuccessfulStudentsBySubject("OOP", groupManager.Groups);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s;
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllUnSuccessfulStudentsTest()
        {
            // arrange
            string expected = "\nStudent Yaroslava Sobko\n" +
                "Group: PI-220\n" +
                "Course: 2\n" +
                "GPA: 2\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 5, groupManager);
            learningProcessManager.AddGrade("PI-220", "Yaroslava", "Sobko", "OOP", 2, groupManager);
            List<string> list = SearchEngine.GetAllUnSuccessfulStudents(groupManager.Groups);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s;
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetAllUnSuccessfulStudentsBySubjectTest()
        {
            // arrange
            string expected = "\nStudent Hlib Semeniuk\n" +
                "Group: PI-220\n" +
                "Course: 2\n" +
                "GPA: 2,5\n" +
                "\nStudent Yaroslava Sobko\n" +
                "Group: PI-221\n" +
                "Course: 2\n" +
                "GPA: 2\n";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();
            LearningProcessManager learningProcessManager = new LearningProcessManager();

            // act
            groupManager.AddGroup("PI-220", 2);
            studentsManager.AddStudent("PI-220", "Hlib", "Semeniuk", "Male", "1234567890", "12345678", groupManager);
            groupManager.AddGroup("PI-221", 2);
            studentsManager.AddStudent("PI-221", "Yaroslava", "Sobko", "Female", "1234567890", "12345678", groupManager);

            learningProcessManager.AddSubject("PI-220", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 1, groupManager);
            learningProcessManager.AddGrade("PI-220", "Hlib", "Semeniuk", "OOP", 4, groupManager);
            learningProcessManager.AddSubject("PI-221", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-221", "Yaroslava", "Sobko", "OOP", 2, groupManager);
            List<string> list = SearchEngine.GetAllUnSuccessfulStudentsBySubject("OOP", groupManager.Groups);

            string actuall = "";
            foreach (string s in list)
            {
                actuall += s;
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }
    }
}