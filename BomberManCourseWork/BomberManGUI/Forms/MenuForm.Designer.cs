namespace BomberManGUI
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.nameField = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.authoriseButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameField.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameField.Location = new System.Drawing.Point(638, 178);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(324, 38);
            this.nameField.TabIndex = 0;
            this.nameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameField.TextChanged += new System.EventHandler(this.nameField_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(658, 126);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(284, 36);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Enter your name:";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.closeButton.BackgroundImage = global::BomberManGUI.Properties.Resources.closeButton2;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.Location = new System.Drawing.Point(963, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(55, 59);
            this.closeButton.TabIndex = 3;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // passwordText
            // 
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordText.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordText.Location = new System.Drawing.Point(638, 295);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(324, 38);
            this.passwordText.TabIndex = 4;
            this.passwordText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.Location = new System.Drawing.Point(632, 235);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(344, 36);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Enter your password:";
            this.passwordLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // authoriseButton
            // 
            this.authoriseButton.BackColor = System.Drawing.Color.LightGray;
            this.authoriseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authoriseButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authoriseButton.Location = new System.Drawing.Point(724, 383);
            this.authoriseButton.Name = "authoriseButton";
            this.authoriseButton.Size = new System.Drawing.Size(139, 49);
            this.authoriseButton.TabIndex = 6;
            this.authoriseButton.Text = "Sign In";
            this.authoriseButton.UseVisualStyleBackColor = false;
            this.authoriseButton.Click += new System.EventHandler(this.authoriseButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.LightGray;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerButton.Location = new System.Drawing.Point(724, 464);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(139, 49);
            this.registerButton.TabIndex = 7;
            this.registerButton.Text = "Sign Up";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1030, 633);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.authoriseButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameField);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button authoriseButton;
        private System.Windows.Forms.Button registerButton;
    }
}