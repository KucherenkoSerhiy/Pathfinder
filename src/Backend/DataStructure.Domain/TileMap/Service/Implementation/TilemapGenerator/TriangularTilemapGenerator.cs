namespace DataStructure.Domain.TileMap.Service.Implementation.TilemapGenerator
{
    using System;
    using System.Collections.Generic;
    using Model;
    using Model.Shape;

    public class TriangularTilemapGenerator: ITilemapGenerator
    {
        public EnTileMapShape Type => EnTileMapShape.Triangular;

        public TileMap Generate(Dictionary<string, int> sizeValues)
        {
            throw new NotImplementedException();
        }
    }
}
