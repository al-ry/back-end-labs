using System;

using System.IO;


namespace RemoveExtraBlanks
{
    public struct Arguments
    {
        public string inputFile;
        public string outputFile;
    }
    public class Program
    {
        public static Arguments? ParseArg(string[] args)
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

        public static string RemoveExtraBlanks(string line)
        {
            line = line.Trim();
            line = System.Text.RegularExpressions.Regex.Replace(line, "\\s+|\\t+", " ");
            return line;
        }

        public static void CopyFileWithRemoveExtraBlanks(StreamReader inputStream, StreamWriter outputStream)
        {
            string line;
            while ((line = inputStream.ReadLine()) != null)
            {
                outputStream.WriteLine(RemoveExtraBlanks(line));
            }
            try
            {
                outputStream.Flush();
            }
            catch
            {
                Console.WriteLine("Failed to write data to output file!");
            }
        }

        public static bool OpenAndCopyFileWithRemoveExtraBlanks(string inputFileName, string outputFileName)
        {
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Source input file doesn't exist");
                return false;
            }

            using StreamReader streamReader = new StreamReader(inputFileName);
            using StreamWriter streamWriter = new StreamWriter(outputFileName);
           
            CopyFileWithRemoveExtraBlanks(streamReader, streamWriter);

            return true;
        }


        static int Main(string[] args)
        {
            Arguments? arguments = new Arguments();
            arguments = ParseArg(args);
            if (arguments == null)
            {
                return 1;
            }
            if (!OpenAndCopyFileWithRemoveExtraBlanks(arguments.Value.inputFile, arguments.Value.outputFile))
            {
                return 1;
            }
            return 0;
        }
    }
}
