using CharacterRecognitionPerceptron.Utils;

namespace CharacterRecognitionPerceptron.Common
{
    /// <summary>
    /// This class represents a perceptron.
    /// </summary>
    public class Perceptron
    {
        private double _bias;
        private double _learningRate;
        private double[] _weights;

        private double _totalError;

        private int[] _input;
        private int _output;

        public Perceptron(int weightSize, double learningRate = 0.001, double bias = 0.5, bool randomizeWeights = true)
        {          
            _totalError = 0;
            _learningRate = learningRate;
            _weights = Array<double>.AllZeroes(weightSize);
            _bias = bias;

            if (randomizeWeights)
            {
                var rand = new Random();
                _weights = Array<double>.NormalDistribution(weightSize);
            }
        }

        /// <summary>
        /// This property will return the weights of the perceptron.
        /// </summary>
        public double[] Weights { get => _weights; }

        /// <summary>
        /// This property will return the total error.
        /// </summary>
        public double TotalError { get => _totalError; }
        
        /// <summary>
        /// This will property will be used to set and get learning rate of the perceptron
        /// </summary>
        public double LearningRate
        {
            get => _learningRate;
            set
            {
                _learningRate = value;
            }
        }

        /// <summary>
        /// This method will set the <paramref name="input"/>
        /// </summary>
        /// <param name="input">The input X_i array</param>
        public void SetInput(int[] input)
        {
            _input = input;
        }

        /// <summary>
        /// This method will set the corresponding <paramref name="output"/> of input
        /// </summary>
        /// <param name="output">The output y</param>
        public void SetDesiredOutput(int output)
        {
            _output = output;
        }

        /// <summary>
        /// This method will predict the given <paramref name="input"/>
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The prediction if vowel; otherwise consonant</returns>
        public string Prediction(int[] input)
        {   
            var linear_output = NetInput(input);
            var y_pred = Activation(linear_output);

            return y_pred > 0.5 ? "vowel" : "consonant";
        }

        /// <summary>
        /// This method will perform the dot product of weights and input instance.
        /// </summary>
        /// <param name="x">The input instance</param>
        /// <returns>The output of dot product</returns>
        private double NetInput(int[] input)
        {
            double dotProduct = 0;
            for (int i = 0; i < input.Length; i++)
            {
                dotProduct += _weights[i] * input[i];
            }

            dotProduct += _bias;

            return dotProduct;
        }

        /// <summary>
        /// This method will return the output of the perceptron
        /// </summary>
        /// <param name="netInput">The output of the dot product</param>
        /// <returns>y' value</returns>
        private double Activation(double netInput)
        {
            // using sigmoid function
            return 1 / (1 + Math.Exp(-netInput));
        }

        /// <summary>
        ///  This method will train the perceptron with the given input instances.
        /// </summary>
        /// <param name="epoch">The number of iterations to train the perceptron</param>
        public void Learn()
        {
            var linear_output = NetInput(_input);
            var y_pred = Activation(linear_output);
            var error = _output - y_pred;

            // Update weights
            for (int i = 0; i < _weights.Length; i++)
            {
                _weights[i] += _learningRate * error * _input[i];
            }

            _bias += _learningRate * error;
            _totalError += error;
        }
    }
}