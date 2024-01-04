using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.ThirdDay
{
    public static class ThirdDay
    {
        public static void Execute()
        {
            var rows = File.ReadAllLines(".\\ThirdDay\\InputData.txt").ToList();
            List<string> numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            List<char> chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            int columnsPosition = 0;
            int rowPosition = 0;
            foreach (var row in rows)
            {
                var charRow = row.ToCharArray();




                var indexOfFirstNumber = row.IndexOfAny(chars.ToArray());
                if (indexOfFirstNumber != -1)
                {
                    columnsPosition = indexOfFirstNumber;
                    rowPosition++;
                }
                else
                {
                    columnsPosition++;
                }


                // var result = numbers.Any(row.In);
            }
        }
    }
}
