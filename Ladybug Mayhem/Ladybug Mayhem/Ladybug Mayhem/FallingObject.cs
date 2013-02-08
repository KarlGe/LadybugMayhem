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
        private DrawSprite sprite;
        public int height { get; protected set; }
        public int width { get; protected set; }
        private Vector2 drawPlacement;
        /// <summary>
        /// Setter opp dataene som trengs for å tegne en bokstav som faller
        /// </summary>
        /// <param name="content">Contentmanager</param>
        /// <param name="receivedSprite">Navn på filen som skal tegnes</param>
        /// <param name="drawPlacement">Hvor teksturen skal tegnes</param>
        /// <param name="falling">Hvorvidt bokstaven skal "falle" eller ikke</param>
        /// <param name="ySpeed">Hvor raskt bokstaven skal falle</param>
        public FallingObject(ContentManager content, String receivedSprite, Vector2 drawPlacement, bool falling, int ySpeed)
        {
            this.ySpeed = ySpeed;
            this.falling = falling;
            sprite = new DrawSprite(content, receivedSprite, drawPlacement, 1);
            this.drawPlacement = drawPlacement;
        }
        /// <summary>
        /// Øker posisjonen langs x-aksen så lenge falling = true
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (sprite.position.Y > GlobalVars.GROUND_Y_POS) falling = false;
            if (falling) sprite.position.Y += ySpeed;
        }
        /// <summary>
        /// Setter tilbake sprite for å kunne falle igjen
        /// </summary>
        /// <param name="yPos">Hvor på Y-aksen bokstaven skal settes</param>
        public void reset(int yPos)
        {
            sprite.position.Y = yPos;
            falling = true;
        }
        /// <summary>
        /// Tegner teksturen
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}

