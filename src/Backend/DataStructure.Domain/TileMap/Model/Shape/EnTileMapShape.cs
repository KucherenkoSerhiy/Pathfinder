namespace DataStructure.Domain.TileMap.Model.Shape
{
    using System.ComponentModel;

    [DefaultValue(Rectangle)]
    public enum EnTileMapShape
    {
        Shapeless,
        Triangular,
        Squared,
        Rectangle,
        Pentagonal,
        Hexagonal
    }
}