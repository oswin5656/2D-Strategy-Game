using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2D_Strategy_Game
{
    class GameData
    {
        private Map map;

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
        }

        public Map Map() { return this.map; }

        public void SetMap(Map map)
        {
            this.map = map;
        }
    }
}
