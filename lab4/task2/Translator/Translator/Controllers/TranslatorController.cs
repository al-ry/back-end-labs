using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translator.Models;


namespace Translator.Controllers
{
    public class TranslatorController : Controller
    {
        
        public ActionResult TranslatorHandler(string word)
        {
            if (word == null)
            {
                return BadRequest();
            }
            Translator.Models.Translator translator = new Models.Translator("dict.txt");
            string translation = translator.FindTranslation(word);
            if (translation == null)
            {
                return NotFound();
            }
            ViewBag.Word = word;
            ViewBag.Translation = translation;
            return  View("Translation");
        }
    }
}
