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
    class Ladybug //: Microsoft.Xna.Framework.GameComponent
    {
        private Texture2D _ladybug;
        private SpriteFont _font;
        private Vector2 _ladybugPosition;
        private int _clicks;

        /// <summary>
        /// Class for ladybug entity.
        /// Contains position and clicks.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ladybugPosition"></param>
        /// <param name="fontPosition"></param>
        public Ladybug(/*Game game, */ContentManager content, Vector2 ladybugPosition, Vector2 fontPosition)
            //: base(game)
        {
            _ladybug = content.Load<Texture2D>("Enemy Bug");
            _font = content.Load<SpriteFont>("TestFont");
            _ladybugPosition = ladybugPosition;
            _clicks = 0;
        }

        #region Get Set methods
        public void SetClicks()
        {
            _clicks++;
        }

        public int GetClicks()
        {
            return _clicks;
        }

        public Vector2 GetPosition()
        {
            return _ladybugPosition;
        }
        #endregion

        #region Draw ladybug and font
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ladybug, _ladybugPosition, Color.White);
            spriteBatch.DrawString(_font, _clicks.ToString(), _ladybugPosition, Color.White);
        }
        #endregion
    }
}
