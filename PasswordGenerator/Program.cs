using System.Diagnostics.SymbolStore;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                ShowOptions();
                return;
            }
           
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
            Console.WriteLine("     - s = special characters !\"#¤%&/(){}[]");
            Console.WriteLine("");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
            Console.WriteLine("     Min. 1 lower case");
            Console.WriteLine("     Min. 1 upper case");
            Console.WriteLine("     Min. 2 special characters");
            Console.WriteLine("     Min. 2 digits");
        }

        static bool IsValid(string[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }
            else
            {
                CheckArgs(args);
                return true;
            }
        }
        static void CheckArgs(string[] args)
        {
            CheckFirstArg(args[0]);
            CheckSecondArg(args[1]);
        }

        private static void CheckFirstArg(string firstArg)
        {
            foreach (var c in firstArg)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Please enter a number");
                    ShowOptions();
                    return;
                }
                else
                {
                    Console.WriteLine("We did it! test");
                    //TODO: Convert string digits to int and use for Password Length Argument
                }
            }
        }
        private static void CheckSecondArg(string secondArg)
        {
            foreach (var c in secondArg)
            {
                CheckChar(c);
            }
        }
        private static bool CheckChar(char c)
        {
            if (c == 'l')
            {
                Console.WriteLine(c);
                return true;
            }
            else if (c == 'L')
            {
                Console.WriteLine(c);
                return true;
            }
            else if (c == 'd')
            {
                Console.WriteLine(c);
                return true;
            }
            else if (c == 's')
            {
                Console.WriteLine(c);
                return true;
            }
            Console.WriteLine("Please insert valid options");
            ShowOptions();
            return false;
        }
    }
}