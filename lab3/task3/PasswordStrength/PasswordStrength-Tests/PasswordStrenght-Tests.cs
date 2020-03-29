using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrength_Tests
{
    [TestClass]
    public class CalculateSecurityByLenght_Test
    {
        [TestMethod]
        public void empty_password_should_return_0_strenght()
        {
            string emptyPassword = "";
            int expectedStrenght = emptyPassword.Length * 4;

            int res = CPasswordStrength.CalculateSecurityByLenght(emptyPassword);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void password_lenght_should_return_lenght_multiply_by_4()
        {
            string password = "qwerty50000";
            int expectedStrenght = password.Length * 4;

            int res = CPasswordStrength.CalculateSecurityByLenght(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }

    [TestClass]
    public class CalculateSecurityByNumbersAmount_Test
    {
        [TestMethod]
        public void only_numbers_password_should_return_lenght_multiply_by_4()
        {
            string password = "1234";
            int expectedStrenght = password.Length * 4;

            int res = CPasswordStrength.CalculateSecurityByNumbersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }

        [TestMethod]
        public void only_letters_password_should_return_0_strenght()
        {
            string password = "abc";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByNumbersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void combining_password_should_return_numbers_amount_multiply_by_4()
        {
            string password = "abc123";
            int expectedStrenght = 3 * 4;

            int res = CPasswordStrength.CalculateSecurityByNumbersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }

    [TestClass]
    public class CalculateSecurityByUpperCaseLettersAmount_Test
    {
        [TestMethod]
        public void only_upper_case_password_should_return_strenght_by_formula()
        {
            string password = "QWERTY";
            int expectedStrenght = (password.Length - password.Length) *2;

            int res = CPasswordStrength.CalculateSecurityByUpperCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void only_lower_case_password_should_return_0_strenght_password()
        {
            string password = "abcd";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByUpperCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void combining_password_should_return_strenght_by_formula()
        {
            string password = "abcd1234QWE";
            int expectedStrenght = (password.Length - 3) * 2;

            int res = CPasswordStrength.CalculateSecurityByUpperCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }
    [TestClass]
    public class CalculateSecurityByLowerCaseLettersAmount_Test
    {
        [TestMethod]
        public void only_upper_case_password_should_return_0_strenght()
        {
            string password = "QWERTY";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByLowerCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void only_lower_case_password_should_return_strenght_by_formula()
        {
            string password = "abcd";
            int expectedStrenght = (password.Length - 4) * 2;

            int res = CPasswordStrength.CalculateSecurityByLowerCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void combining_password_should_return_strenght_by_formula()
        {
            string password = "abcd1234QWE";
            int expectedStrenght = (password.Length - 4) * 2;

            int res = CPasswordStrength.CalculateSecurityByLowerCaseLettersAmount(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }


    [TestClass]
    public class CalculateSecurityByOnlyLetters_Test
    {
        [TestMethod]
        public void only_letters_password_should_return_lenght_minus_letters_amount()
        {
            string password = "asdasdQWERTY";
            int expectedStrenght = -password.Length;

            int res = CPasswordStrength.CalculateSecurityByOnlyLetters(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void password_with_letters_and_numbers_should_return_0_strenght()
        {
            string password = "asdasdQWERTY1234";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByOnlyLetters(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }

    [TestClass]
    public class CalculateSecurityByOnlyNumbers_Test
    {
        [TestMethod]
        public void only_numbers_password_should_returns_lenght_minus_number_amount()
        {
            string password = "1234567890";
            int expectedStrenght = -password.Length;

            int res = CPasswordStrength.CalculateSecurityByOnlyNumbers(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void password_with_letters_and_numbers_should_return_0_strenght()
        {
            string password = "asdasdQWERTY1234";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByOnlyNumbers(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }

    [TestClass]
    public class CalculateSecurityByRepeatedSymbols_Test
    {
        [TestMethod]
        public void password_with_repeated_symbols_should_return_reduced_strenght()
        {
            string password = "asdasdQWERTY1234";
            int expectedStrenght = -6;

            int res = CPasswordStrength.CalculateSecurityByReapetedSymbols(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void password_without_repeated_symbols_should_return_0_strenght()
        {
            string password = "QWERTY1234";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByReapetedSymbols(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void password_with_one_symbols_should_return_0_strenght()
        {
            string password = "a";
            int expectedStrenght = 0;

            int res = CPasswordStrength.CalculateSecurityByReapetedSymbols(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }

    [TestClass]
    public class PasswordStrength_Test
    {
        [TestMethod]
        public void Qwerty123_password_returns_password_72_strenght()
        {
            string password = "Qwerty123";
            int expectedStrenght = 72;

            int res = CPasswordStrength.PasswordStrength(password);

            Assert.AreEqual(expectedStrenght, res);
        }

        [TestMethod]
        public void aa1_password_returns_password_72_strenght()
        {
            string password = "aa1";
            int expectedStrenght = 16;

            int res = CPasswordStrength.PasswordStrength(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void number_password_returns_password_16_strenght()
        {
            string password = "8";
            int expectedStrenght = 7;

            int res = CPasswordStrength.PasswordStrength(password);

            Assert.AreEqual(expectedStrenght, res);
        }
        [TestMethod]
        public void bbb_password_returns_password_6_strenght()
        {
            string password = "bbb";
            int expectedStrenght = 6;

            int res = CPasswordStrength.PasswordStrength(password);

            Assert.AreEqual(expectedStrenght, res);
        }
    }
}
