using System;
using System.Linq;

namespace Apportion
{
    public class Jefferson
    {

        public static Tuple<int[], int[], decimal[], decimal[], decimal, decimal> Calculate(int seats, int[] populations)
        {
            int states = populations.Length;
            decimal initialDivisor = populations.Sum() / (decimal)seats;
            decimal[] initialQuotas = new decimal[states];

            // Calculate the initial quotas.
            for (int i = 0; i < states; i++)
            {
                initialQuotas[i] = populations[i] / initialDivisor;
            }

            int[] initialFairShares = new int[states];

            // Calculate the initial fair shares.
            for (int i = 0; i < states; i++)
            {
                initialFairShares[i] = (int)Math.Floor(initialQuotas[i]);
            }

            decimal[] finalQuotas = new decimal[states];
            decimal[] decimalArray = new decimal[states];
            decimal modifiedDivisor = populations.Sum() / (decimal)seats;

            // Calculate the final quotas.
            for (int i = 0; i < states; i++)
            {
                finalQuotas[i] = populations[i] / modifiedDivisor;
                decimalArray[i] = finalQuotas[i] - Math.Truncate(populations[i] / modifiedDivisor);
            }

            int[] finalFairShares = new int[states];
            decimal estimator = populations.Sum() / seats;

            // Initialize final fair shares.
            for (int i = 0; i < states; i++)
            {
                finalFairShares[i] = (int)Math.Floor(initialQuotas[i]);
            }

            int timeKeeper = 0;

            // Begin apportionment.
            while (finalFairShares.Sum() != seats)
            {
                if (timeKeeper == 5000)
                {
                    break;
                }

                if (finalFairShares.Sum() > seats)
                {
                    modifiedDivisor += estimator;
                }
                else
                {
                    modifiedDivisor -= estimator;
                }

                estimator /= 2;

                if (modifiedDivisor == 0)
                {
                    modifiedDivisor = 1;
                }

                for (int i = 0; i < states; i++)
                {
                    finalQuotas[i] = populations[i] / modifiedDivisor;
                }

                for (int i = 0; i < states; i++)
                {
                    finalFairShares[i] = (int)Math.Floor(finalQuotas[i]);
                }

                timeKeeper++;
            }

            if (timeKeeper == 5000)
            {
                return null;
            }
            else
            {
                return Tuple.Create(initialFairShares, finalFairShares, initialQuotas, finalQuotas, initialDivisor, modifiedDivisor);
            }
        }
    }
}
