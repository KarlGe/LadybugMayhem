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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameOverScreen gameOverScreen;
        StartScreen startScreen;
        DrawBG backgroundScreen;
        LadybugAndGemLogic ladybugs;
        private bool gameOver = false;
        int screenWidth;
        int screenHeight;

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
            // TODO: Add your initialization logic here
            base.Initialize();
            this.IsMouseVisible = true;
            screenHeight = Window.ClientBounds.Height;
            screenWidth = Window.ClientBounds.Width;
            GlobalVars.MOUSE_STATE = Mouse.GetState();
            backgroundScreen = new DrawBG(this);
            startScreen = new StartScreen(this, Content);
            gameOverScreen = new GameOverScreen(this);

            LosingControl.Initialize(Content);
            ladybugs = new LadybugAndGemLogic(this.Content, spriteBatch);
            base.Initialize(); 
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //font = Content.Load<SpriteFont>("TestFont");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            gameOver = GlobalVars.lives <= 0 || GlobalVars.gems >= GlobalVars.MAX_GEMS;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
            GlobalVars.PREVIOUS_MOUSE_STATE = GlobalVars.MOUSE_STATE;
            GlobalVars.MOUSE_STATE = Mouse.GetState();
            //Starskjerm
            if(startScreen.draw) 
                startScreen.Update(gameTime);
            //SPILL!
            if (!startScreen.draw && !gameOver)
            {
                LosingControl.Update(gameTime, Window);
                ladybugs.Update(gameTime);
            }
            //GameOver-skjerm
            if (gameOver) gameOverScreen.Update(gameTime);

            //Hvis man ønsker å spille igjen
            if (gameOverScreen.replay)
            {
                gameOverScreen.reset();
                LosingControl.Reset(Content);
                ladybugs.Reset();

                startScreen.reset();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            //Bakgrunn
            backgroundScreen.Draw(spriteBatch);
            //Startskjerm
            if(startScreen.draw) startScreen.Draw(spriteBatch);
            //SPILL!
            if (!startScreen.draw && !gameOver)
            {
                LosingControl.Draw(spriteBatch);
                ladybugs.Draw(spriteBatch);
            }
            //GameOver-skjerm
            if (gameOver) 
                gameOverScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
