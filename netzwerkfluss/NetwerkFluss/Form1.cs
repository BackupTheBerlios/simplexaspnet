using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetwerkFluss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable matrix = new DataTable();

            int anzahl = Convert.ToInt32(knotenTextBox.Text);
            
            for (int x = 0; x < anzahl; x++)
            {
                matrix.Columns.Add(x.ToString());
            }


            for (int y = 0; y < anzahl; y++)
            {
                DataRow row = matrix.NewRow();
                matrix.Rows.Add(row);

                //for (int x = 0; x < anzahl; x++)
                //{
                //    row[x] = x;
                //}
            }

            this.dataGridView1.DataSource=matrix;
        }
    }
}