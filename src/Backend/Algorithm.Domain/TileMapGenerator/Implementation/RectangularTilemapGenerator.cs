using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Domain.TileMapGenerator.Implementation
{
    using System.Linq;
    using DataStructure.Domain.Tile.Model;
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;

    public class RectangularTilemapGenerator : ITileMapGenerator
    {
        public EnTileMapShape Type => EnTileMapShape.Rectangle;

        public TileMap Generate(int width, int height = 0)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException($"Width cannot be {width}, must be > 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException($"Height cannot be {height}, must be > 0");


            return new TileMap
            {
                Shape = EnTileMapShape.Rectangle,
                Tiles = this.GenerateTiles(width, height),
                Width = width,
                Height = height
            };
        }

        private IEnumerable<Tile> GenerateTiles(int width, int height)
        {
            var tiles = new Dictionary<int, Tile>();

            for (var i = 0; i < width * height; i++)
                tiles.Add(i, new Tile(i));

            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    this.AddConnectionsToCurrentTile(width, height, row, column, tiles);
                }
            }

            return tiles.Values.ToList();
        }

        private void AddConnectionsToCurrentTile(int width, int height, int row, int column, Dictionary<int, Tile> tiles)
        {
            var index = row * width + column;
            var tile = tiles[index];

            if (column > 0)
                this.AddLeftConnection(tile);
            if (column < width - 1)
                this.AddRightConnection(tile);
            if (row > 0)
                this.AddTopConnection(width, tile);
            if (row < height - 1)
                this.AddBottomConnection(width, tile);
        }

        private void AddLeftConnection(Tile tile)
        {
            var left = tile.Index - 1;
            tile.Connections.Add(left);
        }

        private void AddRightConnection(Tile tile)
        {
            var right = tile.Index + 1;
            tile.Connections.Add(right);
        }

        private void AddTopConnection(int width, Tile tile)
        {
            var top = tile.Index - width;
            tile.Connections.Add(top);
        }

        private void AddBottomConnection(int width, Tile tile)
        {
            var bottom = tile.Index + width;
            tile.Connections.Add(bottom);
        }
    }
}
