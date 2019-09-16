using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispose_Demo
{
    class Employee : IDisposable
    {
        bool _isDisposed = false;
        string name;

        public Employee(string Name)
        {
            name = Name;
        }

        public void PaySalary()
        {
            if (!_isDisposed)
            {
                Console.WriteLine("Employee {0} paid.", name);
            }
            else
            {
                throw new ObjectDisposedException("Employee already disposed.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool IsDisposing)
        {
            if (IsDisposing)
            {
                _isDisposed = true;
                Console.WriteLine("Employee object disposed.");
            }
            GC.SuppressFinalize(this);
        }
    }
}
