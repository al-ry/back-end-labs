using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.Models;
using MyNotes.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Unicode;
using System.Text;

namespace MyNotes.Data.Repositories
{
    public class NotesRepository: INotesRepository
    {
        private static string _path;
        public static void SetPath(string path)
        {
            _path = path;
        }
        public void AddNote(string message)
        {
            Note note = new Note()
            {
                Content = message
            };
            var dstEncoding = Encoding.UTF8;
            bool appendMode;
            using (StreamReader reader = new StreamReader(_path))
            {
                string str = reader.ReadToEnd();
                if (str == null)
                {
                    appendMode = false;
                }
                appendMode = true;
            }
            using (StreamWriter notesWriter = new StreamWriter(_path, appendMode, dstEncoding))
            {
                notesWriter.WriteLine(note.Content);
            }
        }

        public List<Note> GetNotes()
        {
            List<Note> notesList = new List<Note>();
            using (StreamReader notesReader = new StreamReader(_path))
            {
                string noteStr;
                while ((!notesReader.EndOfStream))
                {
                    noteStr = notesReader.ReadLine();
                    notesList.Add(new Note
                    {
                        Content = noteStr
                    });
                   
                }
            }
            return notesList;
        }


    }
}
