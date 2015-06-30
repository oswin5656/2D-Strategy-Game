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


        public Square Location() { return location; }
        public void SetLocation(Square location) { this.location = location; }


        public void Draw(SpriteBatch spriteBatch)
        {

        }


        public void Update(GameTime gameTime)
        {

        }


        public void LoadContent(ContentManager content)
        {

        }

        public override string ToString()
        {
            return "";
        }
    }
}
