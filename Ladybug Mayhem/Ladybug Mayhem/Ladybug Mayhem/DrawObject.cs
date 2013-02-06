using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Ladybug_Mayhem
{
    public class DrawObject
    {
        private int windowHeight;
        private int windowWidth;
        public Texture2D sprite { get; protected set; }
        public Vector2 drawPlacement;
        public int drawAmount;
        public int height { get; private set; }
        public int width { get; private set; }

        public DrawObject(Game game, ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement)
        {
            sprite = content.Load<Texture2D>(receivedSprite);
            height = sprite.Bounds.Height;
            width = sprite.Bounds.Width;
            this.drawPlacement = drawPlacement;
            this.drawAmount = drawAmount;
        }
        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < drawAmount; i++)
            {
                spriteBatch.Draw(sprite, new Vector2(drawPlacement.X + (i * sprite.Bounds.Width), drawPlacement.Y), Color.White);
            }
        }
    }
}

