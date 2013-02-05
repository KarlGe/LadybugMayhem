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
        private int numObjectsToDraw = 0;
        private int delay = 10;
        private int currentDelay;
        private Texture2D title;
        private Texture2D begin;
        private Vector2 titleStartPos;
        private bool drawBegin = false;
        public bool draw{get; protected set;}
        private int opacity = 0;
        public StartScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            title = content.Load<Texture2D>(@"StartScreen\gameTitle");
            begin = content.Load<Texture2D>(@"StartScreen\beginText");
            titleStartPos = new Vector2(screenWidth, screenHeight - title.Bounds.Height);
            draw = true;
        }
        public void Update(GameTime gameTime)
        {
            titleStartPos.X -= 10;
            if (opacity > 600) draw = false;
            else if (titleStartPos.X < 0 - title.Bounds.Width)
            {
                drawBegin = true;
                draw = true;
                opacity += 10;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (draw)
            {
                spriteBatch.Draw(title, titleStartPos, Color.White);
                if (drawBegin) spriteBatch.Draw(begin, new Vector2(screenWidth / 2 - begin.Width / 2, screenHeight / 2 - begin.Height / 2), new Color(255, 255, 255, opacity));
            }
        }
    }
}

