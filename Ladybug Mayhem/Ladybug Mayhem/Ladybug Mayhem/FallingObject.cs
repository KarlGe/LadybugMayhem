using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ladybug_Mayhem
{
    class FallingObject : DrawObject
    {
        public bool falling;
        public int ySpeed;
        public int currentYPos { get; protected set; }
        private int prevYPos;
        public FallingObject(Game game, ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement, bool falling, int ySpeed)
            : base(game, content, receivedSprite, drawAmount, drawPlacement)
        {
            this.ySpeed = ySpeed;
            this.falling = falling;
            currentYPos = (int)drawPlacement.Y;
        }
        public void Update(GameTime gameTime)
        {
            if (falling) currentYPos += ySpeed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(drawPlacement.X, currentYPos), Color.White);

        }
    }
}

