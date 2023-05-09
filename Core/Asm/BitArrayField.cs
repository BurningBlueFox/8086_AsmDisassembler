using System.Collections;

namespace Core.Asm
{
    internal struct BitArrayField
    {
        public int _index;
        public bool _shouldBeSetTo;
        public BitArrayField(int index, bool shouldBeSetTo)
        {
            _index = 0;
            _shouldBeSetTo = shouldBeSetTo;
        }

        public BitArrayField(int index, int shouldBeSetTo)
        {
            _index = index;
            _shouldBeSetTo = shouldBeSetTo == 0 ? false : true;
        }

        internal static bool ValidateBitArrayFields(IEnumerable<BitArrayField> fields, BitArray arr)
        {
            foreach (var field in fields)
            {
                if (arr.Get(field._index) != field._shouldBeSetTo)
                {
                    return false;
                }
            }
            return true;
        }
    }
}