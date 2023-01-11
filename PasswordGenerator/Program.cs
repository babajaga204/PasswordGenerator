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


            string pattern = args[1].PadRight(Convert.ToInt32(args[0]), 'l');
            Console.WriteLine(pattern);

        }

        static bool IsValid(string[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }
            else if (args.Length == 2)
            {
                CheckArgs(args);
                return true;
            }
            else
            {
                return false;
            }
        }
        static void CheckArgs(string[] args)
        {
            if (!CheckFirstArg(args[0])) { Console.WriteLine("Please enter a valid number"); ShowOptions(); }
            else if (!CheckSecondArg(args[1])) { Console.WriteLine("Please insert valid options"); ShowOptions(); }
        }

        private static bool CheckFirstArg(string firstArg)
        {
            foreach (var c in firstArg)
            {
                if (!char.IsDigit(c))
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
            Console.WriteLine("     - s = special characters !\"#¤%&/(){}[]");
            Console.WriteLine("");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
            Console.WriteLine("     Min. 1 lower case");
            Console.WriteLine("     Min. 1 upper case");
            Console.WriteLine("     Min. 2 special characters");
            Console.WriteLine("     Min. 2 digits");
        }
    }
}