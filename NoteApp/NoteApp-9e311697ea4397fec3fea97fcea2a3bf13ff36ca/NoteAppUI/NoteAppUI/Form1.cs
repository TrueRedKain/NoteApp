using NoteApp;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace NoteAppUI
{
    public partial class NoteAppMain : Form
    {
        private Project _noteList = new Project();
        private readonly Project _projectForFind = new Project();
        private Note _note = new Note();

        public NoteAppMain()
        {
            InitializeComponent();
            _noteList = ProjectManager.LoadFile(String.Empty);
            FillListView(_noteList.Notes);
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
        /// <param name="notes">Список контактов</param>
        private void FillListView(List<Note> notes)
        {
            if (NoteList.Items.Count > 0) NoteList.Items.Clear();

            notes = _noteList.SortNotes(notes);

            foreach (Note note in notes)
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
            var noteList = (CategoriesComboBox.Text == "All") ? _noteList : _projectForFind;

            if (NoteList.SelectedItems.Count != 0)
            {
                CategoryLabel.Text = noteList.Notes[NoteList.SelectedIndices[0]].NoteCategory.ToString();
                Headline.Text = noteList.Notes[NoteList.SelectedIndices[0]].Name;
                TextBox.Text = noteList.Notes[NoteList.SelectedIndices[0]].Text;
                CreateDatePicker.Value = noteList.Notes[NoteList.SelectedIndices[0]].CreationDate;
                ModifiedDatePicker.Value = noteList.Notes[NoteList.SelectedIndices[0]].LastEditDate;
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
            if (NoteList.SelectedIndices.Count != 0)
            {
                int EditInd = (CategoriesComboBox.Text == "All") ? NoteList.SelectedIndices[0]
                    : GetNoteIndex(_noteList.Notes, _projectForFind.Notes);
                AddEditForm EditForm = new AddEditForm();
                EditForm.NoteView(_noteList.Notes[EditInd]);
                if (EditForm.ShowDialog() == DialogResult.OK)
                {
                    FillListView(_noteList.Notes);
                    _noteList.Notes.RemoveAt(EditInd);
                    NoteList.Items[EditInd].Remove();
                    _noteList.Notes.Insert(EditInd, EditForm._noteContainer);                    
                    SaveFile(_noteList);
                    FilldListCategory();

                }
            }
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NoteList.SelectedIndices.Count != 0)
            {
                int RemInd = (CategoriesComboBox.Text == "All") ? NoteList.SelectedIndices[0]
                    : GetNoteIndex(_noteList.Notes, _projectForFind.Notes);
                FillListView(_noteList.Notes);
                _noteList.Notes.RemoveAt(RemInd);
                NoteList.Items[RemInd].Remove();
                SaveFile(_noteList);
                ClearAtRemove();
                FilldListCategory();
            }
        }

        private void SaveFile(Project noteList)
        {
            ProjectManager.SaveFile(noteList,String.Empty);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CategoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilldListCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="findedNotes"></param>
        /// <returns></returns>
       private int GetNoteIndex(List<Note> notes, List<Note> findedNotes)
        {
            int index = 0;

            foreach (var note in notes)
            {
                if (note == findedNotes[NoteList.SelectedIndices[0]])
                {
                    return index;
                }

                index++;
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FilldListCategory()
        {
            if (CategoriesComboBox.Text != "All")
            {
                _projectForFind.Notes = _noteList.FindCategory(CategoriesComboBox.Text);
                FillListView(_projectForFind.Notes);
            }
            else
            {
                FillListView(_noteList.Notes);
            }
        }
        private void ClearAtRemove()
        {
            CategoryLabel.Text = string.Empty;
            Headline.Text = string.Empty;
            TextBox.Text = string.Empty;
            CreateDatePicker.Value = new DateTime(2000, 01, 01);
            ModifiedDatePicker.Value = new DateTime(2000, 01, 01);
        }
    }


}
