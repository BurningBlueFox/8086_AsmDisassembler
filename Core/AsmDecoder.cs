using System.Collections;
using System.Text;
using Core.Asm;
using Core.Asm.Data;

namespace Core
{
    public class AsmDecoder
    {
        StringBuilder strBuilder = new(16);
        public string DecodeAsm(BitArray bitArray)
        {
            strBuilder.Clear();
            var instruction = GetInstruction(bitArray);
            strBuilder.Append(instruction + " ");
            switch (instruction)
            {
                case "mov":
                    strBuilder.Append(DecodeMov(bitArray));
                    break;
                default:
                    return strBuilder.ToString();
            }
            return strBuilder.ToString();
        }


        private string DecodeMov(BitArray bitArray)
        {
            var registers = bitArray.GetRegisters();
            ModMode modMode = GetModMode(bitArray);
            return $"{registers.Item1}, {registers.Item2}";
        }

        private ModMode GetModMode(BitArray bitArray)
        {
            int offset = 8;
            if (bitArray.Get(7 + offset) == true &&
            bitArray.Get(6 + offset) == true)
            {
                return ModMode.RegisterToRegister;
            }
            return default;
        }

        public string GetInstruction(BitArray bitArray)
        {
            if (bitArray.ValidateBitArray(Opcodes.OpMov))
            {
                return "mov";
            }
            return string.Empty;
        }
    }
}