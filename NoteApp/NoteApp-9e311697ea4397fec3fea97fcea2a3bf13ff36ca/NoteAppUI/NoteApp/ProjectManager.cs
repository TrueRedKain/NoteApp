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
    public class ProjectManager
    {
        /// <summary>
        /// Создаёт экземпляр сериализатора
        /// </summary>
        JsonSerializer serializer = new JsonSerializer() {Formatting = Formatting.Indented };

        /// <summary>
        /// Открывает поток и записывает в файл указанный объект
        /// </summary>
        public void SaveFile(Project noteList)
        {
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"C:\Users\RedKain\Documents\Notes\NoteApp.notes"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, noteList);
            }
        }
        /// <summary>
        /// Создает переменную, в которую записывает , с помощью сериализатора, данные из файла
        /// </summary>
        /// <returns> Возвращает данные из файла по указанному пути,в элементе списка
        /// </returns>
        public Project LoadFile()
        {
            //Создаём переменную, в которую поместим результат десериализации
            Project noteList = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"C:\Users\RedKain\Documents\Notes\NoteApp.notes"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                noteList = serializer.Deserialize <Project>(reader);
            }
            return noteList;
        }


    }
}
