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
        private DrawObject[] textures = new DrawObject[12];
        private SpriteBatch spriteBatch;
        private int baseXPos = 0;
        private Texture2D checkTexture;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch, int windowHeight, int windowWidth)

        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here

            checkTexture = content.Load<Texture2D>("Roof North West");
            textures[0] = new DrawObject(game, content, "Roof North West", 1, new Vector2(baseXPos, -(checkTexture.Bounds.Height / 2)), 1f);
            textures[1] = new DrawObject(game, content, "Roof North", 5, new Vector2(baseXPos + textures[1].GetSprite().Bounds.Width, textures[1].GetPosition().Y), 0f);
            textures[2] = new DrawObject(game, content, "Roof North East", 1, new Vector2
                (baseXPos + (textures[1].width * 5), textures[1].GetPosition().Y), 0f);
            textures[2] = new DrawObject(game, content, "Roof West", 1, new Vector2(baseXPos, textures[1].GetPosition().Y + textures[1].GetSprite().Bounds.Height - 87), 1f);
            textures[3] = new DrawObject(game, content, "Brown Block", 4, new Vector2(textures[2].GetPosition().X + textures[2].GetSprite().Bounds.Width, roofWest.GetPosition().Y), 1f);
            textures[4] = new DrawObject(game, content, "Roof East", 1, new Vector2(textures[3].GetPosition().X + textures[3].GetSprite().Bounds.Width * 5, brownBlock.GetPosition().Y), 0.5f);
            textures[5] = new DrawObject(game, content, "Roof South West", 1, new Vector2(baseXPos, textures[2].GetPosition().Y + (textures[2].GetSprite().Bounds.Height / 2)), 1f);
            textures[6] = new DrawObject(game, content, "Roof South", 4, new Vector2(textures[5].GetPosition().X + textures[5].GetSprite().Bounds.Width, roofSouthWest.GetPosition().Y), 1f);
            textures[7] = new DrawObject(game, content, "Window Tall", 1, new Vector2(textures[6].GetPosition().X + textures[6].GetSprite().Bounds.Width * 4, roofSouthWest.GetPosition().Y), 0.7f);
            textures[8] = new DrawObject(game, content, "Roof South East", 1, new Vector2(textures[7].GetPosition().X + textures[7].GetSprite().Bounds.Width, roofSouthWest.GetPosition().Y), 1f);
            textures[9] = new DrawObject(game, content, "Wall Block Tall", 7, new Vector2(baseXPos, roofSouthWest.GetPosition().Y + (roofSouthWest.GetSprite().Bounds.Height / 2)), 0.5f);
            textures[10] = new DrawObject(game, content, "Door Tall Closed", 1, new Vector2(baseXPos + wallBlockTall.GetSprite().Bounds.Width * 7, roofSouthWest.GetPosition().Y + (roofSouthWest.GetSprite().Bounds.Height / 2)), 0.5f);
           
            checkTexture = content.Load<Texture2D>("Stone Block");
            textures[11] = new DrawObject(game, content, "Stone Block", 7, new Vector2(baseXPos, wallBlockTall.GetPosition().Y + wallBlockTall.GetSprite().Bounds.Height - 54), 0);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(DrawObject obj in textures) obj.Draw(spriteBatch);
        }
    }
}
