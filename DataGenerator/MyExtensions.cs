using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugu.Extensions
{
    public static class MyExtensions
    {
        public static void Write<T>(this IEnumerable<T> liste, 
            string header="*********************",
            string footer = "*********************")
        {
            Console.WriteLine(header);
            foreach(T elem in liste)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine(footer);
        }

    }
    
}
