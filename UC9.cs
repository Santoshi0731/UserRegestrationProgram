using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserRegistrationProgram
{
    public class UserName8
    {
        public static void EmailSample()       
        {
            string[] userInput = {"abc@yahoo.com","abc-100@yahoo.com","abc.100@yahoo.com","abc111@abc.com","abc-100@abc.net","abc.100@abc.com.au",
                                "abc@1.com","abc@gmail.com.com","abc+100@gmail.com",
                                "abc","abc@.com.my","abc123@gmail.a","abc123@.com","abc123@.com.com",".abc@abc.com","abc()*@gmail.com","abc@%*.com",
                                "abc..2002@gmail.com","abc.@gmail.com","abc@abc@gmail.com","abc@gmail.com.1a","abc@gmail.com.aa.au"};
            string regexCondition = "^[a-z0-9]{1,}([._+-]{1}[a-z0-9]{1,}){0,1}[@]{1}[a-z0-9]{1,}[.]{1}[a-zA-Z]{2,3}([.]{1}[a-z]{2,3}){0,1}$";
            foreach (string input in userInput)
            {
                if (Regex.IsMatch(input, regexCondition))
                {
                    Console.WriteLine($"{input} --> Valid");
                }
                else
                {
                    Console.WriteLine($"{input} --> Invalid");
                }
            }


        }
    }
}
