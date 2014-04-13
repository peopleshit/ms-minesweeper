namespace Minesweeper
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newgameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelBombs = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(292, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newgameButton,
            this.statisticsButton,
            this.settingsButton,
            this.exitButton});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // newgameButton
            // 
            this.newgameButton.Name = "newgameButton";
            this.newgameButton.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newgameButton.Size = new System.Drawing.Size(157, 22);
            this.newgameButton.Text = "Новая игра";
            this.newgameButton.Click += new System.EventHandler(this.newgameButtonClick);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.statisticsButton.Size = new System.Drawing.Size(157, 22);
            this.statisticsButton.Text = "Статистика";
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButtonClick);
            // 
            // settingsButton
            // 
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.settingsButton.Size = new System.Drawing.Size(157, 22);
            this.settingsButton.Text = "Параметры";
            this.settingsButton.Click += new System.EventHandler(this.settingsButtonClick);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitButton.Size = new System.Drawing.Size(157, 22);
            this.exitButton.Text = "Выход";
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 176);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(52, 13);
            this.labelTime.TabIndex = 1;
            this.labelTime.Tag = "";
            this.labelTime.Text = "labelTime";
            // 
            // labelBombs
            // 
            this.labelBombs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBombs.AutoSize = true;
            this.labelBombs.Location = new System.Drawing.Point(87, 176);
            this.labelBombs.Name = "labelBombs";
            this.labelBombs.Size = new System.Drawing.Size(61, 13);
            this.labelBombs.TabIndex = 2;
            this.labelBombs.Text = "labelBombs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.labelBombs);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newgameButton;
        private System.Windows.Forms.ToolStripMenuItem statisticsButton;
        private System.Windows.Forms.ToolStripMenuItem settingsButton;
        private System.Windows.Forms.ToolStripMenuItem exitButton;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelBombs;

    }
}

