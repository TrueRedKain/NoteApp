using System;

namespace NoteApp
{
    /// <summary>
    /// Класс отвечает за создание новых записей в журнале заметок
    /// </summary>
    public class Note
    {
        private string _name;
        /// <summary>
        /// Поле отвечает за присваивание имени заметке
        /// </summary>
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
                    LastEditDate = DateTime.Now;
                }
            }
        }

        private NoteCategory _noteCategory;
        /// <summary>
        /// Поле отвечает за присваивание типа заметке
        /// </summary>
        public NoteCategory NoteCategory
        {
            get => _noteCategory;
            set
            {
                _noteCategory = value;
            }
        }

        private string _text;
        /// <summary>
        /// Поле отвечает за текст, передаваемый в заметку
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
            }
        }
        

        private DateTime _creationDate;
        /// <summary>
        /// Поле отвечает за присваивание даты создания заметки
        /// </summary>
        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                if (value>System.DateTime.Now)
                {
                    throw new ArgumentException("Дата создания не может быть позже сегодняшней даты, а задается"+ value);
                }
                else
                {
                    _creationDate = value;
                }

            }
        }

        private DateTime _lastEditDate;
        /// <summary>
        /// Поле отвечает за присваивание даты последнего редактирования заметки
        /// </summary>
        public DateTime LastEditDate
        {
            get => _lastEditDate;
            set
            {
                if (value > System.DateTime.Now)
                {
                    throw new ArgumentException("Дата последнего изменения не может быть позже сегодняшней даты, а задается" + value);
                }
                else if (value < _creationDate)
                {
                    throw new ArgumentException("Дата последнего изменения не может быть ранее даты создания");
                }
                else
                {
                    _lastEditDate = value;
                }
            }
        }
    }
}
