using System;
using System.Windows.Forms;

namespace GosExApp
{
    public partial class FormAdd : Form
    {
        private readonly Form1 _formUsers;

        public FormAdd(Form1 form1)
        {
            InitializeComponent();
            _formUsers = form1;
            comboBox1.DataSource = form1.classes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserModel newUser = new UserModel();
            try
            {
                newUser.Number = int.TryParse(textBox1.Text ?? "0", out int result) ? result : 0;
                newUser.Id = int.TryParse(textBox1.Text ?? "0", out int result2) ? result2 : 0;
                newUser.Name = textBox2.Text ?? "No name";
                newUser.Age = int.TryParse(textBox3.Text ?? "0", out int resultAge) ? resultAge : 0;
                newUser.ClassId = comboBox1.SelectedItem != null ? (comboBox1.SelectedItem as ClassModel).Id : 0;
                _formUsers.AddUser(newUser);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
