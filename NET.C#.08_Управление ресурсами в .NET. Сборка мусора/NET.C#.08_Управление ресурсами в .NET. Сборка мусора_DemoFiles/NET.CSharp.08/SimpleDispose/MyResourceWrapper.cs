using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDispose
{
    class MyResourceWrapper : IDisposable
    {
        public void Dispose()
        {
            // Освобождение неуправляемых ресурсов. . . 

            // Избавление от других содержащихся внутри 
            //и пригодных для очистки объектов. 

            // Только для целей тестирования. 
            Console.WriteLine("***** In Dispose! *****");
        }
    }
}
