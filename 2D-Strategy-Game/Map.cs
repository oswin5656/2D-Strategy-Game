using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class Map
    {
        private Square[,] squares;
        private List<Unit> enemies;
        private int rows;
        private int cols;

        public Map(Square[,] squares, List<Unit> enemies, int rows, int cols)
        {
            this.squares = squares;
            this.enemies = enemies;
            this.rows = rows;
            this.cols = cols;
        }


        public Square Square(int row, int col) { return squares[row, col]; }



        public int Rows() { return rows; }

        public int Cols() { return cols; }

        public void Draw(GameTime gameTime)
        {
            foreach (Square s in squares)
            {
                s.Draw(gameTime);
            }

            foreach (Unit u in enemies)
            {
                u.Draw(gameTime);
            }
        }


        public override string ToString()
        {
            string str = "" + Rows() + "\n" + Cols();
            foreach (Square s in squares)
            {
                str += "\n" + s.ToString();
            }
            foreach (Unit u in enemies)
            {
                str += "\n" + u.ToString();
            }

            return str;
        }

        public void Load(string filename)
        {
            StreamReader stream = new StreamReader(filename);
            string line = stream.ReadLine();
            this.rows = int.Parse(line);
            line = stream.ReadLine();
            this.cols = int.Parse(line);
            this.squares = new Square[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    line = stream.ReadLine();
                    squares[i, j].Load(line);
                }
            }
        }
    }
}
