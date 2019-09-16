using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceImplemantation
{
    interface ICalculator
    {
        double Add();
        double Subtract();
        double Multiply();
        double Divide();
    }

    interface ITaxCalculator
    {
        double Add();
        double Subtract();
    }

    //class Calculator : ICalculator
    //{
    //    // The methods of the ICalculator interface return test data in this code.
    //    #region ICalculator Members
    //    public double Add()
    //    {
    //        return 0;
    //    }
    //    public double Subtract()
    //    {
    //        return 0;
    //    }
    //    public double Multiply()
    //    {
    //        return 0;
    //    }
    //    public double Divide()
    //    {
    //        return 0;
    //    }
    //    #endregion
    //}


    class Calculator : ICalculator, ITaxCalculator
    {
        private double calculatedValue;
        private double taxAmount;
        // private fields not shown...
        double ICalculator.Add()
        {
            return 0;
        }
        double ICalculator.Subtract()
        {
            return 0;
        }
        double ICalculator.Multiply()
        {
            return 0;
        }
        double ICalculator.Divide()
        {
            return 0;
        }
        double ITaxCalculator.Add()
        {
            return calculatedValue + taxAmount;
        }
        double ITaxCalculator.Subtract()
        {
            return calculatedValue - taxAmount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator clc = new Calculator();
            ICalculator clc1 = clc;
            clc1.Add();
            ITaxCalculator clcx = clc;
        }
    }
}
