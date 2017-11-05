using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad6
{
    public class Class1
    {
        public static async Task<int> FactorialDigitSum(int n)
        {
            return await Task.Run(() =>
            {
                int fact = 1;
                while (n != 1)
                {
                    fact *= n;
                    n -= 1;
                }

                char[] digits = fact.ToString().ToArray();

                return digits.Sum(d => int.Parse(d.ToString()));
            });

        }

    }
}