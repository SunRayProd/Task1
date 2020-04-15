using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.IO;

namespace New_Way
{
    public abstract class Anzlizer
    {
       public abstract double DisplayBiggerNumber(double a, double b);
    }
    public class NumberAnalizer : Anzlizer
    {
        public double input;
        public static bool Check { get; set; }
        public bool ValidateInput()
        {
            string ourInput = Console.ReadLine();
            var regex = new Regex(@"^\d*\d+$");
            bool check = regex.IsMatch(ourInput);
            if (check)
            {
                input = Convert.ToDouble(ourInput);
                Check = true;
            }
            else
            {
                Console.WriteLine("You enter wrong symbols! \nPlease try again");
                Console.WriteLine("To exit this program press - Y, or you may try again press - N");

                    ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);

                }
                else if (key.Key == ConsoleKey.N)
                    {
                    Console.ReadKey();
                    Console.Clear();
                    Check = false;
                    }
                else
                {
                    Console.WriteLine("Next time choose wrigt button!");
                    Environment.Exit(0);
                }
            }
            return check;
        }
        public override double DisplayBiggerNumber(double a, double b)
        {
            double sum;
            if (a > b)
            {
                sum = a;
                Console.WriteLine(a + " is bigger.");
            }
            else if (Math.Abs(a - b) < 0.005)
            {
                sum = a;
                Console.WriteLine("Your numbers are equal " + a + " = " + b);
            }
            else
            {
                sum = b;
                Console.WriteLine(b + " is bigger");
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NumberAnalizer numberAnalizer = new NumberAnalizer();
            bool check = NumberAnalizer.Check;
            do
            {
                Console.WriteLine("Please, enter your first number:");
                numberAnalizer.ValidateInput();
                check = NumberAnalizer.Check;
            } while (!check);
                double firstInput = numberAnalizer.input;
                Console.Clear();
                NumberAnalizer secondAnalizer = new NumberAnalizer();
                check = NumberAnalizer.Check;
            do
            {
                Console.WriteLine("Please, enter your second number:");
                secondAnalizer.ValidateInput();
                check = NumberAnalizer.Check;
            } while (!check);
                double secondInput = secondAnalizer.input;
            double result = numberAnalizer.DisplayBiggerNumber(firstInput, secondInput);
        }
    }
}
