namespace ComputeMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputeController : ControllerBase
    {
        private readonly IComputeMatrixService _computeMatrixService;
        public ComputeController(IComputeMatrixService computeMatrixService)
        {
            _computeMatrixService = computeMatrixService;
        }

        [HttpPost, Route("Echo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Echo(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Echo(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Invert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Invert(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Invert(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Flatten")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Flatten(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Flatten(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Sum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Sum(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Sum(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Multiply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Multiply(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Multiply(arrayResult);
            return Ok(response);
        }

        #region PrivateMethods
        /// <summary>
        /// Validates Form File Input(allows only csv files)
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private static bool SupportedType(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
                return false;

            var supportedTypes = new[] { ".csv" };
            if (!supportedTypes.Contains(fileExtension)) return false;

            return true;
        }

        /// <summary>
        /// Checks If Size of Rows and Columns are equal
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static bool IsMatrixBox(string[][] array)
        {
            if (array is null) return false;
                        
            if (array.GetLength(0) == 3) return true;

            return false;
        }

        private static string[][] ConvertToArray(IFormFile formFile)
        {
            var filePath = Path.GetTempFileName();
            using var stream = System.IO.File.Create(filePath);
            formFile.CopyTo(stream);

            return System.IO.File.ReadAllLines(filePath)
                            .Select(s => s.Split(",".ToCharArray())).ToArray().ToArray();
        }
        #endregion
    }
}