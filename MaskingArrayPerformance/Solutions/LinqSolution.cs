using System.Linq;

namespace MaskingArray
{
    public class LinqSolution
    {
        public byte[] Mask(byte[] array, byte[] mask)
        {
            return array.Zip(mask, (arr, msk) => msk != 0 ? msk : arr).ToArray();
        }

    }
}
