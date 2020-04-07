using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Domain.TileMapGenerator.Implementation
{
    using DataStructure.Domain.Tile.Model;
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;

    public class RectangularTilemapGenerator: ITileMapGenerator
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
                Shape = EnTileMapShape.Triangular,
                Tiles = this.GenerateTiles(width, height),
                Width = width,
                Height = height
            };
        }

        private IEnumerable<Tile> GenerateTiles(int width, int height)
        {
            var tiles = new List<Tile>();

            for (var i = 0; i < width*height; i++)
                tiles.Add(new Tile(i));

            // TODO: Connections

            return tiles;
        }
    }
}
