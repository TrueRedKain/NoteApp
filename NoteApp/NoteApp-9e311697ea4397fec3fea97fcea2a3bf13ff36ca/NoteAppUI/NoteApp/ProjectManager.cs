using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;
using Newtonsoft.Json;
using System.IO;

namespace NoteApp
{
    /// <summary>
    /// Класс отвечающий за сериализацию
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Создаёт экземпляр сериализатора
        /// </summary>
        private static string _filePathDefault = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"Note.notes";

        /// <summary>
        /// Открывает поток и записывает в файл указанный объект
        /// </summary>
        public static void SaveFile(Project project, string _filePath)
        {
            //if (_filePath == String.Empty)
            //{
            //    _filePath = _filePathDefault;
            //}

            _filePath = (_filePath == String.Empty) ? _filePathDefault : _filePath;

            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };

            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(_filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Создает переменную, в которую записывает , с помощью сериализатора, данные из файла
        /// </summary>
        /// <returns> Возвращает данные из файла по указанному пути,в элементе списка
        /// </returns>
        public static Project LoadFile(string _filePath)
        {
            _filePath = (_filePath == string.Empty) ? _filePathDefault : _filePath;

            if (!File.Exists(_filePathDefault))
            {
                return new Project();
            }

            //Создаём переменную, в которую поместим результат десериализации
            Project noteList = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(_filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                noteList = serializer.Deserialize <Project>(reader);
                
            }
            return noteList;
        }


    }
}
