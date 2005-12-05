namespace NetwerkFluss
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataSet1 = new System.Data.DataSet();
            this.matrixButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.knotenTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.quelleTextBox = new System.Windows.Forms.TextBox();
            this.senkeTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mapleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mengeTextBox = new System.Windows.Forms.TextBox();
            this.pictureButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.kostenLbl = new System.Windows.Forms.Label();
            this.mengeLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.mapleOutputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // matrixButton
            // 
            this.matrixButton.Location = new System.Drawing.Point(145, 65);
            this.matrixButton.Name = "matrixButton";
            this.matrixButton.Size = new System.Drawing.Size(75, 23);
            this.matrixButton.TabIndex = 1;
            this.matrixButton.Text = "Matrix erstellen";
            this.matrixButton.UseVisualStyleBackColor = true;
            this.matrixButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anzahl Knoten";
            // 
            // knotenTextBox
            // 
            this.knotenTextBox.Location = new System.Drawing.Point(94, 15);
            this.knotenTextBox.Name = "knotenTextBox";
            this.knotenTextBox.Size = new System.Drawing.Size(36, 20);
            this.knotenTextBox.TabIndex = 3;
            this.knotenTextBox.Text = "6";
            this.knotenTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quelle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senke";
            // 
            // quelleTextBox
            // 
            this.quelleTextBox.Location = new System.Drawing.Point(94, 41);
            this.quelleTextBox.Name = "quelleTextBox";
            this.quelleTextBox.Size = new System.Drawing.Size(36, 20);
            this.quelleTextBox.TabIndex = 3;
            this.quelleTextBox.Text = "1";
            this.quelleTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // senkeTextBox
            // 
            this.senkeTextBox.Location = new System.Drawing.Point(94, 67);
            this.senkeTextBox.Name = "senkeTextBox";
            this.senkeTextBox.Size = new System.Drawing.Size(36, 20);
            this.senkeTextBox.TabIndex = 3;
            this.senkeTextBox.Text = "6";
            this.senkeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Maple Code erstellen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.createMatrix_Click);
            // 
            // mapleTextBox
            // 
            this.mapleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapleTextBox.Location = new System.Drawing.Point(3, 3);
            this.mapleTextBox.Multiline = true;
            this.mapleTextBox.Name = "mapleTextBox";
            this.mapleTextBox.Size = new System.Drawing.Size(697, 306);
            this.mapleTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Menge";
            // 
            // mengeTextBox
            // 
            this.mengeTextBox.Location = new System.Drawing.Point(182, 12);
            this.mengeTextBox.Name = "mengeTextBox";
            this.mengeTextBox.Size = new System.Drawing.Size(36, 20);
            this.mengeTextBox.TabIndex = 3;
            this.mengeTextBox.Text = "10";
            this.mengeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureButton
            // 
            this.pictureButton.Enabled = false;
            this.pictureButton.Location = new System.Drawing.Point(625, 5);
            this.pictureButton.Name = "pictureButton";
            this.pictureButton.Size = new System.Drawing.Size(88, 23);
            this.pictureButton.TabIndex = 6;
            this.pictureButton.Text = "Bild anzeigen";
            this.pictureButton.UseVisualStyleBackColor = true;
            this.pictureButton.Click += new System.EventHandler(this.pictureButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 338);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(703, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matrix";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.Size = new System.Drawing.Size(691, 276);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mapleTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(703, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maple Input";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.kostenLbl);
            this.tabPage3.Controls.Add(this.mengeLbl);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.mapleOutputTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(703, 312);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Maple Output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // kostenLbl
            // 
            this.kostenLbl.AutoSize = true;
            this.kostenLbl.Location = new System.Drawing.Point(377, 11);
            this.kostenLbl.Name = "kostenLbl";
            this.kostenLbl.Size = new System.Drawing.Size(10, 13);
            this.kostenLbl.TabIndex = 3;
            this.kostenLbl.Text = "-";
            // 
            // mengeLbl
            // 
            this.mengeLbl.AutoSize = true;
            this.mengeLbl.Location = new System.Drawing.Point(161, 11);
            this.mengeLbl.Name = "mengeLbl";
            this.mengeLbl.Size = new System.Drawing.Size(10, 13);
            this.mengeLbl.TabIndex = 3;
            this.mengeLbl.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "enstehen minimale Kosten von";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Bei einer Transportmenge von";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(622, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Bild erstellen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // mapleOutputTextBox
            // 
            this.mapleOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapleOutputTextBox.Location = new System.Drawing.Point(3, 35);
            this.mapleOutputTextBox.Multiline = true;
            this.mapleOutputTextBox.Name = "mapleOutputTextBox";
            this.mapleOutputTextBox.Size = new System.Drawing.Size(697, 281);
            this.mapleOutputTextBox.TabIndex = 0;
            this.mapleOutputTextBox.Text = "{x46 = 6, x56 = 0, x12 = 0, x24 = 0, x32 = 0, x45 = 0, x13 = 6, x35 = 0, x34 = 6}" +
                "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 444);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.senkeTextBox);
            this.Controls.Add(this.quelleTextBox);
            this.Controls.Add(this.mengeTextBox);
            this.Controls.Add(this.knotenTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matrixButton);
            this.Name = "Form1";
            this.Text = "Netzwerkflussproblem";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button matrixButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox knotenTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quelleTextBox;
        private System.Windows.Forms.TextBox senkeTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox mapleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mengeTextBox;
        private System.Windows.Forms.Button pictureButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox mapleOutputTextBox;
        private System.Windows.Forms.Label mengeLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label kostenLbl;
        private System.Windows.Forms.Label label7;
    }
}

