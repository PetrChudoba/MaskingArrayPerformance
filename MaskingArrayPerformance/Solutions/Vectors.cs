using System.Numerics;

namespace MaskingArray
{
    public class Vectors
    {
        public byte[] Mask(byte[] array, byte[] mask)
        {
            int byteVectorSize = Vector<byte>.Count;
            var outputArray = new byte[array.Length];


            for (int i = 0; i + byteVectorSize <= array.Length ; i += byteVectorSize)
            {
                
                var arrayVector = new Vector<byte>(array, i);
                var maskVector = new Vector<byte>(mask, i);

                var zeroBits = Vector.Equals(maskVector, Vector<byte>.Zero);

                var resultVector = (arrayVector & zeroBits) | maskVector;


                resultVector.CopyTo(outputArray, i);
            }

            int remainder = array.Length % byteVectorSize;


            for (int i = array.Length - remainder; i < array.Length; i++)
            {
                outputArray[i] = mask[i] != 0 ? mask[i] : array[i];
            }


            return outputArray;
        }
    }
}
