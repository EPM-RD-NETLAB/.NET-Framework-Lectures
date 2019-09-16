using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicLINQ
{
    class TestScore
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TestScore> scores = new List<TestScore>()
                                         {
                                             new TestScore {Score = 90, Name = "Mike"},
                                             new TestScore {Score = 60, Name = "Louisa"},
                                             new TestScore {Score = 85, Name = "Antony"},
                                             new TestScore {Score = 100, Name = "Richard"},
                                             new TestScore {Score = 45, Name = "Jason"},
                                             new TestScore {Score = 35, Name = "Tom"},
                                             new TestScore {Score = 96, Name = "Chris"},
                                             new TestScore {Score = 26, Name = "Adam"},
                                             new TestScore {Score = 71, Name = "Charles"},
                                             new TestScore {Score = 91, Name = "Alison"},
                                             new TestScore {Score = 34, Name = "John"}
                                         };

            var passes1 = scores.Where(testResult => testResult.Score > 50).
                OrderBy(testResult => testResult.Name).
                Select(testResult => testResult.Name);

            // Run the query and display the results.
            foreach (var pass in passes1)
            {
                Console.WriteLine(pass);
            }
            Console.WriteLine("==========================================");
            Console.WriteLine("Compiling and Running a Dynamic LINQ Query");
            Console.WriteLine("==========================================");
            /* The following code generates a LINQ query that is equivalent
                to the following:

            var passes = scores.Where(testResult => testResult.Score > 50).
                OrderBy(testResult => testResult.Name).
                Select(testResult => testResult.Name);

            Note that this query involves three lambda expressions:
            1. The lambda expression for the Where method takes a TestScore
               object and returns a Boolean value.
            2. The lambda expression for the OrderBy method takes a TestScore
               object and returns a string (the data to order by).
            3. The lambda expression for the Select method takes a TestScore
               object and returns a string (the candidate names). 
             */

            // Build the lambda expression for the Where method: testResult => testResult.Score > 50
            Type testScoreType = typeof(TestScore);

            ParameterExpression testResultParam = Expression.Parameter(testScoreType, "testResult");
            MemberInfo scoreProperty = testScoreType.GetProperty("Score");
            MemberExpression valueInScoreProperty = Expression.MakeMemberAccess(testResultParam, scoreProperty);
            ConstantExpression fifty = Expression.Constant(50, typeof(int));
            BinaryExpression scoreGreaterThanFifty = Expression.GreaterThan(valueInScoreProperty, fifty);

            Expression<Func<TestScore, bool>> whereExpression =
                Expression<Func<TestScore, bool>>.Lambda<Func<TestScore, bool>>(scoreGreaterThanFifty, testResultParam);

            // Build the lambda expression for the OrderBy method: testResult => testResult.Name

            MemberInfo nameProperty = testScoreType.GetProperty("Name");
            MemberExpression valueInNameProperty = Expression.MakeMemberAccess(testResultParam, nameProperty);

            Expression<Func<TestScore, string>> orderByExpression =
                Expression<Func<TestScore, string>>.Lambda<Func<TestScore, string>>(valueInNameProperty, testResultParam);

            // Build the lambda expression for the Select method: testResult => testResult.Name

            Expression<Func<TestScore, string>> selectExpression =
                Expression<Func<TestScore, string>>.Lambda<Func<TestScore, string>>(valueInNameProperty, testResultParam);



            // Compile the lambda expressions, starting with the Where expression.
            IEnumerable<TestScore> passingScores = scores.Where(whereExpression.Compile());

            // Now append the OrderBy expression.
            passingScores = passingScores.OrderBy(orderByExpression.Compile());

            // Finally, add the Select expression.
            IEnumerable<string> passes = passingScores.Select(selectExpression.Compile());

            // Run the query and display the results.
            foreach (var pass in passes)
            {
                Console.WriteLine(pass);
            }

            Console.ReadLine();
        }
    }
}
