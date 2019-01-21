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

        public List<Note> SortNotes(List<Note> notesList)
        {
            //
            notesList.Sort(delegate (Note x, Note y)
            {
                if (x.LastEditDate == null && y.LastEditDate == null) return 0;
                else if (x.LastEditDate == null) return -1;
                else if (y.LastEditDate == null) return 1;
                else return x.LastEditDate.CompareTo(y.LastEditDate);
            });

            return notesList;
        }
    }
}
