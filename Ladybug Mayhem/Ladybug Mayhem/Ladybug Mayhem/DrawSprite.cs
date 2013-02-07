using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Ladybug_Mayhem
{

    public class DrawSprite
    {
        private Texture2D sprite;
        public Rectangle position;
        public Rectangle source;
        private int drawAmount;
        private float zIndex;
        public int height{ get; private set;}
        public int width{ get; private set;}

        public DrawSprite(ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement, float zIndex)
        {
            // TODO: Construct any child components here
            sprite = content.Load<Texture2D>(receivedSprite);
            this.position = new Rectangle((int) drawPlacement.X, (int)drawPlacement.Y,sprite.Bounds.Width, sprite.Bounds.Height);
            this.drawAmount = drawAmount;
            this.zIndex = zIndex;
            source = sprite.Bounds;
        }
        public DrawSprite(ContentManager content, String receivedSprite, Vector2 drawPlacement, float zIndex)
                    :this(content, receivedSprite, 1, drawPlacement, zIndex)
        {}
        public DrawSprite(ContentManager content, String receivedSprite, Vector2 drawPlacement, Rectangle source, float zIndex)
                    :this(content, receivedSprite, 1, drawPlacement, zIndex)
        {
            this.source = source;
        }
        public DrawSprite(ContentManager content, String receivedSprite, Rectangle drawPlacement, Rectangle source, float zIndex)
            : this(content, receivedSprite, 1, new Vector2(drawPlacement.X, drawPlacement.Y), zIndex)
        {
            this.source = source;
            this.position = drawPlacement;
        }
        public int getHeight()
        {
            return (int)sprite.Bounds.Height;
        }
        public int getWidth()
        {
            return (int)sprite.Bounds.Width;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < drawAmount; i++)
            {
                spriteBatch.Draw(sprite, new Rectangle(position.X + (i * sprite.Bounds.Width), position.Y, position.Width, position.Height), source, Color.White, 0, Vector2.Zero, SpriteEffects.None, zIndex);            
            }
        }
    }
}
