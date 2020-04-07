namespace Algorithm.Domain.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using DataStructure.Domain.Tile.Model;
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;
    using FluentAssertions;
    using TileMapGenerator.Implementation;

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TriangularTileMapGeneratorTest
    {
        [Test]
        public void Generate_Size0_Throws()
        {
            // Arrange
            var sut = this.GetSut();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { sut.Generate(0);});
        }

        /*
              ^
             /0\
            /___\
        */
        [Test]
        public void Generate_Size1_Generates1Tile()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.GenerateSize1TileMap();

            // Act
            var actual = sut.Generate(1);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /*
                 ^
                /2\
               /___\
              ^     ^
             /0\ 1 /3\
            /___\ /___\
        */
        [Test]
        public void Generate_Size2_Generates4ConnectedTiles()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.GenerateSize2TileMap();

            // Act
            var actual = sut.Generate(2);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /*
                    ^
                   /6\
                  /___\
                 ^     ^
                /2\ 4 /7\
               /___\ /___\
              ^     ^     ^
             /0\ 1 /3\ 5 /8\
            /___\ /___\ /___\
        */
        [Test]
        public void Generate_Size3_Generates9ConnectedTiles()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.GenerateSize3TileMap();

            // Act
            var actual = sut.Generate(3);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /*
         Disclaimer: to not ruin the drawing, used hexadecimal count
                       ^
                      /C\
                     /___\
                    ^     ^
                   /6\ 9 /D\
                  /___\ /___\
                 ^     ^     ^
                /2\ 4 /7\ A /E\
               /___\ /___\ /___\
              ^     ^     ^     ^
             /0\ 1 /3\ 5 /8\ B /F\
            /___\ /___\ /___\ /___\
        */
        [Test]
        public void Generate_Size4_Generates16ConnectedTiles()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.GenerateSize4TileMap();

            // Act
            var actual = sut.Generate(4);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        private TriangularTileMapGenerator GetSut()
        {
            return new TriangularTileMapGenerator();
        }

        /*
              ^
             /0\
            /___\
        */
        private TileMap GenerateSize1TileMap()
        {
            return new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>{ new Tile(0) },
                Width = 1,
                Height = 0
            };
        }

        /*
                 ^
                /2\
               /___\
              ^     ^
             /0\ 1 /3\
            /___\ /___\
        */
        private TileMap GenerateSize2TileMap()
        {
            // Tiles
            var t0 = new Tile(0);
            var t1 = new Tile(1);
            var t2 = new Tile(2);
            var t3 = new Tile(3);

            // Connections
            t0.Connections.Add(t1.Index);
            t1.Connections.AddRange(new [] {t0.Index, t2.Index, t3.Index});
            t2.Connections.Add(t1.Index);
            t3.Connections.Add(t1.Index);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3
                },
                Width = 2,
                Height = 0
            };
            return tileMap;
        }
        
        /*
                    ^
                   /6\
                  /___\
                 ^     ^
                /2\ 4 /7\
               /___\ /___\
              ^     ^     ^
             /0\ 1 /3\ 5 /8\
            /___\ /___\ /___\
        */
        private TileMap GenerateSize3TileMap()
        {
            // Tiles
            var t0 = new Tile(0);
            var t1 = new Tile(1);
            var t2 = new Tile(2);
            var t3 = new Tile(3);
            var t4 = new Tile(4);
            var t5 = new Tile(5);
            var t6 = new Tile(6);
            var t7 = new Tile(7);
            var t8 = new Tile(8);

            // Connections
            t0.Connections.Add(t1.Index);
            t1.Connections.AddRange(new [] {t0.Index, t2.Index, t3.Index});
            t2.Connections.AddRange(new [] {t1.Index, t4.Index});
            t3.Connections.AddRange(new [] {t1.Index, t5.Index});
            t4.Connections.AddRange(new [] {t2.Index, t6.Index, t7.Index});
            t5.Connections.AddRange(new [] {t3.Index, t7.Index, t8.Index});
            t6.Connections.Add(t4.Index);
            t7.Connections.AddRange(new [] {t4.Index, t5.Index});
            t8.Connections.Add(t5.Index);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3, t4, t5, t6, t7, t8
                },
                Width = 3,
                Height = 0
            };
            return tileMap;
        }
        
        /*
         Disclaimer: to not ruin the drawing, used hexadecimal count
                       ^
                      /C\
                     /___\
                    ^     ^
                   /6\ 9 /D\
                  /___\ /___\
                 ^     ^     ^
                /2\ 4 /7\ A /E\
               /___\ /___\ /___\
              ^     ^     ^     ^
             /0\ 1 /3\ 5 /8\ B /F\
            /___\ /___\ /___\ /___\
        */
        private TileMap GenerateSize4TileMap()
        {
            // Tiles
            var t0 = new Tile(0);
            var t1 = new Tile(1);
            var t2 = new Tile(2);
            var t3 = new Tile(3);
            var t4 = new Tile(4);
            var t5 = new Tile(5);
            var t6 = new Tile(6);
            var t7 = new Tile(7);
            var t8 = new Tile(8);
            var t9 = new Tile(9);
            var tA = new Tile(10);
            var tB = new Tile(11);
            var tC = new Tile(12);
            var tD = new Tile(13);
            var tE = new Tile(14);
            var tF = new Tile(15);

            // Connections
            t0.Connections.Add(t1.Index);
            t1.Connections.AddRange(new [] {t0.Index, t2.Index, t3.Index});
            t2.Connections.AddRange(new [] {t1.Index, t4.Index});
            t3.Connections.AddRange(new [] {t1.Index, t5.Index});
            t4.Connections.AddRange(new [] {t2.Index, t6.Index, t7.Index});
            t5.Connections.AddRange(new [] {t3.Index, t7.Index, t8.Index});
            t6.Connections.AddRange(new [] {t4.Index, t9.Index});
            t7.Connections.AddRange(new [] {t4.Index, t5.Index, tA.Index});
            t8.Connections.AddRange(new [] {t5.Index, tB.Index});
            t9.Connections.AddRange(new [] {t6.Index, tC.Index, tD.Index});
            tA.Connections.AddRange(new [] {t7.Index, tD.Index, tE.Index});
            tB.Connections.AddRange(new [] {t8.Index, tE.Index, tF.Index});
            tC.Connections.Add(t9.Index);
            tD.Connections.AddRange(new [] {t9.Index, tA.Index});
            tE.Connections.AddRange(new [] {tA.Index, tB.Index});
            tF.Connections.Add(tB.Index);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3, t4, t5, t6, t7, t8, t9, tA, tB, tC, tD, tE, tF
                },
                Width = 4,
                Height = 0
            };
            return tileMap;
        }
    }
}
