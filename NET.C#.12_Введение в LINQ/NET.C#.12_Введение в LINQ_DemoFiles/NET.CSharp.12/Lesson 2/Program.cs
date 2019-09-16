using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Lesson_1;
using Expressions = System.Linq.Expressions;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Прстроение динамических LINQ запросов и выражений

            Customer cst = new Customer() { Age = 23, CompanyName = "TTT", FirstName = "Ivan", LastName = "Ivanov" };

            ParameterExpression parametrExpression = Expression.Parameter(typeof(int), "t");
            ConstantExpression constantExpression = Expression.Constant(5, typeof(int));
            // Assume that expression1 and expression2 are expression tree objects.
            BinaryExpression myExp = Expression.Add(parametrExpression, constantExpression);

            // Assume that the propertyInfo object is a valid instance of the
            // MemberInfo class that references a field that the MyType type exposes.
            Type customerType = typeof(Customer);
            MemberInfo customerProperty = customerType.GetProperty("Age");
            ParameterExpression customerParam = Expression.Parameter(customerType, "ageParam");
            MemberExpression member = Expression.MakeMemberAccess(customerParam, customerProperty);
            ConstantExpression constantExpres = Expression.Constant(34, typeof(int));
            BinaryExpression ageGreaterThen34 = Expression.GreaterThan(member, parametrExpression);
            Console.WriteLine(ageGreaterThen34.ToString());
            // Assume that the propertyInfo object is a valid MemberInfo object
            // that references a static property of a type.
            //MemberExpression staticProperty = Expression.MakeMemberAccess(null, customerProperty);

            // Assume that the parameter is a valid ParameterExpression object.
            UnaryExpression negation = Expressions.Expression.Negate(parametrExpression);

            Expression<Func<int, bool>> lambda = null;
            ParameterExpression paramExpression = Expression.Parameter(typeof(int), "x");
            ConstantExpression two = Expression.Constant(2, typeof(int));
            BinaryExpression body = Expression.GreaterThan(paramExpression, two);
            lambda = Expression.Lambda<Func<int, bool>>(body, paramExpression);
            Console.WriteLine(lambda.ToString());

            //Type stringType = typeof(string);
            //ParameterExpression param = Expression.Parameter(stringType, "data");


            Type stringType = typeof(string);
            MemberInfo stringLength = stringType.GetProperty("Length");
            string data = "Hello, World!";
            MemberExpression length = Expression.MakeMemberAccess(Expression.Constant(data), stringLength);
            ConstantExpression maxLength = Expression.Constant(25);
            BinaryExpression compareLength = Expression.GreaterThanOrEqual(length, maxLength);
            Console.WriteLine(compareLength.ToString());

            Console.ReadLine();
        }
    }
}