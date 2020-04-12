using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Repositories;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using MyNotes.Data.Models;



namespace MyNotes.Controllers
{
    public class NotesController : Controller
    {

        private INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            NotesRepository.SetPath("Storage/notes1.txt");
        }

        [Route("/")]
        public string ShowUsage()
        {
            return "Usage: \nGET /notes/list HTTP/1.1 " +
                   "(Getting notes list)\n" +
                   "POST /note/add HTTP/1.1 " + "(Adding note)\n";
        }
        [HttpGet]
        [Route("notes/list")]
        public IActionResult GetNotesList()
        {
            var notes = _notesRepository.GetNotes();
            var json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            return Content(json);
        }

        [HttpPost]
        [Route("note/add")]
        public async Task<StatusCodeResult> AddNote()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var srcEncoding = Encoding.GetEncoding(1251);
            string noteStr = await new StreamReader(Request.Body, srcEncoding).ReadToEndAsync();
            Note note = new Note()
            {
                 Content = noteStr
            };
            _notesRepository.AddNote(note);
            return Ok();
        }
        

    }
}
