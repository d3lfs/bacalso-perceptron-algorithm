namespace LogicGatesPerceptron.Utils
{
    public class TimeStamp
    {
        public static String GetUTCNow()
        {
            return Convert.ToString((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }
    }
    
}
