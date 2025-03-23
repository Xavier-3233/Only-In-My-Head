using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Runtime.CompilerServices;

namespace Project598
{
    public class TileSetData
    {
        private int _tilecount;

        private int _tileheight;

        private int _tileWidth;

        private string _filename;

        [JsonProperty("tiles")]
        public Tile[] _tiles { get; set; } = Array.Empty<Tile>();

        public Dictionary<int, Texture2D> idTextures = new Dictionary<int, Texture2D>();

        public TileSetData(string filename)
        {
            _filename = filename;
        }

        public void LoadContent(ContentManager content)
        {
            string dataSet = File.ReadAllText(Path.Join(content.RootDirectory, _filename));
            var tilesetData = JsonConvert.DeserializeObject<TileSetData>(dataSet);


            _tiles = tilesetData._tiles;

            for (int i = 0; i < _tiles.Length; i++)
            {
                Texture2D temp = content.Load<Texture2D>(Path.GetFileNameWithoutExtension(_tiles[i].image));
                idTextures.Add(_tiles[i].id + 1, temp);
            }
        }


    }
}
