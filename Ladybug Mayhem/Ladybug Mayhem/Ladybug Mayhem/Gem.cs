using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Ladybug_Mayhem
{
    class Gem
    {
        private bool _canClick;
        private DrawSprite _draw;

        public Gem(ContentManager content, String gemTexture)
        {
            _canClick = true;
            _draw = new DrawSprite(content, gemTexture, new Rectangle(0, 0, 0, 0), GlobalVars.GEM_SPRITE_RECTANGLE, 1);
        }

        public bool CanClick()
        {
            return _canClick;
        }

        public void SetCanClick()
        {
            if (!_canClick)
                _canClick = true;
            else
                _canClick = false;
        }

        public Rectangle Position
        {
            get { return _draw.position; }
            set { _draw.position = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _draw.Draw(spriteBatch);
        }

    }
}
