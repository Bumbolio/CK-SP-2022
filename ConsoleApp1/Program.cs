using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            using (var reader = new StreamReader(@"data/people.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                people = csv.GetRecords<Person>().ToList();
            }


            string userInput = "";

            do
            {
                AddPerson(people);
                Console.WriteLine("To exit, type \"exit\" or just hit enter to add another person. ");
                userInput = Console.ReadLine();
            } while (userInput != "exit");


            people.ForEach((person) => 
            {
                Console.WriteLine(person.FullName);
            });
        }

        static void AddPerson(List<Person> people)
        {
            Console.WriteLine("Please enter a first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please enter a last name:");
            var lastName = Console.ReadLine();

            Person person = new Person()
            {
                FirstName = firstName,
                LastName = lastName
            };

            people.Add(person);
        }

    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
