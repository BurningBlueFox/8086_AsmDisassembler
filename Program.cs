using System.Collections;
using Core;

if (args.Length > 0)
{
    AsmReader asmReader = new();
    AsmDecoder asmDecoder = new();

    var fileContents = await asmReader.ReadFile(args[0]);
    Console.WriteLine("bits 16\n");

    foreach (var b in fileContents)
    {
        Console.WriteLine(asmDecoder.DecodeAsm(b));
    }
}
else
{
    Console.WriteLine("No arguments");
    return;
}