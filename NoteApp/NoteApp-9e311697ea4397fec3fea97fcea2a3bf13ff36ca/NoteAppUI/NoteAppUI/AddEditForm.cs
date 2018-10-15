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
            try
            {
                //TODO: Преобразовать str в NoteCategory
               // _note.NoteCategory= CategoryComboBox.Text;
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
    }
}
