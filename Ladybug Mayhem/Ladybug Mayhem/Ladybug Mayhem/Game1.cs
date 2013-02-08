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

namespace Ladybug_Mayhem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Deklarerer nødvendige objekter.
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameOverScreen gameOverScreen;
        StartScreen startScreen;
        DrawBG backgroundScreen;
        LadybugAndGemLogic ladybugs;
        //Privat boolean for å holde styr på om spillet er over (vunnet eller tapt)
        private bool _gameOver = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = GlobalVars.SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = GlobalVars.SCREEN_WIDTH;
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            //Musepeker er synlig
            this.IsMouseVisible = true;
            //Musens status ligger i GlobalVars (der kan den hentes ut av alle)
            GlobalVars.MOUSE_STATE = Mouse.GetState();
            //Objektet som tegner bakgrunnen
            backgroundScreen = new DrawBG(this);
            //Objektet som tegner start-skjermen
            startScreen = new StartScreen(this, Content);
            //Objektet som tegner slutt-skjermen (vunnet eller tapt)
            gameOverScreen = new GameOverScreen(this);

            //Klassen som styrer hjerter og innbyggere, holder orden på om du taper
            LosingControl.Initialize(Content);
            //Objektet som styrer diamanter of marihøner, holder orden på om du vinner
            ladybugs = new LadybugAndGemLogic(this.Content, spriteBatch);

            //Er det objekter eller bare "vanlige" klasser som er riktig måte å lage kontroller-klasser (slik som over) på?
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _gameOver = GlobalVars.lives <= 0 || GlobalVars.gems >= GlobalVars.MAX_GEMS;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
            //Oppdaterer musens status GlobalVars
            GlobalVars.PREVIOUS_MOUSE_STATE = GlobalVars.MOUSE_STATE;
            GlobalVars.MOUSE_STATE = Mouse.GetState();
            //Starskjerm
            if(startScreen.draw) 
                startScreen.Update(gameTime);
            //SPILL!
            if (!startScreen.draw && !_gameOver)
            {
                LosingControl.Update(gameTime, Window);
                ladybugs.Update(gameTime);
            }
            //Sluttskjerm
            if (_gameOver) gameOverScreen.Update(gameTime);

            //Hvis man ønsker å spille igjen kalles "reset" funksjonen i hver av kontroller-klassene
            if (gameOverScreen.replay)
            {
                startScreen.reset();
                gameOverScreen.reset();
                LosingControl.Reset(Content);
                ladybugs.Reset();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Bakgrunnsfarge
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Start å tegne, sorter etter layerDepth (+ en BlendStat som fungerer)
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            //Bakgrunn
            backgroundScreen.Draw(spriteBatch);
            //Startskjerm
            if(startScreen.draw) startScreen.Draw(spriteBatch);
            //SPILL!
            if (!startScreen.draw && !_gameOver)
            {
                LosingControl.Draw(spriteBatch);
                ladybugs.Draw(spriteBatch);
            }
            //Sluttskjerm
            if (_gameOver) 
                gameOverScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
