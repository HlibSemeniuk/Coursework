using System;
using System.Collections.Generic;
using BLL;

namespace PL
{
    public class Menu
    {
        GroupManager groupManager = new GroupManager();
        StudentsManager studentsManager = new StudentsManager();
        LearningProcessManager LearningProcessManager = new LearningProcessManager();
        DataManager dataManager = new DataManager();

        public void RunApp()
        {
            bool end = false;
            int option = 0;
            do
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                PrintStartMenu();

                try
                {
                    option = Int32.Parse(Console.ReadLine());
                    if ((option < 0) | (option > 4))
                    {
                        throw new Exception("Please, input only digital (0-4):");
                    }
                }
                catch
                {
                    Console.WriteLine("Please, input only digital (0-4):");
                }


                if (option == 1)
                {
                    WorkWithGroups();
                }

                else if (option > 1 && !groupManager.IsDataExist())
                    Console.WriteLine("There is no groups. At first, created group");

                else if (option == 2)
                {
                    WorkWithStudents();
                }

                else if (option == 3)
                {
                    WorkWithLearningProcess();
                }

                else if (option == 4)
                    WorkWithSearcher();

                else if (option == 0)
                {
                    dataManager.WriteData(groupManager.Groups);
                    end = true;
                }



                option = 0;
            } while (end == false);
        }

        private void WorkWithGroups()
        {
            bool end = false;
            
            while (end == false)
            {
                
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                Console.WriteLine("\tWhat do you want to do?");
                Console.WriteLine("1. Add Group\n" +
                    "2. Delete Group\n" +
                    "3. Change Group's data\n" +
                    "4. Show Group's data\n" +
                    "5. Show specific Group's data\n" +
                    "0. Exit");

                int option = -1;
                while (option == -1)
                {
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        if ((option < 0) | (option > 5))
                        {
                            throw new Exception("Please, input only digital (0-5):");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please, input only digital (0-5):");
                    }
                }
               

                if (option == 1)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    int course = InteractorWithUser.SetCourse();

                    groupManager.AddGroup(groupName, course);
                    Console.WriteLine('\n' + groupManager.OperationResult);
                }


                else if (option == 2)
                {
                    string groupName = InteractorWithUser.SetGroupName();

                    groupManager.DeliteGroup(groupName);
                    Console.WriteLine('\n' + groupManager.OperationResult);
                }

                else if (option == 3)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    Console.WriteLine("\n\tWhat dou you want to change?\n" +
                        "1. Group Name\n" +
                        "2. Course\n" +
                        "0. Exit");

                    int subOption = -1;
                    while (subOption == -1)
                    {
                        try
                        {
                            subOption = Int32.Parse(Console.ReadLine());
                            if ((subOption < 0) | (subOption > 2))
                            {
                                throw new Exception("Please, input only digital (0-2):");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please, input only digital (0-2):");
                        }
                    }

                    if (subOption == 1)
                    {
                        string newData = InteractorWithUser.SetGroupName();
                        groupManager.ChangeGroupData(groupName, "Name", newData);
                        Console.WriteLine('\n' + groupManager.OperationResult);
                    }
                    else if (subOption == 2)
                    {
                        int newData = InteractorWithUser.SetCourse();
                        groupManager.ChangeGroupData(groupName, "Course", newData.ToString());
                        Console.WriteLine('\n' + groupManager.OperationResult);
                    }
                }

                else if (option == 4)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    Console.WriteLine('\n' + groupManager.GetAllGroupData(groupName));
                }

