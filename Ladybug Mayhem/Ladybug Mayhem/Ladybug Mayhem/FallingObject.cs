using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ladybug_Mayhem
{
    class FallingObject
    {
        public bool falling;
        public int ySpeed;
        public int currentYPos { get; set; }
        private int prevYPos;
        private Texture2D sprite;
        public int height { get; protected set; }
        public int width { get; protected set; }
        private Vector2 drawPlacement;
        public FallingObject(Game game, ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement, bool falling, int ySpeed)
        {
            this.ySpeed = ySpeed;
            this.falling = falling;
            currentYPos = (int)drawPlacement.Y;
            sprite = content.Load<Texture2D>(receivedSprite);
            height = sprite.Bounds.Height;
            width = sprite.Bounds.Width;
            this.drawPlacement = drawPlacement;
        }
        public void Update(GameTime gameTime)
        {
            if (falling) currentYPos += ySpeed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(drawPlacement.X, currentYPos), Color.White);

        }
    }
}

