using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;
using System;

namespace CheckIdentifier_Tests
{
    [TestClass]
    public class ParseArgMethod
    {
        [TestMethod]
        public void Check_correct_number_of_arg()
        {
            string[] args = new string[] {"indetifier"};
            var res = Program.ParseArg(args);
            Assert.AreEqual(true, res);
        }
        public void Check_too_few_number_of_arg()
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
        public void Check_bound_values()
        {
            Assert.AreEqual(true, Program.IsDigit('9'));
            Assert.AreEqual(true, Program.IsDigit('0'));
        }
        [TestMethod]
        public void Check_values_in_range()
        {
            Assert.AreEqual(true, Program.IsDigit('7'));
            Assert.AreEqual(true, Program.IsDigit('4'));
       }
        [TestMethod]
        public void Check_values_out_of_range()
        {
            Assert.AreEqual(false, Program.IsDigit('z'));
            Assert.AreEqual(false, Program.IsDigit('F'));
        }
    }

    [TestClass]
    public class IsLetterMethod
    {
        [TestMethod]
        public void Check_bound_for_upper_case_letter()
        {
            Assert.AreEqual(true, Program.IsLetter('A'));
            Assert.AreEqual(true, Program.IsLetter('Z'));
        }
        [TestMethod]
        public void Check_bound_for_lower_case_letter()
        {
            Assert.AreEqual(true, Program.IsLetter('a'));
            Assert.AreEqual(true, Program.IsLetter('z'));
        }
        public void Check_values_in_range()
        {
            Assert.AreEqual(true, Program.IsLetter('f'));
            Assert.AreEqual(true, Program.IsLetter('G'));
        }
        [TestMethod]
        public void Check_values_out_of_range()
        {
            Assert.AreEqual(false, Program.IsLetter('5'));
            Assert.AreEqual(false, Program.IsLetter(' '));
            Assert.AreEqual(false, Program.IsLetter('@'));
        }
    }

    [TestClass]
    public class CheckIdentifierMethod
    {
        [TestMethod]
        public void Check_correct_identiifiers()
        {
            Assert.AreEqual(true, Program.CheckIdentifier("Ch1"));
            Assert.AreEqual(true, Program.CheckIdentifier("Number"));
            Assert.AreEqual(true, Program.CheckIdentifier("UPPER"));
            Assert.AreEqual(true, Program.CheckIdentifier("lower"));
        }
        public void Check_when_firts_character_is_digit()
        {
            Assert.AreEqual(false, Program.CheckIdentifier("1Ch"));
        }
        public void Check_when_firts_character_is_wrong_character()
        {
            Assert.AreEqual(false, Program.CheckIdentifier(" Ch"));
        }
        public void Check_identifier_with_invalid_character()
        {
            Assert.AreEqual(false, Program.CheckIdentifier("var&"));
        }
    }
}
