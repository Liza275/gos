using System;
using System.Windows.Forms;

namespace GosExApp
{
    public partial class FormAddClass : Form
    {
        private readonly Form1 _form1;

        public FormAddClass(Form1 form)
        {
            InitializeComponent();
            _form1 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassModel newClassModel = new ClassModel();
            newClassModel.Id = int.TryParse(textBox1.Text ?? "0", out int id) ? id : 0;
            newClassModel.Name = textBox2.Text ?? "No name";
            _form1.AddClass(newClassModel);
            Close();
        }
    }
}
