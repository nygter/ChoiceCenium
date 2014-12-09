using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choice.Cenium.HotelImportJob
{
    public class ReadFile<T> where T : new()
    {
        public delegate void GetLine(string[] a, T newPos);

        protected static List<T> ReadStream(Stream stream, GetLine getLine)
        {
            {
                var retList = new List<T>();

                TextReader tr = new StreamReader(stream, new UTF8Encoding(true), true);

                // Leave the first line
                tr.ReadLine();

                string readLine;
                while ((readLine = tr.ReadLine()) != null)
                {
                    var a = readLine.Split(new[] { ';' });

                    // Find 
                    var line = new T();
                    try
                    {
                        getLine(a, line);
                        retList.Add(line);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Unreadable line:" + readLine);
                    }

                }
                tr.Close();

                return retList;
            }
        }
    }
}
