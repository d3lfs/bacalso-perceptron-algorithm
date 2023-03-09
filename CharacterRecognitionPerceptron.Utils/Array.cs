namespace CharacterRecognitionPerceptron.Utils
{
    /// <summary>
    /// Array helper class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Array<T>
    {
        /// <summary>
        /// Creates an array of size 'size' with all elements set to 0.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>Array of zeroes</returns>
        public static T[] AllZeroes(int size)
        {
            return new T[size];
        }

        /// <summary>
        /// Creates an array of size 'size' using a normal distribution.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>Randomized normal distribution array</returns>
        public static T[] NormalDistribution(int size)
        {
            var rand = new Random();
            var array = new T[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = (T)Convert.ChangeType(rand.NextDouble() * 2 - 1, typeof(T));
            }

            return array;
        }
    }
}
