using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Project598
{
    public class TileMapData
    {
        public int compressionLevel;
        public int Height { get; set; }
        public int Width { get; set; }

        public int[,] Data { get; set; }

        
        public int tileheight;
        public int tilewidth;
        private string sourceTileSet;
        private string sourceMap;
        private string _filename;
        //public List<Tile>


        public TileMapData(string filename)
        {
            _filename = filename;
        }
        public void LoadContent(ContentManager content)
        {
            string dataMap = File.ReadAllText(Path.Join(content.RootDirectory, _filename));
            var tilemapData = JsonConvert.DeserializeObject<MapData>(dataMap);

            var firstLayer = tilemapData.layers[0];
            int index;
            Data = new int[tilemapData.height, tilemapData.width];
            for(int i = 0; i < firstLayer.height; i++)
            {
                for(int j = 0; j < firstLayer.width; j++)
                {
                    index = i * firstLayer.width + j;
                    Data[i, j] = firstLayer.data[index];
                }
            }
            

            Height = tilemapData.height;

            Width = tilemapData.width;
        }

        public class MapLayer
        {
            public int[] data { get; set; }
            public int height { get; set; }

            public int width { get; set; }
        }

        public class MapData
        {
            public List<MapLayer> layers { get; set; }
            public int width { get; set; }

            public int height { get; set; }
        }
    }
}
