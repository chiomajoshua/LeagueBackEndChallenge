using ComputeMatrix.Controllers;
using ComputeMatrix.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace ComputeMatrix.Test
{
    public class ComputeControllerTests
    {
        Mock<IComputeMatrixService> _mockComputeMatrixService;

        [SetUp]
        public void Setup()
        {
            _mockComputeMatrixService = new Mock<IComputeMatrixService>(MockBehavior.Strict);
        }

        [Test]
        public async Task Post_Echo_Test_Success()
        {
            //Arrange
            var physicalFile = ToMockIFormFile(@".\matrix.csv");

            //expected Response
            var expected = "1,2,3\n4,5,6\n7,8,9";

            //Mocking The Echo Method
            _mockComputeMatrixService.Setup(setup => setup.Echo(It.IsAny<string[][]>())).Returns(expected);

            //Act
            var computeController = new ComputeController(_mockComputeMatrixService.Object);
            var result = await computeController.Echo(physicalFile) as OkObjectResult;

            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public async Task Post_Invert_Test_Success()
        {
            //Arrange
            var physicalFile = ToMockIFormFile(@".\matrix.csv");

            //expected Response
            var expected = "1,4,7\n2,5,8\n3,6,9";

            //Mocking The Echo Method
            _mockComputeMatrixService.Setup(setup => setup.Invert(It.IsAny<string[][]>())).Returns(expected);

            //Act
            var computeController = new ComputeController(_mockComputeMatrixService.Object);
            var result = await computeController.Invert(physicalFile) as OkObjectResult;

            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public async Task Post_Flatten_Test_Success()
        {
            //Arrange
            var physicalFile = ToMockIFormFile(@".\matrix.csv");

            //expected Response
            var expected = "1,2,3,4,5,6,7,8,9";

            //Mocking The Echo Method
            _mockComputeMatrixService.Setup(setup => setup.Flatten(It.IsAny<string[][]>())).Returns(expected);

            //Act
            var computeController = new ComputeController(_mockComputeMatrixService.Object);
            var result = await computeController.Flatten(physicalFile) as OkObjectResult;

            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public async Task Post_Sum_Test_Success()
        {
            //Arrange
            var physicalFile = ToMockIFormFile(@".\matrix.csv");

            //expected Response
            var expected = 45;

            //Mocking The Echo Method
            _mockComputeMatrixService.Setup(setup => setup.Sum(It.IsAny<string[][]>())).Returns(expected);

            //Act
            var computeController = new ComputeController(_mockComputeMatrixService.Object);
            var result = await computeController.Sum(physicalFile) as OkObjectResult;

            Assert.AreEqual(expected, result.Value);
        }


        [Test]
        public async Task Post_Multiply_Test_Success()
        {
            //Arrange
            var physicalFile = ToMockIFormFile(@".\matrix.csv");

            //expected Response
            var expected = 362880;

            //Mocking The Echo Method
            _mockComputeMatrixService.Setup(setup => setup.Multiply(It.IsAny<string[][]>())).Returns(expected);

            //Act
            var computeController = new ComputeController(_mockComputeMatrixService.Object);
            var result = await computeController.Multiply(physicalFile) as OkObjectResult;

            Assert.AreEqual(expected, result.Value);
        }

        private static IFormFile ToMockIFormFile(string physicalFile)
        {
            var fileMock = new Mock<IFormFile>();
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            var fileInfo = new FileInfo(physicalFile);
            writer.Write(fileInfo.OpenRead());
            writer.Flush();
            ms.Position = 0;
            var fileName = fileInfo.Name;
            //Setup mock file using info from physical file
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
            fileMock.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));
            return fileMock.Object;
        }
    }
}