﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinDungeon.Constants;

namespace WinDungeon
{
    public partial class Form1 : Form
    {
        Dungeon _dungeon = new Dungeon();
        bool _intialize = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            _intialize = false;
        }

        private void timerDungeon_Tick(object sender, EventArgs e)
        {
            timerDungeon.Enabled = false;
            _dungeon.MoveMonsters();
            _dungeon.MovePlayer();
            if (_dungeon.Player.Location.Level+1 != (int) currentLevelNumericUpDown.Value)
            {
                currentLevelNumericUpDown.Value = _dungeon.Player.Location.Level+1;
            }

            timerDungeon.Enabled = true;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            buttonGenerate.Enabled = false;

            rowsNumericUpDown.ReadOnly = true;
            rowsNumericUpDown.InterceptArrowKeys = false;
            colsNumericUpDown.ReadOnly = true;
            colsNumericUpDown.InterceptArrowKeys = false;
            levelsNumericUpDown.ReadOnly = true;
            levelsNumericUpDown.InterceptArrowKeys = false;

            _dungeon.Generate(this, (int)levelsNumericUpDown.Value, (int)rowsNumericUpDown.Value, (int)colsNumericUpDown.Value);

            currentLevelNumericUpDown.Maximum = levelsNumericUpDown.Value;
            currentLevelNumericUpDown.Value = 1;
            buttonAdventure.Enabled = true;
        }

        private void currentLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_intialize)
            {
                foreach(var level in _dungeon.Levels.Values)
                {
                    level.ShapeContainer.Visible = false;
                }
                _dungeon.Levels[(int)currentLevelNumericUpDown.Value - 1].ShapeContainer.Visible = true;
            }
        }

        private void buttonAdventure_Click(object sender, EventArgs e)
        {
            timerDungeon.Start();
        }

        private void btnPlayerData_Click(object sender, EventArgs e)
        {
            PlayerData playerDataform = new PlayerData();
            playerDataform.Show();
        }
    }
}
