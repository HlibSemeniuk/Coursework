using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SearchEngine
    {
        public static string GetStudentDataByFirstAndLastName(string firstName, string lastName, List<Group> groups)
        {

            try
            {
                if (groups == null)
                    throw new Exception("There are no groups");

                string info = $"There is no student named {firstName} {lastName}";

                foreach (Group g in groups)
                {
                    foreach (Student student in g.Students)
                    {
                        if (student.FirstName.Equals(firstName) && student.LastName.Equals(lastName))
                            return $"\nGroup: {g.Name}\n" +
                                $"Course: {student.Course}\n" +
                                $"Sex: {student.Sex}\n" +
                                $"Identification code: {student.IdentificationCode}\n" +
                                $"Student ID: {student.StudentID}\n" +
                                $"GPA: {student.GPA}\n";
                    }
                }
                return info;
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }

        public static List<string> GetAllStudenstInGroup(string groupName, GroupManager groupManager)
        {
            try
            {
                Group group = groupManager.GetGroup(groupName);
                List<string> studentInfo = new List<string>();

                if (group.Students == null)
                {
                    studentInfo.Add("There is no student in group");
                    return studentInfo;
                }
                else
                {
                    studentInfo.Add($"\nGroup: {group.Name}");
                    foreach (Student student in group.Students)
                    {
                        studentInfo.Add($"Student {student.FirstName} {student.LastName}\n" +
                            $"Course: {student.Course}\n" +
                             $"Sex: {student.Sex}\n" +
                             $"Identification code: {student.IdentificationCode}\n" +
                             $"Student ID: {student.StudentID}\n" +
                             $"GPA: {student.GPA}\n");
                    }
                    return studentInfo;
                }
            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public static List<string> GetAllStudentsByGPA(float gpa, GroupManager groupManager)
        {
            try
            {
                if (groupManager.Groups == null)
                    throw new Exception("There are no groups");

                List<string> studentInfo = new List<string>();

                foreach (Group group in groupManager.Groups)
                {
                    if (group.Students != null)
                    {
                        foreach (Student student in group.Students)
                        {
                            if (student.GPA == gpa)
                            {
                                studentInfo.Add($"\nStudent {student.FirstName} {student.LastName}\n" +
                               $"Group: {group.Name}\n" +
                               $"Course: {student.Course}\n" +
                                $"Sex: {student.Sex}\n" +
                                $"Identification code: {student.IdentificationCode}\n" +
                                $"Student ID: {student.StudentID}\n");
                            }
                        }
                    }
                }

                if (studentInfo.Count == 0)
                    studentInfo.Add($"There are no students with GPA {gpa}");

                return studentInfo;

            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public static List<string> GetAllSuccessfulStudents(GroupManager groupManager)
        {
            try
            {
                if (groupManager.Groups == null)
                    throw new Exception("There are no groups");

                List<string> studentInfo = new List<string>();

                foreach (Group group in groupManager.Groups)
                {
                    if (group.Students != null)
                    {
                        foreach (Student student in group.Students)
                        {
                            if (student.GPA >= 3)
                            {
                                studentInfo.Add($"\nStudent {student.FirstName} {student.LastName}\n" +
                               $"Group: {group.Name}\n" +
                               $"Course: {student.Course}\n" +
                                $"GPA: {student.GPA}\n");
                            }
                        }
                    }
                }

                if (studentInfo.Count == 0)
                    studentInfo.Add($"There are no successful students");

                return studentInfo;

            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }


        public static List<string> GetAllSuccessfulStudentsBySubject(string subjectName, List<Group> groups)
        {
            try
            {
                if (groups == null)
                    throw new Exception("There are no groups");

                List<string> studentInfo = new List<string>();

                bool isSubjectExist = false;
                foreach (Group group in groups)
                {
                    if (group.Students != null)
                    {
                        foreach (Student student in group.Students)
                        {
                            foreach (Subject subject in student.Subjects)
                            {
                                if (subject.Name.Equals(subjectName))
                                {
                                    isSubjectExist = true;
                                    if (subject.GPA >= 3)
                                    {
                                        studentInfo.Add($"\nStudent {student.FirstName} {student.LastName}\n" +
                                       $"Group: {group.Name}\n" +
                                       $"Course: {student.Course}\n" +
                                        $"GPA: {subject.GPA}\n");
                                    }
                                }

                            }

                        }
                    }
                }

                if (isSubjectExist == false)
                    studentInfo.Add($"There is no subject named {subjectName}");
                else if (studentInfo.Count == 0)
                    studentInfo.Add("There are no successful students in this subject");

                return studentInfo;

            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public static List<string> GetAllUnSuccessfulStudents(List<Group> groups)
        {
            try
            {
                if (groups == null)
                    throw new Exception("There are no groups");

                List<string> studentInfo = new List<string>();

                foreach (Group group in groups)
                {
                    if (group.Students != null)
                    {
                        foreach (Student student in group.Students)
                        {
                            if (student.GPA < 3)
                            {
                                studentInfo.Add($"\nStudent {student.FirstName} {student.LastName}\n" +
                               $"Group: {group.Name}\n" +
                               $"Course: {student.Course}\n" +
                                $"GPA: {student.GPA}\n");
                            }
                        }
                    }
                }

                if (studentInfo.Count == 0)
                    studentInfo.Add($"There are no unsuccessful students");

                return studentInfo;

            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }

        public static List<string> GetAllUnSuccessfulStudentsBySubject(string subjectName, List<Group> groups)
        {
            try
            {
                if (groups == null)
                    throw new Exception("There are no groups");

                List<string> studentInfo = new List<string>();

                bool isSubjectExist = false;
                foreach (Group group in groups)
                {
                    if (group.Students != null)
                    {
                        foreach (Student student in group.Students)
                        {
                            foreach (Subject subject in student.Subjects)
                            {
                                if (subject.Name.Equals(subjectName))
                                {
                                    isSubjectExist = true;
                                    if (subject.GPA < 3)
                                    {
                                        studentInfo.Add($"\nStudent {student.FirstName} {student.LastName}\n" +
                                       $"Group: {group.Name}\n" +
                                       $"Course: {student.Course}\n" +
                                        $"GPA: {subject.GPA}\n");
                                    }
                                }

                            }

                        }
                    }
                }

                if (isSubjectExist == false)
                    studentInfo.Add($"There is no subject named {subjectName}");
                else if (studentInfo.Count == 0)
                    studentInfo.Add("There are no unsuccessful students in this subject");

                return studentInfo;

            }
            catch (EntityNotFoundExeption ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return temp;
            }
        }
    }
}
