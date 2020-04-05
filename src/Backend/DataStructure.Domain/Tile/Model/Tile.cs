namespace DataStructure.Domain.Tile.Model
{
    using System.Collections.Generic;

    public class Tile
    {
        public IEnumerable<Tile> Connections { get; set; } = new List<Tile>();
        public int Weight { get; set; } = 1;
        public object Content { get; set; }
    }
}
