using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class Square
    {
        public static int SQUARE_SIZE = 50;
        

        private int row, col;
        private string terrain;
        private bool passable;
        private int moveCost;
        private Texture2D image;  //the image that will be drawn for the square
        private Vector2 position; // the position in pixels of the top right corner of the square - equal to (row * SQUARE_SIZE, col * SQUARE_SIZE) 
        private bool selected;    // represents if the cursor is over this square
        private Map map;
        private List<Square> sPath; // used for movement calculation
        private int distanceFrom;  // used for movement calculation
        private Color color;
        private Unit occupant;

        public Square(int row, int col, string terrain)
        {
            this.row = row;
            this.col = col;
            this.terrain = terrain;
            switch (terrain)
            {
                case "plains":
                    passable = true;
                    moveCost = 2;
                    break;
                case "forest":
                    passable = true;
                    moveCost = 4;
                    break;
                case "hills":
                    passable = true;
                    moveCost = 5;
                    break;
                case "mountain":
                    passable = true;
                    moveCost = 20;
                    break;
            }
            selected = false;
            position = new Vector2(col * SQUARE_SIZE, row * SQUARE_SIZE); //example - the square in row 2 column 1 has position (25,50) in pixels if Square size is 25 pixels
        }
        public int DistanceFrom() { return distanceFrom; }
        public void SetDistanceFrom(int distance) { this.distanceFrom = distance; }
        public void SetOccupant(Unit u) { this.occupant = u;}
        public Unit Occupant() { return occupant; }
        public List<Square> SPath() { return sPath; }
        public void SetSPath(List<Square> sPath) { this.sPath = sPath; }
        public int Row() { return row; }
        public int Col() { return col; }
        public Map Map(){return map;}
        public int MoveCost() { return moveCost; }
        public void SetMap (Map map) { this.map = map;}
        public Vector2 Position() { return position; }
        public void SetColor(Color c){color = c;}

        public void Select() { selected = true; }
        public void Deselect() { selected = false; }
        
        public List<Square> AdjacentSquares()
        {
            List<Square> adjSquares = new List<Square>();
            if (row > 0) adjSquares.Add(map.Square(row - 1, col));
            if (col > 0) adjSquares.Add(map.Square(row, col - 1));
            if (row < map.Rows() - 1) adjSquares.Add(map.Square(row + 1, col));
            if (col < map.Cols() - 1) adjSquares.Add(map.Square(row, col + 1));

            return adjSquares;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            if (selected)   // changes draw color if square is highlighted
            {
                spriteBatch.Draw(image, position + offset, Color.Orange);
            }
            else
            {
                spriteBatch.Draw(image, position + offset, color);
            }
        }

        public void Load(string line)  // this method loads a square from string, generally a line from a text file passed into map.Load()
        {
            string[] data = line.Split(' ');
            row = int.Parse(data[0]);
            col = int.Parse(data[1]);
            terrain = data[2];
            switch (terrain)
            {
                case "plains":
                    passable = true;
                    moveCost = 2;
                    break;
                case "forest":
                    passable = true;
                    moveCost = 4;
                    break;
                case "hills":
                    passable = true;
                    moveCost = 5;
                    break;
                case "mountain":
                    passable = true;
                    moveCost = 20;
                    break;
            }

            //passable = bool.Parse(data[3]);
            //moveCost = int.Parse(data[4]);
            selected = false;

        }

        public void LoadContent(ContentManager content)  //this method loads the pixel art image that will be drawn
        {
             image = content.Load<Texture2D>(terrain);
             sPath = new List<Square>();
             color = Color.White;
             
        }

        public override string ToString()  //writes square to a string. Important if we want to save or create maps in game.
        {
            return "" + row + " " + col + " " + terrain; // +" " + passable + " " + moveCost;
        }
    }
}
