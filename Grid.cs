namespace Infiniminer_map_maker
{
    class Grid
    {
        private Cell[,,] Content;

        public Grid(Int32 xSize, Int32 ySize, Int32 zSize)
        {
            Content = new Cell[xSize, ySize, zSize];
            Populate();
        }

        public Cell this[int x, int y, int z]
        {
            get { return Content[x, y, z]; }
            set { Content[x, y, z] = value; }
        }

        private void Populate()
        {
            for (Int32 z = 0; z < Content.GetLength(0); z++)
            {
                for (Int32 y = 0; y < Content.GetLength(1); y++)
                {
                    for (Int32 x = 0; x < Content.GetLength(2); x++)
                    {
                        Content[x, y, z] = new Cell(0, 0);
                    }
                }
            }
        }

        public Grid To64Grid()
        {
            Grid newGrid = new Grid(64, 64, 64);

            for (Int32 z = 0; z < Content.GetLength(0); z++)
            {
                for (Int32 y = 0; y < Content.GetLength(1); y++)
                {
                    for (Int32 x = 0; x < Content.GetLength(2); x++)
                    {
                        newGrid[x + 1, y + 1, z + 1] = Content[x, y, z];
                    }
                }
            }

            // for (Int32 y = 0; y < Content.GetLength(1); y++)
            // {
            //     String line = "";
            //     for (Int32 x = 0; x < Content.GetLength(2); x++)
            //     {
            //         line += newGrid[x, y, 0].ToString();
            //     }
            //     Console.WriteLine(line);
            // }
            return newGrid;
        }

        public List<String> ToLines()
        {
            List<String> lines = new();

            for (Int32 z = 0; z < Content.GetLength(0); z++)
            {
                for (Int32 y = 0; y < Content.GetLength(1); y++)
                {
                    for (Int32 x = 0; x < Content.GetLength(2); x++)
                    {
                        lines.Add(Content[x, y, z].ToString());
                    }
                }
            }
            return lines;
        }
    }
}