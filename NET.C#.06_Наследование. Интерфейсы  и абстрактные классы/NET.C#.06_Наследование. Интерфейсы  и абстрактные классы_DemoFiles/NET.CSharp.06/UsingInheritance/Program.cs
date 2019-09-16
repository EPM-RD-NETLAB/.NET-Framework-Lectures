using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingInheritance
{
    internal class B
    {
        // Base class
    }

    internal class D : B
    {
        // Derived class
    }

    #region Employee
    // Base class
    // This type is implicitly derived from System.Object.
    class Employee // : System.Object
    {
        protected string empNum;
        protected string empName;

        public void DoWork()
        {
            //TODO
        }

        virtual public void Do()
        {
            //TODO
        }

        public virtual string GetTypeName()
        {
            return "This is Employee";
        }
    }
    // Inheriting classes
    class Manager : Employee
    {
        public void DoManagementWork()
        {
            //TODO
        }

        public override void Do()
        {
            //TODO
        }

        public override string GetTypeName()
        {
            return "This is Manager";
        }
    }

    class ManualWorker : Employee
    {
        public void DoManualWork()
        {
            //TODO
        }

        public override void Do()
        {
            //TODO
        }

        public override string GetTypeName()
        {
            return "This is ManualWorker";
        }
    }
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            Object o1 = new Object();
            Object o2 = new B();
            Object o3 = new D();
            Object o4 = o3;
            B b1 = new B();
            B b2 = new D();
            D d1 = new D();
            //B b3 = new Object();  //CTE
            //D d2 = new Object();  //CTE
            B b4 = d1;
            //D d3 = b2;            //CTE
            D d4 = (D)d1;
            D d5 = (D)b2;
            //D d6 = (D)b1;           // RTE Throws InvalidCastException
            //B b5 = (B)o1;           // RTE Throws InvalidCastException
            B b6 = (D)b2;

            // No cast needed since new returns an Employee object
            // and Object is a base type of Employee.

            Object o = new Employee();
            // Cast required since Employee is derived from Object.
            Employee e = (Employee)o;

            // Construct a Manager object and pass it to PromoteEmployee.
            // a Manager is a an Object: PromoteEmployee runs OK.
            Manager m = new Manager();
            PromoteEmployee(m);

            // Construct a DateTime object and pass it to PromoteEmployee.
            // a DateTime is NOT derived from Employee. PromoteEmployee 
            // throws a System.InvalidCastException exception. 
            DateTime newYears = new DateTime(2007, 1, 1);
            PromoteEmployee(newYears);
            PromoteEmployee2(newYears);
            PromoteEmployee3(newYears);


            Manager mng = new Manager();
            mng.DoWork();
            Employee emp = mng;
            emp.DoWork();
            emp.Do();
            Employee em = new Manager();
            em.Do();
            Console.WriteLine(mng.GetTypeName());
            Console.WriteLine(emp.GetTypeName());
            Console.WriteLine(em.GetTypeName());
        }

        public static void PromoteEmployee(Object o)
        {
            // At this point, the compiler doesn’t know exactly what
            // type of object o refers to. So the compiler allows the 
            // code to compile. However, at run time, the CLR does know 
            // what type o refers to (each time the cast is performed) and
            // it checks whether the object’s type is Employee or any type
            // that is derived from Employee.
            //Employee e = (Employee)o;
        }

        public static void PromoteEmployee2(Object o)
        {
            if (o is Employee)
            {
                Employee e = (Employee)o;
                // Use e within the remainder of the 'if' statement. 
            }
        }

        public static void PromoteEmployee3(Object o)
        {
            Employee e = o as Employee;
            if (e != null)
            {
                // Use e within the 'if' statement.
            }
        }
    }
}
