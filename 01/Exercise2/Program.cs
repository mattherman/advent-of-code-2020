using System;
using System.IO;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenses = File.ReadAllLines(args[0]);

            for (int i = 0; i < expenses.Length; i++)
            {
                var firstValue = int.Parse(expenses[i]);
                for (int j = i + 1; j < expenses.Length; j++)
                {
                    var secondValue = int.Parse(expenses[j]);
                    for (int k = j + 1; k < expenses.Length; k++)
                    {
                        var thirdValue = int.Parse(expenses[k]);
                        if (firstValue + secondValue + thirdValue == 2020)
                        {
                            Console.WriteLine(firstValue * secondValue * thirdValue);
                            Environment.Exit(0);
                        }
                    }
                    
                }
            }
        }
    }
}
