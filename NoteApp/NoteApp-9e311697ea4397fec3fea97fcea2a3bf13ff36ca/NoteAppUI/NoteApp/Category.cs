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
        /// <summary>
        /// Категория "Дом"
        /// </summary>
        Home = 1,
        /// <summary>
        /// Категория "Работа"
        /// </summary>
        Work,
        /// <summary>
        ///  Категория "Здоровье и спорт"
        /// </summary>
        SportAndHealth,
        /// <summary>
        /// Категория "Люди"
        /// </summary>
        Humans,
        /// <summary>
        /// Категория "Документы"
        /// </summary>
        Documents,
        /// <summary>
        /// Категория "Финансы"
        /// </summary>
        Finance,
        /// <summary>
        /// Категория "Другое"
        /// </summary>
        Others,
    }
    
}
