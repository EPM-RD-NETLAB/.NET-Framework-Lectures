using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Customer> customers = new[]
                 {
                     new Customer {FirstName = "Luka", LastName = "Abrus", Age = 41,CompanyName = "Contoso"},
                     new Customer {FirstName = "Syed", LastName = "Abbas", Age = 23,CompanyName  = "Contoso"},
                     new Customer {FirstName = "Keith", LastName = "Harris", Age = 59,CompanyName = "Fabrikam"},
                     new Customer {FirstName = "Keith", LastName = "Harris", Age = 59,CompanyName = "Fabrikam"},
                     new Customer {FirstName = "David", LastName = "Pelton", Age = 25,CompanyName = "Contoso"},
                     new Customer {FirstName = "John", LastName = "Peoples", Age = 37,CompanyName = "Fabrikam"},
                     new Customer {FirstName = "Toni", LastName = "Poe", Age = 29,CompanyName = "Fabrikam"},
                     new Customer {FirstName = "Jeff", LastName = "Price", Age = 74,CompanyName = "Contoso"}
                 };

            IEnumerable<Company> companies = new[]
                 {
                     new Company {CompanyName = "Contoso", Country = "United Kingdom"},
                     new Company {CompanyName = "Fabrikam", Country = "United States"}
                 };

            //List<string> customerLastNames = new List<string>();
            //foreach (Customer customer in customers)
            //{
            //    customerLastNames.Add(customer.LastName);
            //}


            //Using the Select Extension Method
            IEnumerable<string> customerLastNames = customers.Select(cust => cust.LastName);
            //Using the Query Operator
            //IEnumerable<string> customerLastNames = from cust in customers select cust.LastName; 

            foreach (string name in customerLastNames)
            {
                Console.WriteLine(name);
            }

            //Using the Select Extension Method with Anonymous Types
            var customerNamesAnonim = customers.Select(cust => new { First = cust.FirstName, Last = cust.LastName });
            //Using the Query Operator with Anonymous Types
            //var customerNamesAnonim = from cust in customers select new { First = cust.FirstName, Last = cust.LastName };

            foreach (var customer in customerNamesAnonim)
            {
                Console.WriteLine("{0} {1}", customer.First, customer.Last);
            }

            //Using the Where Extension Method
            var customerOver25 = customers.Where(cust => cust.Age > 25).Select(cust => cust.LastName);
            //Using the Query Operator 
            //var customerOver25 = from cust in customers
            //                     where cust.Age > 25
            //                     orderby cust.Age
            //                     select new { first = cust.LastName, age = cust.Age };

            //Using the OrderBy and OrderByDescending Extension Methods
            //var sortedCustomers = customers.OrderBy(cust => cust.FirstName);
            //var sortedCustomers = customers.OrderByDescending(cust => cust.FirstName);
            //var sortedCustomers = customers.OrderBy(cust => cust.FirstName).ThenBy(cust => cust.Age);
            //var sortedCustomers = customers.OrderByDescending(cust => cust.FirstName).ThenByDescending(cust => cust.Age);

            //Performing Aggregate Calculations
            Console.WriteLine("Count:{0}\t\tAverage age:{1}\t\tLowest:{2}\t\tHighest:{3}",
                customers.Count(), customers.Average(cust => cust.Age),
                customers.Min(cust => cust.Age), customers.Max(cust => cust.Age));

            //Grouping Data
            var customersGroupedByAgeRange = customers.GroupBy(cust =>
            {
                if (cust.Age < 20)
                    return "age < 20";
                if (cust.Age >= 20 && cust.Age < 40)
                    return "age >= 20 and < 40";
                if (cust.Age >= 40 && cust.Age < 60)
                    return "age >= 40 and < 60";
                if (cust.Age >= 60)
                    return "age >= 60";
                return "Error";
            });

            foreach (var cust in customersGroupedByAgeRange.OrderBy(cust => cust.Key))
            {
                Console.WriteLine("{0}\t\t{1}", cust.Key, cust.Count());
                foreach (Customer customer in cust)
                {
                    Console.WriteLine(customer.FirstName);
                }
            }

            //Eliminating Duplicates in Aggregate Calculations
            Console.WriteLine("{0}", customers.Select(cust => cust.Age).Count());
            Console.WriteLine("{0}", customers.Select(cust => cust.Age).Distinct().Count());

            //Joining Data from Different Data Sets
            var customersAndCompanies = customers.Join(companies,
                custs => custs.CompanyName,
                comps => comps.CompanyName,
                (custs, comps) => new { custs.FirstName, custs.LastName, comps.Country });//.OrderByDescending(cust=>cust.FirstName);
            foreach (var item in customersAndCompanies)
            {
                Console.WriteLine(item);
            }

            //Join extension method example
            var customersAndCountries = customers.Join(companies,
                cust => cust.CompanyName,
                comp => comp.CompanyName,
                (cust, comp) => new { cust.FirstName, cust.LastName, comp.Country });

            //join query operator example
            var customersAndCountries1 = from cust in customers
                                         join comp in companies on cust.CompanyName
                                         equals comp.CompanyName
                                         select new { cust.FirstName, cust.LastName, comp.Country };

            var customerCount = (from cust in customers select cust).Count();

            var maxAge = (from cust in customers select cust.Age).Max();

            var minAge = (from cust in customers select cust.Age).Min();

            var possibleAges = (from cust in customers select cust.Age).Distinct();

            //var usCompanies = from a in companies where String.Equals(a.Country, "United States") select a.CompanyName;
            //foreach (string name in usCompanies)
            //{
            //    Console.WriteLine(name);
            //}

            var usCompanies = from a in companies.ToList()
                              where String.Equals(a.Country, "United States")
                              select a.CompanyName;
        }
    }
}
