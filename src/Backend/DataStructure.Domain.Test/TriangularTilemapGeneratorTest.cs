namespace DataStructure.Domain.Test
{
    using NUnit.Framework;
    using TileMap.Service.Implementation.TilemapGenerator;

    [TestFixture]
    public class TriangularTilemapGeneratorTest
    {
        [Test]
        public void Generate_NullShape_Throws()
        {

        }

        [Test]
        public void Generate_SizeZero_Throws()
        {

        }

        [Test]
        public void Generate_SizeOne_Generates1Node()
        {

        }

        [Test]
        public void Generate_SizeThree_Generates6ConnectedNodes()
        {

        }

        [Test]
        public void Generate_SizeFour_Generates10ConnectedNodes()
        {

        }

        private TriangularTilemapGenerator GetSut()
        {
            return new TriangularTilemapGenerator();
        }
    }
}
