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
    public class LearningProcessManagerTests
    {
        LearningProcessManager learningProcessManager = new LearningProcessManager();
        [TestMethod()]
        public void AddSubjectTest()
        {
            // arrange
            string expected = "Subject OOP added";

            string groupName = "PI-220";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();


            // act
            groupManager.AddGroup(groupName, 2);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            string actuall = learningProcessManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void DeleteSubjectTest()
        {
            // arrange
            string expected = "Subject OOP deleted";

            string groupName = "PI-220";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();

            // act
            groupManager.AddGroup(groupName, 2);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.DeleteSubject(groupName, subjectName, groupManager);
            string actuall = learningProcessManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void AddGradeTest()
        {
            // arrange
            string expected = "Grade added";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            string actuall = learningProcessManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void ChangeGradeTest()
        {
            // arrange
            string expected = "Grade changed";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);
            learningProcessManager.ChangeGrade(groupName, firstName, lastName, subjectName, 4, 5, groupManager);
            string actuall = learningProcessManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void DeliteGradeTest()
        {
            // arrange
            string expected = "Grade deleted";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);
            learningProcessManager.DeliteGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            string actuall = learningProcessManager.OperationResult;

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGradesOfAllStudentsTest()
        {
            // arrange
            string expected = "\nGroup: PI-220\n" +
                "Student Hlib Semeniuk\n" +
                "Subject: OOP\n" +
                "Grades: \t4\t5\n" +
                "GPA: 4,5\n" +
                "\nGroup: PI-320\n" +
                "Student Yaroslava Sobko\n" +
                "Subject: Math\n" +
                "Grades: \t5\t5\n" +
                "GPA: 5\n";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            groupManager.AddGroup("PI-320", 3);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            studentsManager.AddStudent("PI-320", "Yaroslava", "Sobko", "Female", "0987654321", "87654321", groupManager);
            learningProcessManager.AddSubject("PI-320", "Math", groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "Math", 5, groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "Math", 5, groupManager);

            List<string> list = learningProcessManager.GetGradesOfAllStudents(groupManager);
            string actuall = "";
            foreach (string s in list)
            {
                actuall += s + '\n';
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGradesInTheSubjectOfAllStudentsTest()
        {
            // arrange
            string expected = "Group: PI-220\n" +
                "Student Hlib Semeniuk\n" +
                "Grades: \t4\t5\n" +
                "GPA: 4,5\n" +
                "\nGroup: PI-320\n" +
                "Student Yaroslava Sobko\n" +
                "Grades: \t5\t4\n" +
                "GPA: 4,5\n\n";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            groupManager.AddGroup("PI-320", 3);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            studentsManager.AddStudent("PI-320", "Yaroslava", "Sobko", "Female", "0987654321", "87654321", groupManager);
            learningProcessManager.AddSubject("PI-320", "Math", groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "Math", 5, groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "Math", 5, groupManager);
            learningProcessManager.AddSubject("PI-320", "OOP", groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "OOP", 5, groupManager);
            learningProcessManager.AddGrade("PI-320", "Yaroslava", "Sobko", "OOP", 4, groupManager);
            List<string> list = learningProcessManager.GetGradesInTheSubjectOfAllStudents("OOP", groupManager);
            string actuall = "";
            foreach (string s in list)
            {
                actuall += s + '\n';
            }

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGradesTest()
        {
            // arrange
            string expected = "Subject: OOP\n" +
                "Grades: \t4\t5\n" +
                "GPA: 4,5\n" +
                "Subject: Math\n" +
                "Grades: \t3\t5\n" +
                "GPA: 4\n";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);
            learningProcessManager.AddSubject(groupName, "Math", groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, "Math", 3, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, "Math", 5, groupManager);

            string actuall = learningProcessManager.GetGrades(groupName, firstName, lastName, groupManager);

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
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            string actuall = learningProcessManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager);

            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetStudentGPATest()
        {
            // arrange
            string expected = "GPA: 4,5";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            string actuall = learningProcessManager.GetStudentGPA(groupName, firstName, lastName, groupManager);
            // assert
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod()]
        public void GetGPAofAllStudentTest()
        {
            // arrange
            string expected = "\nPI-220\n" +
                "Student Hlib Semeniuk\n" +
                "GPA: 4,5\n" +
                "Student Yaroslava Sobko\n" +
                "GPA: no grades\n";

            string groupName = "PI-220";
            string firstName = "Hlib";
            string lastName = "Semeniuk";
            string sex = "Male";
            string identificationCode = "1234567890";
            string studentID = "12345678";
            string subjectName = "OOP";
            GroupManager groupManager = new GroupManager();
            StudentsManager studentsManager = new StudentsManager();

            // act
            groupManager.AddGroup(groupName, 2);
            studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
            studentsManager.AddStudent("PI-220", "Yaroslava", "Sobko", "Female", "1243", "1243", groupManager);
            learningProcessManager.AddSubject(groupName, subjectName, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 4, groupManager);
            learningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, 5, groupManager);

            string actuall = learningProcessManager.GetGPAofAllStudent(groupManager);

            // assert
            Assert.AreEqual(expected, actuall);
        }
    }
}