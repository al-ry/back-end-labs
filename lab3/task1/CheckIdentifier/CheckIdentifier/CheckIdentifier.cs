using System;

namespace CheckIdentifier
{
    public class Program
    {
        static public bool IsDigit(char ch)
        {
            return (ch >= '0' && ch <= '9');
        }

        public static bool IsLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }
        public static bool ParseArg(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return false;
            }
            return true;
        }

        public static bool CheckIdentifier(string identifier)
        {
            if (IsDigit(identifier[0]))
            {
                Console.WriteLine("No");
                Console.WriteLine("Identifier mustn't begin with number");
                return false;
            }
            for (int i = 0; i < identifier.Length; i++)
            {
                if (!IsDigit(identifier[i]) && !IsLetter(identifier[i]))
                {
                    Console.WriteLine("No\nInvalid identifier is found: " + "'" + identifier[i] + "'" + ", in position: " + i + "");
                    return false;
                }
            }
            Console.WriteLine("Yes");
            return true;
        }


        static int Main(string[] args)
        {
            if (!ParseArg(args))
            {
                return 1;
            }
            string identifier = args[0];
            if (!CheckIdentifier(identifier))
            {
                return 1;
            }
            return 0;
        }
    }
}
