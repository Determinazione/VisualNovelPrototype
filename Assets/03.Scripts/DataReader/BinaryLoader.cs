using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace PlayerProgress
{
    public class BinaryLoader<T> : IDataLoader<T> where T : class
    {
        public T LoadDataFromFiles(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream readStream = new FileStream(path, FileMode.Open))
            {
                T data = default(T);
                Type typeOfData = data.GetType();
                SequenceTypelengthAttribute lengthAttribute =
                    (SequenceTypelengthAttribute) Attribute.GetCustomAttribute(typeOfData, typeof(SequenceTypelengthAttribute));
                try
                {
                    data = binaryFormatter.Deserialize(readStream) as T;
                }
                catch (FileNotFoundException e)
                {

                }
                finally
                {
                    readStream.Close();
                }
                return data;
            }
        }
    }
}
