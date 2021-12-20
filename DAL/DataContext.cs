using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext<T> : IDataContext<T>
    {
        public string Path { get; private set; }
        public IDataProvider<T> DataProvider { get; set; }

        public T Data { get; set; }

        public DataContext(string path)
        {
            Path = path;
        }

        public T GetData()
        {
            DataProvider = new XMLDataProvider<T>();
            Data = DataProvider.Read(Path);
            return Data;
        }

        public void SetData(T data)
        {
            DataProvider = new XMLDataProvider<T>();
            DataProvider.Write(data, Path);
        }
    }
}
