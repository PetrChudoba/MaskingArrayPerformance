using MaskingArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingArrayPerformanceTests
{
    [TestClass()]
    public class Generated3333Values
    {
        private const int arrayLength = 3333;
        private const int seed = 4242;
        private const int expectedZero = 10;

        private readonly Random r = new Random(seed);
        private byte[] array = new byte[arrayLength];
        private byte[] mask = new byte[arrayLength];

        private byte[] exp = new byte[arrayLength];

        public Generated3333Values()
        {



            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = (byte)r.Next(255);
                mask[i] = (byte)(r.Next(expectedZero - 1) == 0 ? 0 : r.Next(255));

                exp[i] = mask[i] != 0 ? mask[i] : array[i];
            }
        }



        [TestMethod()]
        public void ClassicForMaskTest()
        {
            // Arrange
            var vs = new ClassicFor();
            byte[] output;

            // Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void ParallelForMaskTest()
        {
            // Arrange
            var vs = new ParallelFor();
            byte[] output;

            // Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void LinqSolutionMaskTest()
        {
            // Arrange
            var vs = new LinqSolution();
            byte[] output;

            //Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void UnsafeArithmeticsMaskTest()
        {
            // Arrange
            var vs = new UnsafeArithmetics();
            byte[] output;

            // Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void UnsafeIncrementsMaskTest()
        {
            // Arrange
            var vs = new UnsafeIncrements();
            byte[] output;

            //Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void VectorsMaskTest()
        {
            // Arrange
            var vs = new Vectors();
            byte[] output;

            // Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }

        [TestMethod()]
        public void UnsafeVectorsMaskTest()
        {
            // Arrange
            var vs = new UnsafeVectors();
            byte[] output;

            // Act
            output = vs.Mask(array, mask);

            // Assert
            output.ShouldBe(exp);

        }


    }
}
