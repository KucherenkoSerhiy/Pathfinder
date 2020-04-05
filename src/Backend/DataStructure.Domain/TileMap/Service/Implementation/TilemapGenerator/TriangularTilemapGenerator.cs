namespace DataStructure.Domain.TileMap.Service.Implementation.TilemapGenerator
{
    using System;
    using System.Collections.Generic;
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
                Tiles = new List<Tile>
                {
                    new Tile()
                }
            };

            throw new NotImplementedException();
        }
    }
}
