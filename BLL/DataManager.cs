using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataManager
    {
        private string path = @"C:\Users\user\Desktop\DataBase\Journal.xml";
        public void SetData(ref List<Group> groups)
        {
            DataContext<List<Group>> dataContext = new DataContext<List<Group>>(path);
            groups = dataContext.GetData();
        }

        public void WriteData(List<Group> groups)
        {
            DataContext<List<Group>> dataContext = new DataContext<List<Group>>(path);
            dataContext.SetData(groups);
        }
    }
}
