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
    class ProjectManager
    {
        //Создаём экземпляр сериализатора
        JsonSerializer serializer = new JsonSerializer();

        public void SaveFile(Project noteList)
        {
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, noteList);
            }
        }

        public Project LoadFile()
        {
            //Создаём переменную, в которую поместим результат десериализации
            Project noteList = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"c:\json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                noteList = serializer.Deserialize <Project>(reader);
            }
            return noteList;
        }


    }
}
