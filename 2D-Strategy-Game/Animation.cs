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
    class Animation // class for anything that needs to be drawn that moves, like unit sprites but not like the tiles. Also works for drawing text for menus.
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color, drawColor;
        protected Rectangle sourceRect;
        protected float rotation, scale;
        protected Vector2 origin, position;
        protected ContentManager content;
        protected bool isActive;
        protected float alpha;
        protected SpriteEffects effect;
        protected int frameCounter, switchFrame;
        protected Vector2 frames, currentFrame;
        

        public virtual int FrameWidth()
        {
            return sourceRect.Width;
        }

        public virtual int FrameHeight()
        {
            return sourceRect.Height;
        }

        public virtual float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public Color DrawColor
        {
            set { drawColor = value; }
        }
        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public float Scale
        {
            set { scale = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public virtual void LoadContent(ContentManager Content)
        {

        }
        public virtual void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image = image;
            this.text = text;
            this.position = position;
            drawColor = Color.White;
            if (text != String.Empty)
            {
                font = this.content.Load<SpriteFont>("Font1");
                color = new Color(114,77,255);
            }
            if (image != null)
                sourceRect = new Rectangle(0, 0, image.Width, image.Height);
            rotation = 0.0f;
            scale = alpha = 1.0f;
            isActive = false;
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            sourceRect = Rectangle.Empty;
            image = null;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            if (image != null)
            {
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
                spriteBatch.Draw(image, position + origin + offset, sourceRect, drawColor * alpha, rotation, origin, scale, effect, 0.0f);
            }
            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X /2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color * alpha, rotation, origin, scale, effect, 0.0f);
            }
        }
    }
}
