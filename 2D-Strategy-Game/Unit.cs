using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class Unit
    {
        private Square location;
        private bool selected;
        private Animation animation;
        private List<Square> inMoveRange;

        private int movement;
        private int strength;
        private int hp;

        public Unit()
        {
            movement = 15;
        }

        public List<Square> InMoveRange() { return inMoveRange; }
        public Square Location() { return location; }
        public void SetLocation(Square location)  // for setting initial position
        {
            if(this.location != null) this.location.SetOccupant(null);
            this.location = location;
            location.SetOccupant(this);
        }

        public void MoveTo(Square location) // for moving in game
        {
            if(this.location != null) this.location.SetOccupant(null);
            this.location = location;
            location.SetOccupant(this);

            animation.Position = location.Position();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            animation.Draw(spriteBatch, offset);
        }


        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }


        public void LoadContent(ContentManager content)
        {
            Texture2D image = content.Load<Texture2D>("Unit_Idle");
            this.animation = new IdleUnitAnimation();
            animation.LoadContent(content, image, String.Empty, location.Position());
            animation.IsActive = true;
            inMoveRange = new List<Square>();
        }

        public override string ToString()
        {
            return "";
        }

        public void Select()
        {
            SetMoveRange();
            foreach (Square s in inMoveRange)
            {
                s.SetColor(Color.Blue);
            }
        }

        public void Deselect()
        {
            foreach (Square s in inMoveRange)
            {
                s.SetColor(Color.White);
            }
        }

        private void Attack(Unit other) 
        {
            other.hp = other.hp - this.strength;
        }


        /* this method finds all squares in move range and also sets their shortest paths.
         * Shortest paths are reset in GameData.deselectUnit() when the unit is deselected.
         * */
        private void SetMoveRange()
        {
            Square current;
            List<Square> squares = new List<Square>();
            foreach(Square s in location.Map().Squares())
            {
                squares.Add(s);
            }


            List<Square> complete = new List<Square>();
            foreach (Square s in this.location.Map().Squares())
            {
                s.SetDistanceFrom(999);
            }

            this.location.SetDistanceFrom(0);

            while (true)
            {
                current = minDistance(squares);
                if (current.DistanceFrom() > movement) break;
                complete.Add(current);
                squares.Remove(current);
                foreach(Square s in current.AdjacentSquares()) //for each adjacent square
                {
                    if (squares.Contains(s))
                    {
                        if (current.DistanceFrom() + s.MoveCost() < s.DistanceFrom()) //if new path is smaller
                        {
                            s.SetDistanceFrom(current.DistanceFrom() + s.MoveCost()); // set new shorter distance
                            foreach(Square sp in current.SPath())
                            {
                                s.SPath().Add(sp);
                            }
                            s.SPath().Add(current);
                        }
                    }
                }
            }
            inMoveRange = complete;
        } 

        private Square minDistance(List<Square> squares)
        {
            int index = 0;
            int smallest = squares[0].DistanceFrom();
            for (int i = 0; i < squares.Count; i++)
            {
                if (squares[i].DistanceFrom() < smallest)
                {
                    smallest = squares[i].DistanceFrom();
                    index = i;
                }   
            }
            return squares[index];
        }
    }
}
