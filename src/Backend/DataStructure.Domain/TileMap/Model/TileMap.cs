namespace DataStructure.Domain.TileMap.Model
{
    using System.Collections.Generic;
    using Shape;
    using Tile.Model;

    public class TileMap
    {
        public EnTileMapShape Shape { get; set; }
        public IEnumerable<Tile> Tiles { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
