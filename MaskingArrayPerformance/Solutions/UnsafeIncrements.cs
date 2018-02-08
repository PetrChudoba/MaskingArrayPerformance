namespace MaskingArray
{
    public class UnsafeIncrements
    {
        public unsafe byte[] Mask(byte[] array, byte[] mask)
        {
            var outputArray = new byte[array.Length];

            fixed (byte* arr = array, msk = mask, outp = outputArray)
            {
                byte* cArr = arr,  cMsk = msk , cOutp = outp;

                for (int i = 0; i < array.Length; i++)
                {
                    *cOutp = *cMsk  != 0 ? *cMsk : *cArr;

                    cArr++;
                    cMsk++;
                    cOutp++;
                }
            }

            return outputArray;
        }
    }
}
