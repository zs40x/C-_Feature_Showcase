using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            PowerOf2Example();
            
            InstanceSubsetExampe();
        }
        
        
        /*
            Example 1: Power of 2
        */
        private static void PowerOf2Example()
        {
            var numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            
            foreach (var number in GetPowersOf2( numbers ))
            {
                Console.WriteLine(number);
            }
        }
        
        private static IEnumerable<int> GetPowersOf2(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if(number % 2 == 0)
                {
                    yield return number;
                }
            }
        }  
        
        
        /*
            Example 2: Return a subset of objects using yield return
        */
        private static void InstanceSubsetExampe()
        {
            var persons = new List<Person>() { new Person(15, "Carl"), new Person(20, "Dan"), new Person(25, "Mitchell") };
            
            foreach (var adultPerson in GetAdults(persons))
            {
                Console.WriteLine(adultPerson);
            }
        }
        
        private static IEnumerable<Person> GetAdults(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                if(person.Age >= 18)
                {
                    yield return person;
                }
            }
        }
        
    }
    
    class Person
    {
        public int Age { get; }
        public string Name { get; }
        
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        
        public override string ToString()
        {
            return $"{ Name }: { Age }";
        }
    }
}
