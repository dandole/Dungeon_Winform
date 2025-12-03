
namespace Dungeon;

partial class PlayerData
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerData));
        this.picPlayer = new System.Windows.Forms.PictureBox();
        this.lblHP = new System.Windows.Forms.Label();
        this.lblHitPoints = new System.Windows.Forms.Label();
        this.lblPlayerType = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
        this.SuspendLayout();
        // 
        // picPlayer
        // 
        this.picPlayer.Image = ((System.Drawing.Image)(resources.GetObject("picPlayer.Image")));
        this.picPlayer.Location = new System.Drawing.Point(457, 12);
        this.picPlayer.Name = "picPlayer";
        this.picPlayer.Size = new System.Drawing.Size(495, 392);
        this.picPlayer.TabIndex = 7;
        this.picPlayer.TabStop = false;
        // 
        // lblHP
        // 
        this.lblHP.AutoSize = true;
        this.lblHP.Location = new System.Drawing.Point(88, 153);
        this.lblHP.Name = "lblHP";
        this.lblHP.Size = new System.Drawing.Size(47, 25);
        this.lblHP.TabIndex = 6;
        this.lblHP.Text = "HP:";
        // 
        // lblHitPoints
        // 
        this.lblHitPoints.AutoSize = true;
        this.lblHitPoints.Location = new System.Drawing.Point(88, 106);
        this.lblHitPoints.Name = "lblHitPoints";
        this.lblHitPoints.Size = new System.Drawing.Size(110, 25);
        this.lblHitPoints.TabIndex = 5;
        this.lblHitPoints.Text = "Hit Points:";
        // 
        // lblPlayerType
        // 
        this.lblPlayerType.AutoSize = true;
        this.lblPlayerType.Location = new System.Drawing.Point(88, 62);
        this.lblPlayerType.Name = "lblPlayerType";
        this.lblPlayerType.Size = new System.Drawing.Size(133, 25);
        this.lblPlayerType.TabIndex = 4;
        this.lblPlayerType.Text = "Player Type:";
        // 
        // PlayerData
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1047, 695);
        this.Controls.Add(this.picPlayer);
        this.Controls.Add(this.lblHP);
        this.Controls.Add(this.lblHitPoints);
        this.Controls.Add(this.lblPlayerType);
        this.Name = "PlayerData";
        this.Text = "PlayerData";
        ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picPlayer;
    private System.Windows.Forms.Label lblHP;
    private System.Windows.Forms.Label lblHitPoints;
    private System.Windows.Forms.Label lblPlayerType;
}