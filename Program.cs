/*
    Map generation starts from SW
    Then goes east, up, and north

    Map is 64*64*64 except the outer most blocks will not show up in game effectively making it just a 62*62*62 grid

    Blocks:
    0: Air
    1: Dirt
    2: Ore
    3: Gold
    4: Diamond?
    5: Basalt
    6: Ladder
    7: Explosive block
    8: Jump block
    9: Shock block
    10: Ore bank (Red)
    11: Ore bank (Blue)
    12: Beacon (Red)
    13: Beacon (Blue)
    14: Road
    15: Solid Block (Red)
    16: Solid Block (Blue)
    17: Metal
    18: "Dig here!" dirt
    19: Lava
    20: Force field block (Red)
    21: Force field block (Blue)
*/

namespace Infiniminer_map_maker
{
    internal class Program
    {
        public const Int32 MapSize = 62;

        public const Int32 RowSize = MapSize;
        public const Int32 PlaneSize = MapSize * MapSize;
        public const Int32 MaxSize = MapSize * MapSize * MapSize;

        static void Main()
        {
            Grid grid = new Grid(MapSize, MapSize, MapSize);

            Cell bank = new Cell(10, 0);
            Cell air = new Cell(0, 0);

            for (Int32 x = 0; x < MapSize; x++)
            {
                for (Int32 z = 0; z < MapSize; z++)
                {
                    grid[x, 60, z] = new Cell(1, 0);
                }
            }

            for (Int32 i = 0; i < 22; i++)
            {
                if (i == 19) continue;
                grid[i, 61, 0] = new Cell(i, 0);
            }

            File.Delete(@"D:\.Programmas\Program Files (x86)\Zachtronics Industries\Infiniminer\maps\generated");
            File.WriteAllLines(@"D:\.Programmas\Program Files (x86)\Zachtronics Industries\Infiniminer\maps\generated", grid.To64Grid().ToLines());
        }

        static Cell[] Repeat(Cell block, Int32 times)
        {
            return Enumerable.Repeat(block, times).ToArray();
        }
    }
}
