namespace DataStructure.Domain.TileMap.Service
{
    using Model;
    using Model.Shape;

    public interface ITilemapGenerator
    {
        public TileMap Generate(TileMapShape shape);
    }
}