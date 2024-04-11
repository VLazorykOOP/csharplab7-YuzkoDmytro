using System;
using System.Windows.Forms;

namespace lab7c_yuzkodmytro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Введіть значення для додавання до списку.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Виберіть елемент для видалення зі списку.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
