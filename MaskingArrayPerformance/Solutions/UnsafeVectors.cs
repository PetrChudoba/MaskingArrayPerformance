using System.Numerics;
using System.Runtime.CompilerServices;

namespace MaskingArray
{
    public class UnsafeVectors
    {
        public unsafe byte[] Mask(byte[] array, byte[] mask)
        {
            int byteVectorSize = Vector<byte>.Count;
            var outputArray = new byte[array.Length];
           
            fixed (byte* arr = array, msk = mask)
            {
                for (int i = 0; i + byteVectorSize <= array.Length; i += byteVectorSize)
                {
                 
                    Vector<byte> arrayVector = Unsafe.Read<Vector<byte>>( arr + i);
                    Vector<byte> maskVector = Unsafe.Read<Vector<byte>>(msk + i);


                    var zeroBits = Vector.Equals(maskVector, Vector<byte>.Zero);

                    var resultVector = (arrayVector & zeroBits) | maskVector;


                    resultVector.CopyTo(outputArray, i);
                }
            }



            int remainder = array.Length % byteVectorSize;

            
            for (int i = array.Length - remainder  ; i < array.Length; i++)
            {
                outputArray[i] = mask[i] != 0 ? mask[i] : array[i];
            }
            

            return outputArray;
        }
    }
}
