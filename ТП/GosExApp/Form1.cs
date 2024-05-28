using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace GosExApp
{
    public partial class Form1 : Form
    {
        private readonly string _saveFilePath1 = "D:\\save1.txt";
        private readonly string _saveFilePath2 = "D:\\save2.txt";
        public List<UserModel> users = new List<UserModel>();
        public List<ClassModel> classes = new List<ClassModel>();

        public Form1()
        {
            InitializeComponent();
            if (File.Exists(_saveFilePath1))
            {
                users = JsonSerializer.Deserialize<List<UserModel>>(File.ReadAllText(_saveFilePath1));
            }

            if (File.Exists(_saveFilePath2))
            {
                classes = JsonSerializer.Deserialize<List<ClassModel>>(File.ReadAllText(_saveFilePath2));
            }

            dataGridView1.DataSource = users;
            dataGridView2.DataSource = classes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdd(this);
            formAdd.ShowDialog();
        }

        public void AddClass(ClassModel cls)
        {
            classes.Add(cls);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = classes;
            //dataGridView1.Rows.Add(user);
        }

        public void AddUser(UserModel user)
        {
            users.Add(user);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
            //dataGridView1.Rows.Add(user);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!File.Exists(_saveFilePath1))
            {
                File.Create(_saveFilePath1).Close();
            }

            if (!File.Exists(_saveFilePath2))
            {
                File.Create(_saveFilePath2).Close();
            }

            File.WriteAllText(_saveFilePath1, JsonSerializer.Serialize(users));
            File.WriteAllText(_saveFilePath2, JsonSerializer.Serialize(classes));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAddClass(this);
            formAdd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            classes = classes.OrderByDescending(x => x.Name).ToList();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = classes;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Join(";", users.Where(x => x.Name.Contains("Name")).Select(x => $"{x.Id} {x.Name}")));

            string[] _users = (from x in users
                              where x.Name.Contains("Name")
                              select x.Name) 
                              .ToArray();

            MessageBox.Show(string.Join(";", _users));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(users.Max(x=>x.Age).ToString());
        }
    }
}
