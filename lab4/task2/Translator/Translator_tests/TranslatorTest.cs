using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator;

namespace Translator_tests
{
    [TestClass]
    public class TranslatorFind
    {
        Translator.Models.Translator dictionary = new Translator.Models.Translator("../../../../Translator/dict.txt");
        [TestMethod]
        public void Find_empty_word_should_return_null_translation()
        {
            string word = "";
            string result = dictionary.FindTranslation(word);
            Assert.AreEqual(null, result);
        }
        public void Find_nonexistent_word_should_return_null_translation()
        {
            string word = "coronavirus";
            string result = dictionary.FindTranslation(word);
            Assert.AreEqual(null, result);
        }
        public void Find_existing_word_should_return_translation()
        {
            string word = "potato";
            string result = dictionary.FindTranslation(word);
            string expectedResult = "картошка";
            Assert.AreEqual(expectedResult, result);
        }
        public void Backward_translation_should_return_translation()
        {
            string word = "картошка";
            string result = dictionary.FindTranslation(word);
            string expectedResult = "potato";
            Assert.AreEqual(expectedResult, result);
        }
    }
}
