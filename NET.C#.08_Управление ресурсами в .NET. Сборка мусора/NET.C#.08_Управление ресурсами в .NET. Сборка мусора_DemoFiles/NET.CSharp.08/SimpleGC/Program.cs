using System;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.GC *****");

            // Вывод подсчитанного количества байтов в куче. 
            //GC.GetTotalMemory - Возвращает информацию о том, какой объем памяти (в байтах) 
            //в настоящий момент занят в управляемой куче. Булевский параметр указывает,
            //должен ли вызов сначала дождаться выполнения сборки мусора, прежде чем возвращать результат 

            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // Отсчет для MaxGeneration начинается с нуля, поэтому для удобства добавляется 1. 
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());

            // Вывод информации о поколении объекта refToMyCar. 
            Console.WriteLine("\nGeneration of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

            // Принудительная активизация процесса сборки мусора 
            GC.Collect();
            // ожидание завершения финализации каждого из объектов. 
            GC.WaitForPendingFinalizers();

            // Создание большого количества объектов для целей тестирования. 
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();

            //во втором параметре метода Collect ()  может передаваться значение  
            //перечисления GCCollectionMode, которое позволяет более точно указать, каким образом 
            //исполняющая среда должна принудительно инициировать сборку мусора.(Default,Forced,Optimized)
            // Выполнение сборки мусора в отношении только объектов, относящихся к поколению 0. 
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            //GC.Collect(0, GCCollectionMode.Forced);
            // Вывод информации о поколении, к которому 
            // относится refToMyCar. 
            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
            GC.AddMemoryPressure(Int32.MaxValue);
            // Выполнение проверки, удалось ли tonsOfObjects[9000] уцелеть после сборки мусора. );
            if (tonsOfObjects[9000] != null)
            {
                // Вывод поколения tonsOfObjects [ 9000] . 
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                // tonsOfObjects[9000] больше не существует. 
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");

            // Вывод информации о том, сколько раз в отношении 
            // объектов каждого поколения выполнялась сборка мусора. 
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
            Console.ReadLine();
        }
    }
}
