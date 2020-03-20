using System;

namespace print_args
{
    class Program
    {

        static bool ParseArgs(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Number of arguments: " + args.Length);
                Console.Write("Arguments: ");
                for (uint i = 0; i < args.Length; i++)
                {
                    Console.Write(args[i] + " ");
                }
                return true;
            }
            else
            {
                Console.WriteLine("No parameters were specified!");
                return false;
            }
        }

        static int Main(string[] args)
        {
            if(!ParseArgs(args))
            {
                return 1;
            }
            return 0;
        }
    }
}
