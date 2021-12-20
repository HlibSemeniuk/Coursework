using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Group
    {
        public List<Student> Students { get; set; }
        public string Name { get; set; }

        private int course;
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                if (Students != null)
                {
                    foreach (Student student in Students)
                    {
                        student.Course = value;
                    }
                }
                
            }
        }

        public int CountOfStudents { get; set; }
        public List<string> SubjectsName { get; set; }

        public Group()
        { }
        public Group(string groupName, int course)
        {
            Name = groupName;
            Course = course;
            Students = new List<Student>();
            SubjectsName = new List<string>();
        }


    }
}
