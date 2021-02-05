using System;
using System.IO;
using System.Linq;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(args[0]);
            var validPasswordCount = 0;
            foreach (var line in lines) {
                var lineParts = line.Split(" ");
                var rangeParts = lineParts[0].Split("-");
                var min = int.Parse(rangeParts[0]);
                var max = int.Parse(rangeParts[1]);
                var character = lineParts[1][0];
                var password = lineParts[2];
                var characterCount = password.ToCharArray().Count(c => c == character);
                if (characterCount >= min && characterCount <= max) validPasswordCount++;
            }
            Console.WriteLine(validPasswordCount);
        }
    }
}
