namespace WinDungeon
{
    partial class Form1
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
            this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.colsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.timerDungeon = new System.Windows.Forms.Timer(this.components);
            this.currentLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonAdventure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentLevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rowsNumericUpDown
            // 
            this.rowsNumericUpDown.Location = new System.Drawing.Point(80, 13);
            this.rowsNumericUpDown.Name = "rowsNumericUpDown";
            this.rowsNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.rowsNumericUpDown.TabIndex = 0;
            this.rowsNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // colsNumericUpDown
            // 
            this.colsNumericUpDown.Location = new System.Drawing.Point(80, 39);
            this.colsNumericUpDown.Name = "colsNumericUpDown";
            this.colsNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.colsNumericUpDown.TabIndex = 1;
            this.colsNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // levelsNumericUpDown
            // 
            this.levelsNumericUpDown.Location = new System.Drawing.Point(80, 65);
            this.levelsNumericUpDown.Name = "levelsNumericUpDown";
            this.levelsNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.levelsNumericUpDown.TabIndex = 2;
            this.levelsNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(174, 10);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(94, 23);
            this.buttonGenerate.TabIndex = 3;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // timerDungeon
            // 
            this.timerDungeon.Interval = 250;
            this.timerDungeon.Tick += new System.EventHandler(this.timerDungeon_Tick);
            // 
            // currentLevelNumericUpDown
            // 
            this.currentLevelNumericUpDown.Enabled = false;
            this.currentLevelNumericUpDown.InterceptArrowKeys = false;
            this.currentLevelNumericUpDown.Location = new System.Drawing.Point(385, 13);
            this.currentLevelNumericUpDown.Name = "currentLevelNumericUpDown";
            this.currentLevelNumericUpDown.ReadOnly = true;
            this.currentLevelNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.currentLevelNumericUpDown.TabIndex = 4;
            this.currentLevelNumericUpDown.ValueChanged += new System.EventHandler(this.currentLevelNumericUpDown_ValueChanged);
            // 
            // buttonAdventure
            // 
            this.buttonAdventure.Enabled = false;
            this.buttonAdventure.Location = new System.Drawing.Point(174, 39);
            this.buttonAdventure.Name = "buttonAdventure";
            this.buttonAdventure.Size = new System.Drawing.Size(94, 23);
            this.buttonAdventure.TabIndex = 5;
            this.buttonAdventure.Text = "Start Adventure";
            this.buttonAdventure.UseVisualStyleBackColor = true;
            this.buttonAdventure.Click += new System.EventHandler(this.buttonAdventure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Floor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Room Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Room Cols";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Floors";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 532);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdventure);
            this.Controls.Add(this.currentLevelNumericUpDown);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.levelsNumericUpDown);
            this.Controls.Add(this.colsNumericUpDown);
            this.Controls.Add(this.rowsNumericUpDown);
            this.Name = "Form1";
            this.Text = "Dungeon";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentLevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

