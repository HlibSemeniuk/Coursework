using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IDataProvider<T>
    {
        void Write(T data, string path);
        T Read(string path);
    }
}
