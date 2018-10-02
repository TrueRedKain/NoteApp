using NoteApp;
using System.Windows.Forms;
using System;

namespace NoteAppUI
{
    public partial class Form1 : Form
    {
        private Project _noteList = new Project();

        public Form1()
        {
            InitializeComponent();
        }

        public Project NoteInstance()
        {
            Note _note = new Note();

            
            _note.Name = "Toxa";
            _note.Text = "Сегодня я снова сгорел играя за Браюна";
            _note.CreationDate = System.DateTime.Now;
            _note.LastEditDate = System.DateTime.Now;
            _note.NoteCategory = NoteCategory.Home;


            _noteList.Notes.Add(_note);

            MessageBox.Show(_note.Name);    
            MessageBox.Show(_note.Text);
            return _noteList;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _noteList = NoteInstance();
            ProjectManager _project = new ProjectManager();
            _project.SaveFile(_noteList);
        }
    }
}
