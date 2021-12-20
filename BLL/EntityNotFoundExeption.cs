using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EntityNotFoundExeption : Exception
    {
        public EntityNotFoundExeption(string message) : base (message)
        { }
    }
}
