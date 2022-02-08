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
            StringBuilder columnBuilder = new();
            for (int i = 0; i < array.Length; i++)
            {
                columnBuilder.Append(string.Join(",", array[i]));
                columnBuilder.Append("\n");
            }
            return columnBuilder.ToString().TrimEnd();
        }

        public string Flatten(string[][] array)
        {
            //Convert Jagged Array to Single-Dimensional Array
            var flattenArray = array.SelectMany(a => a).ToArray();
            return string.Join(",", flattenArray.Cast<string>());
        }

        public string Invert(string[][] array)
        {
            return Echo(Transpose(array));
        }

        public int Multiply(string[][] array)
        {
            return Flatten(array).Split(',').Aggregate(1, (a, b) => a * Convert.ToInt32(b));
        }

        public int Sum(string[][] array)
        {
            return Flatten(array).Split(',').Select(r => Convert.ToInt32(r)).Sum();
        }
        
        public string[][] Transpose(string[][] array)
        {
            var elemMin = array.Select(x => x.Length).Min();
            return array
                .SelectMany(x => x.Take(elemMin).Select((y, i) => new { val = y, idx = i }))
                .GroupBy(x => x.idx, x => x.val, (x, y) => y.ToArray()).ToArray();
        }
    }
}