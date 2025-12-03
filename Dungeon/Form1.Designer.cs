namespace Dungeon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            rowsNumericUpDown = new NumericUpDown();
            colsNumericUpDown = new NumericUpDown();
            levelsNumericUpDown = new NumericUpDown();
            buttonGenerate = new Button();
            timerDungeon = new System.Windows.Forms.Timer(components);
            currentLevelNumericUpDown = new NumericUpDown();
            buttonAdventure = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnPlayerData = new Button();
            ((System.ComponentModel.ISupportInitialize)rowsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)levelsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentLevelNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // rowsNumericUpDown
            // 
            rowsNumericUpDown.Location = new Point(93, 15);
            rowsNumericUpDown.Margin = new Padding(4);
            rowsNumericUpDown.Name = "rowsNumericUpDown";
            rowsNumericUpDown.Size = new Size(48, 23);
            rowsNumericUpDown.TabIndex = 0;
            rowsNumericUpDown.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // colsNumericUpDown
            // 
            colsNumericUpDown.Location = new Point(93, 45);
            colsNumericUpDown.Margin = new Padding(4);
            colsNumericUpDown.Name = "colsNumericUpDown";
            colsNumericUpDown.Size = new Size(48, 23);
            colsNumericUpDown.TabIndex = 1;
            colsNumericUpDown.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // levelsNumericUpDown
            // 
            levelsNumericUpDown.Location = new Point(93, 75);
            levelsNumericUpDown.Margin = new Padding(4);
            levelsNumericUpDown.Name = "levelsNumericUpDown";
            levelsNumericUpDown.Size = new Size(48, 23);
            levelsNumericUpDown.TabIndex = 2;
            levelsNumericUpDown.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(203, 11);
            buttonGenerate.Margin = new Padding(4);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(110, 26);
            buttonGenerate.TabIndex = 3;
            buttonGenerate.Text = "Generate";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += ButtonGenerate_Click;
            // 
            // timerDungeon
            // 
            timerDungeon.Interval = 250;
            timerDungeon.Tick += TimerDungeon_Tick;
            // 
            // currentLevelNumericUpDown
            // 
            currentLevelNumericUpDown.Enabled = false;
            currentLevelNumericUpDown.InterceptArrowKeys = false;
            currentLevelNumericUpDown.Location = new Point(449, 15);
            currentLevelNumericUpDown.Margin = new Padding(4);
            currentLevelNumericUpDown.Name = "currentLevelNumericUpDown";
            currentLevelNumericUpDown.ReadOnly = true;
            currentLevelNumericUpDown.Size = new Size(48, 23);
            currentLevelNumericUpDown.TabIndex = 4;
            currentLevelNumericUpDown.ValueChanged += CurrentLevelNumericUpDown_ValueChanged;
            // 
            // buttonAdventure
            // 
            buttonAdventure.Enabled = false;
            buttonAdventure.Location = new Point(203, 45);
            buttonAdventure.Margin = new Padding(4);
            buttonAdventure.Name = "buttonAdventure";
            buttonAdventure.Size = new Size(110, 26);
            buttonAdventure.TabIndex = 5;
            buttonAdventure.Text = "Start Adventure";
            buttonAdventure.UseVisualStyleBackColor = true;
            buttonAdventure.Click += ButtonAdventure_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(364, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 6;
            label1.Text = "Current Floor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 17);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 7;
            label2.Text = "Room Rows";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 46);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 8;
            label3.Text = "Room Cols";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 76);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 9;
            label4.Text = "Floors";
            // 
            // btnPlayerData
            // 
            btnPlayerData.Location = new Point(571, 11);
            btnPlayerData.Margin = new Padding(4);
            btnPlayerData.Name = "btnPlayerData";
            btnPlayerData.Size = new Size(110, 26);
            btnPlayerData.TabIndex = 11;
            btnPlayerData.Text = "Player Data";
            btnPlayerData.UseVisualStyleBackColor = true;
            btnPlayerData.Click += BtnPlayerData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 614);
            Controls.Add(btnPlayerData);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAdventure);
            Controls.Add(currentLevelNumericUpDown);
            Controls.Add(buttonGenerate);
            Controls.Add(levelsNumericUpDown);
            Controls.Add(colsNumericUpDown);
            Controls.Add(rowsNumericUpDown);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Dungeon";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)rowsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)colsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)levelsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentLevelNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
        private System.Windows.Forms.NumericUpDown colsNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelsNumericUpDown;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Timer timerDungeon;
        private System.Windows.Forms.NumericUpDown currentLevelNumericUpDown;
        private System.Windows.Forms.Button buttonAdventure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPlayerData;
    }
}
