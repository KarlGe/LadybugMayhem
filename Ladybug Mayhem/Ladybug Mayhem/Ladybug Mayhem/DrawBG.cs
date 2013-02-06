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
        private DrawObject[] textures = new DrawObject[14];
        private SpriteBatch spriteBatch;
        private int baseXPos = 0;
        private int baseYPos = 0;
        private Texture2D checkTexture;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch, int windowHeight, int windowWidth)

        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here

            checkTexture = content.Load<Texture2D>("Roof North West");
            textures[0] = new DrawObject(game, content, "Roof North West", 1, new Vector2(baseXPos, baseYPos-(checkTexture.Bounds.Height / 2)), 1f);
            textures[1] = new DrawObject(game, content, "Roof North", 5, new Vector2(baseXPos + textures[0].GetSprite().Bounds.Width, textures[0].GetPosition().Y), 0f);
            textures[2] = new DrawObject(game, content, "Roof North East", 1, new Vector2
                (textures[1].GetPosition().X + (textures[1].width * 5), textures[0].GetPosition().Y), 0f);
            textures[3] = new DrawObject(game, content, "Roof West", 1, new Vector2(baseXPos, textures[1].GetPosition().Y + textures[1].GetSprite().Bounds.Height - 87), 1f);
            textures[4] = new DrawObject(game, content, "Brown Block", 4, new Vector2(baseXPos + textures[3].GetSprite().Bounds.Width, textures[3].GetPosition().Y), 1f);
            textures[5] = new DrawObject(game, content, "Roof North2", 1, new Vector2(textures[4].GetPosition().X + textures[4].GetSprite().Bounds.Width * 4, textures[1].GetPosition().Y + 43), 0.7f);
            textures[6] = new DrawObject(game, content, "Roof East", 1, new Vector2(textures[4].GetPosition().X + textures[3].GetSprite().Bounds.Width * 5, textures[3].GetPosition().Y), 0.5f);
            textures[7] = new DrawObject(game, content, "Roof South West", 1, new Vector2(baseXPos, textures[3].GetPosition().Y + (textures[3].GetSprite().Bounds.Height / 2)), 1f);
            textures[8] = new DrawObject(game, content, "Roof South", 4, new Vector2(baseXPos + textures[7].GetSprite().Bounds.Width, textures[7].GetPosition().Y), 1f);
            textures[9] = new DrawObject(game, content, "Window Tall", 1, new Vector2(textures[8].GetPosition().X + textures[8].GetSprite().Bounds.Width * 4, textures[7].GetPosition().Y), 0.7f);
            textures[10] = new DrawObject(game, content, "Roof South East", 1, new Vector2(textures[9].GetPosition().X + textures[9].GetSprite().Bounds.Width, textures[7].GetPosition().Y), 1f);
            textures[11] = new DrawObject(game, content, "Wall Block Tall", 7, new Vector2(baseXPos, textures[7].GetPosition().Y + (textures[7].GetSprite().Bounds.Height / 2)), 0.5f);
            textures[12] = new DrawObject(game, content, "Door Tall Closed", 1, new Vector2(baseXPos + textures[11].GetSprite().Bounds.Width * 5, textures[7].GetPosition().Y + (textures[9].GetSprite().Bounds.Height / 1.6f)), 0.5f);
           
            checkTexture = content.Load<Texture2D>("Stone Block");
            textures[13] = new DrawObject(game, content, "Stone Block", 7, new Vector2(baseXPos, textures[10].GetPosition().Y + textures[11].GetSprite().Bounds.Height + 31), 0);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(DrawObject obj in textures) obj.Draw(spriteBatch);
        }
    }
}
