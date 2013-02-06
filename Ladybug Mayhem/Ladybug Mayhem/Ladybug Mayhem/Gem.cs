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
        private Texture2D _gemTexture;
        private bool _canClick;
        private Vector2 _gemPosition;
        private Rectangle _ladybugRectangle;

        public Gem(ContentManager content, Vector2 gemPosition, Texture2D gemTexture)
        {
            _gemTexture = gemTexture;
            _gemPosition = gemPosition;
            _canClick = true;
            _ladybugRectangle = new Rectangle((int)_gemPosition.X, (int)_gemPosition.Y, _gemTexture.Width, (_gemTexture.Height - 114));
        }

        public bool CanClick()
        {
            return _canClick;
        }

        public void SetClick()
        {
            _canClick = false;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_gemTexture, _gemPosition, new Rectangle(0, 57, _gemTexture.Width, _gemTexture.Height), Color.White);
        }

    }
}
