using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberManGUI
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (nameField.Text != String.Empty)
            {
                this.Hide();
                FileManager.FileManager.WritePlayerNameIntoFile(nameField.Text);
                var form = new GameForm();
                form.Show();
            }
            else
            {
                MessageBox.Show("Enter your name");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want leave the game?", "Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
