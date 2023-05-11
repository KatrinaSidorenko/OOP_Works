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
        private string _userName;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_userName != null)
            {
                this.Hide();
                var form = new GameForm();
                form.SetUserName(_userName);
                form.Show();
            }
            else
            {
                MessageBox.Show("Enter your name");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {
            _userName = nameField.Text;
        }
    }
}
