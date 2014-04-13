namespace Minesweeper
{
    partial class Settings
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonResetProgress = new System.Windows.Forms.Button();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 110);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(170, 21);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonCloseClick);
            // 
            // buttonResetProgress
            // 
            this.buttonResetProgress.Location = new System.Drawing.Point(12, 83);
            this.buttonResetProgress.Name = "buttonResetProgress";
            this.buttonResetProgress.Size = new System.Drawing.Size(170, 21);
            this.buttonResetProgress.TabIndex = 1;
            this.buttonResetProgress.Text = "Сбросить рекорды";
            this.buttonResetProgress.UseVisualStyleBackColor = true;
            this.buttonResetProgress.Click += new System.EventHandler(this.buttonResetProgressClick);
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Location = new System.Drawing.Point(12, 12);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(135, 17);
            this.radioButtonEasy.TabIndex = 2;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Новичок (9х9, 10 мин)";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(12, 35);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(155, 17);
            this.radioButtonMedium.TabIndex = 3;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Любитель (16х16, 40 мин)";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Location = new System.Drawing.Point(12, 58);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(180, 17);
            this.radioButtonHard.TabIndex = 4;
            this.radioButtonHard.TabStop = true;
            this.radioButtonHard.Text = "Профессионал (16х30, 99 мин)";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 143);
            this.ControlBox = false;
            this.Controls.Add(this.radioButtonHard);
            this.Controls.Add(this.radioButtonMedium);
            this.Controls.Add(this.radioButtonEasy);
            this.Controls.Add(this.buttonResetProgress);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Settings";
            this.Text = "Параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonResetProgress;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonHard;
    }
}