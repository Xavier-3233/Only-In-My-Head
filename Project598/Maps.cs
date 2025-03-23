using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Project598
{
    public class Maps
    {
        int _tileWidth, _tileHeight, _mapWidth, _mapHeight;

        Texture2D _mapTexture;

        Vector2 position;

        Texture2D _a;

        TileSetData _set;
        TileMapData _map1;
        TileSetData _set2;
        TileMapData _map2;


        Rectangle[] _tiles;

        int[,] _map;

        string _filename;

        string _tilesetname;

        

        /*public Maps(string filename)
        {
            _filename = filename;
            position = new Vector2((32 * 8), (32 * 4));
            _set = new TileSetData("GrassArea.tsj");
            _map1 = new TileMapData("GrassArea.json");
            //_set2 = new TileSetData("T")
            _map2 = new TileMapData("Town.json");
        }*/

        public Maps(string filename, TileSetData set)
        {
            _filename = filename;
            _set = set;
            _map1 = new TileMapData(filename);

        }

        public void LoadContent(ContentManager content)
        {
            /*string data = File.ReadAllText(Path.Join(content.RootDirectory, _filename));
            var lines = data.Split('\n');

            var name = lines[0].Trim();
            _mapTexture = content.Load<Texture2D>(name);

            var nums = lines[1].Split(",");
            _tileWidth = int.Parse(nums[0]);
            _tileHeight = int.Parse(nums[1]);

            var tileData = lines[2].Split(",");
            _mapWidth = int.Parse(tileData[0]);
            _mapHeight = int.Parse(tileData[1]);

            int tilesetColumns = _mapTexture.Width / _tileWidth;
            int tilesetRows = _mapTexture.Height / _tileHeight;
            _tiles = new Rectangle[tilesetColumns * tilesetRows];

            for (int y = 0; y < tilesetColumns; y++)
            {
                for (int x = 0; x < tilesetRows; x++)
                {
                    int index = y * tilesetColumns + x;
                    _tiles[index] = new Rectangle(
                        x * _tileWidth,
                        y * _tileHeight,
                        _tileWidth,
                        _tileHeight
                        );
                }
            }

            _map = new int[_mapWidth, _mapHeight];
            for(int i = 0; i < _mapHeight; i++)
            {
                var row = lines[i + 3].Split(",");
                for(int j = 0; j < _mapWidth; j++)
                {
                    _map[j, i] = int.Parse(row[j]);
                }

            }*/
            _a = content.Load<Texture2D>("Brick");
            //_tileHeight = data.height;
            //_set1.LoadContent(content);
            _map1.LoadContent(content);
            //_map2.LoadContent(content);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            /*for(int i = 0; i < _mapWidth; i++)
            {
                for(int j = 0; j < _mapHeight; j++)
                {
                    int index = _map[i, j];
                    if (index == -1) continue;
                    spriteBatch.Draw(_mapTexture, new Vector2(i * _tileWidth, j * _tileHeight), _tiles[index], Color.White);
                }
            }
            spriteBatch.Draw(_a, new Rectangle((int)position.X, (int)position.Y, 32, 32), Color.White);
            //Lets hope this works!*/
            Texture2D tileTexture;
            for (int i = 0; i < _map1.width; i++)
            {
                for(int j = 0; j < _map1.height; j++)
                {
                    //int index = j * _map1.width + i;
                    _set.idTextures.TryGetValue(_map1._data[j, i], out tileTexture);
                    if (tileTexture != null)
                    {
                        spriteBatch.Draw(tileTexture, new Vector2(i * 32, j * 32), Color.White);
                    }
                    
                }
            }
        }

        public void GetTilePosition(int index, int mapWidth)
        {
            int row = index / mapWidth;  // Calculate the row
            int column = index % mapWidth;  // Calculate the column

            //Console.WriteLine($"Tile at index {index} is at Row: {row}, Column: {column}");
        }
    }
}
