using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class XMLDataProvider<T>: IDataProvider<T>
    {
        public T Read(string path)
        {
            T data;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    data = (T)xmlSerializer.Deserialize(fs);
                }
            }
            catch
            {
                data = default(T);
            }
            return data;
        }

        public void Write(T data, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
                xmlSerializer.Serialize(fs, data);
            }
        }
    }
}
