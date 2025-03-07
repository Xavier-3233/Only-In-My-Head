using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public class TileMapData
    {
        public int compressionLevel;
        public int height { get; set; }
        bool infinite;
        List<int> data;
        int nextLayerid;
        int nextObjectid;
        string orientation;
        string renderoder;
        int tileHeight;
        int tileWidth;

    }
}
