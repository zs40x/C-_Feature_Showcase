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
        }
        
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
    }
}
