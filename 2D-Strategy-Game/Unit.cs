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

        public Square Location() { return location; }
        public void SetLocation(Square location) { this.location = location; }


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
        }

        public override string ToString()
        {
            return "";
        }

        
    }
}
