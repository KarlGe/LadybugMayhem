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
    class Ladybug
    {
        private Texture2D _ladybugTexture;
        private SpriteFont _font;
        private Vector2 _ladybugPosition;
        private Rectangle _ladybugRectangle;
        private double _timeExisted, _timeSinceDespawn;
        private int _clicks;
        private bool _isDead;

        /// <summary>
        /// Class for ladybug entity.
        /// Contains position and clicks.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ladybugPosition"></param>
        /// <param name="fontPosition"></param>
        public Ladybug(ContentManager content, Vector2 ladybugPosition)
        {
            _ladybugTexture = content.Load<Texture2D>("Enemy Bug");
            _font = content.Load<SpriteFont>("TestFont");
            _ladybugPosition = ladybugPosition;
            _clicks = 0;
            _ladybugRectangle = new Rectangle((int)_ladybugPosition.X, (int)_ladybugPosition.Y, _ladybugTexture.Width, (_ladybugTexture.Height - 95));
            _timeExisted = 0.0;
            _timeSinceDespawn = 0.0;
            _isDead = false;
        }

        #region Get Set methods
        public void SetTime(bool add, double timeToAdd)
        {
            if (add)
                _timeExisted += timeToAdd;
            else
                _timeExisted = 0;
        }

        public double GetTime()
        {
            return _timeExisted;
        }

        public void SetTimeDespawn(bool add, double timeToAdd)
        {
            if (add)
                _timeSinceDespawn += timeToAdd;
            else
                _timeSinceDespawn = 0;
        }

        public double GetTimeDespawn()
        {
            return _timeSinceDespawn;
        }

        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = value; }

        }

        public void SetClicks(bool reset)
        {
            if (reset)
                _clicks = 0;
            else 
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

        public Rectangle GetRectangle()
        {
            return _ladybugRectangle;
        }

        #endregion

        #region Draw ladybug and font
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(_ladybugTexture, _ladybugPosition, new Rectangle(0, 77, _ladybugTexture.Width, 76), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(_font, _clicks.ToString(), _ladybugPosition, Color.White);
        }
        #endregion
    }
}
