using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class Map
    {
        private Square[,] squares; // 2d array of squares, the most important piece of the map
        private List<Unit> enemies; //the list of enemies on the map
        private List<Unit> units; // list of your units on map
        private int rows; //hieght of map in # of squares
        private int cols; //width of map in # of squares
        private Vector2 offset; //allows view of map to follow cursor
        


        /* constructor - note that we probably won't use this one much in the final game.
         * Rather, we will usually use the default constructor (which initializes all the variables as nulls)
         * and then use the Load method to get all the info from a text file
         * */
        public Map(Square[,] squares, List<Unit> enemies, int rows, int cols) 
        {                                                                      
            this.squares = squares;                                           
            this.enemies = enemies;
            this.rows = rows;
            this.cols = cols;
            this.offset = Vector2.Zero;
            this.units = new List<Unit>();
        }

        public void AddUnit(Unit unit) { units.Add(unit); }
        public Unit Unit(int index) { return units[index]; }
        public Square Square(int row, int col) { return squares[row, col]; }
        public Square[,] Squares() { return squares; }
        public Vector2 Offset() { return offset; }
        public void SetOffset(Vector2 offset) { this.offset = offset; }
        
        public int Rows() { return rows; }

        public int Cols() { return cols; }

        public void Draw(SpriteBatch spriteBatch) //map draw method. Draws all squares and then all units on top of them
        {
            foreach (Square s in squares)
            {
                s.Draw(spriteBatch, offset);
            }

            foreach (Unit u in enemies)
            {
                u.Draw(spriteBatch, offset);
            }

            foreach (Unit u in units)
            {
                u.Draw(spriteBatch, offset);
            }
        }

        public void LoadContent(ContentManager content) //Load the content for all the squares and enemies in the map
        {
            foreach(Square s in squares)
            {
                s.LoadContent(content);
                s.SetMap(this);
            }
            foreach(Unit u in units)
            {
                u.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Unit u in units)
            {
                u.Update(gameTime);
            }
        }

        public override string ToString() //puts all the info from the map into a string, useful for writing a map to a text file.
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

      

        public void Load(string filename) //reads all the info for a map from a text file.
        {
            StreamReader stream = new StreamReader(filename);
            string line = stream.ReadLine();
            this.rows = int.Parse(line); // first line is the # of rows
            line = stream.ReadLine();
            this.cols = int.Parse(line); // second line is the # of columns
            this.squares = new Square[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)  // rest of the lines are each one square
                {
                    line = stream.ReadLine();
                    squares[i, j].Load(line);
                }
            }
        }
    }
}
