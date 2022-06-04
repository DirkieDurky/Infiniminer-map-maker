using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniminer_map_maker
{
    internal class Cell
    {
        public Int32 Blocktype;
        public Int32 Blockdata;

        public Cell(Int32 blocktype, Int32 blockdata)
        {
            Blocktype = blocktype;
            Blockdata = blockdata;
        }

        public override String ToString()
        {
            return $"{Blocktype},{Blockdata}";
        }
    }
}
