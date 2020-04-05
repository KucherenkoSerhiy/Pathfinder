namespace DataStructure.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using Tile.Model;
    using TileMap.Model;
    using TileMap.Model.Shape;
    using TileMap.Service.Implementation.TilemapGenerator;

    [TestFixture]
    public class TriangularTilemapGeneratorTest
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
        public void Generate_Size1_Generates1Node()
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
        public void Generate_Size2_Generates4ConnectedNodes()
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
        public void Generate_Size3_Generates9ConnectedNodes()
        {
            // Arrange
            var sut = this.GetSut();

            // Act

            // Assert

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
        public void Generate_Size4_Generates16ConnectedNodes()
        {
            // Arrange
            var sut = this.GetSut();

            // Act

            // Assert

        }

        private TriangularTilemapGenerator GetSut()
        {
            return new TriangularTilemapGenerator();
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
                    t0,
                    t1,
                    t2,
                    t3
                }
            };
            return tileMap;
        }
    }
}
