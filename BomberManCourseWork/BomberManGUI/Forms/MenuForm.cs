using BomberManGUI.Helpers;
using BomberManGUI.UsersManager;
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
        private UserService _userService;
        public MenuForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        //private void startButton_Click(object sender, EventArgs e)
        //{
        //    if (nameField.Text != String.Empty)
        //    {
        //        this.Hide();
        //        FileManager.FileManager.WritePlayerNameIntoFile(nameField.Text);
        //        var form = new GameForm();
        //        form.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Enter your name");
        //    }
        //}

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void authoriseButton_Click(object sender, EventArgs e)
        {
            if (CheckTextIsNotEmpty())
            {               
                if (_userService.AuthoriseUser(nameField.Text, PasswordHasher.Hash(passwordText.Text)))
                {
                    this.Hide();
                    var form = new GameForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid input user data");
                }
            }
        }

        private bool CheckTextIsNotEmpty()
        {
            if (nameField.Text == String.Empty)
            {
                MessageBox.Show("Enter your name");
                return false;
            }
            else if(passwordLabel.Text == String.Empty)
            {
                MessageBox.Show("Enter your password");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (CheckTextIsNotEmpty())
            {
                if (_userService.RegisterUser(new User() { Name = nameField.Text, Password = PasswordHasher.Hash(passwordText.Text) }))
                {
                    this.Hide();
                    var form = new GameForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid input user data");
                }               
            }
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
