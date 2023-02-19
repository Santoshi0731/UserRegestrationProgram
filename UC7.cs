using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserRegistrationProgram
{

    public class UserName6
    {
        public static void Passmin1num()      //UC7
        {
            Console.WriteLine("Enter your Password");
            string userInput = Console.ReadLine();
            string regexCondition = "^[a-zA-Z]{7}[0-9]{1}$";
            Iteration(userInput, regexCondition);
        }

        public static void Iteration(string userInput, string regexCondition)
        {
            if (Regex.IsMatch(userInput, regexCondition))
            {
                Console.WriteLine("Validated successfully!\n");
            }
            else
            {
                Console.WriteLine("Entered Details are not in required format.Please try again!\n");
            }
        }
    }
}
