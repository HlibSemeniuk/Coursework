using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class InteractorWithUser
    {
        public static string SetFirstName()
        {
            Console.WriteLine("\nWrite first name:");
            string firstName = Console.ReadLine();

            while (Validator.ValidateNames(firstName) == false)
            {
                Console.WriteLine("Incorect data. Please, writre first name (only letters):");
                firstName = Console.ReadLine();
            }

            DataHandler.ToCorrect(ref firstName);
            return firstName;
        }

        public static string SetLasttName()
        {
            Console.WriteLine("\nWrite last name:");
            string lastName = Console.ReadLine();

            while (Validator.ValidateNames(lastName) == false)
            {
                Console.WriteLine("Incorect data. Please, writre last name (only letters):");
                lastName = Console.ReadLine();
            }

            DataHandler.ToCorrect(ref lastName);
            return lastName;
        }

        public static string SetGroupName()
        {
            Console.WriteLine("Please, write group name(Upper case):");
            string groupName = Console.ReadLine();

            groupName = groupName.ToUpper();
            return groupName;
        }

        public static int SetCourse()
        {
            bool isCorrect = false;
            int course = 0;
            Console.WriteLine("Please, write course (one digit from 1 to 6):");
            do
            {
                try
                {
                    course = Int32.Parse(Console.ReadLine());

                    if (course < 1 || course > 6)
                        throw new Exception();

                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("Incorect data. Please, write course (one digit from 1 to 6)");
                }
            }
            while (isCorrect == false);

            return course;
        }

        public static string SetSex()
        {
            Console.WriteLine("\nWrite sex:");
            string sex = Console.ReadLine().ToUpper();
            while (Validator.ValidateSex(sex) == false)
            {
                Console.WriteLine("Incorect data. Please, writre sex (only letters):");
                sex = Console.ReadLine().ToUpper();
            }

            DataHandler.ToCorrect(ref sex);
            return sex;
        }

        public static string SetSubjectName()
        {
            Console.Write("\nWrite subject name:\n");
            string subjectName = Console.ReadLine();

            while (Validator.ValidateNames(subjectName) == false)
            {
                Console.WriteLine("Incorect data. Please, writre subject name (only letters):");
                subjectName = Console.ReadLine();
            }

            return subjectName;
        }

        public static string SetIdentificationCode()
        {
            Console.WriteLine("\nWrite identification code (10 digitals):");
            string identificationCode = Console.ReadLine();

            while (Validator.ValidateIDCode(identificationCode) == false)
            {
                Console.WriteLine("Incorect data. Please, write identification code (10 digitals):");
                identificationCode = Console.ReadLine();
            }

            return identificationCode;
        }

        public static string SetStudentID()
        {
            Console.WriteLine("\nWrite student ID (8 digitals):");
            string studentID = Console.ReadLine();

            while (Validator.ValidateStudentID(studentID) == false)
            {
                Console.WriteLine("Incorect data. Please, write student ID (8 digitals):");
                studentID = Console.ReadLine();
            }

            return studentID;
        }

        public static int SetGrade()
        {
            bool isCorrect = false;
            int grade = 0;
            Console.WriteLine("Please, write grade (one digit from 1 to 5):");
            do
            {
                try
                {
                    grade = Int32.Parse(Console.ReadLine());

                    if (grade < 1 || grade > 5)
                        throw new Exception();

                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("Incorect data. Please, write grade (one digit from 1 to 5)");
                }
            }
            while (isCorrect == false);

            return grade;
        }
    }
}
