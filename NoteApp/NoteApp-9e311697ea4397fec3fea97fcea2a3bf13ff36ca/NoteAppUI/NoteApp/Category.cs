using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Перечисление, определяющее тип создаваемой заметки.
    /// </summary>
        public enum NoteCategory
        {
        /// <param name="NoteCategory">
        /// Тип заметки задается целочисленным значением от 1 до 7
        /// </param>
            Home = 1,
            Work,
            SportAndHealth,
            Humans,
            Documents,
            Finance,
            Others,
        }
    
}
