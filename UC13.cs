using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationProgram
{
    using NUnit.Framework;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class User10
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public User10(string firstName, string lastName, string email, string mobile, string password)
        {
            ValidateInput(firstName, x => !string.IsNullOrEmpty(x), "Invalid First Name");
            ValidateInput(lastName, x => !string.IsNullOrEmpty(x), "Invalid Last Name");
            ValidateInput(email, IsValidEmail, "Invalid Email Address");
            ValidateInput(mobile, IsValidMobile, "Invalid Mobile Number");
            ValidateInput(password, IsValidPassword, "Invalid Password");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            Password = password;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
        }

        private static bool IsValidMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return false;
            }
            else
            {
                string pattern = @"^[0-9]{10}$";
                return Regex.IsMatch(mobile, pattern);
            }
        }

        private static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
                return Regex.IsMatch(password, pattern);
            }
        }

        private static void ValidateInput(string input, Func<string, bool> validationFunction, string errorMessage)
        {
            if (!validationFunction(input))
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }

    [TestFixture]
    public class User10Tests
    {
        [Test]
        public void User_ValidDetails_NoExceptionThrown()
        {
            // Act
            User user = new User("John", "Doe", "johndoe@example.com", "1234567890", "Password1");

            // Assert
            Assert.IsNotNull(user);
        }

        [TestCase(null, "Doe", "johndoe@example.com", "1234567890", "Password1", "Invalid First Name")]
        [TestCase("John", null, "johndoe@example.com", "1234567890", "Password1", "Invalid Last Name")]
        [TestCase("John", "Doe", "invalid-email", "1234567890", "Password1", "Invalid Email Address")]
        [TestCase("John", "Doe", "johndoe@example.com", "123", "Password1", "Invalid Mobile Number")]
        [TestCase("John", "Doe", "johndoe@example.com", "1234567890", "password", "Invalid Password")]
        public void User_InvalidDetails_ThrowsException(string firstName, string lastName, string email, string mobile, string password, string expectedExceptionMessage)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new User(firstName, lastName, email, mobile, password), expectedExceptionMessage);
        }
    }
}
   
