namespace Dungeon;

public partial class Form1 : Form
{

    private readonly Dungeon _dungeon = new();
    private bool _intialize = true;
    private int _currentLevel = 0;

    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        DoubleBuffered = true;
        _intialize = false;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // Draw the current level if it exists
        if (_dungeon.Levels != null && _dungeon.Levels.TryGetValue(_currentLevel, out var level))
        {
            level.Draw(e.Graphics);
        }
    }

    private void TimerDungeon_Tick(object sender, EventArgs e)
    {
        timerDungeon.Enabled = false;
        _dungeon.MoveMonsters();
        _dungeon.MovePlayer();
        if (_dungeon.Player.Location.Level + 1 != (int)currentLevelNumericUpDown.Value)
        {
            currentLevelNumericUpDown.Value = _dungeon.Player.Location.Level + 1;
        }

        timerDungeon.Enabled = true;
        Invalidate(); // Redraw the form
    }

    private void ButtonGenerate_Click(object sender, EventArgs e)
    {
        buttonGenerate.Enabled = false;

        rowsNumericUpDown.ReadOnly = true;
        rowsNumericUpDown.InterceptArrowKeys = false;
        colsNumericUpDown.ReadOnly = true;
        colsNumericUpDown.InterceptArrowKeys = false;
        levelsNumericUpDown.ReadOnly = true;
        levelsNumericUpDown.InterceptArrowKeys = false;

        _dungeon.Generate((int)levelsNumericUpDown.Value, (int)rowsNumericUpDown.Value, (int)colsNumericUpDown.Value);

        currentLevelNumericUpDown.Maximum = levelsNumericUpDown.Value;
        currentLevelNumericUpDown.Value = 1;
        buttonAdventure.Enabled = true;
        Invalidate(); // Redraw the form
    }

    private void CurrentLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        if (!_intialize)
        {
            _currentLevel = (int)currentLevelNumericUpDown.Value - 1;
            Invalidate(); // Redraw the form to show the new level
        }
    }

    private void ButtonAdventure_Click(object sender, EventArgs e)
    {
        timerDungeon.Start();
    }

    private void BtnPlayerData_Click(object sender, EventArgs e)
    {
        PlayerData playerDataform = new();
        playerDataform.Show();
    }

}
