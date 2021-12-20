using System;
using System.Collections.Generic;

namespace BLL
{
    public class Student
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string IdentificationCode { get;  set; }
        public string Sex { get;  set; }
        public int Course { get;  set; }
        public string StudentID { get;  set; }

        private float gpa;
        public float GPA
        {
            get
            {
                CalculateGPA();
                return gpa;
            }
        }

        public List<Subject> Subjects { get; set; }

        public Student()
        { }
        public Student(string firstName, string lastName, string sex, string identificationCode, int course, string studentID, List<string> subjectsName)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            IdentificationCode = identificationCode;
            Course = course;
            StudentID = studentID;
            Subjects = new List<Subject>();

            foreach (string subject in subjectsName)
            {
                Subjects.Add(new Subject(subject));
            }
        }

        public Student(string firstName, string lastName, string sex, string identificationCode, int course, string studentID, List<string> subjectsNameInGroup, List<Subject> subjectsOfStudent)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            IdentificationCode = identificationCode;
            Course = course;
            StudentID = studentID;
            Subjects = new List<Subject>();

            foreach (string subject in subjectsNameInGroup)
            {
                foreach(Subject s in subjectsOfStudent)
                {
                    if (s.Name.Equals(subject))
                        Subjects.Add(s);
                    else
                        Subjects.Add(new Subject(subject));
                }
                
            }
        }

        public void CalculateGPA()
        {
            float gpaOfSubjects = 0;
            int countOfSubjects = 0;
            foreach (Subject s in Subjects)
            {
                s.CalculateGPA();
                countOfSubjects++;
                gpaOfSubjects += s.GPA;
            }

            if (countOfSubjects == 0)
                gpa = 0;
            else
                gpa = (float)gpaOfSubjects / countOfSubjects;
        }
    }
}
