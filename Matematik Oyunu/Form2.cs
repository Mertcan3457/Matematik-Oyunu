using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Form1 gec = new Form1();
                this.Hide();
                gec.Show();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Form3 gec = new Form3();
                this.Hide();
                gec.Show();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                Form4 gec = new Form4();
                this.Hide();
                gec.Show();
            }
            if (comboBox2.SelectedIndex == 3)
            {
                Form5 gec = new Form5();
                this.Hide();
                gec.Show();
            }
            if (comboBox2.SelectedIndex == 4)
            {
                Form6 gec = new Form6();
                this.Hide();
                gec.Show();
            }
        }
    }
}
