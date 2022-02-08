using ComputeMatrix.Core.Interface;
using System.Text;

namespace ComputeMatrix.Core.Services
{
    public class ComputeMatrixService : IComputeMatrixService
    {
        public ComputeMatrixService()
        {

        }

        public string Echo(string[][] array)
        {
            try
            {
                StringBuilder columnBuilder = new();
                for (int i = 0; i < array.Length; i++)
                {
                    columnBuilder.Append(string.Join(",", array[i]));
                    columnBuilder.Append("\n");
                }
                return columnBuilder.ToString().TrimEnd();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Flatten(string[][] array)
        {
            try
            {
                //Convert Jagged Array to Single-Dimensional Array
                var flattenArray = array.SelectMany(a => a).ToArray();
                return string.Join(",", flattenArray.Cast<string>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Invert(string[][] array)
        {
            return Echo(Transpose(array));
        }

        public int Multiply(string[][] array)
        {
            try
            {
                return Flatten(array).Split(',').Aggregate(1, (a, b) => a * Convert.ToInt32(b));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Sum(string[][] array)
        {
            try
            {
                return Flatten(array).Split(',').Select(r => Convert.ToInt32(r)).Sum();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public string[][] Transpose(string[][] array)
        {
            try
            {
                var elemMin = array.Select(x => x.Length).Min();
                return array
                    .SelectMany(x => x.Take(elemMin).Select((y, i) => new { val = y, idx = i }))
                    .GroupBy(x => x.idx, x => x.val, (x, y) => y.ToArray()).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}