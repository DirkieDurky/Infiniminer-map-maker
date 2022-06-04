/*
    Map generation starts from SW
    Then goes east, up, and north
*/

using System;
using System.Linq;

namespace Infiniminer_map_maker
{
    internal class Program
    {
        static void Main()
        {
            const Int32 rowSize = 64;
            const Int32 planeSize = 64 * 64;
            const Int32 maxSize = 64 * 64 * 64;
            //Cell[] lines = new Cell[maxSize];
            List<Cell> lines = new List<Cell>();

            Cell bank = new Cell(10, 0);
            Cell air = new Cell(0, 0);

            // for (Int32 i = 0; i < 32; i++)
            // {
            //     for (Int32 j = 0; j < 2; j++)
            //     {
            //         lines.AddRange(Repeat(bank, 32));
            //         lines.AddRange(Repeat(air, 32));
            //     }
            //     for (Int32 j = 0; j < 62; j++)
            //     {
            //         lines.AddRange(Repeat(air, 64));
            //     }
            // }
            // for (Int32 i = 0; i < 32; i++)
            // {
            //     lines.AddRange(Repeat(air, 64 * 64));
            // }

            lines.AddRange(Repeat(bank, planeSize + rowSize + 1));

            FillRemainingCells();

            if (lines.Count != maxSize)
            {
                Console.WriteLine($"Wrong linecount! ({lines.Count}, should be {maxSize})");
            }
            else
            {
                File.Delete(@"D:\.Programmas\Program Files (x86)\Zachtronics Industries\Infiniminer\maps\generated");
                File.WriteAllLines(@"D:\.Programmas\Program Files (x86)\Zachtronics Industries\Infiniminer\maps\generated", lines.Select(line => line.ToString()));
            }

            void FillRemainingCells()
            {
                lines.AddRange(Repeat(air, maxSize - lines.Count));
            }
        }

        static Cell[] Repeat(Cell block, Int32 times)
        {
            return Enumerable.Repeat(block, times).ToArray();
        }
    }
}
