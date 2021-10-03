using System;

namespace Apportion
{
    class Apportion
    {
        static void Main(string[] args)
        {
            var method = Adam.Calculate(15, new int[] { 25, 34, 65, 77 });
            Console.WriteLine("Initial fair shares: " + String.Join(",", method.Item1));
            Console.WriteLine("Final fair shares: " + String.Join(",", method.Item2));
            Console.WriteLine("Initial quotas: " + String.Join(",", method.Item3));
            Console.WriteLine("Final quotas: " + String.Join(",", method.Item4));
            Console.WriteLine("Initial divisor: " + String.Join(",", method.Item5));
            Console.WriteLine("Modified divisor: " + String.Join(",", method.Item6));
        }
    }
}
