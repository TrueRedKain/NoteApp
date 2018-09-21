using NoteApp;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class Form1 : Form
    {
        private Project _noteList = new Project();

        public Form1()
        {
            InitializeComponent();
        }

        public Project jhgsd()
        {
            Note _note = new Note();

            
            _note.Name = "Toxa";
            _note.Text = "Сегодня я снова сгорел играя за Браюна";
            _note.MakeDate = new System.DateTime(2000, 10, 25);
            _note.LastEditDate = new System.DateTime(2000, 10, 30);
            _note.NoteCategory = null;


            _noteList.NoteList.Add(_note);

            MessageBox.Show(_note.Name);    
            MessageBox.Show(_note.Text);
            return _noteList;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _noteList = jhgsd();
            ProjectManager _project = new ProjectManager();
            _project.SaveFile(_noteList);
        }
    }
}
