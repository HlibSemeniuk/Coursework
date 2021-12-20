using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LearningProcessManager
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

        public void AddSubject(string groupName, string subjectName, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);

                bool isSubjectExist = false;
                foreach (string s in group.SubjectsName)
                {
                    if (s.Equals(subjectName))
                    {
                        isSubjectExist = true;
                        break;
                    }
                }

                if (isSubjectExist == true)
                    OperationResult = "This group already has this subject";
                else
                {
                    group.SubjectsName.Add(subjectName);

                    foreach (Student student in group.Students)
                    {
                        student.Subjects.Add(new Subject(subjectName));
                    }
                    OperationResult = $"Subject {subjectName} added";
                }
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void DeleteSubject(string groupName, string subjectName, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);

                List<string> changedSubjectNames = new List<string>();
                List<Subject> changedSubjects = new List<Subject>();

                bool isSubjectExist = false;
                foreach (string s in group.SubjectsName)
                {
                    if (s.Equals(subjectName))
                    {
                        isSubjectExist = true;
                        break;
                    }
                }

                if (isSubjectExist == false)
                    OperationResult = $"This group doesn't have subject named {subjectName}";
                else
                {
                    foreach (string name in group.SubjectsName)
                    {
                        if (name.Equals(subjectName) == false)
                        {
                            changedSubjectNames.Add(name);
                        }
                    }
                    group.SubjectsName = changedSubjectNames;

                    if (group.CountOfStudents != 0)
                    {
                        Student student = group.Students[0];
                        foreach (Subject subject in student.Subjects)
                        {
                            if (subject.Name.Equals(subjectName) == false)
                            {
                                changedSubjects.Add(subject);
                            }
                        }

                        foreach (Student s in group.Students)
                        {
                            s.Subjects = changedSubjects;
                        }
                    }

                    OperationResult = $"Subject {subjectName} deleted";
                }
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void AddGrade(string groupName, string firstName, string lastName, string subjectName, int grade, GroupManager groupManager)
        {
            try
            {
                StudentsManager studentsManager = new StudentsManager();
                Student student = studentsManager.GetStudent(groupName, firstName, lastName, groupManager);

                bool isSubjectExist = false;
                foreach (Subject s in student.Subjects)
                {
                    if (s.Name.Equals(subjectName))
                    {
                        isSubjectExist = true;
                        s.Grades.Add(grade);
                        break;
                    }
                }

                if (isSubjectExist == false)
                    OperationResult = $"This group doesn't have subject named {subjectName}";
                else
                    OperationResult = "Grade added";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void ChangeGrade(string groupName, string firstName, string lastName, string subjectName, int gradeToChange, int newGrade, GroupManager groupManager)
        {
            try
            {
                StudentsManager studentManager = new StudentsManager();
                Student student = studentManager.GetStudent(groupName, firstName, lastName, groupManager);

                bool isSubjectExist = false;
                bool isGradeChanged = false;
                foreach (Subject s in student.Subjects)
                {
                    if (s.Name.Equals(subjectName))
                    {
                        List<int> list = new List<int>();
                        isSubjectExist = true;

                        foreach (int grade in s.Grades)
                        {

                            if (grade == gradeToChange && isGradeChanged == false)
                            {
                                isGradeChanged = true;
                                list.Add(newGrade);
                            }
                            else
                                list.Add(grade);
                        }
                        s.Grades = list;
                        break;
                    }
                }

                if (isSubjectExist == false)
                    OperationResult = $"This group doesn't have subject named {subjectName}";
                else if (isGradeChanged == false)
                    OperationResult = $"This student doesn't have grade {gradeToChange} in subject named {subjectName}";
                else if (isGradeChanged == true)
                    OperationResult = "Grade changed";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void DeliteGrade(string groupName, string firstName, string lastName, string subjectName, int gradeToDelite, GroupManager groupManager)
        {
            try
            {
                StudentsManager studentManager = new StudentsManager();
                Student student = studentManager.GetStudent(groupName, firstName, lastName, groupManager);

                List<int> changedGrades = new List<int>();
                bool isSubjectExist = false;
                bool isGradeExist = false;
                foreach (Subject s in student.Subjects)
                {
                    if (s.Name.Equals(subjectName))
                    {
                        isSubjectExist = true;
                        foreach (int grade in s.Grades)
                        {
                            if (grade == gradeToDelite && isGradeExist == false)
                            {
                                isGradeExist = true;
                            }
                            else
                                changedGrades.Add(grade);
                        }
                        s.Grades = changedGrades;
                        break;
                    }
                }

                if (isSubjectExist == false)
                    OperationResult = $"This group doesn't have subject named {subjectName}";
                else if (isGradeExist == false)
                    OperationResult = $"This student doesn't have grade {gradeToDelite} in subject named {subjectName}";
                else if (isGradeExist == true)
                    OperationResult = "Grade deleted";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public List<string> GetGradesOfAllStudents(GroupManager groupManager)
        {
            try
            {
                if (groupManager.Groups == null)
                    throw new EntityNotFoundExeption("Ther are no groups");

                List<string> listOfGrades = new List<string>();

                foreach (Group group in groupManager.Groups)
                {
                    if (group.Students.Count == 0)
                        continue;
                    else
                    {
                        listOfGrades.Add($"\nGroup: {group.Name}");

                        foreach (Student student in group.Students)
                        {
                            listOfGrades.Add($"Student {student.FirstName} {student.LastName}");

                            foreach (Subject subject in student.Subjects)
                            {
                                listOfGrades.Add($"Subject: {subject.Name}");
                                string grades = "";

                                if (subject.Grades == null)
                                    listOfGrades.Add("Grades: none");
                                else
                                {
                                    foreach (int grade in subject.Grades)
                                    {
                                        grades += $"\t{grade}";
                                    }
                                    listOfGrades.Add($"Grades: {grades}\n" +
                                        $"GPA: {subject.GPA}");
                                }
                            }
                        }    
                   
                    }
                }

                return listOfGrades;
            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public List<string> GetGradesInTheSubjectOfAllStudents(string subjectName, GroupManager groupManager)
        {
            try
            {
                if (groupManager.Groups == null)
                    throw new EntityNotFoundExeption("Ther are no groups");

                List<string> listOfGrades = new List<string>();

                foreach (Group group in groupManager.Groups)
                {
                    foreach (Student student in group.Students)
                    {
                        foreach (Subject subject in student.Subjects)
                        {
                            if (subject.Name.Equals(subjectName))
                            {
                                listOfGrades.Add($"Group: {group.Name}");
                                listOfGrades.Add($"Student {student.FirstName} {student.LastName}");

                                string grades = "";

                                if (subject.Grades == null)
                                    listOfGrades.Add("Grades: none\n");
                                else
                                {
                                    foreach (int grade in subject.Grades)
                                    {
                                        grades += $"\t{grade}";
                                    }
                                    listOfGrades.Add($"Grades: {grades}\n" +
                                        $"GPA: {subject.GPA}\n");
                                }
                                break;
                            }
                        }
                    }
                }

                return listOfGrades;
            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public string GetGrades(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                StudentsManager studentsManager = new StudentsManager();
                Student student = studentsManager.GetStudent(groupName, firstName, lastName, groupManager);

                if (student.Subjects == null)
                    return "Student has no subject";
                else
                {
                    string grades = "";
                    foreach (Subject subject in student.Subjects)
                    {
                        grades += $"Subject: {subject.Name}\n" +
                            $"Grades: ";

                        if (subject.Grades == null)
                            grades += "none\n";
                        else
                        {
                            foreach (int grade in subject.Grades)
                            {
                                grades += $"\t{grade}";
                            }
                            grades += $"\nGPA: {subject.GPA}\n";
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

        public string GetGradesInTheSubject(string groupName, string firstName, string lastName, string subjectName, GroupManager groupManager)
        {
            StudentsManager studentsManager = new StudentsManager();
            return studentsManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager);
        }

        public string GetStudentGPA(string groupName, string firstName, string lastName, GroupManager groupManager)
        {
            try
            {
                StudentsManager  studentsManager = new StudentsManager();
                Student student = studentsManager.GetStudent(groupName, firstName, lastName, groupManager);

                if (student.GPA == 0)
                    return $"There is no grades";
                else
                    return $"GPA: {student.GPA}";
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }

        public string GetGPAofAllStudent(GroupManager groupManager)
        {
            try
            {
                string GPAs = "";

                foreach(Group group in groupManager.Groups)
                {
                    if (group.Students.Count != 0)
                    {
                        GPAs += '\n' + group.Name + '\n';
                        foreach (Student s in group.Students)
                        {
                            GPAs += $"Student {s.FirstName} {s.LastName}\n";

                            if (s.GPA == 0)
                                GPAs += $"GPA: no grades\n";
                            else
                                GPAs += $"GPA: {s.GPA}\n";
                        }
                    }
                }

                if (GPAs.Equals(""))
                    return "There is no groups";
                
                else
                    return GPAs;
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }


    }
}
