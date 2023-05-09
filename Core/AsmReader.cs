using System.Collections;

namespace Core
{
    public class AsmReader
    {
        public async Task<IEnumerable<BitArray>> ReadFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File {file} is not valid");
            }
            var bytes = await File.ReadAllBytesAsync(file);

            List<BitArray> returnList = new(bytes.Length / 2);
            for (int i = 0; i < bytes.Length; i += 2)
            {
                BitArray arr = new(new byte[2] { bytes[i], bytes[i + 1] });
                returnList.Add(arr);
            }
            return returnList;
        }
    }
}