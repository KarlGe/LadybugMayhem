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
        private String _ladybugTexture;
        private SpriteFont _font;
        private Rectangle _ladybugPosition;
        private Rectangle _ladybugRectangle;
        private DrawSprite _draw;
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
        public Ladybug(ContentManager content, Rectangle ladybugPosition)
        {
            _ladybugTexture = GlobalVars.LADYBUG_SPRITE_NAME;
            _font = content.Load<SpriteFont>("TestFont");
            _ladybugPosition = ladybugPosition;
            _ladybugRectangle = new Rectangle((int)_ladybugPosition.X, (int)_ladybugPosition.Y, GlobalVars.LADYBUG_BOX_WIDTH, (GlobalVars.LADYBUG_BOX_HEIGHT - 95));
            _clicks = 0;
            _timeExisted = 0.0;
            _timeSinceDespawn = 0.0;
            _isDead = false;
            _draw = new DrawSprite(content, _ladybugTexture, _ladybugPosition, GlobalVars.LADYBUG_SPRITE_RECTANGLE, 1) ;


            /*
            _drawHearts.Add(new DrawSprite(content, "heart",
                    new Rectangle(5 + ((GlobalVars.HEART_WIDTH_HEIGHT+12) * heartCounter),3, GlobalVars.HEART_WIDTH_HEIGHT, GlobalVars.HEART_WIDTH_HEIGHT),
                    GlobalVars.HEART_SPRITE_RECTANGLE, 1));
            */
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

        public Rectangle GetPosition()
        {
            return _draw.position;
        }
        /*
        public Rectangle GetRectangle()
        {
            return _ladybugRectangle;
        }
         */

        #endregion

        #region Draw ladybug and font
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //spriteBatch.Draw(_ladybugTexture, _ladybugPosition, new Rectangle(0, 77, _ladybugTexture.Width, 76), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            //spriteBatch.DrawString(_font, _clicks.ToString(), _ladybugPosition, Color.White);
            _draw.Draw(spriteBatch);
        }
        #endregion
    }
}
