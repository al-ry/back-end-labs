using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
namespace MyNotes.Data.Interfaces
{
    public interface INotesRepository
    {
        List<Note> GetNotes();
        void AddNote(string message);
    }
}
