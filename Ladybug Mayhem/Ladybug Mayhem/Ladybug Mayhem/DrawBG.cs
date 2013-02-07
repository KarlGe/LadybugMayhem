using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace Ladybug_Mayhem
{
    public class DrawBG
    {
        private int windowHeight;
        private int windowWidth;
        private DrawSprite[] textures = new DrawSprite[14];
        private SpriteBatch spriteBatch;
        private int baseXPos = 0;
        private int baseYPos = 93;
        private Texture2D checkTexture;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch)

        {
            this.windowHeight = GlobalVars.SCREEN_HEIGHT;
            this.windowWidth = GlobalVars.SCREEN_WIDTH;
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here

            checkTexture = content.Load<Texture2D>("Roof North West");
            textures[0] = new DrawSprite(content, "Roof North West", 1, new Vector2(baseXPos, baseYPos-(checkTexture.Bounds.Height / 2)), 0.1f);
            textures[1] = new DrawSprite(content, "Roof North", 5, new Vector2(baseXPos + textures[0].getWidth(), textures[0].position.Y), 0f);
            textures[2] = new DrawSprite(content, "Roof North East", 1, new Vector2(textures[1].position.X + (textures[1].getWidth() * 5), textures[0].position.Y), 0f);
            textures[3] = new DrawSprite(content, "Roof West", 1, new Vector2(baseXPos, textures[1].position.Y + textures[1].getHeight() - 87), 0.2f);
            GlobalVars.FIRST_BROWN_BLOCK_POS = new Vector2(baseXPos + textures[3].getWidth(), textures[3].position.Y);
            textures[4] = new DrawSprite(content, "Brown Block", 4, GlobalVars.FIRST_BROWN_BLOCK_POS, 0.2f);
            textures[5] = new DrawSprite(content, "Roof North2", 1, new Vector2(textures[4].position.X + textures[4].getWidth() * 4, textures[1].position.Y + 43), 0.2f);
            textures[6] = new DrawSprite(content, "Roof East", 1, new Vector2(textures[4].position.X + textures[3].getWidth() * 5, textures[3].position.Y), 0.1f);
            textures[7] = new DrawSprite(content, "Roof South West", 1, new Vector2(baseXPos, textures[3].position.Y + (textures[3].getHeight() / 2)), 0.3f);
            textures[8] = new DrawSprite(content, "Roof South", 4, new Vector2(baseXPos + textures[7].getWidth(), textures[7].position.Y), 0.3f);
            GlobalVars.WINDOW_POS = new Vector2(textures[8].position.X + textures[8].getWidth() * 4, textures[7].position.Y);
            textures[9] = new DrawSprite(content, "Window Tall", 1, GlobalVars.WINDOW_POS, 0.25f);
            textures[10] = new DrawSprite(content, "Roof South East", 1, new Vector2(textures[9].position.X + textures[9].getWidth(), textures[7].position.Y), 0.3f);
            textures[11] = new DrawSprite(content, "Wall Block Tall", 7, new Vector2(baseXPos, textures[7].position.Y + (textures[7].getHeight() / 2)), 0.1f);
            textures[12] = new DrawSprite(content, "Door Tall Closed", 1, new Vector2(baseXPos + textures[11].getWidth() * 5, textures[7].position.Y + (textures[9].getHeight() / 1.6f)), 0.15f);
           
            checkTexture = content.Load<Texture2D>("Stone Block");
            textures[13] = new DrawSprite(content, "Stone Block", 7, new Vector2(baseXPos, textures[10].position.Y + textures[11].getHeight() + 31), 0f);
            GlobalVars.GROUND_Y_POS = (int) textures[13].position.Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(DrawSprite obj in textures) obj.Draw(spriteBatch);
        }
    }
}
