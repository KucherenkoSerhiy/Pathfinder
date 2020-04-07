﻿namespace DataStructure.Domain.Tile.Model
{
    using System.Collections.Generic;

    public class Tile
    {
        public int Index { get; }
        public int Weight { get; set; } = 1;
        public object Content { get; set; }
        public List<int> Connections { get; } = new List<int>();

        public Tile(int index)
        {
            this.Index = index;
        }
    }
}
