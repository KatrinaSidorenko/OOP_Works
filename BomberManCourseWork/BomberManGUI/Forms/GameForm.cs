using System;
using System.Windows.Forms;
using BomberManGUI.View;
using BomberManGUI.Engine;
using BomberManGUI.Enums;
using System.Xml.Linq;
using BomberManGUI.UsersManager;

namespace BomberManGUI
{
    public partial class GameForm : Form
    {
        private InputController _inputController;
        private GameLogic _logic;
        private SceneManager _graphics;
        private UserService _userService;
        public GameForm(UserService userService)
        { 
            _userService = userService;
            InitializeComponent();            
            Init();
            BackgroundSoundPlayer();
        }

        private void Init()
        {
            _graphics = new SceneManager(gamePanel);
            _inputController = new InputController();
            _logic = new GameLogic(_graphics);
        }

        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The goal of the game:".ToUpper() + "destroy all the gray walls - in 2 minutes" +
                "\nBefore starting the game, you will be given the opportunity to choose the appearance of the player" +
                "\nSome explanations what exists in the game:" +
                "\n\t - bomb " +
                "\n\t - indestructible wall" +
                "\n\t - temporary wall (this type of walls can has different strength)" +
                "\n\t - explosion trace" +
                "\n\t - coin (here is differnt types of coin)" +
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
            if (!_logic.ProcessGameLogic(_inputController.GetInput(e.KeyCode)))
            {
                if(_logic.GameState == GameState.Dead || _logic.GameState == GameState.TimeLeftEnd)
                {
                    _userService.UpdateAmountOfGames(GameState.Dead);
                    ShowGameOverBox("dead");
                }
                else if(_logic.GameState == GameState.Exit)
                {
                    exitToolStripMenuItem_Click(null, null);
                }
                else
                {
                    _userService.UpdateAmountOfGames(GameState.Victory);
                    ShowGameOverBox("win");
                }
            }
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
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Do you want leave the game?", "Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }           
        }

        private void BackgroundSoundPlayer()
        {
            MusicManager.BackgroundSoundPlay(MXP);
        }

        private void ShowGameOverBox(string gameOver)
        {

            MessageBox.Show($"{_userService.CurrentUser.Name.ToUpper()}, YOU {gameOver.ToUpper()}.");
            DialogResult result = MessageBox.Show($" YOUR STATISTIC: " +
                $"\t\n Total amount of games - {_userService.CurrentUser.TotalAmountOfGames}" +
                $"\t\n Number of won games - {_userService.CurrentUser.AmountOfWonGames}" +
                $"\t\n Number of lost games - {_userService.CurrentUser.TotalAmountOfGames - _userService.CurrentUser.AmountOfWonGames}." +
                $"\t\n Do you want try again ?", "Game End", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               this.Close();
               var form = new GameForm(_userService);
                form.Show();
            }
            else
            {
               Application.Exit();
            }
        }
    }
}
