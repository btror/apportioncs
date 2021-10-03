using System;
using System.Linq;

namespace Apportion
{
    class EqualProportions
    {

        public static Tuple<int[]> Calculate(int seats, int[] populations)
        {
            int states = populations.Length;
            int[] fairShares = new int[states];

            // Each state gets one seat by default.
            for (int i = 0; i < states; i++)
            {
                fairShares[i] = 1;
            }

            decimal[] priorityNumbers = new decimal[states];
            for (int i = 0; i < states; i++)
            {
                priorityNumbers[i] = (decimal)(populations[i] / Math.Sqrt(fairShares[i] * (fairShares[i] + 1)));
            }

            while (fairShares.Sum() != seats)
            {
                for (int i = 0; i < states; i++)
                {
                    priorityNumbers[i] = (decimal)(populations[i] / Math.Sqrt(fairShares[i] * (fairShares[i] + 1)));
                }

                decimal highestPriority = priorityNumbers.Max();
                int index = Array.IndexOf(priorityNumbers, highestPriority);
                fairShares[index]++;
            }


            return Tuple.Create(fairShares);
        }
    }
}
