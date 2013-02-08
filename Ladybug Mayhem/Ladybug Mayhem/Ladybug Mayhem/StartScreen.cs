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

        private DrawSprite title;
        private Vector2 titleStartPos;
        private Vector2 titlePos;
        private DrawSprite begin;
        Game game;
        private bool drawBeginText = false;
        private int opacity = 0;//Hvor gjennomsiktig "BEGIN!" teksten er

        public bool draw { get; protected set; }//Bestemmer om startskjermen skal tegnes
        public ContentManager content;
        public StartScreen(Game game, ContentManager content)
        {
            screenHeight = GlobalVars.SCREEN_HEIGHT;
            screenWidth = GlobalVars.SCREEN_WIDTH;
            this.game = game;
            initialize();
        }
        /// <summary>
        /// Laster inn tittel og begin tekst
        /// setter startposisjonen til tittel 
        /// kaller reset
        /// </summary>
        public void initialize()
        {
            titleStartPos = new Vector2(screenWidth, GlobalVars.GROUND_Y_POS);
            title = new DrawSprite(game.Content, @"StartScreen\gameTitle", titleStartPos, 1);
            begin = new DrawSprite(game.Content, @"StartScreen\beginText", Vector2.Zero, 1);
            begin.placeInMidOfScreen();
            reset();
        }
        /// <summary>
        /// flytter tittelen fra høyre til venstre, hvis den har gått ut av bildet 
        /// tegner den "Begin!" teksten, hvis tallet som skal holde oversikten over 
        /// gjennomsiktigheten til denne kommer over 600 (ca. 10 sekunder etter at 
        /// tittelen kommer på skjermen, slutter den å tegne seg selv.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (opacity > 600) draw = false;
            else if (title.position.X < 0 - title.width)
            {
                drawBeginText = true;
                draw = true;
                opacity += 10;
            }
            else title.position.X -= 10;   
        }
        public void Draw(SpriteBatch spriteBatch)
        {
                title.Draw(spriteBatch);
                if (drawBeginText) begin.Draw(spriteBatch);
        }
        /// <summary>
        /// Setter tilbake nødvendige variabler for å kjøre på nytt
        /// </summary>
        public void reset()
        {
            titlePos = new Vector2(titleStartPos.X, titleStartPos.Y);
            opacity = 0;
            draw = true;
        }
    }
}

