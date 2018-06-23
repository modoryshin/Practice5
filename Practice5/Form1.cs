using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool ok;
            ok = Int32.TryParse(textBox1.Text, out n);
            if (!ok || n <= 0)
            {
                MessageBox.Show("Unexceptable data type.");
                textBox1.Text = null;
                button1.Visible = false;
            }
            else if (n == 1)
            {
                MessageBox.Show("Matrix will only have one slot.");
                textBox1.Text = null;
                button1.Visible = false;
            }
            else if (n % 2 == 0)
            {
                MessageBox.Show("With an even size matrix won't have a central slot.");
                textBox1.Text = null;
                button1.Visible = false;
            }
            else
            {
                MessageBox.Show("Fill matrix with numbers. Every empty slot will be filled with 0.");
                dataGridView1.Visible = true;
                dataGridView1.RowCount = Convert.ToInt32(textBox1.Text);
                dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text);
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(textBox1.Text); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
            button1.Visible = false;
            textBox1.Text = null;
            textBox1.ReadOnly = false;
            dataGridView1.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(textBox1.Text) / 2 + 1;
            double[,] matr = new double[Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text)];
            for(int i=0;i< Convert.ToInt32(textBox1.Text); i++)
            {
                for(int j=0;j< Convert.ToInt32(textBox1.Text);j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        matr[i, j] = 0;
                    }
                    else
                    {
                        try
                        {
                            matr[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        }
                        catch (System.FormatException)
                        {
                            matr[i, j] = 0;
                        }
                    }
                }
            }
            double max = Double.MinValue;
            for(int i = s-1; i >= 0; i--)
            {
                for(int j=s-1;j< Convert.ToInt32(textBox1.Text); j++)
                {
                    if(max<matr[i,j])
                        max=matr[i,j];
                }
                s++;
            }
            s= Convert.ToInt32(textBox1.Text) / 2 + 1;
            for (int i = s-1; i < Convert.ToInt32(textBox1.Text); i++)
            {
                for (int j = s-1; j < Convert.ToInt32(textBox1.Text); j++)
                {
                    if (max < matr[i, j])
                        max = matr[i, j];
                }
                s++;
            }
            label2.Visible = true;
            textBox2.Visible = true;
            textBox2.Text = Convert.ToString(max);
        }
    }
}
