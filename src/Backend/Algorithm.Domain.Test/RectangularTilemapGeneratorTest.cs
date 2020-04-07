namespace Algorithm.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using DataStructure.Domain.Tile.Model;
    using DataStructure.Domain.TileMap.Model;
    using DataStructure.Domain.TileMap.Model.Shape;
    using FluentAssertions;
    using NUnit.Framework;
    using TileMapGenerator.Implementation;

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RectangularTilemapGeneratorTest
    {
        [Test]
        public void Generate_Width0_Throws()
        {
            // Arrange
            var sut = this.GetSut();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { sut.Generate(0, 1);});
        }

        [Test]
        public void Generate_Height0_Throws()
        {
            // Arrange
            var sut = this.GetSut();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { sut.Generate(1);});
        }

        [Test]
        public void Generate_Width4Height3_Generates()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.Generate4x3TileMap();

            // Act
            var actual = sut.Generate(4, 3);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Generate_Width2Height5_Generates()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = this.Generate2x5TileMap();

            // Act
            var actual = sut.Generate(2, 5);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        private RectangularTilemapGenerator GetSut()
        {
            return new RectangularTilemapGenerator();
        }

        /*
            [0][1][2][3]
            [4][5][6][7]
            [8][9][A][B]
        */
        private TileMap Generate4x3TileMap()
        {
            var t00 = new Tile{Index = 0};
            var t01 = new Tile{Index = 1};
            var t02 = new Tile{Index = 2};
            var t03 = new Tile{Index = 3};
            var t10 = new Tile{Index = 4};
            var t11 = new Tile{Index = 5};
            var t12 = new Tile{Index = 6};
            var t13 = new Tile{Index = 7};
            var t20 = new Tile{Index = 8};
            var t21 = new Tile{Index = 9};
            var t22 = new Tile{Index = 10};
            var t23 = new Tile{Index = 11};

            // row 0 connections
            t00.Connections.AddRange(new []{t01.Index, t10.Index});
            t01.Connections.AddRange(new []{t00.Index, t02.Index, t11.Index});
            t02.Connections.AddRange(new []{t01.Index, t03.Index, t12.Index});
            t03.Connections.AddRange(new []{t02.Index, t13.Index});
            
            // row 1 connections
            t10.Connections.AddRange(new []{t11.Index, t00.Index, t20.Index});
            t11.Connections.AddRange(new []{t10.Index, t12.Index, t01.Index, t21.Index});
            t12.Connections.AddRange(new []{t11.Index, t13.Index, t02.Index, t22.Index});
            t13.Connections.AddRange(new []{t12.Index, t03.Index, t23.Index});
            
            // row 2 connections
            t20.Connections.AddRange(new []{t21.Index, t10.Index});
            t21.Connections.AddRange(new []{t20.Index, t22.Index, t11.Index});
            t22.Connections.AddRange(new []{t21.Index, t23.Index, t12.Index});
            t23.Connections.AddRange(new []{t22.Index, t13.Index});

            return new TileMap
            {
                Shape = EnTileMapShape.Rectangle,
                Tiles = new List<Tile>
                {
                    t00, t01, t02, t03,
                    t10, t11, t12, t13,
                    t20, t21, t22, t23
                },
                Width = 4,
                Height = 3
            };
        }

        /*
            [0][1]
            [2][3]
            [4][5]
            [6][7]
            [8][9]
        */
        private TileMap Generate2x5TileMap()
        {
            var t00 = new Tile{Index = 0};
            var t01 = new Tile{Index = 1};
            var t10 = new Tile{Index = 2};
            var t11 = new Tile{Index = 3};
            var t20 = new Tile{Index = 4};
            var t21 = new Tile{Index = 5};
            var t30 = new Tile{Index = 6};
            var t31 = new Tile{Index = 7};
            var t40 = new Tile{Index = 8};
            var t41 = new Tile{Index = 9};

            // row 0 connections
            t00.Connections.AddRange(new []{t01.Index, t10.Index});
            t01.Connections.AddRange(new []{t00.Index, t11.Index});
            
            // row 1 connections
            t10.Connections.AddRange(new []{t11.Index, t00.Index, t20.Index});
            t11.Connections.AddRange(new []{t10.Index, t01.Index, t21.Index});
            
            // row 2 connections
            t20.Connections.AddRange(new []{t21.Index, t10.Index, t30.Index});
            t21.Connections.AddRange(new []{t20.Index, t11.Index, t31.Index});
            
            // row 3 connections
            t30.Connections.AddRange(new []{t31.Index, t20.Index, t40.Index});
            t31.Connections.AddRange(new []{t30.Index, t21.Index, t41.Index});
            
            // row 4 connections
            t40.Connections.AddRange(new []{t41.Index, t30.Index});
            t41.Connections.AddRange(new []{t40.Index, t31.Index});

            return new TileMap
            {
                Shape = EnTileMapShape.Rectangle,
                Tiles = new List<Tile>
                {
                    t00, t01,
                    t10, t11,
                    t20, t21,
                    t30, t31,
                    t40, t41
                },
                Width = 2,
                Height = 5
            };
        }
    }
}
