using ComputeMatrix.Core.Constants;

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
        public async Task<IActionResult> Echo(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!Utilities.SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = await Utilities.ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!Utilities.IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Echo(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Invert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Invert(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!Utilities.SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = await Utilities.ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!Utilities.IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Invert(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Flatten")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Flatten(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!Utilities.SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = await Utilities.ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!Utilities.IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Flatten(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Sum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Sum(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!Utilities.SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = await Utilities.ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!Utilities.IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Sum(arrayResult);
            return Ok(response);
        }

        [HttpPost, Route("Multiply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Multiply(IFormFile formFile)
        {
            if (formFile is null || formFile.Length < 1) return BadRequest("Please Upload File.");

            if (!Utilities.SupportedType(Path.GetExtension(formFile.FileName))) return BadRequest("Upload File Not In Correct Format. Please Upload CSV file.");

            var arrayResult = await Utilities.ConvertToArray(formFile);
            if (arrayResult is null) return BadRequest("CSV File Is Empty");

            if (!Utilities.IsMatrixBox(arrayResult)) return BadRequest("Matrix Is Not A Square");

            var response = _computeMatrixService.Multiply(arrayResult);
            return Ok(response);
        }       
    }
}