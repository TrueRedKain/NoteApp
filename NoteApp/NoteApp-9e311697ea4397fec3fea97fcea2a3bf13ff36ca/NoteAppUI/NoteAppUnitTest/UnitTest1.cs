using System;
using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        [TestCase("Вынести мусор","Ошибка в длине имени заметки",
            TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue(string expected, string message)
        {
            var actual = _note.Name = expected;
            Assert.AreEqual(expected,actual,"Геттер названия заметки возвращаетнеправильную информацию");
        }

        [TestCase("1234567890123456789012345678901234567890123456789901234",typeof(ArgumentException),
            "Присваивается неверное значение", TestName = "Негативный тест сеттера Name")]
        public void TestNameSet_CorrectValue(string wrongName, Type expectedException, string message)
        {
           Assert.Throws(expectedException, () => { _note.Name = wrongName; }, message);
        }

        [TestCase("1900.01.01",typeof(FormatException),
            "Ошибка в несоответствии даты редактирования дате создания",
            TestName = "Позитивный тест геттера LastEditDate на соотвествие дате создания")]
        [TestCase("2096.01.01",typeof(ArgumentException),
            "Ошибка в несоответствии даты редактирования нынешней дате",
            TestName = "Позитивный тест геттера LastEditDate на соответствие нынешней дате")]
        public void TestLastEditDate(string wrongDate, Type expectedException, string message)
        {
            _note.CreationDate = new DateTime(2000, 01, 01);
            Assert.Throws(expectedException, () => { _note.LastEditDate = Convert.ToDateTime(wrongDate); }, message);
        }

    }
}
