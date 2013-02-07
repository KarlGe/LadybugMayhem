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
        private Rectangle _gemRectangle;

        public Gem(ContentManager content, Vector2 gemPosition, Texture2D gemTexture)
        {
            _gemTexture = gemTexture;
            _gemPosition = gemPosition;
            _canClick = true;
            //_ladybugRectangle = new Rectangle((int)_gemPosition.X, (int)_gemPosition.Y, _gemTexture.Width, (_gemTexture.Height - 114));
        }

        public bool CanClick()
        {
            return _canClick;
        }

        public void SetCanClick()
        {
            if (!_canClick)
                _canClick = true;
            _canClick = false;
        }

        public void SetPosition(Vector2 position)
        {
            _gemPosition = position;
        }

        public Vector2 GetPosition()
        {
            return _gemPosition;
        }

        public void SetRectangle(Vector2 position)
        {
            _gemRectangle = new Rectangle((int)position.X, (int)position.Y, _gemTexture.Width/2, (_gemTexture.Height - 95)/2);
        }

        public Rectangle GetRectangle()
        {
            return _gemRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_gemTexture, new Rectangle((int)_gemPosition.X, (int)_gemPosition.Y, _gemTexture.Width/2, _gemTexture.Height/2), new Rectangle(0, 57, _gemTexture.Width, _gemTexture.Height), Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

    }
}
