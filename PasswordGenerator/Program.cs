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
                CheckFirstArg(args);
                return true;
            }
        }
        static void CheckFirstArg(string[] args)
        {
            foreach (var c in args[0])
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Please enter a number.");
                    ShowOptions();
                }
                else
                {
                    Console.WriteLine("We did it! test");
                    //TODO: Convert string digits to ints and use for Password Length
                }
                
            }
        }
        static bool IsNumber(string[] args)
        {
            string firstArg = args[0];
        }
    }
}