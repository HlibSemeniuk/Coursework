using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentsManager
    {
        private string operationResult;
        public string OperationResult
        {
            get
            {
                return operationResult;
            }
            set
            {
                operationResult = value;
            }
        }

        public StudentsManager()
        { }

        public void AddStudent(string groupName, string firstName, string lastName, string sex, string identificationCode, string studentID, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);
                int indexOfGroup = groupManager.Groups.IndexOf(group);

                group.Students.Add(new Student(firstName, lastName, sex, identificationCode, group.Course, studentID, group.SubjectsName));
                group.CountOfStudents++;
                groupManager.Groups[indexOfGroup] = group;

                OperationResult = $"Student {firstName} {lastName} added";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        private void ChangeStudentGroup(Student student, GroupManager groupManager, string newGroup)
        {
            try
            {
                Group group = groupManager.GetGroup(newGroup);
                int indexOfGroup = groupManager.Groups.IndexOf(group);

                group.Students.Add(new Student(student.FirstName, student.LastName, student.Sex, student.IdentificationCode, group.Course, student.StudentID, group.SubjectsName, student.Subjects));
                group.CountOfStudents++;
                groupManager.Groups[indexOfGroup] = group;
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void DeleteStudent(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);
                List<Student> changedStudents = new List<Student>();

                bool isDeleted = false;
                foreach (Student s in group.Students)
                {
                    if (firstName.Equals(s.FirstName) && lastName.Equals(s.LastName))
                        isDeleted = true;
                    else
                        changedStudents.Add(s);
                }

                if (isDeleted == true)
                {
                    group.Students = changedStudents;
                    group.CountOfStudents--;
                    OperationResult = $"Student {firstName} {lastName} deleted";
                }
                else
                    OperationResult = $"There is no student named {firstName} {lastName} in this group";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void ChangeStudentData(string groupName, string firstName, string lastName, string whatChanging, string newData, GroupManager groupManager)
        {
            try
            {
                Student student = GetStudent(groupName, firstName, lastName, groupManager);

                if (whatChanging.Equals("First name"))
                {
                    student.FirstName = newData;
                    OperationResult = "First name changed";
                }
                else if (whatChanging.Equals("Last name"))
                {
                    student.LastName = newData;
                    OperationResult = "Last name changed";
                }
                else if (whatChanging.Equals("Identification сode"))
                {
                    student.IdentificationCode = newData;
                    OperationResult = "Identification сode changed";
                }
                else if (whatChanging.Equals("Student ID"))
                {
                    student.StudentID = newData;
                    OperationResult = "Student ID changed";
                }
                else if (whatChanging.Equals("Group"))
                {
                    if (groupManager.IsGroupExist(newData))
                    {
                        DeleteStudent(groupName, firstName, lastName, groupManager);
                        ChangeStudentGroup(student, groupManager, newData);
                        OperationResult = "Group changed";
                    }
                    else
                        OperationResult = $"There in no group named {newData}";
                }

            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public string GetGradesInTheSubject(string groupName, string firstName, string lastName, string subjectName, GroupManager groupManager)
        {
            try
            {
                Student student = GetStudent(groupName, firstName, lastName, groupManager);

                if (student.Subjects == null)
                    return "Student has no subject";
                else
                {
                    string grades = $"Student has no subject named {subjectName}";
                    foreach (Subject subject in student.Subjects)
                    {
                        if (subject.Name.Equals(subjectName))
                        {
                            grades = $"{subject.Name}\nGrades:";

                            if (subject.GPA == 0)
                                grades += " none\n";
                            else
                            {
                                foreach (int grade in subject.Grades)
                                {
                                    grades += $"\t{grade}";
                                }
                                grades += $"\nGPA: {subject.GPA}";
                            }
                            break;
                        }
                    }
                    return grades;
                }
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }

        public string GetGPAInTheSubjects(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                Student student = GetStudent(groupName, firstName, lastName, groupManager);

                string grades = "";
                foreach (Subject subject in student.Subjects)
                {
                    grades += $"{subject.Name}\n";
                    if (subject.GPA == 0)
                        grades += "There are no grades\n";
                    else
                        grades += $"GPA: {subject.GPA}\n";
                }
                return grades;
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }

        public string GetListOfAllStudents(List<Group> groups)
        {
            string info = "";

            foreach (Group group in groups)
            {
                if (group.Students.Count != 0)
                {
                    info += $"\nGroup {group.Name}\n";
                    foreach (Student student in group.Students)
                    {
                        info += $"{student.FirstName} {student.LastName}\n";
                    }
                }
            }

            if (info.Equals(""))
                return "There is no students";
            else
                return info;
        }


        public Student GetStudent(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);

                foreach (Student s in group.Students)
                {
                    if (firstName.Equals(s.FirstName) && lastName.Equals(s.LastName))
                    {
                        return s;
                    }
                }

                throw new Exception($"There is no student named {firstName}, {lastName}");
            }
            catch (Exception e)
            {
                throw new EntityNotFoundExeption(e.Message);
            }
        }
   
        public bool IsStudentExist(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                GetStudent(groupName, firstName, lastName, groupManager);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
