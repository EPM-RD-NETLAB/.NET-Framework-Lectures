using System;

namespace CreatingAnAbstractClassDemo
{
    class Program
    {
        abstract class Television
        {

            public void TurnOn()
            {
                Console.WriteLine("Television on.");
            }

            public void TurnOff()
            {
                Console.WriteLine("Television off.");
            }

            public abstract void IncreaseVolume();

            public abstract void DecreaseVolume();
        }

        class WidescreenTV : Television
        {
            public override void IncreaseVolume()
            {
                Console.WriteLine("Volume increased (WidescreenTV).");
            }

            public override void DecreaseVolume()
            {
                Console.WriteLine("Volume decreased (WidescreenTV).");
            }
        }

        class TV : Television
        {
            public override void IncreaseVolume()
            {
                Console.WriteLine("Volume increased (TV).");
            }

            public override void DecreaseVolume()
            {
                Console.WriteLine("Volume decreased (TV).");
            }
        }

        static void Main(string[] args)
        {
            WidescreenTV tv = new WidescreenTV();
            tv.TurnOn();
            tv.IncreaseVolume();
            tv.DecreaseVolume();
            tv.TurnOff();
            TV tv2 = new TV();
            tv2.TurnOn();
            tv2.IncreaseVolume();
            tv2.DecreaseVolume();
            tv2.TurnOff();
            Console.ReadLine();
        }
    }
}