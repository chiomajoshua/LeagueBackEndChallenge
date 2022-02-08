using ComputeMatrix.Core.Services;
using NUnit.Framework;

namespace ComputeMatrix.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Echo_Test()
        {
            //expected Response
            var expected = "1,2,3\n4,5,6\n7,8,9";
           
            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Echo(request);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Invert_Test()
        {
            //expected Response
            var expected = "1,4,7\n2,5,8\n3,6,9";

            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Invert(request);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Flatten_Test()
        {
            var result = "1,2,3,4,5,6,7,8,9";

            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Flatten(request);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void Tranpose_Test()
        {
            //expected Response
            var expected = new string[][]{
                new string[] {"1","4","7"},
                new string[] {"2","5","8"},
                new string[] {"3","6","9"}
            };

            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Transpose(request);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_Test()
        {
            var expected = 362880;

            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Multiply(request);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sum_Test()
        {
            var expected = 45;

            //Request Object
            var request = new string[][]{
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            //Act
            var computeService = new ComputeMatrixService();
            var actual = computeService.Sum(request);

            Assert.AreEqual(expected, actual);
        }
    }
}