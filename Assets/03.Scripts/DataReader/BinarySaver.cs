using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace PlayerProgress
{
    public class BinarySaver
    {
        const int ZERO_POSITION = 0;
        byte[] Header;
        byte[] Body;

        public BinarySaver()
        {
            Header = new byte[0];
            Body = new byte[0];
        }

        #region Add data to stream

        /// <summary>
        /// Append new data to the byte string which would be saved.
        /// </summary>
        /// <param name="data">The data that caller wish to save.</param>
        public void AddDataToWritingStream(object data)
        {
            if (data.GetType().IsSerializable)
            {
                WrapFileHeader(data.GetType().ToString());
                WrapFileBody(data);
            }
        }

        #endregion

        /// <summary>
        /// Receive a location from the caller ,then save the reserved data to indicated path.
        /// </summary>
        /// <param name="path">The location where the file would be saved in local file system.</param>
        public bool SaveDataToFiles(string path)
        {
            byte[] completedData = ConcatenateTwoByteArray(TransferObjectToByteArray(Header.Length), Header);
            completedData = ConcatenateTwoByteArray(completedData, Body);
            try
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    binaryWriter.Write(completedData);
                }
            }
            catch (IOException IOError)
            {
            }
            catch (ObjectDisposedException streamClosedException)
            {
            }
            return true;
        }

        public bool LoadDataFromFiles(string path)
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                byte[] something = binaryReader.Read();
            }

            using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] data = new byte[readStream.Length];
                int numBytesToRead = (int)readStream.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = readStream.Read(data, numBytesRead, numBytesToRead);
                    if (n == 0)
                    {
                        break;
                    }
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
            }
            return true;
        }

        /// <summary>
        /// Wrap the header which can make readers know how package's body was composed.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        private void WrapFileHeader(string type, int length = 1)
        {
            byte[] temporarySpace = new byte[0];
            temporarySpace = ConcatenateTwoByteArray(temporarySpace, TransferObjectToByteArray(length));
            temporarySpace = ConcatenateTwoByteArray(temporarySpace, TransferObjectToByteArray(type));
            Header = ConcatenateTwoByteArray(Header, temporarySpace);
        }

        private void WrapFileBody(object data)
        {
            Body = ConcatenateTwoByteArray(Body, TransferObjectToByteArray(data));
        }

        private byte[] TransferObjectToByteArray(object theObject)
        {
            if (theObject.GetType().IsSerializable)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, theObject);
                    return stream.ToArray();
                }
            }
            return new byte[ZERO_POSITION];
        }

        private object TransferByteArrayToObject(byte[] theByteArray)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(theByteArray, 0, theByteArray.Length);
                stream.Seek(0, SeekOrigin.Begin);
                var returnedObject = formatter.Deserialize(stream);
                return returnedObject;
            }
        }

        private byte[] ConcatenateTwoByteArray(byte[] first, byte[] second)
        {
            byte[] result = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, ZERO_POSITION, result, ZERO_POSITION, first.Length);
            Buffer.BlockCopy(second, ZERO_POSITION, result, first.Length, second.Length);
            return result;
        }
    }
}
