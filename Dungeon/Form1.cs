namespace Dungeon;

public partial class Form1 : Form
{

    const int cXOffset = 100;
    const int cYOffset = 100;
    const int cRoomSize = 30;
    const int cHallwayWidth = 10;
    const int cHallwayLength = 10;
    const int cLairSize = 8;
    const int cMonsterSize = 8;
    const int cPlayerSize = 8;

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
            foreach (var room in level.Rooms.Values)
            {
                //room.Draw(e.Graphics);
                var g = e.Graphics;
                //if (!room.Mapped)
                //    continue;
                // Calculate position
                int x = cXOffset + ((cHallwayLength + cRoomSize) * room.Position.X);
                int y = cYOffset + ((cHallwayLength + cRoomSize) * room.Position.Y);

                // Draw room rectangle
                g.FillRectangle(Brushes.DarkKhaki, x, y, cRoomSize, cRoomSize);
                g.DrawRectangle(Pens.Black, x, y, cRoomSize, cRoomSize);

                // Draw hallways if present
                if (room.North)
                    g.FillRectangle(Brushes.Gray, x + (cRoomSize - cHallwayWidth) / 2, y - cHallwayLength / 2, cHallwayWidth, cHallwayLength / 2);
                if (room.South)
                    g.FillRectangle(Brushes.Gray, x + (cRoomSize - cHallwayWidth) / 2, y + cRoomSize, cHallwayWidth, cHallwayLength / 2);
                if (room.East)
                    g.FillRectangle(Brushes.Gray, x + cRoomSize, y + (cRoomSize - cHallwayWidth) / 2, cHallwayLength / 2, cHallwayWidth);
                if (room.West)
                    g.FillRectangle(Brushes.Gray, x - cHallwayLength / 2, y + (cRoomSize - cHallwayWidth) / 2, cHallwayLength / 2, cHallwayWidth);
                if (room.Up)
                    DrawStairsUp(g, Pens.Green, x, y, cRoomSize);
                if (room.Down)
                    DrawStairsDown(g, Pens.BlueViolet, x, y, cRoomSize);

                // Draw lair, monster, player as ovals
                if (room.Lair)
                    g.FillEllipse(Brushes.Purple, x + 2, y + 2, cLairSize, cLairSize);
                if (room.Monster)
                    g.FillEllipse(Brushes.Red, x + (cRoomSize - cMonsterSize), y + (cRoomSize - cMonsterSize), cMonsterSize, cMonsterSize);
                if (room.Player)
                    g.FillEllipse(Brushes.Blue, x + (cRoomSize - cPlayerSize) / 2, y + (cRoomSize - cPlayerSize) / 2, cPlayerSize, cPlayerSize);
            }
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
        timerDungeon.Enabled = !timerDungeon.Enabled;
        //timerDungeon.Start();
    }

    private void BtnPlayerData_Click(object sender, EventArgs e)
    {
        PlayerData playerDataform = new();
        playerDataform.Show();
    }
    private static void DrawStairsUp(Graphics g, Pen pen, int x, int y, int size)
    {
        const int margin = 4;
        const int steps = 5;

        int leftX = x + margin;
        int rightX = x + size - margin;
        int topY = y + margin;
        int bottomY = y + size - margin;

        // Bottom landing
        g.DrawLine(pen, leftX, bottomY, rightX, bottomY);

        // --- removed the left wall here! ---

        float span = (rightX - leftX) * 0.92f;
        float startX = leftX + (rightX - leftX - span) / 2f;
        float spacing = span / (steps + 1);

        float maxHeight = (bottomY - topY) * 0.85f;

        for (int i = 0; i < steps; i++)
        {
            float sx = startX + spacing * (i + 1);
            float height = maxHeight * (i + 1) / (float)(steps + 1);

            float sy1 = bottomY;
            float sy2 = bottomY - height;

            g.DrawLine(pen, sx, sy1, sx, sy2);
            g.DrawLine(pen, sx, sy2, sx + 3, sy2);
        }
    }

    private static void DrawStairsDown(Graphics g, Pen pen, int x, int y, int size)
    {
        const int margin = 4;
        const int steps = 5;

        int leftX = x + margin;
        int rightX = x + size - margin - 2;   // slight inset for breathing room
        int topY = y + margin;
        int bottomY = y + size - margin;

        // Top landing
        g.DrawLine(pen, leftX, topY, rightX, topY);

        // Keep steps well spaced and centered
        float span = (rightX - leftX) * 0.92f;
        float startX = leftX + (rightX - leftX - span) / 2f;
        float stepSpacing = span / (steps + 1);

        // Max depth (reduced slightly for cleaner shape)
        float maxDepth = (bottomY - topY) * 0.85f;

        for (int i = 0; i < steps; i++)
        {
            float sx = startX + stepSpacing * (i + 1);
            float depth = maxDepth * (i + 1) / (steps + 1);

            float sy1 = topY;
            float sy2 = topY + depth;

            // Vertical step
            g.DrawLine(pen, sx, sy1, sx, sy2);

            // Short bottom cap
            g.DrawLine(pen, sx, sy2, sx + 3, sy2);
        }

        // Right-side wall
        g.DrawLine(pen, rightX, topY, rightX, bottomY);
    }

}
