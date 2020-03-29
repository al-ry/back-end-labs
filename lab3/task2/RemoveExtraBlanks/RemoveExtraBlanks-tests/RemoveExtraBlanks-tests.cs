using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanks_tests
{
    [TestClass]
    public class ParseArgMethod
    { 
        [TestMethod]
        public void correct_arguments_number_return_not_null_res()
        {
            string[] args = { "input.txt", "output.txt" };

            Arguments? res = new Arguments();
            res = Program.ParseArg(args);

            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void too_little_arguments_number_return_null_res()
        {
            string[] args = { "output.txt" };

            Arguments? res = new Arguments();
            res = Program.ParseArg(args);

            Assert.IsNull(res);
        }
        [TestMethod]
        public void too_many_arguments_number_return_null_res()
        {
            string[] args = { "input.txt", "output.txt", "string"};

            Arguments? res = new Arguments();
            res = Program.ParseArg(args);

            Assert.IsNull(res);
        }
    }

    [TestClass]
    public class RemoveExtraBlanksMethod
    {
        [TestMethod]
        public void string_without_extra_blanks_returns_similiar_string()
        {
            string sentence = "The quick brown fox jumps over a lazy dog.";
            string expected = sentence;

            string res = Program.RemoveExtraBlanks(sentence);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void extra_blanks_at_the_beggining_should_return_string_without_extra_blanks_at_the_begining()
        {
            string str = "      Hello world!";
            string expected = "Hello world!";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void extra_blanks_at_the_end_should_return_string_without_blanks_at_the_end()
        {
            string str = "Hello world!         ";
            string expected = "Hello world!";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void string_with_extra_blanks_should_return_string_without_extra_blanks()
        {
            string str = "   The       quick  brown    fox jumps over    a lazy dog.   ";
            string expected = "The quick brown fox jumps over a lazy dog.";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void empty_string_should_returns_empty_string()
        {
            string str = "";
            string expected = "";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void string_with_one_space_should_returns_one_space()
        {
            string str = " ";
            string expected = "";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void string_with_one_tab_should_returns_one_space_between_words()
        {
            string str = "Hello\tworld ";
            string expected = "Hello world";

            string res = Program.RemoveExtraBlanks(str);

            Assert.AreEqual(expected, res);
        }
    }
}
