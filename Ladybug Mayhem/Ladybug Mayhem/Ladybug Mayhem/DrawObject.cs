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
        private Texture2D sprite; // { get; protected set; }
        public Vector2 drawPlacement;
        public int drawAmount;
        public float zIndex;
        public int height{ get; private set;}
        public int width{ get; private set;}

        public DrawObject(Game game, ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement, float zIndex)

        {
            // TODO: Construct any child components here
            sprite = content.Load<Texture2D>(receivedSprite);
            height = sprite.Bounds.Height;
            width = sprite.Bounds.Width;
            this.drawPlacement = drawPlacement;
            this.drawAmount = drawAmount;
            this.zIndex = zIndex;
        }

            //windowHeight = Window.ClientBounds.Height;
            //windowWidth = Window.ClientBounds.Width;

        public Texture2D GetSprite()
        {
            return sprite;
        }

        public Vector2 GetPosition()
        {
            return drawPlacement;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < drawAmount; i++)
            {
                spriteBatch.Draw(sprite, new Vector2(drawPlacement.X + (i * sprite.Bounds.Width), drawPlacement.Y), null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);            }
            
        }
    }
}
