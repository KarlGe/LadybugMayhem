using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Ladybug_Mayhem
{
    public class StartScreen
    {
        private int screenHeight;
        private int screenWidth;

        private Texture2D title;
        private Vector2 titleStartPos;
        private Vector2 titlePos;
        private Texture2D begin;
        private bool drawBeginText = false;
        private int opacity = 0;//Hvor gjennomsiktig "BEGIN!" teksten er

        public bool draw { get; protected set; }//Bestemmer om startskjermen skal tegnes
        public ContentManager content;
        public StartScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.content = content;
            initialize();
        }
        /// <summary>
        /// Laster inn tittel og begin tekst
        /// setter startposisjonen til tittel 
        /// kaller reset
        /// </summary>
        public void initialize()
        {
            title = content.Load<Texture2D>(@"StartScreen\gameTitle");
            begin = content.Load<Texture2D>(@"StartScreen\beginText");
            titleStartPos = new Vector2(screenWidth, screenHeight - title.Bounds.Height);
            reset();
        }
        //
        public void Update(GameTime gameTime)
        {
            
            if (opacity > 600) draw = false;
            else if (titlePos.X < 0 - title.Bounds.Width)
            {
                drawBeginText = true;
                draw = true;
                opacity += 10;
            }
            else titlePos.X -= 10;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (draw)
            {
                spriteBatch.Draw(title, titlePos, Color.White);
                if (drawBeginText) spriteBatch.Draw(begin, new Vector2(screenWidth / 2 - begin.Width / 2, screenHeight / 2 - begin.Height / 2), new Color(255, 255, 255, opacity));
            }
        }
        public void reset()
        {
            titlePos = new Vector2(titleStartPos.X, titleStartPos.Y);
            opacity = 0;
            draw = true;
        }
    }
}

