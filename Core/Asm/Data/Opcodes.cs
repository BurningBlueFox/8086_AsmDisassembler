using System.Collections;

namespace Core.Asm.Data
{
    internal static class Opcodes
    {
        internal static IReadOnlyList<BitArrayField> OpMov = new List<BitArrayField>()
        {
            new(7, 1),
            new(6, 0),
            new(5, 0),
            new(4, 0),
            new(3, 1),
            new(2, 0)
        };

        internal static IReadOnlyList<BitArrayField> MovDField = new List<BitArrayField>()
        {
            new(1, 1)
        };

        internal static IReadOnlyList<BitArrayField> MovWField = new List<BitArrayField>()
        {
            new(0, 1)
        };

        internal static bool ValidateBitArray(this BitArray arr, IEnumerable<BitArrayField> fields)
        {
            return BitArrayField.ValidateBitArrayFields(fields, arr);
        }
    }
}