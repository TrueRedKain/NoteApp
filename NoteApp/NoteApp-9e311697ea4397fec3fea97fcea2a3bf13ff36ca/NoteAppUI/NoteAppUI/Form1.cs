using NoteApp;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace NoteAppUI
{
    public partial class NoteAppMain : Form
    {
        private Project _noteList = new Project();
        ProjectManager _projectManager = new ProjectManager();
        Note _note = new Note();

        public NoteAppMain()
        {
            InitializeComponent();
        }

        public Note NoteInstance()
        {              
            _note.Name = "Toxa";
            _note.Text = "Сегодня я снова сгорел играя за Браюна";
            _note.CreationDate = DateTime.Now;
            _note.LastEditDate = DateTime.Now;
            _note.NoteCategory = NoteCategory.Home;            
            return _note;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _note = NoteInstance();
            _noteList.Notes.Add(_note);
            FillListView(_noteList.Notes);
            SaveFile(_noteList);
        }

        /// <summary>
        /// Заполнить список контактов. Если в списке уже есть данные (список ранее был заполнен),
        /// то список будет очищен и снова заполнен.
        /// </summary>
        /// <param name="_note">Список контактов</param>
        public void FillListView(List<Note> _note)
        {
            if (NoteList.Items.Count > 0) NoteList.Items.Clear();
            foreach (Note note in _note)
            {
                AddNewClient(note);
            }
        }

        /// <summary>
        /// Добавить нового контакта
        /// </summary>
        /// <param name="Note">Контакт</param>
        public void AddNewClient(Note contact)
        {
            int index = NoteList.Items.Add(contact.Name).Index;
            NoteList.Items[index].Tag = contact; //свойство Tag теперь ссылается на клиента, пригодится при удалении из списка и редактировании
        }

        private void NoteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteList.SelectedItems.Count != 0)
            {
                CategoryLabel.Text = _noteList.Notes[NoteList.SelectedIndices[0]].NoteCategory.ToString();
                Headline.Text = _noteList.Notes[NoteList.SelectedIndices[0]].Name;
                TextBox.Text = _noteList.Notes[NoteList.SelectedIndices[0]].Text;
                CreateDatePicker.Value = _noteList.Notes[NoteList.SelectedIndices[0]].CreationDate;
                ModifiedDatePicker.Value = _noteList.Notes[NoteList.SelectedIndices[0]].LastEditDate;
            }
            else
            {
                CategoryLabel.Text = string.Empty;
                Headline.Text = string.Empty;
                TextBox.Text = string.Empty;
                CreateDatePicker.Value = new DateTime(2000,01,01);
                ModifiedDatePicker.Value = new DateTime(2000, 01, 01);
            }

        }

        /// <summary>
        /// Вызов формы About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form About = new AboutForm();
            About.ShowDialog();
        }        

        /// <summary>
        /// Событие закрытия главного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm AddNote = new AddEditForm();
            if (AddNote.ShowDialog() == DialogResult.OK)
            {
                _noteList.Notes.Add(AddNote._noteContainer);
                FillListView(_noteList.Notes);
                SaveFile(_noteList);
                
            }
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm EditForm = new AddEditForm();
            int EditInd = NoteList.SelectedIndices[0];
            EditForm.NoteView(_noteList.Notes[EditInd]);
            if (EditForm.ShowDialog() == DialogResult.OK)
            {
                _noteList.Notes.RemoveAt(EditInd);
                NoteList.Items[EditInd].Remove();
                _noteList.Notes.Insert(EditInd,EditForm._noteContainer);
                FillListView(_noteList.Notes);
                SaveFile(_noteList);

            }
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RemInd = NoteList.SelectedIndices[0];
            _noteList.Notes.RemoveAt(RemInd);
            NoteList.Items[RemInd].Remove();
            SaveFile(_noteList);
        }

        private void SaveFile(Project noteList)
        {
            _projectManager.SaveFile(noteList);
        }
    }
}
