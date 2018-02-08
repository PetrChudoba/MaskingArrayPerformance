using MaskingArray.Helpers;
using System;
using System.Collections.Generic;

namespace MaskingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // 120MB photo
            int arrayLength = 120000000;
            // Roughly every tenth value is zero 
            int expectedZero = 10; 

            var array1 = new byte[arrayLength];
            var mask = new byte[arrayLength];

            // Every benchmark test takes 5seconds
            int testTime = 5000;

            Random r = new Random();

            for (int i = 0; i < arrayLength; i++)
            {
                array1[i] = (byte) r.Next(255);
                mask[i] = (byte) (r.Next(expectedZero -1) == 0 ? 0 : r.Next(255));  
            }

            var cf = new ClassicFor();
            var pf = new ParallelFor();
            var linq = new LinqSolution();
            var uf = new UnsafeArithmetics();
            var uf2 = new UnsafeIncrements();
            var vectors = new Vectors();
            var vectors2 = new UnsafeVectors();

            var cfTime = MicroBenchmarkHelper.RunMilliseconds(testTime, () => cf.Mask(array1, mask));
            var pfTime = MicroBenchmarkHelper.RunMilliseconds(testTime, () => pf.Mask(array1, mask));
            var linqTime = MicroBenchmarkHelper.RunMilliseconds(testTime, () => linq.Mask(array1, mask));
            var ufTime = MicroBenchmarkHelper.RunMilliseconds(testTime, () => uf.Mask(array1, mask));
            var ufTime2 = MicroBenchmarkHelper.RunMilliseconds(testTime, () => uf2.Mask(array1, mask) );
            var vectTime = MicroBenchmarkHelper.RunMilliseconds(testTime, () => vectors.Mask(array1, mask));
            var vectTime2 = MicroBenchmarkHelper.RunMilliseconds(testTime, () => vectors2.Mask(array1, mask));

            Console.WriteLine("For:                     {0}",cfTime);
            Console.WriteLine("Parallel.For:            {0}",pfTime);
            Console.WriteLine("Linq:                    {0}", linqTime);
            Console.WriteLine("Unsafe (arithmetics):    {0}", ufTime);
            Console.WriteLine("Unsafe (increments):     {0}", ufTime2);
            Console.WriteLine("Vectors:                 {0}", vectTime);
            Console.WriteLine("Unsafe vectors:          {0}", vectTime2);

            Console.ReadLine();


        }
    }
}
