namespace LogicGatesPerceptron.Utils
{
    public class Array<T>
    {
        public static T[] AllZeroes(int size)
        {
            return new T[size];
        }

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
