using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Subject
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        private float gpa;
        public float GPA
        {
            get
            {
                CalculateGPA();
                return gpa;
            }
        }

        public Subject()
        {
        }
        public Subject(string subjectName)
        {
            Name = subjectName;
            Grades = new List<int>();
        }

        public void CalculateGPA()
        {
            int grades = 0;
            int countOfGrades = 0;
            foreach (int grade in Grades)
            {
                countOfGrades++;
                grades += grade;
            }

            if (countOfGrades == 0)
                gpa = 0;
            else
                gpa = (float)grades / countOfGrades;
        }
    }
}
