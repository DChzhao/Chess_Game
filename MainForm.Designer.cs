using System.Drawing;

namespace Chess_Game
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.newGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.TextBox();
            this.player2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.Seconds = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.boardSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(173, 223);
            this.newGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(100, 28);
            this.newGame.TabIndex = 0;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player 1";
            // 
            // player1
            // 
            this.player1.Location = new System.Drawing.Point(159, 52);
            this.player1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(132, 22);
            this.player1.TabIndex = 2;
            this.player1.Text = "Player 1";
            // 
            // player2
            // 
            this.player2.Location = new System.Drawing.Point(159, 103);
            this.player2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(132, 22);
            this.player2.TabIndex = 4;
            this.player2.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time Limit";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Minute
            // 
            this.Minute.Location = new System.Drawing.Point(159, 164);
            this.Minute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(53, 22);
            this.Minute.TabIndex = 6;
            this.Minute.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Seconds
            // 
            this.Seconds.Location = new System.Drawing.Point(316, 164);
            this.Seconds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(53, 22);
            this.Seconds.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Increment";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boardSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // boardSettingsToolStripMenuItem
            // 
            this.boardSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightColorToolStripMenuItem,
            this.darkColorToolStripMenuItem});
            this.boardSettingsToolStripMenuItem.Name = "boardSettingsToolStripMenuItem";
            this.boardSettingsToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.boardSettingsToolStripMenuItem.Text = "Board Settings";
            // 
            // lightColorToolStripMenuItem
            // 
            this.lightColorToolStripMenuItem.Name = "lightColorToolStripMenuItem";
            this.lightColorToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.lightColorToolStripMenuItem.Text = "Light Color";
            this.lightColorToolStripMenuItem.Click += new System.EventHandler(this.LightColor_Click);
            // 
            // darkColorToolStripMenuItem
            // 
            this.darkColorToolStripMenuItem.Name = "darkColorToolStripMenuItem";
            this.darkColorToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.darkColorToolStripMenuItem.Text = "Dark Color";
            this.darkColorToolStripMenuItem.Click += new System.EventHandler(this.DarkColor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 306);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Minute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox player1;
        private System.Windows.Forms.TextBox player2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.NumericUpDown Seconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem boardSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Color LightColor;
        private Color DarkColor;
    }
}

