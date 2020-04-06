namespace Algorithm.Domain.TileMapGenerator
{
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;

    public interface ITileMapGenerator
    {
        public EnTileMapShape Type { get; }
        public TileMap Generate(int width, int height = 0);
    }
}