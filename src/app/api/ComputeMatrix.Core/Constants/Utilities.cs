using Microsoft.AspNetCore.Http;

namespace ComputeMatrix.Core.Constants
{
    public class Utilities
    {
        /// <summary>
        /// Validates Form File Input(allows only csv files)
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static bool SupportedType(string fileExtension)
        {
            try
            {
                if (string.IsNullOrEmpty(fileExtension))
                    return false;

                var supportedTypes = new[] { ".csv" };
                if (!supportedTypes.Contains(fileExtension)) return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks If Size of Rows and Columns are equal
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsMatrixBox(string[][] array)
        {
            try
            {
                if (array is null) return false;

                if (array.GetLength(0) == 3) return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Converts IFormFile(csv) to Jagged Array
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async static Task<string[][]> ConvertToArray(IFormFile formFile)
        {
            try
            {
                var filePath = Path.GetTempFileName();
                using (var stream = File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }

                return File.ReadAllLines(filePath)
                           .Select(s => s.Split(",".ToCharArray())).ToArray().ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}