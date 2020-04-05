namespace DataStructure.Domain.TileMap.Model
{
    using System.Collections.Generic;
    using Shape;
    using Tile.Model;

    public abstract class TileMap
    {
        public IEnumerable<Tile> Tiles { get; set; }
        public TileMapShapeBase ShapeBase { get; set; }
    }
}
