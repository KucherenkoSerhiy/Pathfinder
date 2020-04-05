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

        [Test]
        public void Generate_Size1_Generates1Node()
        {
            // Arrange
            var sut = this.GetSut();

            var expected = new TileMap
            {
                Shape = EnTileMapShape.Triangular,
                Tiles = new List<Tile>{ new Tile() }
            };

            // Act
            var actual = sut.Generate(1);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Generate_Size2_Generates3ConnectedNodes()
        {
            // Arrange
            var sut = this.GetSut();

            // Act

            // Assert

        }

        [Test]
        public void Generate_Size3_Generates6ConnectedNodes()
        {
            // Arrange
            var sut = this.GetSut();

            // Act

            // Assert

        }

        [Test]
        public void Generate_Size4_Generates10ConnectedNodes()
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
    }
}
