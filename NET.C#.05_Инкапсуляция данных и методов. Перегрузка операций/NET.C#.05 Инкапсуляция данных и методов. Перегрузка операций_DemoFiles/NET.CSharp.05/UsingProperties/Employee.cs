using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingProperties
{
    class Employee
    {
        public string Name { get; set; }
        private int salary;
        public string Department { get; set; }

        public Employee(string Name)
        {
            this.Name = Name;
            // Set default values for properties not passed ot the constructor.
            Salary = 10000;
            Department = "Customer Service";
        }

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
                else
                {
                    salary = 0;
                }
            }
        }
        public override string ToString()
        {
            return String.Format("{0} earns ${1} and is in the {2} department.", Name, Salary.ToString(), Department.ToLower());
        }
    }
}
