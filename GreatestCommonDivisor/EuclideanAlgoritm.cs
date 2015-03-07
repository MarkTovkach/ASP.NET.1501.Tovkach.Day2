using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Delegate type for my methods
    /// </summary>
    /// <param name="elapsedTime"></param>
    /// <param name="u"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public delegate int CommonDivisor(out double elapsedTime, int u, int v);

    public class EuclideanAlgoritm
    {
        /// <summary>
        /// Method of finding Greatest Common Divisor by Euclidian algoritm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="elapsedTime"></param>
        /// <returns></returns>
        public static int EuclidGreatestCommonDivisor(out double elapsedTime, int a, int b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            sw.Stop();
            elapsedTime = sw.Elapsed.TotalMilliseconds;
            return Math.Abs(a);
        }

        /// <summary>
        /// Method of finding Greatest Common Divisor by Stein algoritm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="elapsedTime"></param>
        /// <returns></returns>
        public static int BinaryCD(out double elapsedTime, int a, int b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            elapsedTime = sw.Elapsed.TotalMilliseconds;
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * BinaryCD(out elapsedTime, a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return BinaryCD(out elapsedTime, a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return BinaryCD(out elapsedTime, a, b / 2);
            sw.Stop();
            elapsedTime = sw.Elapsed.TotalMilliseconds;
            return BinaryCD(out elapsedTime, b, Math.Abs(a - b));

        }

        /// Overloaded version with params
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int GCD(out double elapsedTime, CommonDivisor function, params int[] a)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (a.Length == 1)
            {
                elapsedTime = 0;
                return a[0];
            }
            int result = function(out elapsedTime, a[0], a[1]);
            for (int i = 1; i < a.Length; i++)
            {
                result = function(out elapsedTime, a[i], result);
            }

            sw.Stop();
            elapsedTime = sw.Elapsed.TotalMilliseconds;
            return result;
        }


    }
}
