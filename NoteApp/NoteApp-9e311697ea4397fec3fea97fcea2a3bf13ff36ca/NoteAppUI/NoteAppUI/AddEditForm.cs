using NoteApp;
using System;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
            CategoryComboBox.Items.Add(NoteCategory.Finance);
            CategoryComboBox.Items.Add(NoteCategory.Documents);
            CategoryComboBox.Items.Add(NoteCategory.Work);
            CategoryComboBox.Items.Add(NoteCategory.SportAndHealth);
            CategoryComboBox.Items.Add(NoteCategory.Home);
            CategoryComboBox.Items.Add(NoteCategory.Humans);
            CategoryComboBox.Items.Add(NoteCategory.Others);

           
        }
        
        private Note _note = new Note();
        public Note _noteContainer => _note;

        private void button1_Click(object sender, System.EventArgs e)
        {
            
            if (Correct() == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Correct()
        {

            try
            {
                _note.Name = TitleTextBox.Text;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Note Add Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TitleTextBox.Focus();
                return false;
            }

            //NoteCategory
            try
            {
                _note.NoteCategory = (NoteCategory)CategoryComboBox.SelectedItem;
            }
            catch
            {

            }

            try
            {
                _note.Text = NoteTextBox.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Note Add Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TitleTextBox.Focus();
                return false;
            }
            try
            {
                _note.LastEditDate = ModifiedDatePicker.Value;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Note Add Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TitleTextBox.Focus();
                return false;
            }
            _note.CreationDate = CreationDatePicker.Value;


            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void NoteView(Note NoteEdit)
        {
            TitleTextBox.Text = NoteEdit.Name;
            CategoryComboBox.Text = NoteEdit.NoteCategory.ToString();
            CreationDatePicker.Value = NoteEdit.CreationDate;
            NoteTextBox.Text = NoteEdit.Text;
            ModifiedDatePicker.Value = DateTime.Now;
        }
    }
}
