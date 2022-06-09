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

        public static Grid Grid = new Grid(MapSize, MapSize, MapSize);

        static void Main(String[] args)
        {
            if (args.Length != 2)
            {
                return;
            }
            String path = args[0];
            String fileName = args[1];

            Cell air = new Cell(0, 0);
            Cell dirt = new Cell(1, 0);
            Cell ore = new Cell(2, 0);
            Cell gold = new Cell(3, 0);
            Cell diamond = new Cell(4, 0);
            Cell basalt = new Cell(5, 0);
            Cell ladder = new Cell(6, 0);
            Cell explosiveBlock = new Cell(7, 0);
            Cell tnt = explosiveBlock;
            Cell jumpBlock = new Cell(8, 0);
            Cell shockBlock = new Cell(9, 0);
            Cell oreBankRed = new Cell(10, 0);
            Cell oreBankBlue = new Cell(11, 0);
            Cell beaconRed = new Cell(12, 0);
            Cell beaconBlue = new Cell(13, 0);
            Cell road = new Cell(14, 0);
            Cell solidBlockRed = new Cell(15, 0);
            Cell solidBlockBlue = new Cell(16, 0);
            Cell metal = new Cell(17, 0);
            Cell digHereDirt = new Cell(18, 0);
            Cell lava = new Cell(19, 0);
            Cell forceFieldBlockRed = new Cell(20, 0);
            Cell forceFieldBlockBlue = new Cell(21, 0);

            for (Int32 i = 0; i < MapSize; i++)
            {
                for (Int32 j = 0; j < MapSize - 1; j++)
                {
                    for (Int32 k = 0; k < MapSize; k++)
                    {
                        Grid[k, j, i] = tnt;
                    }
                }
            }

            File.Delete(path + fileName);
            File.WriteAllLines(path + fileName, Grid.To64Grid().ToLines());
        }

        public void FillRow(Int32 column, Int32 aisle, Cell cell)
        {
            for (Int32 row = 0; row < MaxSize; row++)
            {
                Grid[row, column, aisle] = cell;
            }
        }

        public void FillColumn(Int32 row, Int32 aisle, Cell cell)
        {
            for (Int32 column = 0; column < MaxSize; column++)
            {
                Grid[row, column, aisle] = cell;
            }
        }

        public void FillAisle(Int32 row, Int32 column, Cell cell)
        {
            for (Int32 aisle = 0; aisle < MaxSize; aisle++)
            {
                Grid[row, column, aisle] = cell;
            }
        }

        public void FillPlaneX(Int32 x, Cell cell)
        {
            for (Int32 y = 0; y < MaxSize; y++)
            {
                for (Int32 z = 0; z < MaxSize; z++)
                {
                    Grid[x, y, z] = cell;
                }
            }
        }

        public void FillPlaneY(Int32 y, Cell cell)
        {
            for (Int32 x = 0; x < MaxSize; x++)
            {
                for (Int32 z = 0; z < MaxSize; z++)
                {
                    Grid[x, y, z] = cell;
                }
            }
        }

        public void FillPlaneZ(Int32 z, Cell cell)
        {
            for (Int32 x = 0; x < MaxSize; x++)
            {
                for (Int32 y = 0; y < MaxSize; y++)
                {
                    Grid[x, y, z] = cell;
                }
            }
        }

        public void FillField(Cell cell)
        {
            for (Int32 z = 0; z < MaxSize; z++)
            {
                for (Int32 y = 0; y < MaxSize; y++)
                {
                    for (Int32 x = 0; x < MaxSize; x++)
                    {
                        Grid[x, y, z] = cell;
                    }
                }
            }
        }

        static Cell[] Repeat(Cell block, Int32 times)
        {
            return Enumerable.Repeat(block, times).ToArray();
        }
    }
}
