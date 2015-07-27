using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace _2D_Strategy_Game
{
    class MoveUnitAnimation : Animation
    {
        List<Square> path;
        public MoveUnitAnimation(List<Square> path)
        {
            this.path = path;
        }

        public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            base.LoadContent(Content, image, text, position);
            frameCounter = 0;
            switchFrame = 300;
            currentFrame = new Vector2(0, 0);
            frames = new Vector2(1, 0);
            sourceRect = new Rectangle(0, 0, Square.SQUARE_SIZE, Square.SQUARE_SIZE);
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (frameCounter >= switchFrame)
                {
                    frameCounter = 0;
                    currentFrame.X++;

                    if (currentFrame.X > frames.X)
                        currentFrame.X = 0;
                }
            }
            else
            {
                frameCounter = 0;
                currentFrame.X = 0;
            }
            sourceRect = new Rectangle((int)currentFrame.X * Square.SQUARE_SIZE, (int)currentFrame.Y * Square.SQUARE_SIZE, Square.SQUARE_SIZE, Square.SQUARE_SIZE);
        }
    }
}
