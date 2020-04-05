namespace DataStructure.Domain.TileMap.Service
{
    using System.Collections.Generic;
    using Model;
    using Model.Shape;

    public interface ITilemapGenerator
    {
        public EnTileMapShape Type { get; }
        public TileMap Generate(Dictionary<string, int> sizeValues);
    }
}