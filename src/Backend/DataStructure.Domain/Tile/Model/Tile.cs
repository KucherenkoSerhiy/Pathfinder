namespace DataStructure.Domain.Tile.Model
{
    using System.Collections.Generic;

    public class Tile
    {
        public IEnumerable<Tile> Connections { get; set; }
        public int Weight { get; set; }
        public object Content { get; set; }
    }
}
