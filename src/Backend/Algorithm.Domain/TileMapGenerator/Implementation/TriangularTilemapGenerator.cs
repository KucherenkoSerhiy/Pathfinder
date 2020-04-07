namespace Algorithm.Domain.TileMapGenerator.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructure.Domain.Tile.Model;
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;
    using TileMapGenerator;

    public class TriangularTileMapGenerator: ITileMapGenerator
    {
        public EnTileMapShape Type => EnTileMapShape.Triangular;

        // TODO: width = 139 ok, width = 140 test crashes
        public TileMap Generate(int width, int height = 0)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException($"Width cannot be {width}, must be > 0");

            return new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = this.GenerateTiles(width),
                Width = width,
                Height = 0
            };
        }

        private List<Tile> GenerateTiles(int width)
        {
            var tiles = new List<Tile>();

            this.AddTiles(width, tiles);
            this.LinkTiles(tiles);

            return tiles;
        }

        private void AddTiles(int width, List<Tile> tiles)
        {
            var numberOfTiles = Math.Pow(width, 2);
            for (var i = 0; i < numberOfTiles; i++)
                tiles.Add(new Tile {Index = i});
        }

        private void LinkTiles(List<Tile> tiles)
        {
            var efficientTiles = tiles.ToDictionary(tile => tile.Index);
            
            int zone = 1, currentIndex = 0;
            this.ImmersionLinkTiles(efficientTiles, zone, currentIndex);
        }

        /* Algorithm Description
           Each tile has up to 3 connections: 1 left, 1 right and 1 up or down
           depending on if that tile is represented by triangle downside-up or upside-down

           Which tile will be connected depends on which zone is that tile placed.
           Zone is set of tiles of index between (n-1)^2 and n^2
           There are 2 types of connections:
                horizontal: connect bidirectional to (index + zone) 
                Vertical: 
                    - is applied only for upside down because all of these have connections
                    - connect bidirectional to (index + zone - 1)
                    - upside down are first LESSER half of the tiles for each zone (0 for first)
           
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
        private void ImmersionLinkTiles(Dictionary<int, Tile> tiles, int zone, int currentTileIndex)
        {
            if (currentTileIndex >= tiles.Count)
                return;

            if (this.IsOutOfBoundsOfCurrentZone(zone, currentTileIndex))
                this.NextZone(ref zone);

            this.LinkNextHorizontalTile(tiles, zone, currentTileIndex);

            if (this.IsTileUpsideDown(zone, currentTileIndex))
            {
                this.LinkNextVerticalTile(tiles, zone, currentTileIndex);
            }

            this.ImmersionLinkTiles(tiles, zone, currentTileIndex+1);
        }

        private bool IsOutOfBoundsOfCurrentZone(int zone, int currentIndex)
        {
            var currentZoneUpperLimit = Math.Pow(zone, 2) - 1;
            return currentIndex > currentZoneUpperLimit;
        }

        private void NextZone(ref int zone)
        {
            zone++;
        }

        private void LinkNextHorizontalTile(Dictionary<int, Tile> tiles, int zone, int currentTileIndex)
        {
            var nextHorizontalTileIndex = currentTileIndex + zone;

            if (nextHorizontalTileIndex >= tiles.Count) return;

            var currentTile = tiles[currentTileIndex];
            var nextHorizontalTile = tiles[nextHorizontalTileIndex];

            currentTile.Connections.Add(nextHorizontalTile.Index);
            nextHorizontalTile.Connections.Add(currentTile.Index);
        }

        private bool IsTileUpsideDown(int zone, int currentTileIndex)
        {
            var minimalTileIndexForCurrentZone = Math.Pow(zone - 1, 2);
            var numberOfUpsideDownTiles = zone - 1;

            var firstUpsideDownForCurrentZone = minimalTileIndexForCurrentZone;
            var lastUpsideDownForCurrentZone = 
                Math.Truncate(firstUpsideDownForCurrentZone + numberOfUpsideDownTiles - 1);

            return currentTileIndex >= firstUpsideDownForCurrentZone
                   && currentTileIndex <= lastUpsideDownForCurrentZone;
        }

        private void LinkNextVerticalTile(Dictionary<int, Tile> tiles, int zone, int currentTileIndex)
        {
            var nextVerticalTileIndex = currentTileIndex + zone - 1;

            var currentTile = tiles[currentTileIndex];
            var nextVerticalTile = tiles[nextVerticalTileIndex];

            currentTile.Connections.Add(nextVerticalTile.Index);
            nextVerticalTile.Connections.Add(currentTile.Index);
        }
    }
}
