namespace ComputeMatrix.Core.Interface
{
    public interface IComputeMatrixService
    {
        /// <summary>
        /// returns an array converted to string result in matrix format
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        string Echo(string[][] array);

        /// <summary>
        /// returns a string in matrix format after converting rows to columns and columns to rows
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        string Invert(string[][] array);

        /// <summary>
        /// returns a string in the array on a straight line
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        string Flatten(string[][] array);

        /// <summary>
        /// returns the sum of all elements within the array 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        int Sum(string[][] array);

        /// <summary>
        /// multiply all elements within the array and returns
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        int Multiply(string[][] array);

        /// <summary>
        /// Invert a Jagged Array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        string[][] Transpose(string[][] array);
    }
}