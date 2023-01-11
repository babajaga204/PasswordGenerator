using System;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;

namespace PasswordGenerator
{
    internal class Program
    {
        static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                ShowOptions();
                return;
            }

            var length = Convert.ToInt32(args[0]);
            var options = args[1];

            var pattern = options.PadRight(length, 'l');
            // StringBuffer
            var password = string.Empty;

            while (pattern.Length > 0)
            {

                var randomIndex = Random.Next(0, pattern.Length - 1);
                var category = pattern[randomIndex];


                // extract char at rand index and add remaining substrings together
                pattern = pattern.Substring(0, randomIndex) +
                          pattern.Substring(randomIndex + 1, pattern.Length - randomIndex - 1);

                if (category == 'l') password += WriteRandomLowerCaseLetter();
                else if (category == 'L') password += WriteRandomUpperCaseLetter();
                else if (category == 'd') password += WriteRandomInt();
                else password += WriteRandomSpecialChar();
            }

            Console.WriteLine(password);

        }

        private static char WriteRandomLowerCaseLetter()
        {
            return GetRandomLetter('a', 'z');
        }
        private static char WriteRandomUpperCaseLetter()
        {
            return GetRandomLetter('A', 'Z');
        }

        private static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }

        private static char WriteRandomInt()
        {
            return Random.Next(0, 9).ToString()[0];
        }

        private static char WriteRandomSpecialChar()
        {
            var allChars = "!\"?#¤%&/(){}[]"; 
            var index = Random.Next(0, allChars.Length - 1);
            return allChars[index];
        }

        private static bool IsValid(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    return false;
                case 2:
                    CheckArgs(args);
                    return true;
                default:
                    return false;
            }
        }
        private static void CheckArgs(string[] args)
        {
            if (!CheckFirstArg(args[0])) { Console.WriteLine("Please enter a valid number"); ShowOptions(); }
            else if (!CheckSecondArg(args[1])) { Console.WriteLine("Please insert valid options"); ShowOptions(); }
        }

        private static bool CheckFirstArg(string firstArg)
        {
            foreach (var c in firstArg)
            {
                return char.IsDigit(c);
            }
            return true;
        }
        private static bool CheckSecondArg(string secondArg)
        {
            if (secondArg.Length == 0) { return false; }
            foreach (var c in secondArg)
            {
                if (!CheckChar(c))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private static bool CheckChar(char c)
        {
            if (c == 'l' || c == 'L' || c == 'd' || c == 's') { return true; }
            else { return false; }
        }
        static void ShowOptions()
        {
            Console.WriteLine("PasswordGenerator");
            Console.WriteLine("");
            Console.WriteLine("Write: PasswordGenerator <length> <options>");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("     - l = lower case letter");
            Console.WriteLine("     - L = upper case letter");
            Console.WriteLine("     - d = digit");
            Console.WriteLine("     - s = special characters !\"?#¤%&/(){}[]");
            Console.WriteLine("");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
            Console.WriteLine("     Min. 1 lower case");
            Console.WriteLine("     Min. 1 upper case");
            Console.WriteLine("     Min. 2 special characters");
            Console.WriteLine("     Min. 2 digits");
        }
    }
}