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
            var efficientTiles = tiles.ToDictionary(tile => tile.Index);

            /* Algorithm Description
               Each node has up to 3 connections: 1 left, 1 right and 1 up or down
               depending on if that node is represented by triangle downside-up or upside-down

               Which node will be connected depends on which zone is that node placed.
               Zone is set of nodes of index between (n-1)^2 and n^2
               
               Disclaimer: to not ruin the drawing, used hexadecimal count

                                        zone
                                    n=4, n^2=16
                                          ^
                                 zone    /C\
                             n=3, n^2=8 /___\
                                  ^     \    ^
                         zone    /6\     \9 /D\
                     n=2, n^2=4 /___\     \/___\
                          ^     \    ^     \    ^
                 zone    /2\     \4 /7\     \A /E\
             n=1, n^2=1 /___\     \/___\     \/___\
                  ^     \    ^     \    ^     \    ^
                 /0\     \1 /3\     \5 /8\     \B /F\
                /___\     \/___\     \/___\     \/___\
            */

            
        }
    }
}
