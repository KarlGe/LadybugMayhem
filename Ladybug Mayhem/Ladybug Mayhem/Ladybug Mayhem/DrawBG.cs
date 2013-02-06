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
        private DrawObject brownBlock;
        private DrawObject dirtBlock;
        private DrawObject roofEast;
        private DrawObject roofNorthEast;
        private DrawObject roofNorthWest;
        private DrawObject roofNorth;
        private DrawObject roofSouthEast;
        private DrawObject roofSouthWest;
        private DrawObject roofSouth;
        private DrawObject roofWest;
        private DrawObject stoneBlock;
        private DrawObject windowTall;
        private SpriteBatch spriteBatch;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here
            brownBlock = new DrawObject(game, content, "Brown Block", 1, new Vector2(10, 10), 1);
            dirtBlock = new DrawObject(game, content, "Dirt Block", 5, new Vector2(0, roofWest.height), 1);
            //roofEast = new DrawObject(game, content, "Roof East", 1, new Vector2(X, Y));
            //roofNorthEast = new DrawObject(game, content, "Roof North East", 4, new Vector2(X, Y));
            //roofNorthWest = new DrawObject(game, content, "Roof North West", 1, new Vector2(X, Y));

        }
        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch){
            brownBlock.Draw(spriteBatch);
            dirtBlock.Draw(spriteBatch);
            roofEast.Draw(spriteBatch);
            roofNorthEast.Draw(spriteBatch);
            roofNorthWest.Draw(spriteBatch);
        }
    }
}
