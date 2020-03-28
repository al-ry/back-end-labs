using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;
using System;

namespace CheckIdentifier_Tests
{
    [TestClass]
    public class ParseArgMethod
    {
        [TestMethod]
        public void correct_number_of_args_return_true()
        {
            string[] args = new string[] {"indetifier"};

            var res = Program.ParseArg(args);

            Assert.AreEqual(true, res);
        }
        public void too_few_number_of_args_return_false()
        {
            string[] args = new string[] { "indetifier1", "indetifier2" };

            var res = Program.ParseArg(args);

            Assert.AreEqual(false, res);
        }

    }

    [TestClass]
    public class IsDigitMethod
    {
        [TestMethod]
        public void bound_value_9_returns_true()
        {
            bool res = Program.IsDigit('9');

            Assert.AreEqual(true, res);

        }

        [TestMethod]
        public void bound_value_0_returns_true()
        {
            bool res = Program.IsDigit('0');

            Assert.AreEqual(true, res);

        }
        [TestMethod]
        public void value_7_in_range_returns_true()
        {
            bool res = Program.IsDigit('7');

            Assert.AreEqual(true, res);
        }

        [TestMethod]

        public void value_A_out_of_range_returns_false()
        {
            bool res = Program.IsDigit('A');

            Assert.AreEqual(false, res);
        }
    }

    [TestClass]
    public class IsLetterMethod
    {
        [TestMethod]
        public void bound_value_A_for_upper_case_letter_returns_true()
        {
            bool res = Program.IsLetter('A');

            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void bound_value_Z_for_upper_case_letter_returns_true()
        {
            bool res = Program.IsLetter('Z');

            Assert.AreEqual(true, res);

        }
        [TestMethod]
        public void bound_value_a_for_lower_case_letter_returns_true()
        {
            bool res = Program.IsLetter('a');

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void bound_value_z_for_lower_case_letter_returns_true()
        {
            bool res = Program.IsLetter('z');

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void upper_case_value_G_in_range_returns_true()
        {
            bool res = Program.IsLetter('G');

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void lower_case_value_z_in_range_returns_true()
        {
            bool res = Program.IsLetter('f');

            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void values_5_out_of_range_returns_false()
        {
            bool res = Program.IsLetter('5');

            Assert.AreEqual(false, res);
        }
    }

    [TestClass]
    public class CheckIdentifierMethod
    {
        [TestMethod]
        public void correct_identiifier_Ch1_returns_true()
        {
            bool res = Program.CheckIdentifier("Ch1");

            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void empty_enditifier_returns_false()
        {
            bool res = Program.CheckIdentifier("");

            Assert.AreEqual(false, res);
        }
        [TestMethod]
        public void correct_identiifier_Number_returns_true()
        {
            bool res = Program.CheckIdentifier("Number");

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void correct_identiifier_UPPER_returns_true()
        {
            bool res = Program.CheckIdentifier("UPPER");

            Assert.AreEqual(true, res);

        }

        [TestMethod]
        public void correct_identiifier_lower_return_true()
        {
            bool res = Program.CheckIdentifier("lower");

            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void firts_digit_character_returns_false()
        {
            bool res = Program.CheckIdentifier("1Ch");

            Assert.AreEqual(false, res);
        }
        [TestMethod]
        public void firts_wrong_character_returns_false()
        {
            bool res = Program.CheckIdentifier(" Ch");

            Assert.AreEqual(false, res);
        }
        [TestMethod]
        public void identifier_with_invalid_character_returns_false()
        {
            bool res = Program.CheckIdentifier("var&");

            Assert.AreEqual(false, res);
        }
    }
}
