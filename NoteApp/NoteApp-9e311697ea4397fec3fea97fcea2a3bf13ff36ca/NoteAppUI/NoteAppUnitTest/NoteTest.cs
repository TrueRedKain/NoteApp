using System;
using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTest
{
    [TestFixture]
    public class NoteTest
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        [TestCase("Вынести мусор", "Ошибка в длине имени заметки",
            TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue(string expected, string message)
        {
            _note.Name = expected;
            var actual = _note.Name;
            Assert.AreEqual(expected, actual, "Геттер названия заметки возвращает неправильную информацию");
            Assert.AreEqual(expected, _note.Name, "Сеттер названия заметки возвращает неправильную информацию");
        }

        [TestCase("1234567890123456789012345678901234567890123456789901234", typeof(ArgumentException),
            "Присваивается неверное значение", TestName = "Негативный тест сеттера Name")]
        public void TestNameSet_CorrectValue(string wrongName, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () => { _note.Name = wrongName; }, message);
        }
   

        [TestCase(NoteCategory.Home, "Ошибка в задании номера категории", TestName = "Позитивный тест геттера Category")]
        public void TestCategoryGet_CorrectValue(NoteCategory expected, string message)
        {
            _note.NoteCategory = expected;
            var actual = _note.NoteCategory;
            Assert.AreEqual(expected, actual, "Геттер категории заметки возвращает неправильную информацию");
            Assert.AreEqual(expected, _note.NoteCategory, "Сеттер категории заметки возвращает неправильную информацию");
        }


        [TestCase("RandomText", "Ошибка в создании текста заметки", TestName = "Позитивный тест геттера Text")]
        public void TestTextGet_CorrectValue(string expected, string message)
        {
            _note.Text = expected;
            var actual = _note.Text;
            
            Assert.AreEqual(expected, actual, "Геттер текста заметки возвращает неправильную информацию");
            Assert.AreEqual(expected, _note.Text, "Сеттер свойства text не заносит правильную информацию");
        }

        [TestCase("2018.12.04", "Ошибка в задании даты создания заметки", TestName = "Позитивный тест геттера CreationDate")]
        public void TestTextGet_CorrectValue(DateTime expected, string message)
        {
            var actual = _note.CreationDate = expected;
            Assert.AreEqual(expected, actual, "Геттер даты создания заметки возвращает неправильную информацию");
        }

        [TestCase("2020.12.04", typeof(ArgumentException), "Ошибка в задании даты создании заметки",
            TestName = "Негативный тест сеттера CreationDate")]
        public void TestCreationDate(string wrongDate, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () => { _note.CreationDate = Convert.ToDateTime(wrongDate); }, message);
        }

        [TestCase("2018.12.04", "Ошибка в задании даты последнего редактирования заметки", 
            TestName = "Позитивный тест геттера LastEditDate")]
        public void TestLastEditDate_Value(DateTime expected, string message)
        {
            var actual = _note.LastEditDate = expected;
            _note.CreationDate = new DateTime(2018, 12, 04);
            Assert.AreEqual(expected, actual, "Геттер даты последнего редактирования заметки возвращает неправильную информацию");
        }

        [TestCase("1900.01.01",typeof(FormatException),
            "Ошибка в несоответствии даты редактирования дате создания",
            TestName = "Негативный тест геттера LastEditDate на соотвествие дате создания")]
        [TestCase("2096.01.01",typeof(ArgumentException),
            "Ошибка в несоответствии даты редактирования нынешней дате",
            TestName = "Негативный тест геттера LastEditDate на соответствие нынешней дате")]
        public void TestLastEditDate(string wrongDate, Type expectedException, string message)
        {
            _note.CreationDate = new DateTime(2000, 01, 01);
            Assert.Throws(expectedException, () => { _note.LastEditDate = Convert.ToDateTime(wrongDate); }, message);
        }

    }
}
