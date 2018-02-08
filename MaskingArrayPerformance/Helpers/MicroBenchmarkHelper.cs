using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingArray.Helpers
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class containting two methods which run given method for specified time period or number of iterations and returns average running time.
    /// </summary>
    internal static class MicroBenchmarkHelper
    {
        /// <summary>
        /// Run the benchmarked method for given time period in milliseconds.
        /// </summary>
        /// <param name="milliseconds">Testing time in milliseconds.</param>
        /// <param name="action">Benchmarked method.</param>
        /// <returns>Average running time in milliseconds.</returns>
        public static double RunMilliseconds(int milliseconds, Action action, bool allowDebugBenchmark = false)
        {
#if DEBUG
            if (!allowDebugBenchmark)
                throw new ArgumentException("Benchmarking in debug build is not alllowed, change the build mode or set allowDebugBenchmark parameter to true");
#endif

            if (Debugger.IsAttached && !allowDebugBenchmark)
                throw new ArgumentException("Benchmarking with debugging is not allowed, run it without debugging or set allowDebugBenchmark to true.");
            if (milliseconds < 1)
                throw new ArgumentException($"{nameof(milliseconds)} must be greater than or equal to 1");
            if (action == null)
                throw new ArgumentException($"{nameof(action)} must not be null");

            // Perform garbage collection.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Force JIT compilation of the method.
            action.Invoke();

            // Run the benchmark.
            long iterations = 0;
            Stopwatch watch = Stopwatch.StartNew();
            while (watch.ElapsedMilliseconds < milliseconds)
            {
                iterations++;
                action.Invoke();
            }
            watch.Stop();

            //More precise than watch.ElapsedMilliseconds 
            double elapsedMilliseconds = watch.Elapsed.TotalMilliseconds;

            double averageTime = elapsedMilliseconds / iterations;
            return averageTime;
        }

        /// <summary>
        /// Run iterations of the benchmarked method.
        /// </summary>
        /// <param name="iterations">Number of iterations.</param>
        /// <param name="action">Benchmarked method.</param>
        /// <returns>Average running time in milliseconds.</returns>
        public static double RunIterations(int iterations, Action action, bool allowDebugBenchmark = false)
        {
#if DEBUG
            if (!allowDebugBenchmark)
                throw new ArgumentException("Benchmarking in debug build is not alllowed, change the build mode or set allowDebugBenchmark parameter to true");
#endif

            if (Debugger.IsAttached && !allowDebugBenchmark)
                throw new ArgumentException("Benchmarking with debugging is not allowed, run it without debugging or set allowDebugBenchmark to true.");
            if (iterations < 1)
                throw new ArgumentException($"{nameof(iterations)} must be greater than or equal to 1");
            if (action == null)
                throw new ArgumentException($"{nameof(action)} must not be null");

            // Perform garbage collection.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Force JIT compilation of the method.
            action.Invoke();

            // Run the benchmark.
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                action.Invoke();
            }
            watch.Stop();

            //More precise than watch.ElapsedMilliseconds 
            double elapsedMilliseconds = watch.Elapsed.TotalMilliseconds;

            double averageTime = elapsedMilliseconds / iterations;
            return averageTime;
        }
    }
}
