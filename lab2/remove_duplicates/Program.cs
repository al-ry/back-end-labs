using System;


namespace remove_duplicates
{
    class Program
    {
        static bool ParseArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return false;
            }
            return true;
        }
        static string RemoveDuplicates(string sourceString)
        {
            string resultStr = sourceString;
            for (int i = 0; i < resultStr.Length; i++)
            {
                for (int j = resultStr.Length - 1; j > i ; j--)
                {
                    if (resultStr[i] == resultStr[j])
                    {
                        resultStr = resultStr.Remove(j, 1);
                    }
                }
            }
            return resultStr;
        }
        static int Main(string[] args)
        {
            if (!ParseArgs(args))
            {
                return 1;
            }
            string inputStr = args[0];
            string resultStr = RemoveDuplicates(inputStr);
            Console.WriteLine(resultStr);
            return 0;
        }
    }
}
