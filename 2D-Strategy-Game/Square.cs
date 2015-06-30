using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class Square
    {
        public static int SQUARE_SIZE = 20;

        private int row, col;
        private string terrain;
        private bool passable;
        private int moveCost;

        public Square(int row, int col, string terrain, bool passable, int moveCost)
        {
            this.row = row;
            this.col = col;
            this.terrain = terrain;
            this.passable = passable;
            this.moveCost = moveCost;
        }

        public int Row() { return row; }
        public int Col() { return col; }

        public int x()
        {
            return col * SQUARE_SIZE;
        }

        public int y()
        {
            return row * SQUARE_SIZE;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Load(string line)
        {
            string[] data = line.Split(' ');
            row = int.Parse(data[0]);
            col = int.Parse(data[1]);
            terrain = data[2];
            passable = bool.Parse(data[3]);
            moveCost = int.Parse(data[4]);
        }

        public override string ToString()
        {
            return "" + row + " " + col + " " + terrain + " " + passable + " " + moveCost;
        }
    }
}
