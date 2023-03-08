using LogicGatesPerceptron.Utils;

namespace LogicGatesPerceptron.Common
{
    public class Perceptron
    {
        private double _bias;
        private double _learningRate;
        private double[] _weights;

        private List<int[]> _x_i;
        private int[] _y_i;

        private double _totalError;

        public Perceptron(int weightSize, double learningRate = 0.01, double bias = 1, bool randomizeWeightsandBias = true)
        {          
            _totalError = 0;
            _learningRate = learningRate;
            _weights = Array<double>.AllZeroes(weightSize);
            _x_i = new List<int[]>(4);
            _y_i = new int[4];
            
            if (randomizeWeightsandBias)
            {
                var rand = new Random();
                _weights = Array<double>.Randomize(weightSize);
                _bias = rand.NextDouble() * 2 - 1;
            }
            else
            {
                _bias = bias;
            }
        }

        public double Bias
        {
            get { return _bias; }
            set { _bias = value; }
        }

        public double LearningRate
        {
            get { return _learningRate; }
            set { _learningRate = value; }
        }

        public double[] Weights
        {
            get 
            { 
                return _weights; 
            }
        }

        public List<int[]> X_i 
        {
            get => _x_i; 
            set
            {
                _x_i = value;
            }
        }
        public int[] Y_i
        {
            get => _y_i;
            set
            {
                _y_i = value;
            }
        }

        /// <summary>
        /// This method will perform the dot product of weights and the in input instance.
        /// </summary>
        /// <param name="x">The input instance</param>
        /// <returns>The output of dot product</returns>
        public double NetInput(int[] x)
        {
            double dotProduct = 0;
            for (int i = 0; i < x.Length; i++)
            {
                dotProduct += x[i] * _weights[i];
            }

            dotProduct += _bias;

            return dotProduct;
        }

        /// <summary>
        /// This method will return the output of the perceptron
        /// </summary>
        /// <param name="netInput">The output of the dot product</param>
        /// <returns>y' value</returns>
        public double Activation(double netInput)
        {
            // using sigmoid function
            return 1 / (1 + Math.Exp(-netInput));
        }

        /// <summary>
        ///  This method will train the perceptron with the given input instances.
        /// </summary>
        /// <param name="epoch">The number of iterations to train the perceptron</param>
        public void Train(int epoch = 100)
        {
            for (int start = 0; start < epoch; start++)
            {
                for (int i = 0; i < X_i.Count; i++)
                {
                    var linear_output = NetInput(X_i[i]);
                    var y_pred = Activation(linear_output);
                    var error = Y_i[i] - y_pred;

                    // O(1) optimization since we know the size of the weights array
                    // and it's only in the sense of logic gate which is 2 inputs 1 and 0.
                    _weights[0] += _learningRate * error * X_i[i][0];
                    _weights[1] += _learningRate * error * X_i[i][1];

                    _bias += LearningRate * error;
                    _totalError += error;
                }

                if (_totalError <= 0)
                    break;
            }
        }
    }
}