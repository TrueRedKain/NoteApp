using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;

namespace NoteApp
{
    public class Note
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина имени не должна быть более 50 символов, а подается" + value.Length);
                }
                else
                {
                    _name = value;
                }
            }
        }

        private NoteCategory _noteCat;
        public NoteCategory NoteCategory
        { get => _noteCat; set { } }

        private string _text;
        public string Text { get => _text; set { _text = value; } }
        

        private DateTime _creationDate;
        public DateTime CreationDate
        { get => _creationDate; set { _creationDate = value; } }

        private DateTime _lastEditDate;
        public DateTime LastEditDate
        { get => _lastEditDate; set { _lastEditDate = value; } }
    }
}
