using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace RemoveExtraBlanks
{
    struct Arguments
    {
        public string inputFile;
        public string outputFile;
    }
    class Program
    {
        static Arguments? ParseArg(string[] args)
        {
            Arguments arguments = new Arguments();
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments");
                Console.WriteLine("Usage: RemoveExtraBlanks.exe <input file> <output file>");
                return null;
            }
            arguments.inputFile = args[0];
            arguments.outputFile = args[1];
            return arguments;
        }
      

        static int Main(string[] args)
        {
            Arguments? arguments = new Arguments();
            arguments = ParseArg(args);
            if (arguments.HasValue)
            {
                return 1;
            }

            return 0;
        }
    }
}
