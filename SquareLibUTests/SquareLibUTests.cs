using SquareLib;
namespace SquareLibUTests
{
    [TestClass]
    public class SquareLibUTests
    {
        [TestMethod]
        public void PolygoneTypeAndSquareTest_NonConvex()
        {
            //arrange
            double[] A = new double[6] { 4, 3, -1, 2, 2, -3 };
            double[] B = new double[6] { -2, 6, 4, 3, 1, -1 };
            double expectedSquare = 22;
            int expectedPolygoneType = -1;
            //act
            Polygon polygon = new Polygon(A, B);
            double realPolygonSquare = polygon.PolygonSquare();
            int realPolygonType = polygon.PolygonType();
            //assert
            Assert.AreEqual(expectedSquare, realPolygonSquare);
            Assert.AreEqual(expectedPolygoneType, realPolygonType);
        }
        [TestMethod]
        public void PolygonTypeAndSquareTest_Convex()
        {
            //arrange
            double[] A = new double[6] { 3, 1, -1, -2, 1, 4 };
            double[] B = new double[6] { 2, 3, 3, 1, -1, -1 };
            double expectedSquare = 16.5;
            int expectedPolygoneType = 1;
            //act
            Polygon polygon = new Polygon(A, B);
            double realPolygonSquare = polygon.PolygonSquare();
            int realPolygonType = polygon.PolygonType();
            //assert
            Assert.AreEqual(expectedSquare, realPolygonSquare);
            Assert.AreEqual(expectedPolygoneType, realPolygonType);
        }
        [TestMethod]
        public void PolygoneTypeAndSquareTest_NonConvex1()
        {
            //arrange
            double[] A = new double[5] { 3, 5, 12, 9, 5 };
            double[] B = new double[5] { 4, 11, 8, 5, 6 };
            double expectedSquare = 30;
            int expectedPolygoneType = -1;
            //act
            Polygon polygon = new Polygon(A, B);
            double realPolygonSquare = polygon.PolygonSquare();
            int realPolygonType = polygon.PolygonType();
            //assert
            Assert.AreEqual(expectedSquare, realPolygonSquare);
            Assert.AreEqual(expectedPolygoneType, realPolygonType);
        }
    }
}