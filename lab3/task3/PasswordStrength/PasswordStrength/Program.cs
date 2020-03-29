using System;
using System.Linq;


namespace PasswordStrength
{
    public struct Arguments
    {
        public string inputPassword;

    }
    public static class CPasswordStrength
    {
        public static int CalculateSecurityByLenght(string password)
        {
            return 4 * password.Length;
        }
        public static int CalculateSecurityByNumbersAmount(string password)
        {
            var count = password.Where((n) => n >= '0' && n <= '9').Count();
            return count *= 4;
        }

        public static int CalculateSecurityByUpperCaseLettersAmount(string password)
        {
            var count = password.Where((n) => n >= 'A' && n <= 'Z').Count();
            if (count != 0)
            {
                return (password.Length - count) * 2;
            }
            return 0;
        }

        public static int CalculateSecurityByLowerCaseLettersAmount(string password)
        {
            var count = password.Where((n) => n >= 'a' && n <= 'z').Count();
            if (count != 0)
            {
                return (password.Length - count) * 2;
            }
            return 0;
        }
        public static int CalculateSecurityByOnlyNumbers(string password)
        {
            var count = password.Where((n) => n >= '0' && n <= '9').Count();
            if (count == password.Length)
            {
                return -count;
            }
            return 0;
        }
        public static int CalculateSecurityByOnlyLetters(string password)
        {
            var count = password.Count(char.IsLetter);
            if (count == password.Length)
            {
                return -count;
            }
            return 0;
        }
        public static int CalculateSecurityByReapetedSymbols(string password)
        {
            var count = 0;
            var res = 0;
            char prevCh = '\0';
            foreach (var letter in password.Distinct().ToArray())
            {
                count = password.Count(chr => chr == letter);
                if (count != 1)
                {
                    res += count;
                }
            }
            return -res;
        }
        public static int PasswordStrength(string password)
        {
            int passwordStrenght = 0;
            passwordStrenght += CalculateSecurityByLenght(password);
            passwordStrenght += CalculateSecurityByNumbersAmount(password);
            passwordStrenght += CalculateSecurityByUpperCaseLettersAmount(password);
            passwordStrenght += CalculateSecurityByLowerCaseLettersAmount(password);
            passwordStrenght += CalculateSecurityByOnlyLetters(password);
            passwordStrenght += CalculateSecurityByOnlyNumbers(password);
            passwordStrenght += CalculateSecurityByReapetedSymbols(password);
            return passwordStrenght;
        }
    }

    class Program
    {
        public static Arguments? ParseArg(string[] args)
        {
            Arguments arguments = new Arguments();
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
                Console.WriteLine("Usage: PasswordStrength.exe <input password>");
                return null;
            }
            arguments.inputPassword = args[0];
            return arguments;
        }
        static int Main(string[] args)
        {
            Arguments? arguments = new Arguments();
            arguments = ParseArg(args);
            if (arguments == null)
            {
                return 1;
            }
            int passwordStrenght = CPasswordStrength.PasswordStrength(arguments.Value.inputPassword);
            return 1;
        }
    }
}
