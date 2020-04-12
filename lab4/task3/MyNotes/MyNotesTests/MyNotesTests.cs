using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Repositories;
using MyNotes.Data.Models;
using System.Collections.Generic;
using System.IO;

namespace MyNotesTests
{
    [TestClass]
    public class AddNoteTests
    {
        private string pathAdd = @"../../../TestsData/addTest.txt";
        public Note GenerateNote(string message)
        {
            Note note = new Note
            {
                Content = message
            };
            return note;
        }
        public void AddNote(Note note)
        {
            NotesRepository notesRepository = new NotesRepository();
            NotesRepository.SetPath(pathAdd);
            notesRepository.AddNote(note);
        }
        [TestMethod]
        public void OneNotes_Should_Return_One_Note_In_File()
        {
            var note = GenerateNote("home assignment");

            AddNote(note);
            var noteMessage = new StreamReader(pathAdd).ReadLine();

            Assert.AreEqual(note.Content, noteMessage);
            
        }
    }
    [TestClass]

    public class GetNodeTests
    {
        private string pathGet = @"../../../TestsData/getTest.txt";
        public List<Note> GetNotesFromFile()
        {

            NotesRepository notesRepository = new NotesRepository();
            NotesRepository.SetPath(pathGet);
            return notesRepository.GetNotes();
        }
        [TestMethod]
        public void Notes_From_File_should_Read_In_List()
        {
            var list = GetNotesFromFile();
            var res = list.Count;

            var expectedRes = 2;
            Assert.AreEqual(expectedRes, res);

        }
    }
}
