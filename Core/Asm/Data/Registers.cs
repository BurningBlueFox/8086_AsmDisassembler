using System.Collections;

namespace Core.Asm.Data
{
    internal static class Registers
    {
        internal struct RegBits
        {
            internal bool b1, b2, b3;
            internal RegBits(bool b1, bool b2, bool b3)
            {
                this.b1 = b1;
                this.b2 = b2;
                this.b3 = b3;
            }
            internal RegBits(int b1, int b2, int b3)
            {
                this.b1 = b1 > 0;
                this.b2 = b2 > 0;
                this.b3 = b3 > 0;
            }
        }
        private static Dictionary<RegBits, string> _normalRegisters = new(){
            {new(0,0,0), "al"},
            {new(0,0,1), "cl"},
            {new(0,1,0), "dl"},
            {new(0,1,1), "bl"},
            {new(1,0,0), "ah"},
            {new(1,0,1), "ch"},
            {new(1,1,0), "dh"},
            {new(1,1,1), "bh"},
        };

        private static Dictionary<RegBits, string> _wideRegisters = new(){
            {new(0,0,0), "ax"},
            {new(0,0,1), "cx"},
            {new(0,1,0), "dx"},
            {new(0,1,1), "bx"},
            {new(1,0,0), "sp"},
            {new(1,0,1), "bp"},
            {new(1,1,0), "si"},
            {new(1,1,1), "di"},
        };

        internal static (string, string) GetRegisters(this BitArray arr)
        {
            int offset = 8;
            bool dField = arr.ValidateBitArray(Opcodes.MovDField);
            bool wField = arr.ValidateBitArray(Opcodes.MovWField);

            RegBits reg1 = new(arr.Get(offset + 5), arr.Get(offset + 4), arr.Get(offset + 3));
            RegBits reg2 = new(arr.Get(offset + 2), arr.Get(offset + 1), arr.Get(offset + 0));
            string parsedRegister1 = wField? _wideRegisters[reg1] : _normalRegisters[reg1];
            string parsedRegister2 = wField? _wideRegisters[reg2] : _normalRegisters[reg2];
            return dField? (parsedRegister1, parsedRegister2) : (parsedRegister2, parsedRegister1);
        }
    }
}