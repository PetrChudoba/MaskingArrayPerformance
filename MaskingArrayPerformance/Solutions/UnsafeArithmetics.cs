namespace MaskingArray
{
    public class UnsafeArithmetics
    {
        public unsafe byte[] Mask(byte[] array, byte[] mask)
        {
            var outputArray = new byte[array.Length];

            fixed(byte* arr = array, ms = mask, outp = outputArray)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    *(outp +i)   = *(ms + i) != 0 ? *(ms + i) : *(arr + i);
                }

            }
           
            return outputArray;
        }
    }
}
