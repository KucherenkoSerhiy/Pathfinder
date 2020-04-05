namespace DataStructure.Domain.TileMap.Service.Implementation.TilemapGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Model.Shape;
    using Tile.Model;

    public class TriangularTilemapGenerator: ITilemapGenerator
    {
        public EnTileMapShape Type => EnTileMapShape.Triangular;

        public TileMap Generate(int width, int height = 0)
        {
            if (width == 0)
                throw new ArgumentOutOfRangeException($"Width cannot be {width}, must be > 0");

            return new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = GenerateTiles(width)
            };
        }

        private static List<Tile> GenerateTiles(int width)
        {
            var tiles = new List<Tile>();

            AddTiles(width, tiles);
            ConnectTiles(tiles);

            return tiles;
        }

        private static void AddTiles(int width, List<Tile> tiles)
        {
            var numberOfTiles = Math.Pow(width, 2);
            for (var i = 0; i < numberOfTiles; i++)
                tiles.Add(new Tile {Index = i});
        }

        private static void ConnectTiles(List<Tile> tiles)
        {
            foreach (var tile in tiles)
            {
                if (tile.Index == 1)
                {
                    tile.Connections.Add(tiles.First(x => x.Index == tile.Index - 1));
                    tile.Connections.Add(tiles.First(x => x.Index == tile.Index + 1));
                    tile.Connections.Add(tiles.First(x => x.Index == tile.Index + 2));
                }
            }
        }
    }
}
