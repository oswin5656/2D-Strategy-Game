using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * This class holds important data about the state of the game
 * 
 * */

namespace _2D_Strategy_Game
{
    class GameData
    {
        private Map map; // the current map
        private Vector2 cursor; // represents where the cursor is at
        Square selected; // the square which the cursor is over
        InputManager input; // manages input
        private Vector2 screenDimensions; // dimensions of the screen
        private List<Unit> playerUnits;

        public void Initialize()
        {
            map = (MapGenerator.GeneratePlainMap(15, 15));
            map.AddUnit(new Unit());
            map.Unit(0).SetLocation(map.Square(0, 0));
            cursor = new Vector2(0, 0);
            selected = map.Square((int)cursor.Y, (int)cursor.X);
            input = new InputManager();
            screenDimensions = new Vector2(1000, 500);
        }

        public Vector2 ScreenDimensions() { return screenDimensions; }

        public void Draw(SpriteBatch spriteBatch) 
        {
            map.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime) 
        {
            input.Update();

            selected.Deselect(); // deselect previously selected square
            selected = map.Square((int)cursor.Y, (int)cursor.X); 
            selected.Select();  // reset the selected square to the one which the cursor is over
                                   // note that if the cursor doesn't move, it just deselects and selects the same square.
            updateOffset();
            MapInput();
            map.Update(gameTime);  //calls the map to update
            
        }

        public Map Map() { return this.map; }

        public void SetMap(Map map)  // method to set the current map
        {
            this.map = map;
        }

        public void LoadContent(ContentManager content)
        {
            map.LoadContent(content);
        }

        private void MapInput() // helper function for keyboard input on the map. Here to keep update method cleaner.
        {
            if(input.KeyPressed(Keys.W) && (int)cursor.Y != 0)
            {
                cursor.Y -= 1;
            }
            if (input.KeyPressed(Keys.S) && (int)cursor.Y != map.Rows()-1)
            {
                cursor.Y += 1;
            }
            if (input.KeyPressed(Keys.A) && (int)cursor.X != 0)
            {
                cursor.X -= 1;
            }
            if (input.KeyPressed(Keys.D) && (int)cursor.X != map.Cols()-1)
            {
                cursor.X += 1;
            }
        }

        private void updateOffset() //checks if cursor is closer than three squares from edge and changes the offset if it is
        {
            if(cursor.X * Square.SQUARE_SIZE + map.Offset().X < 3 * Square.SQUARE_SIZE)
            {
                map.SetOffset(new Vector2(map.Offset().X + Square.SQUARE_SIZE, map.Offset().Y));
            }
            else if(cursor.X *Square.SQUARE_SIZE + map.Offset().X > screenDimensions.X - (3*Square.SQUARE_SIZE))
            {
                map.SetOffset(new Vector2(-Square.SQUARE_SIZE + map.Offset().X, map.Offset().Y));
            }
            if (cursor.Y * Square.SQUARE_SIZE + map.Offset().Y < 3 * Square.SQUARE_SIZE)
            {
                map.SetOffset(new Vector2(map.Offset().X, Square.SQUARE_SIZE + map.Offset().Y));
            }
            else if (cursor.Y * Square.SQUARE_SIZE + map.Offset().Y > screenDimensions.Y - (3 * Square.SQUARE_SIZE))
            {
                map.SetOffset(new Vector2(map.Offset().X, -Square.SQUARE_SIZE + map.Offset().Y));
            }  
        }
    
    }
}
