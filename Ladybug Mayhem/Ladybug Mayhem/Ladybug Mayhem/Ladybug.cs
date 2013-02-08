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
        public Ladybug(ContentManager content)
        {
            _ladybugTexture = GlobalVars.LADYBUG_SPRITE_NAME;
            _clicks = 0;
            _timeExisted = 0.0;
            _timeSinceDespawn = 0.0;
            _isDead = false;
            _draw = new DrawSprite(content, _ladybugTexture, new Rectangle(0, 0, 0, 0), GlobalVars.LADYBUG_SPRITE_RECTANGLE, 1) ;
        }

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
