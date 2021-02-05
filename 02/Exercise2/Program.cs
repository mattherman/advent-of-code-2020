using System;
using System.IO;
using System.Linq;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(args[0]);
            var validPasswordCount = 0;
            foreach (var line in lines) {
                var lineParts = line.Split(" ");
                var positionParts = lineParts[0].Split("-");
                var firstPosition = int.Parse(positionParts[0]);
                var secondPosition = int.Parse(positionParts[1]);
                var character = lineParts[1][0];
                var password = lineParts[2];
                var characterCount = password.ToCharArray().Count(c => c == character);
                if (password[firstPosition-1] == character ^ password[secondPosition-1] == character) validPasswordCount++;
            }
            Console.WriteLine(validPasswordCount);
        }
    }
}
