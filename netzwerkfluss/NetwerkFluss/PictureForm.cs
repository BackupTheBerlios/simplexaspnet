using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetwerkFluss
{
    public partial class PictureForm : Form
    {
        public PictureForm()
        {
            InitializeComponent();
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {

        }
        
        public void ShowPicture(string path)
        {
            this.pictureBox.ImageLocation = path;
        }
    }
}