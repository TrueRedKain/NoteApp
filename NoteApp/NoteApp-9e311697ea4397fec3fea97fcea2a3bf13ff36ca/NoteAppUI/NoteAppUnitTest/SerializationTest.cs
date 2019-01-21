using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using NoteApp;


namespace NoteAppUnitTest
{

    [TestFixture]
    public class SerializationTest
    {   
        
        private string _path;
        private Project _note = new Project();
        private readonly Note _firstTestNote = new Note();
        private readonly Note _secondTestNote = new Note();

        [SetUp]
        public void InitProjectManejer()
        {
            _path = Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location);
            _firstTestNote.Name = "Жожа";
            _firstTestNote.NoteCategory = NoteCategory.Humans;
            _firstTestNote.Text = "Онемэ";
            _firstTestNote.CreationDate = new DateTime(2018,12,11);
            _firstTestNote.LastEditDate = new DateTime(2018, 12, 11);

            _secondTestNote.Name = "Володарский";
            _secondTestNote.Text = " Вы не люди";
            _secondTestNote.NoteCategory = NoteCategory.Work;
            _secondTestNote.CreationDate = new DateTime(2018, 12,11);
            _secondTestNote.LastEditDate = new DateTime(2018, 12, 11);
        }

        [Test(Description = "Тест десериализации")]
        public void TestDeserialization()
        {
            _note = ProjectManager.LoadFile(_path + @"\TestNote\TestNotes.notes");
            Assert.AreEqual(2, _note.Notes.Count, "Кол-во записей в списке не совпадают");
            Assert.AreEqual(_note.Notes[1].Name, _secondTestNote.Name, "Метод десеариализует не правильную информацию (Имя заметки)");
            Assert.AreEqual(_note.Notes[0].Text, _firstTestNote.Text, "Метод десеариализует не правильную информацию (Текст заметки)");
            Assert.AreEqual(_note.Notes[1].NoteCategory, _secondTestNote.NoteCategory, "Метод десеариализует не правильную информацию (Категория заметки)");
            Assert.AreEqual(_note.Notes[0].CreationDate.Date, _firstTestNote.CreationDate, "Метод десеариализует не правильную информацию (Дата создания)");
            Assert.AreEqual(_note.Notes[1].LastEditDate.Date, _secondTestNote.LastEditDate, "Метод десеариализует не правильную информацию (Дата последнего редактирования)");
        }

        [Test(Description = "Тест сериализации")]
        public void TestSerialization()
        {
            ProjectManager.SaveFile(_note, _path + @"\TestNote\TestNotes.notes");
            var fileAsString = File.ReadAllText(_path + @"\TestNote\TestNotes.notes");
            var expected = File.ReadAllText(_path + @"\TestNote\TestNotes.notes");
            Assert.AreEqual(expected, fileAsString, "Метод сериализует не верную информации");
        }
    }
}
