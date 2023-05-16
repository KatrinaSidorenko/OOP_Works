namespace BomberManGUI
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.dataLabel = new System.Windows.Forms.Label();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.processGameTimer = new System.Windows.Forms.Timer(this.components);
            this.MXP = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1348, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "gameStrip";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menuStrip1_KeyDown);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutGameToolStripMenuItem});
            this.recordToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.recordToolStripMenuItem.Text = "Rules";
            // 
            // aboutGameToolStripMenuItem
            // 
            this.aboutGameToolStripMenuItem.Name = "aboutGameToolStripMenuItem";
            this.aboutGameToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.aboutGameToolStripMenuItem.Text = "About Game";
            this.aboutGameToolStripMenuItem.Click += new System.EventHandler(this.aboutGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePanel.Location = new System.Drawing.Point(83, 114);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(1172, 538);
            this.gamePanel.TabIndex = 1;
            this.gamePanel.Visible = false;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // dataLabel
            // 
            this.dataLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataLabel.Location = new System.Drawing.Point(117, 35);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(1119, 59);
            this.dataLabel.TabIndex = 2;
            this.dataLabel.Text = "Game Data";
            this.dataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataLabel.TextChanged += new System.EventHandler(this.timer1_Tick);
            this.dataLabel.Click += new System.EventHandler(this.dataLabel_Click);
            // 
            // dataTimer
            // 
            this.dataTimer.Enabled = true;
            this.dataTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // processGameTimer
            // 
            this.processGameTimer.Enabled = true;
            this.processGameTimer.Tick += new System.EventHandler(this.processGameTimer_Tick);
            // 
            // MXP
            // 
            this.MXP.Enabled = true;
            this.MXP.Location = new System.Drawing.Point(12, 36);
            this.MXP.Name = "MXP";
            this.MXP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MXP.OcxState")));
            this.MXP.Size = new System.Drawing.Size(233, 58);
            this.MXP.TabIndex = 3;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 664);
            this.Controls.Add(this.MXP);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BomberMan";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutGameToolStripMenuItem;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Timer processGameTimer;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer MXP;
    }
}

