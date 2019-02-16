using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;

namespace NoteApp
{
    /// <summary>
    /// Класс отвечает за список заметок в приложении
    /// </summary>
    public class Project
    {
        public List<Note> Notes = new List<Note>();
        public int CurrentNot = 0;
        public List<Note> SortNotes(List<Note> notesList)
        {
            notesList.Sort(delegate (Note x, Note y)
            {
                if (x.LastEditDate == null && y.LastEditDate == null) return 0;
                else if (x.LastEditDate == null) return 1;
                else if (y.LastEditDate == null) return -1;
                else return y.LastEditDate.CompareTo(x.LastEditDate);
            });

            return notesList;
        }


        public List<Note> FindCategory(string value)
        {
            List<Note> categoryList = new List<Note>();
            NoteCategory result;
            foreach (var note in Notes)
            {                
                if (Enum.TryParse(value, out result) && result == note.NoteCategory)
                {
                    categoryList.Add(note);
                }
            }

            return categoryList;
        }
    }
}
