using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserRegistrationProgram
{
    public class UserName
    {
        public static void LastName()      //UC2
        {
            Console.WriteLine("Enter your LastName");
            string userInput = Console.ReadLine();
            string regexCondition = "^[A-Z]{1}[a-z]{2,}$";
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
