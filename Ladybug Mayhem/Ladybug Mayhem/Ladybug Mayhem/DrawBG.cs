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
        private DrawObject roofNorthWest;
        private DrawObject roofWest;
        private DrawObject roofSouthWest;
        private DrawObject wallBlockTall;
        private DrawObject roofNorth;
        private DrawObject roofNorthEast;
        private DrawObject brownBlock;
        private DrawObject roofSouth;
        //private DrawObject dirtBlock;
        private DrawObject roofEast;
        private DrawObject roofSouthEast;
        private DrawObject stoneBlock;
        private DrawObject windowTall;
        private SpriteBatch spriteBatch;

        private Texture2D stoneBlockTexture;
        private Texture2D roofNorthEastTexture;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch, int windowHeight, int windowWidth)

        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here

            roofNorthWest = new DrawObject(game, content, "Roof North West", 1, new Vector2(0, - (171 / 2)), 1f);
            roofNorth = new DrawObject(game, content, "Roof North", 5, new Vector2(roofNorthWest.GetPosition().X + roofNorthWest.GetSprite().Bounds.Width, -(171 / 2)), 0f);
            roofNorthEastTexture = content.Load<Texture2D>("Roof North East");
            roofNorthEast = new DrawObject(game, content, "Roof North East", 1, new Vector2
                (roofNorth.GetPosition().X + (roofNorth.width * 5), 0 - (roofNorthEastTexture.Bounds.Height / 2)), 0f);
            roofWest = new DrawObject(game, content, "Roof West", 1, new Vector2(0, 0), 1f);
            brownBlock = new DrawObject(game, content, "Brown Block", 4, new Vector2(roofWest.GetPosition().X + roofWest.GetSprite().Bounds.Width,
                roofNorth.GetPosition().Y + (roofNorth.GetSprite().Bounds.Height) / 2), 1f);
            roofEast = new DrawObject(game, content, "Roof East", 1, new Vector2(windowWidth - (roofNorthEast.GetSprite().Bounds.Width * 2), 0), 1f);
            roofSouthWest = new DrawObject(game, content, "Roof South West", 1, new Vector2(0, roofWest.GetPosition().Y + (roofWest.GetSprite().Bounds.Height / 2)), 1f);
            roofSouth = new DrawObject(game, content, "Roof South", 5, new Vector2(roofSouthWest.GetPosition().X +
                roofSouthWest.GetSprite().Bounds.Width, brownBlock.GetPosition().Y + (roofNorth.GetSprite().Bounds.Height) / 2), 1f);
            roofSouthEast = new DrawObject(game, content, "Roof South East", 1, new Vector2(windowWidth - (roofEast.GetSprite().Bounds.Width * 2), 0), 1f);
            wallBlockTall = new DrawObject(game, content, "Wall Block Tall", 7, new Vector2(0, roofSouthWest.GetPosition().Y + (roofSouthWest.GetSprite().Bounds.Height / 2)), 0.5f);
           
            stoneBlockTexture = content.Load<Texture2D>("Stone Block");
            stoneBlock = new DrawObject(game, content, "Stone Block", 7, new Vector2(0, windowHeight - (stoneBlockTexture.Bounds.Height)), 1);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            roofNorthWest.Draw(spriteBatch);
            roofNorth.Draw(spriteBatch);
            roofNorthEast.Draw(spriteBatch);
            roofWest.Draw(spriteBatch);
            brownBlock.Draw(spriteBatch);
            roofEast.Draw(spriteBatch);
            roofSouthWest.Draw(spriteBatch);
            roofSouth.Draw(spriteBatch);
            wallBlockTall.Draw(spriteBatch);
            roofSouthEast.Draw(spriteBatch);
            stoneBlock.Draw(spriteBatch);
        }
    }
}
