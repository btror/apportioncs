using System;

namespace Apportion
{
    class Apportion
    {
        static void Main(string[] args)
        {
            var method = HuntingtonHill.Calculate(70, new int[] { 300500, 200000, 50000, 38000, 21500 });
            Console.WriteLine("Initial fair shares: " + String.Join(",", method.Item1));
            Console.WriteLine("Final fair shares: " + String.Join(",", method.Item2));
            Console.WriteLine("Initial quotas: " + String.Join(",", method.Item3));
            Console.WriteLine("Final quotas: " + String.Join(",", method.Item4));
            Console.WriteLine("Initial divisor: " + String.Join(",", method.Item5));
            Console.WriteLine("Modified divisor: " + String.Join(",", method.Item6));
        }
    }
}
