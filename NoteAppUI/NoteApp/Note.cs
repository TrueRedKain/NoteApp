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
        string Name
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
        Category NoteCategory;
        private string _text;
        string Text
        { get => _text; }
        private DateTime _makeDate;
        DateTime MakeDate
        { get => _makeDate;}
        private DateTime _lastEditDate;
        DateTime LastEditDate
        { get => _lastEditDate;}
    }
}
