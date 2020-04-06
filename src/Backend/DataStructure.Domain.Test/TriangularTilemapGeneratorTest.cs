namespace DataStructure.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using Tile.Model;
    using TileMap.Model;
    using TileMap.Model.Shape;
    using TileMap.Service.Implementation.TileMapGenerator;

    [TestFixture]
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
                Tiles = new List<Tile>{ new Tile{Index = 0} }
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
            var t0 = new Tile{Index = 0};
            var t1 = new Tile{Index = 1};
            var t2 = new Tile{Index = 2};
            var t3 = new Tile{Index = 3};

            // Connections
            t0.Connections.Add(t1);
            t1.Connections.AddRange(new [] {t0, t2, t3});
            t2.Connections.Add(t1);
            t3.Connections.Add(t1);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3
                }
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
            var t0 = new Tile{Index = 0};
            var t1 = new Tile{Index = 1};
            var t2 = new Tile{Index = 2};
            var t3 = new Tile{Index = 3};
            var t4 = new Tile{Index = 4};
            var t5 = new Tile{Index = 5};
            var t6 = new Tile{Index = 6};
            var t7 = new Tile{Index = 7};
            var t8 = new Tile{Index = 8};

            // Connections
            t0.Connections.Add(t1);
            t1.Connections.AddRange(new [] {t0, t2, t3});
            t2.Connections.AddRange(new [] {t1, t4});
            t3.Connections.AddRange(new [] {t1, t5});
            t4.Connections.AddRange(new [] {t2, t6, t7});
            t5.Connections.AddRange(new [] {t3, t7, t8});
            t6.Connections.Add(t4);
            t7.Connections.AddRange(new [] {t4, t5});
            t8.Connections.Add(t5);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3, t4, t5, t6, t7, t8
                }
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
            var t0 = new Tile{Index = 0};
            var t1 = new Tile{Index = 1};
            var t2 = new Tile{Index = 2};
            var t3 = new Tile{Index = 3};
            var t4 = new Tile{Index = 4};
            var t5 = new Tile{Index = 5};
            var t6 = new Tile{Index = 6};
            var t7 = new Tile{Index = 7};
            var t8 = new Tile{Index = 8};
            var t9 = new Tile{Index = 9};
            var tA = new Tile{Index = 10};
            var tB = new Tile{Index = 11};
            var tC = new Tile{Index = 12};
            var tD = new Tile{Index = 13};
            var tE = new Tile{Index = 14};
            var tF = new Tile{Index = 15};

            // Connections
            t0.Connections.Add(t1);
            t1.Connections.AddRange(new [] {t0, t2, t3});
            t2.Connections.AddRange(new [] {t1, t4});
            t3.Connections.AddRange(new [] {t1, t5});
            t4.Connections.AddRange(new [] {t2, t6, t7});
            t5.Connections.AddRange(new [] {t3, t7, t8});
            t6.Connections.AddRange(new [] {t4, t9});
            t7.Connections.AddRange(new [] {t4, t5, tA});
            t8.Connections.AddRange(new [] {t5, tB});
            t9.Connections.AddRange(new [] {t6, tC, tD});
            tA.Connections.AddRange(new [] {t7, tD, tE});
            tB.Connections.AddRange(new [] {t8, tE, tF});
            tC.Connections.Add(t9);
            tD.Connections.AddRange(new [] {t9, tA});
            tE.Connections.AddRange(new [] {tA, tB});
            tF.Connections.Add(tB);

            var tileMap = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>
                {
                    t0, t1, t2, t3, t4, t5, t6, t7, t8, t9, tA, tB, tC, tD, tE, tF
                }
            };
            return tileMap;
        }
    }
}
