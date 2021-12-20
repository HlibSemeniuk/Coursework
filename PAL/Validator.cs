using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Validator
    {
        public static bool ValidateNames(string name)
        {
            if (name.All(Char.IsLetter))
                return true;
            else
                return false;
        }

        public static bool ValidateSex(string sex)
        {
            if (sex.Equals("MALE") || sex.Equals("FEMALE"))
                return true;
            else
                return false;
        }

        public static bool ValidateIDCode(string identificationCode)
        {
            if (identificationCode.All(Char.IsDigit) || identificationCode.Length == 10)
                return true;
            else
                return false;
        }

        public static bool ValidateStudentID(string studentID)
        {
            if (studentID.All(Char.IsDigit) || studentID.Length == 8)
                return true;
            else
                return false;
        }


    }
}
