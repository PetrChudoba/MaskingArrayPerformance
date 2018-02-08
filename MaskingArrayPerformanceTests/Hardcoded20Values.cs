using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaskingArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;


namespace MaskingArray.Tests
{
    [TestClass()]
    public class Hardcoded20Values
    {
        private byte[] array = new byte[] { 12, 155,  12, 0, 255, 18, 82,   0, 12, 45,  12,  15, 78, 79,   1,  2, 99, 12, 15, 17 };
        private byte[] mask = new byte[] {   0,  12, 155, 0, 45,  12,  0, 255, 13,  0, 144, 177,  0,  0, 255, 99, 66, 59, 33,  0 };
        private byte[] exp = new byte[] {  12,  12, 155, 0, 45,  12, 82, 255, 13, 45, 144, 177, 78, 79, 255, 99, 66, 59, 33, 17 };

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