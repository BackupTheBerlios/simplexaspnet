using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LinearProgramming;



namespace NetwerkFluss
{
    public partial class Form1 : Form
    {

        const double PSEUDO = -1;
        
        DataTable matrixTable;
        IMatrix matrix= new Matrix();
        DotBuilder builder;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.matrixTable = new DataTable("matrix");

            int anzahl = Convert.ToInt32(knotenTextBox.Text);
            
            for (int x = 0; x < anzahl; x++)
            {
                matrixTable.Columns.Add((x+1).ToString());

                DataGridViewTextBoxColumn column= new DataGridViewTextBoxColumn();
                
                column.HeaderText = (x+1).ToString();
                column.Name = (x+1).ToString();
                column.Width = 30;
                
                this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            column});
            }


            for (int y = 0; y < anzahl; y++)
            {
                DataRow row = matrixTable.NewRow();
                this.matrixTable.Rows.Add(row);
                //this.dataGridView1.Rows[y].HeaderCell.Value = y.ToString();
            }

            //this.dataSet1.Tables.Add(matrixTable);
            
            //this.dataGridView1.DataSource = dataSet1.Tables[0];  
            this.dataGridView1.DataSource = this.matrixTable.DefaultView;  
            
            for (int y = 0; y < anzahl; y++)
            {
                this.dataGridView1.Rows[y].HeaderCell.Value = (y+1).ToString();
            }
            
        }

        private void createMatrix_Click(object sender, EventArgs e)
        {
            //this.matrixTable.AcceptChanges();
            //this.dataSet1.AcceptChanges();

            int anzahl = this.matrixTable.Columns.Count;

           // DataTable table = this.dataSet1.Tables[0];

            for (int y = 0; y < anzahl; y++)
            {
                Double[] dRow = new Double[anzahl];
                for (int x = 0; x < anzahl; x++)
                {
                    string wert = String.Empty;
                    if (this.dataGridView1.Rows[y].Cells[x].Value != System.DBNull.Value)
                        wert = (string)this.dataGridView1.Rows[y].Cells[x].Value;

                    if (wert == null || wert == String.Empty || wert.Length == 0)
                    {
                        dRow[x] = PSEUDO;
                    }
                    else
                        dRow[x] = Convert.ToDouble(wert);
                }
                Row row = new Row(dRow);
                this.matrix.AddRow(row);
               
            }
           builder = new DotBuilder(matrix, anzahl);
           builder.Build();
                
        }
    }
}