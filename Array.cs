using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

String[] a = { "hello", "new", "string", "array" };

for (int i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);    
    if (a[i] == "string")

    { 
        Console.WriteLine("Match Found!");
        break;
    }    
}
