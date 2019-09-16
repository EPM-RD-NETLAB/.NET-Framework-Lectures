using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImplicitlyTypeVariables
{
    class ThisWillNeverCompile
    {
        // Ошибка! var не может применяться для определения полей! 
        //private var mylnt = 10;
        // Ошибка! var не может применяться для определения возвращаемого значения или типа параметра! 
        //public var MyMethod(var x, var y) { }

        static int GetAnIntValue()
        {
            var retVal = 9;
            return retVal;
        }
    }

    class Car { }

    public class Program
    {
        static void Main(string[] args)
        {
            // Неявно типизированные локальные переменные. 
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Вывод имен типов, лежащих в основе этих переменных. 
            Console.WriteLine("mylnt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);

            // Ошибка! Должно быть присвоено значение! 
            //var myData;
            // Ошибка! Значение должно присваиваться в самом объявлении* 
            //var mylnt;
            //mylnt = 0;
            // Ошибка! Присваивание null в качестве начального значения не допускается! 
            //var myObj = null;

            var myObj = (int?)null;
            myObj = 78;

            // Все в порядке, поскольку Car является переменной ссылочного типа! 
            var myCar = new Car();
            myCar = null;

            // Здесь тоже все в порядке! 
            var myInt2 = 0;
            var anotherInt = myInt;
            string myString2 = "Wake up!";
            var myData = myString;

            // Определять неявно типизированные переменные как допускающие значение null 
            // нельзя, поскольку таким переменным изначально не разрешено присваивать null! 
            //var? nope = new SportsCar();
            //var? stillNo = 12;
            //var? noWay = null;  
        }
    }
}
