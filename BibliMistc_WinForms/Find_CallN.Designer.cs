namespace BibliMistc_WinForms
{
    partial class Find_CallN
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
            this.QuizNumber = new System.Windows.Forms.Label();
            this.DescriptionsCB = new System.Windows.Forms.ComboBox();
            this.Check_Answer = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // QuizNumber
            // 
            this.QuizNumber.AutoSize = true;
            this.QuizNumber.BackColor = System.Drawing.Color.Sienna;
            this.QuizNumber.Font = new System.Drawing.Font("Comic Sans MS", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuizNumber.ForeColor = System.Drawing.Color.White;
            this.QuizNumber.Location = new System.Drawing.Point(152, 254);
            this.QuizNumber.Name = "QuizNumber";
            this.QuizNumber.Size = new System.Drawing.Size(268, 74);
            this.QuizNumber.TabIndex = 0;
            this.QuizNumber.Text = "(Number)";
            // 
            // DescriptionsCB
            // 
            this.DescriptionsCB.Font = new System.Drawing.Font("Comic Sans MS", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionsCB.FormattingEnabled = true;
            this.DescriptionsCB.ItemHeight = 82;
            this.DescriptionsCB.Location = new System.Drawing.Point(165, 390);
            this.DescriptionsCB.Name = "DescriptionsCB";
            this.DescriptionsCB.Size = new System.Drawing.Size(1089, 90);
            this.DescriptionsCB.TabIndex = 1;
            this.DescriptionsCB.Text = "Select a description here!";
            // 
            // Check_Answer
            // 
            this.Check_Answer.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.button;
            this.Check_Answer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Check_Answer.Font = new System.Drawing.Font("Comic Sans MS", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check_Answer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Check_Answer.Location = new System.Drawing.Point(321, 712);
            this.Check_Answer.Name = "Check_Answer";
            this.Check_Answer.Size = new System.Drawing.Size(353, 76);
            this.Check_Answer.TabIndex = 2;
            this.Check_Answer.Text = "Check Answer";
            this.Check_Answer.UseVisualStyleBackColor = true;
            this.Check_Answer.Click += new System.EventHandler(this.Check_Answer_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.button;
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenu.Font = new System.Drawing.Font("Comic Sans MS", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenu.Location = new System.Drawing.Point(680, 712);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(353, 76);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "Main Menu";
            this.MainMenu.UseVisualStyleBackColor = true;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(165, 87);
            this.progressBar1.Maximum = 120;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1089, 71);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 120;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Find_CallN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.NormalBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1574, 929);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Check_Answer);
            this.Controls.Add(this.DescriptionsCB);
            this.Controls.Add(this.QuizNumber);
            this.DoubleBuffered = true;
            this.Name = "Find_CallN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finding Call Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuizNumber;
        private System.Windows.Forms.ComboBox DescriptionsCB;
        private System.Windows.Forms.Button Check_Answer;
        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer gameTimer;
    }
}