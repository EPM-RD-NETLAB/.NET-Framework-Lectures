using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEHExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FormatDataForDisplay();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        #region Function A
        static void FormatDataForDisplay()
        {
            ProcessData();
        }
        #endregion

        #region Function B
        static void ProcessData()
        {
            GetFile();
        }
        #endregion

        #region Function C
        static void GetFile()
        {
            throw new IOException("Data File Data.txt was not found");
        }
        #endregion
    }
}