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
        public int height { get; private set; }
        public int width { get; private set; }

        /// <summary>
        /// Tar imot parametre og gjør klar informasjonen som trengs for å tegne spriten
        /// </summary>
        /// <param name="content">Contentmanager</param>
        /// <param name="receivedSprite">Navnet på filen som skal tegnes</param>
        /// <param name="drawAmount">Hvor mange ganger teksturen skal tegnes bortover</param>
        /// <param name="drawPlacement">Hvor teksturen skal tegnes</param>
        /// <param name="zIndex">Hvilken dybde teksturen skal ha på skjermen</param>
        public DrawSprite(ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement, float zIndex)
        {
            sprite = content.Load<Texture2D>(receivedSprite);
            this.width = sprite.Bounds.Width;
            this.height = sprite.Bounds.Height;
            this.position = new Rectangle((int)drawPlacement.X, (int)drawPlacement.Y, width, height);
            this.drawAmount = drawAmount;
            this.zIndex = zIndex;
            source = sprite.Bounds;
        }
        /// <summary>
        /// Tar ikke imot hvor mange ganger man skal tegne teksturen.
        /// Sender dataene videre til den øverste konstruktøren
        /// </summary>
        public DrawSprite(ContentManager content, String receivedSprite, Vector2 drawPlacement, float zIndex)
            : this(content, receivedSprite, 1, drawPlacement, zIndex)
        { }
        /// <summary>
        /// Tar imot source som rectangle, men ikke hvor mange ganger teksturen skal tegnes.
        /// Sender data til øverste konstruktør og setter source selv
        /// </summary>
        /// <param name="source">Utsnitt av teksturen som skal tegnes</param>
        public DrawSprite(ContentManager content, String receivedSprite, Vector2 drawPlacement, Rectangle source, float zIndex)
            : this(content, receivedSprite, 1, drawPlacement, zIndex)
        {
            this.source = source;
        }
        /// <summary>
        /// Tar imot posisjonen til teksturen som rectangle istedenfor point
        /// Sender til konstruktøren over, som sender videre, og setter position selv.
        /// </summary>
        public DrawSprite(ContentManager content, String receivedSprite, Rectangle drawPlacement, Rectangle source, float zIndex)
            : this(content, receivedSprite, new Vector2(drawPlacement.X, drawPlacement.Y), source, zIndex)
        {
            this.position = drawPlacement;
        }
        /// <summary>
        /// Tar imot en ekstra boolean som sier at man skal plassere
        /// </summary>
        /// <param name="content"></param>
        /// <param name="receivedSprite"></param>
        /// <param name="set"></param>
        /// <param name="zIndex"></param>
        public void placeInMidOfScreen(){
            position.X = GlobalVars.SCREEN_WIDTH / 2 - sprite.Width / 2;
            position.Y = GlobalVars.SCREEN_HEIGHT / 2 - sprite.Height / 2;
        }
        /// <summary>
        /// Tegner teksturen antall ganger som er spesifisert i drawAmount
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < drawAmount; i++)
            {
                spriteBatch.Draw(sprite, new Rectangle(position.X + (i * sprite.Bounds.Width), position.Y, position.Width, position.Height), source, Color.White, 0, Vector2.Zero, SpriteEffects.None, zIndex);
            }
        }
    }
}
