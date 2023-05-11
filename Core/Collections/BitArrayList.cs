using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace AsmParser.Core.Collections
{
    public class BitArrayList
    {
        private BitArray _bitArray;
        public int Count => _bitArray.Count;

        public BitArrayList([NotNull] BitArray bitArray)
        {
            _bitArray = bitArray;
        }

        public bool Get(int index)
        {
            if (index > _bitArray.Count - 1)
            {
                Console.Error.WriteLine($"{this}:: tried to access index {index} of a {Count} sized BitArray");
            }

            return _bitArray.Get(index);
        }

        public void AppendBits(BitArray extraBits)
        {
            List<bool> bitList = new(Count + extraBits.Count);
            for (var i = 0; i < Count; i++)
            {
                bitList.Add(_bitArray.Get(i));
            }
            for (var i = 0; i < extraBits.Count; i++)
            {
                bitList.Add(extraBits.Get(i));
            }
            _bitArray = new BitArray(bitList.ToArray());
        }
    }
}