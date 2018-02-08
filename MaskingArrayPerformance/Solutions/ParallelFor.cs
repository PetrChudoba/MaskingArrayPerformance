using System.Threading.Tasks;

namespace MaskingArray
{
    public class ParallelFor
    {
        public byte[] Mask(byte[] array, byte[] mask)
        {
            var outputArray = new byte[array.Length];

            Parallel.For(0, array.Length, i =>
            {
                outputArray[i] = mask[i] != 0 ? mask[i] : array[i];

            });
            return outputArray;
        }
    }
}
