using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace Ladybug_Mayhem
{
    public class DrawBG
    {
        private DrawSprite[] textures = new DrawSprite[14];
        private Point basePos = new Point(0,93); //Posisjonen bakgrunnen skal begynne å tegne på

        /// <summary>
        /// Gjør klar objekter med posisjon som er plassert i forhold til hverandre, dette gjør 
        /// hvis man endrer på basePos så vil alle elementene flytte seg deretter. De er lagt inn i
        /// en array for iterere igjennom lettere, selv om det er litt vanskeligere å holde oversikt
        /// over hvilken som er textures[4] enn textureBrownBlock.
        /// Setter posisjonene til de brune blokkene, vinduet og steinveien i GlobalVars for bruk i andre klasser.
        /// </summary>
        /// <param name="game"></param>
        public DrawBG(Game game)
        {
            textures[0] = new DrawSprite(game.Content, "Roof North West", 1, new Vector2(basePos.X, basePos.Y-86), 0.1f);
            textures[1] = new DrawSprite(game.Content, "Roof North", 5, new Vector2(basePos.X + textures[0].width, textures[0].position.Y), 0f);
            textures[2] = new DrawSprite(game.Content, "Roof North East", 1, new Vector2(textures[1].position.X + (textures[1].width * 5), textures[0].position.Y), 0f);
            textures[3] = new DrawSprite(game.Content, "Roof West", 1, new Vector2(basePos.X, textures[1].position.Y + textures[1].height - 87), 0.2f);
            GlobalVars.FIRST_BROWN_BLOCK_POS = new Vector2(basePos.X + textures[3].width, textures[3].position.Y);
            textures[4] = new DrawSprite(game.Content, "Brown Block", 4, GlobalVars.FIRST_BROWN_BLOCK_POS, 0.2f);
            textures[5] = new DrawSprite(game.Content, "Roof North2", 1, new Vector2(textures[4].position.X + textures[4].width * 4, textures[1].position.Y + 43), 0.2f);
            textures[6] = new DrawSprite(game.Content, "Roof East", 1, new Vector2(textures[4].position.X + textures[3].width * 5, textures[3].position.Y), 0.1f);
            textures[7] = new DrawSprite(game.Content, "Roof South West", 1, new Vector2(basePos.X, textures[3].position.Y + (textures[3].height / 2)), 0.3f);
            textures[8] = new DrawSprite(game.Content, "Roof South", 4, new Vector2(basePos.X + textures[7].width, textures[7].position.Y), 0.3f);
            GlobalVars.WINDOW_POS = new Vector2(textures[8].position.X + textures[8].width * 4, textures[7].position.Y);
            textures[9] = new DrawSprite(game.Content, "Window Tall", 1, GlobalVars.WINDOW_POS, 0.25f);
            textures[10] = new DrawSprite(game.Content, "Roof South East", 1, new Vector2(textures[9].position.X + textures[9].width, textures[7].position.Y), 0.3f);
            textures[11] = new DrawSprite(game.Content, "Wall Block Tall", 7, new Vector2(basePos.X, textures[7].position.Y + (textures[7].height / 2)), 0.1f);
            textures[12] = new DrawSprite(game.Content, "Door Tall Closed", 1, new Vector2(basePos.X + textures[11].width * 5, textures[7].position.Y + (textures[9].height / 1.6f)), 0.15f);
            textures[13] = new DrawSprite(game.Content, "Stone Block", 7, new Vector2(basePos.X, textures[10].position.Y + textures[11].height + 31), 0f);
            GlobalVars.GROUND_Y_POS = (int) textures[13].position.Y;
        }
        /// <summary>
        /// Tegner ut alle elementene i arrayen textures
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(DrawSprite sprite in textures) sprite.Draw(spriteBatch);
        }
    }
}
