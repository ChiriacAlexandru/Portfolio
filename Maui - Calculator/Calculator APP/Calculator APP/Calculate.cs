using System;

namespace SimpleCalculator
{
    public static class Calculate
    {
        public static double DoCalculation(double val1, double val2, string operatorMath)
        {
            return operatorMath switch
            {
                "/" => val2 == 0 ? 0 : val1 / val2,  
                "-" => val1 - val2,
                "*" => val1 * val2,
                "+" => val1 + val2,
                _ => 0
            };
        }
    }
}
