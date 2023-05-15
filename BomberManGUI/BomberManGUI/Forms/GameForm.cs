using Bomberman;
using BomberManGUI.FileManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BomberManGUI
{
    public partial class GameForm : Form
    {
        private InputController _inputController;
        private GameLogic _logic;
        private MainBoard _board;
        private string _userName;
        public GameForm()
        {
            InitializeComponent();
            Init();
            BackgroundSoundPlayer();
        }

        private void Init()
        {
            _board = new MainBoard(gamePanel);
            _inputController = new InputController();
            _logic = new GameLogic(_board, _board.ImgMap, _board.PhisicMap);
        }

        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The goal of the game:".ToUpper() + "destroy all the walls - 'o' in 2 minutes" +
                "\nBefore starting the game, you will be given the opportunity to choose the appearance of the player" +
                "\nSome explanations:" +
                "\n\t'@' - bomb mark" +
                "\n\t'#' - indestructible wall" +
                "\n\t'o' - temporary wall (this type of walls can has different strength)" +
                "\n\t'.' - explosion trace" +
                "\n\t'♦' - coin (here is differnt types of coin)" +
                "\nWARNING!! If you stay near the bomb for a long time, the explosion will kill you", "Game Rules");
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            _logic.ProcessGameLogic(_inputController.GetInput(e.KeyCode))
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataLabel.Text = $"Score: {_logic.Score}  /  " +
                $"Left to destroy: {_logic.Walls} /  Time left: {_logic.Timer.GetRestOfTheTime().ToString(@"mm\:ss")}";
        }

        private void dataLabel_Click(object sender, EventArgs e)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void processGameTimer_Tick(object sender, EventArgs e)
        {
            var name = FileManager.FileManager.GetPlayerName();
            if (_logic.GameState == GameState.Dead || _logic.GameState == GameState.TimeLeftEnd)
            {
                processGameTimer.Enabled = false;
                DialogResult result = MessageBox.Show($"{name.ToUpper()} YOU DEAD. Do you want try again ?", "Game End", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    var form = new GameForm();
                    form.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
            if (_logic.GameState == GameState.Victory)
            {
                processGameTimer.Enabled = false;
                DialogResult result = MessageBox.Show($"{name.ToUpper()} YOU WIN. Do you want try again ?", "Game End", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    var form = new GameForm();
                    form.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetUserName(string userName)
        {
            _userName = userName;
        }

        private void BackgroundSoundPlayer()
        {
            MusicManager.BackgrounSound(MXP);
        }
    }
}
