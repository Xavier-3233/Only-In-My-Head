using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project598
{
    public class Tiles
    {
        int _tileWidth, _tileHeight, _mapWidth, _mapHeight;

        Texture2D _MapTexture;

        Rectangle[] _tiles;

        int[] _map;

        string _filename;

        public Tiles(string filename)
        {
            _filename = filename;
        }


    }
}
