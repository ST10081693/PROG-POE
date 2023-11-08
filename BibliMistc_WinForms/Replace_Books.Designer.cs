namespace BibliMistc_WinForms
{
    partial class Replace_Books
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
            this.generatebooks = new System.Windows.Forms.Button();
            this.sort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeleft = new System.Windows.Forms.Label();
            this.counttime = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generatebooks
            // 
            this.generatebooks.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.button;
            this.generatebooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.generatebooks.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generatebooks.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.generatebooks.Location = new System.Drawing.Point(232, 778);
            this.generatebooks.Name = "generatebooks";
            this.generatebooks.Size = new System.Drawing.Size(271, 54);
            this.generatebooks.TabIndex = 1;
            this.generatebooks.Text = "Generate books";
            this.generatebooks.UseVisualStyleBackColor = true;
            this.generatebooks.Click += new System.EventHandler(this.generatebooks_Click);
            // 
            // sort
            // 
            this.sort.BackColor = System.Drawing.SystemColors.Control;
            this.sort.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.button;
            this.sort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sort.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sort.Location = new System.Drawing.Point(509, 778);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(175, 54);
            this.sort.TabIndex = 2;
            this.sort.Text = "Sort";
            this.sort.UseVisualStyleBackColor = false;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(44, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 60);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Left: ";
            // 
            // timeleft
            // 
            this.timeleft.AutoSize = true;
            this.timeleft.BackColor = System.Drawing.Color.Transparent;
            this.timeleft.Font = new System.Drawing.Font("Comic Sans MS", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeleft.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeleft.Location = new System.Drawing.Point(315, 102);
            this.timeleft.Name = "timeleft";
            this.timeleft.Size = new System.Drawing.Size(0, 60);
            this.timeleft.TabIndex = 4;
            // 
            // counttime
            // 
            this.counttime.Interval = 1000;
            this.counttime.Tick += new System.EventHandler(this.counttime_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.shelf;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(216, 263);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(972, 509);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.button;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menu.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.menu.Location = new System.Drawing.Point(690, 778);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(175, 54);
            this.menu.TabIndex = 6;
            this.menu.Text = "Main Menu";
            this.menu.UseVisualStyleBackColor = false;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // Replace_Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BibliMistc_WinForms.Properties.Resources.GameBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1405, 894);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.timeleft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.generatebooks);
            this.DoubleBuffered = true;
            this.Name = "Replace_Books";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace_Books";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generatebooks;
        private System.Windows.Forms.Button sort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeleft;
        private System.Windows.Forms.Timer counttime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button menu;
    }
}