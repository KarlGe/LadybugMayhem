using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Innlevering1_bakgrunn
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class DrawObject : Microsoft.Xna.Framework.GameComponent
    {

        private int windowHeight;
        private int windowWidth;
        private int drawAmount;
        private Texture2D sprite;
        private Vector2 drawPlacement;
        public int height{ get; private set;}
        public int width{ get; private set;}

        public DrawObject(Game game, ContentManager content, String receivedSprite, int drawAmount, Vector2 drawPlacement)
            : base(game)
        {
            // TODO: Construct any child components here
            sprite = content.Load<Texture2D>(receivedSprite);
            height = sprite.Bounds.Height;
            width = sprite.Bounds.Width;
            this.drawAmount = drawAmount;
            this.drawPlacement = drawPlacement;

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();

            //windowHeight = Window.ClientBounds.Height;
            //windowWidth = Window.ClientBounds.Width;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < drawAmount; i++)
            {
                spriteBatch.Draw(sprite, new Vector2(drawPlacement.X + (i * sprite.Bounds.Width), drawPlacement.Y), Color.White);
            }
            
        }
    }
}