                else if (option == 5)
                {
                    string groupName = InteractorWithUser.SetGroupName();

                    Console.WriteLine("\n\tWhat dou you want to see?\n" +
                       "1. Course\n" +
                       "2. Count of students\n" +
                       "3. Subjects\n" +
                       "0. Exit\n");

                    int subOption = -1;
                    while (subOption == -1)
                    {
                        try
                        {
                            subOption = Int32.Parse(Console.ReadLine());
                            if ((subOption < 0) | (subOption > 3))
                            {
                                throw new Exception("Please, input only digital (0-3):");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please, input only digital (0-3):");
                        }
                    }

                    if (subOption == 1)
                        Console.WriteLine(groupManager.GetGroupDataOf(groupName, "Course"));

                    else if (subOption == 2)
                        Console.WriteLine(groupManager.GetGroupDataOf(groupName, "Count of students"));

                    else if (subOption == 3)
                        Console.WriteLine(groupManager.GetGroupDataOf(groupName, "Subjects"));
                }

                else if (option == 0)
                    end = true;
            }
           
        }

        private void WorkWithStudents()
        {
            bool end = false;
            

            while (end == false)
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                Console.WriteLine("\tWhat do you want to do?");
              
                Console.WriteLine("1. Add Student\n2. Delete Student\n3. Change Student data\n4. Show all students\n5. Show students's success in subject\n6.Show students's GPA in subjects\n0.Exit");
                int option = -1;
                while (option == -1)
                {
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        if ((option < 0) | (option > 6))
                        {
                            throw new Exception("Please, input only digital (0-6):");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please, input only digital (0-6):");
                    }
                }

                if (option == 1)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    while (groupManager.IsGroupExist(groupName) == false)
                    {
                        Console.WriteLine("There is no group with this name. Write group name:");
                        groupName = Console.ReadLine().ToUpper();
                    }

                    string firstName = InteractorWithUser.SetFirstName();
                    string lastName = InteractorWithUser.SetLasttName();
                    string sex = InteractorWithUser.SetSex();
                    string identificationCode = InteractorWithUser.SetIdentificationCode();
                    string studentID = InteractorWithUser.SetStudentID();

                    studentsManager.AddStudent(groupName, firstName, lastName, sex, identificationCode, studentID, groupManager);
                    Console.WriteLine('\n' + studentsManager.OperationResult);
                }

                else if (option == 2)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    while (groupManager.IsGroupExist(groupName) == false)
                    {
                        Console.WriteLine("There is no group with this name. Write group name:");
                        groupName = Console.ReadLine().ToUpper();
                    }

                    string firstName = InteractorWithUser.SetFirstName();
                    string lastName = InteractorWithUser.SetLasttName();

                    studentsManager.DeleteStudent(groupName, firstName, lastName, groupManager);
                    Console.WriteLine('\n' + studentsManager.OperationResult);
                }

                else if (option == 3)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string firstName = InteractorWithUser.SetFirstName();
                        string lastName = InteractorWithUser.SetLasttName();

                        if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                        {
                            Console.WriteLine("\n\tWhat dou you want to change?\n" +
                            "1. First name\n" +
                            "2. Last name\n" +
                            "3. Identification code\n" +
                            "4. Student ID\n" +
                            "5. Group\n" +
                            "0. Exit\n");

                            int subOption = -1;
                            while (subOption == -1)
                            {
                                try
                                {
                                    subOption = Int32.Parse(Console.ReadLine());
                                    if ((subOption < 0) | (subOption > 5))
                                    {
                                        throw new Exception("Please, input only digital (0-5):");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please, input only digital (0-5):");
                                }
                            }

                            if (subOption == 1)
                            {
                                string newData = InteractorWithUser.SetFirstName();
                                studentsManager.ChangeStudentData(groupName, firstName, lastName, "First name", newData, groupManager);
                                Console.WriteLine('\n' + studentsManager.OperationResult);
                            }
                            else if (subOption == 2)
                            {
                                string newData = InteractorWithUser.SetLasttName();
                                studentsManager.ChangeStudentData(groupName, firstName, lastName, "Last name", newData, groupManager);
                                Console.WriteLine('\n' + studentsManager.OperationResult);
                            }
                            else if (subOption == 3)
                            {
                                string newData = InteractorWithUser.SetIdentificationCode();
                                studentsManager.ChangeStudentData(groupName, firstName, lastName, "Identification сode", newData, groupManager);
                                Console.WriteLine('\n' + studentsManager.OperationResult);
                            }
                            else if (subOption == 4)
                            {
                                string newData = InteractorWithUser.SetStudentID();
                                studentsManager.ChangeStudentData(groupName, firstName, lastName, "Student ID", newData, groupManager);
                                Console.WriteLine('\n' + studentsManager.OperationResult);
                            }
                            else if (subOption == 5)
                            {
                                string newData = InteractorWithUser.SetGroupName();
                                studentsManager.ChangeStudentData(groupName, firstName, lastName, "Group", newData, groupManager);
                                Console.WriteLine('\n' + studentsManager.OperationResult);
                            }
                        }
                        else
                            Console.WriteLine($"There is no student named {firstName} {lastName}");
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }

                else if (option == 4)
                {
                    Console.WriteLine('\n' + studentsManager.GetListOfAllStudents(groupManager.Groups));
                }

                else if (option == 5)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string firstName = InteractorWithUser.SetFirstName();
                        string lastName = InteractorWithUser.SetLasttName();


                        if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                        {
                            string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                            if (subjects.Equals("This group doesn't have any subjects"))
                                Console.WriteLine(subjects);
                            else
                            {
                                Console.WriteLine(subjects);
                                string subjectName = InteractorWithUser.SetSubjectName();
                                Console.WriteLine('\n' + studentsManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager));
                            }

                        }
                        else
                            Console.WriteLine($"There is no student named {firstName} {lastName}");
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }

                else if (option == 6)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string firstName = InteractorWithUser.SetFirstName();
                        string lastName = InteractorWithUser.SetLasttName();

                        if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                        {
                            Console.WriteLine('\n' + studentsManager.GetGPAInTheSubjects(groupName, firstName, lastName, groupManager));
                        }
                        else
                            Console.WriteLine($"There is no student named {firstName} {lastName}");
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }

                else if (option == 0)
                    end = true;
            }
        }

        private void WorkWithLearningProcess()
        {
            bool end = false;
            

            while (end == false)
            {
                int option = -1;
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                Console.WriteLine("\tWhat do you want to do?");
                Console.WriteLine("\n1. Add Subject\n2. Delete Subject\n3. Add grade\n4. Change Grade\n5. Delete Grade\n6. Show student's GPA\n7. Show student's grades in subject\n8. Show GPAs of all students\n9. Show grades of all students in subject\n10.Show all grades of all students in all subjects\n11. Show all student's grade\n0.Exit");

                while (option == -1)
                {
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        if ((option < 0) | (option > 11))
                        {
                            throw new Exception("Please, input only digital (0-11):");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please, input only digital (0-11):");
                    }
                }
                

                if (option == 1)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjectName = InteractorWithUser.SetSubjectName();
                        LearningProcessManager.AddSubject(groupName, subjectName, groupManager);
                        Console.WriteLine('\n' + LearningProcessManager.OperationResult);
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 2)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                        if (subjects.Equals("This group doesn't have any subjects"))
                            Console.WriteLine(subjects);
                        else
                        {
                            Console.WriteLine(subjects);
                            string subjectName = InteractorWithUser.SetSubjectName();
                            LearningProcessManager.DeleteSubject(groupName, subjectName, groupManager);
                            Console.WriteLine('\n' + LearningProcessManager.OperationResult);
                        }
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 3)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                        if (subjects.Equals("This group doesn't have any subjects"))
                            Console.WriteLine(subjects);
                        else
                        {
                            Console.WriteLine(subjects);
                            string subjectName = InteractorWithUser.SetSubjectName();


                            string firstName = InteractorWithUser.SetFirstName();
                            string lastName = InteractorWithUser.SetLasttName();

                            if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                            {
                                int grade = InteractorWithUser.SetGrade();
                                LearningProcessManager.AddGrade(groupName, firstName, lastName, subjectName, grade, groupManager);
                                Console.WriteLine('\n' + LearningProcessManager.OperationResult);
                            }
                            else
                                Console.WriteLine($"There is no student named {firstName} {lastName}");

                        }
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");

                }
                else if (option == 4)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                        if (subjects.Equals("This group doesn't have any subjects"))
                            Console.WriteLine(subjects);
                        else
                        {
                            Console.WriteLine(subjects);
                            string subjectName = InteractorWithUser.SetSubjectName();


                            string firstName = InteractorWithUser.SetFirstName();
                            string lastName = InteractorWithUser.SetLasttName();

                            if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                            {
                                string grades = studentsManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager);

                                if (grades.Equals($"{subjectName}\nThere are no grades\n") == false)
                                {
                                    Console.WriteLine("Write grade, which you want to change:");
                                    int gradeToChange = InteractorWithUser.SetGrade();
                                    Console.WriteLine("Write new grade:");
                                    int newGrade = InteractorWithUser.SetGrade();
                                    LearningProcessManager.ChangeGrade(groupName, firstName, lastName, subjectName, gradeToChange, newGrade, groupManager);
                                    Console.WriteLine('\n' + LearningProcessManager.OperationResult);
                                }

                            }
                            else
                                Console.WriteLine($"There is no student named {firstName} {lastName}");

                        }
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 5)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                        if (subjects.Equals("This group doesn't have any subjects"))
                            Console.WriteLine(subjects);
                        else
                        {
                            Console.WriteLine(subjects);
                            string subjectName = InteractorWithUser.SetSubjectName();


                            string firstName = InteractorWithUser.SetFirstName();
                            string lastName = InteractorWithUser.SetLasttName();

                            if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                            {
                                string grades = LearningProcessManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager);

                                if (grades.Equals($"{subjectName}\nThere are no grades\n") == false)
                                {
                                    Console.WriteLine("Write grade, which you want to delete:");
                                    int gradeToChange = InteractorWithUser.SetGrade();
                                    LearningProcessManager.DeliteGrade(groupName, firstName, lastName, subjectName, gradeToChange, groupManager);
                                    Console.WriteLine('\n' + LearningProcessManager.OperationResult);
                                }

                            }
                            else
                                Console.WriteLine($"There is no student named {firstName} {lastName}");

                        }
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 6)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string firstName = InteractorWithUser.SetFirstName();
                        string lastName = InteractorWithUser.SetLasttName();

                        if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                        {
                            Console.WriteLine('\n' + LearningProcessManager.GetStudentGPA(groupName, firstName, lastName, groupManager));
                        }
                        else
                            Console.WriteLine($"There is no student named {firstName} {lastName}");
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 7)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName))
                    {
                        string subjects = groupManager.GetGroupDataOf(groupName, "Subjects");
                        if (subjects.Equals("This group doesn't have any subjects"))
                            Console.WriteLine(subjects);
                        else
                        {
                            Console.WriteLine(subjects);
                            string subjectName = InteractorWithUser.SetSubjectName();


                            string firstName = InteractorWithUser.SetFirstName();
                            string lastName = InteractorWithUser.SetLasttName();

                            if (studentsManager.IsStudentExist(groupName, firstName, lastName, groupManager))
                                Console.WriteLine('\n' + LearningProcessManager.GetGradesInTheSubject(groupName, firstName, lastName, subjectName, groupManager));
                            else
                                Console.WriteLine($"There is no student named {firstName} {lastName}");
                        }
                    }
                    else
                        Console.WriteLine($"There is no group named {groupName}");
                }
                else if (option == 8)
                {
                    Console.WriteLine('\n' + LearningProcessManager.GetGPAofAllStudent(groupManager));
                }
                else if (option == 9)
                {
                    string subjectName = InteractorWithUser.SetSubjectName();
                    List<string> info = LearningProcessManager.GetGradesInTheSubjectOfAllStudents(subjectName, groupManager); 

                    foreach (string s in info)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (option == 10)
                {
                    List<string> info = LearningProcessManager.GetGradesOfAllStudents(groupManager);

                    foreach (string s in info)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (option == 11)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    if (groupManager.IsGroupExist(groupName) == false)
                        Console.WriteLine($"There is no group named {groupName}");
                    else
                    {
                        string firstName = InteractorWithUser.SetFirstName();
                        string lastName = InteractorWithUser.SetLasttName();

                        Console.WriteLine('\n' + LearningProcessManager.GetGrades(groupName, firstName, lastName, groupManager));
                    }
                    
                    
                }

                else if (option == 0)
                    end = true;
            }
        }

        private void WorkWithSearcher()
        {
            bool end = false;
            

            while (end == false)
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                Console.WriteLine("\tWhat do you want to do?");
                Console.WriteLine("\n1. Find student by first and last name\n2. Find students of group\n3. Find students by GPA\n4. Find successful students\n5. Find successful students in subject\n6. Find unsuccessful students\n7. Find unsuccessful students in subject\n0. Exit");
                
                int option = -1;
                while (option == -1)
                {
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        if ((option < 0) | (option > 7))
                        {
                            throw new Exception("Please, input only digital (0-7):");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please, input only digital (0-7):");
                    }
                }

                if (option == 1)
                {
                    string firstName = InteractorWithUser.SetFirstName();
                    string lastName = InteractorWithUser.SetLasttName();
                    Console.WriteLine(SearchEngine.GetStudentDataByFirstAndLastName(firstName, lastName, groupManager.Groups));
                }

                else if (option == 2)
                {
                    string groupName = InteractorWithUser.SetGroupName();
                    List<string> students = SearchEngine.GetAllStudenstInGroup(groupName, groupManager);

                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 3)
                {
                    Console.WriteLine("Write GPA:");

                    float gpa = -1;
                    while (gpa == -1)
                    {
                        try
                        {
                            gpa = float.Parse(Console.ReadLine());
                            if ((gpa < 0) | (gpa > 5))
                            {
                                throw new Exception("Please, input only digital (0-5):");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    List<string> students = SearchEngine.GetAllStudentsByGPA(gpa, groupManager);
                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 4)
                {
                    List<string> students = SearchEngine.GetAllSuccessfulStudents(groupManager);

                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 5)
                {
                    string subjectName = InteractorWithUser.SetSubjectName();
                    List<string> students = SearchEngine.GetAllSuccessfulStudentsBySubject(subjectName, groupManager.Groups);

                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 6)
                {
                    List<string> students = SearchEngine.GetAllUnSuccessfulStudents(groupManager.Groups);

                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 7)
                {
                    string subjectName = InteractorWithUser.SetSubjectName();
                    List<string> students = SearchEngine.GetAllUnSuccessfulStudentsBySubject(subjectName, groupManager.Groups);

                    foreach (string s in students)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (option == 0)
                    end = true;
            }
        }

        private void PrintStartMenu()
        {
            Console.WriteLine("1. Work with Groups\n" +
                "2. Work with Students\n" +
                "3. Work with Learning process\n" +
                "4. Search\n" +
                "0. Exit" );
        }
    }
}
