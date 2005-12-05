using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using LinearProgramming;

namespace NetwerkFluss
{
    public partial class Form1 : Form
    {
        private const double PSEUDO = -1;

        private DataTable matrixTable;
        private IMatrix matrix = new Matrix();
        private DotBuilder builder;
        double[,] fake = new double[10, 10];
        string opt = "OptimizedGraph.dot";
        string start = "StartGraph.dot";
        private double kosten;

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
                matrixTable.Columns.Add((x + 1).ToString());

                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

                column.HeaderText = (x + 1).ToString();
                column.Name = (x + 1).ToString();
                column.Width = 30;

                this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
                                                        {
                                                            column
                                                        });
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
                this.dataGridView1.Rows[y].HeaderCell.Value = (y + 1).ToString();
            }

            this.tabControl1.Enabled = true;
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
                    if (this.dataGridView1.Rows[y].Cells[x].Value != DBNull.Value)
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
            builder.Build(fake, matrix, start);


            this.mapleTextBox.Text =
                builder.getRestrictions(Convert.ToInt32(this.mengeTextBox.Text),
                                        Convert.ToInt32(this.quelleTextBox.Text),
                                        Convert.ToInt32(this.senkeTextBox.Text));

            this.tabControl1.SelectedTab = this.tabPage2;
            this.pictureButton.Enabled = true;
        }


        private void pictureButton_Click(object sender, EventArgs e)
        {
            PictureForm picForm = new PictureForm();
            string path = "start.jpg";
            picForm.ShowPicture(path);
            this.createPicture("start");
            picForm.Show();

            this.createPicture("start");
        }

        private void createPicture(string _name)
        {
            //string ssss = "dot.exe -Tjpg test.dot > test.jpg";

            string commandLineArgs = string.Format(" -Tjpg {0}.dot -o{1}.jpg ", _name, _name);
            //string executablePath = @"F:\FH\Babsy\netzwerkfluss\NetwerkFluss\bin\Debug\dot.exe";

            string executablePath = @"GraphViz\bin\dot.exe";
            //Process mainProcess = null;


            Process.Start(executablePath, commandLineArgs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] punkte = AnalyzeMapleOutput(this.mapleOutputTextBox.Text);

            this.mengeLbl.Text = mengeTextBox.Text;
            this.kostenLbl.Text = this.kosten.ToString();
        }

        private double[,] AnalyzeMapleOutput(string _output)
        {
            int cnt;
            if (this.matrix == null || this.matrix.RowCount == 0)
            {
                cnt = Convert.ToInt32(this.knotenTextBox.Text);
            }
            else
            {
                cnt = matrix.RowCount;
            }
            double[,] points = new double[cnt, cnt];

            string mapleOutput = _output.Replace("{", "");
            mapleOutput = mapleOutput.Replace("}", "");

            string[] equations = mapleOutput.Split(',');
            foreach (string equation in equations)
            {
                string[] parts = equation.Split('=');
                int menge = Convert.ToInt32(parts[1]);

                if (menge > 0)
                {
                    string[] wert = parts[0].Split('x');

                    int from = Convert.ToInt32(wert[1].Substring(0, 1));
                    int to = Convert.ToInt32(wert[1].Substring(1, 1));

                    points[from - 1, to - 1] = 1;

                    this.kosten += this.matrix.GetRow(from - 1).Values[to - 1];
                }
            }

            builder.Build(points, matrix, opt);
            return points;
            //matrix und filename
        }
    }
}