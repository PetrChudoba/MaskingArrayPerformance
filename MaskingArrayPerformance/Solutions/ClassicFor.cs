namespace MaskingArray
{
    public class ClassicFor
    {
        public byte[] Mask(byte[] array , byte[] mask)
        {
            var outputArray = new byte[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                outputArray[i] = mask[i] != 0 ? mask[i] : array[i];
            }

            return outputArray;
        }
    }
}
