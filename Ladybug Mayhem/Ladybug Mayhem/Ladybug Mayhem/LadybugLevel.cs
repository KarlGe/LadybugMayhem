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
    class LadybugLevel
    {
        private SpriteBatch _spriteBatch;
        private Random _random;
        private Ladybug _ladybug;
        private Vector2 _ladybugPosition;
        private ContentManager _content;
        private bool[] _isPositionTaken;
        private MouseInput _mouseInput;

        /// <summary>
        /// Logic class for ladybugs and gems.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spriteBatch"></param>
        public LadybugLevel(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
            _random = new Random();
            _mouseInput = new MouseInput();
            _isPositionTaken = new bool[5];
        }

        /*
         *
         */

        public void CreateLadybug() 
        {
            int testPosition = _random.Next(5);
            if (testPosition == 0 && !_isPositionTaken[0])
            {
                _ladybug = new Ladybug(_content, new Vector2(100, 100), new Vector2(100, 100));
                _isPositionTaken[0] = true;
            }
            else if (testPosition == 1 && !_isPositionTaken[1])
            {
                _ladybug = new Ladybug(_content, new Vector2(100, 100), new Vector2(100, 100));
                _isPositionTaken[1] = true;
            }
            else if (testPosition == 2 && !_isPositionTaken[2])
            {
                _ladybug = new Ladybug(_content, new Vector2(100, 100), new Vector2(100, 100));
                _isPositionTaken[2] = true;
            }
            else if (testPosition == 3 && !_isPositionTaken[3])
            {
                _ladybug = new Ladybug(_content, new Vector2(100, 100), new Vector2(100, 100));
                _isPositionTaken[3] = true;
            }
            else if (testPosition == 4 && !_isPositionTaken[4])
            {
                _ladybug = new Ladybug(_content, new Vector2(100, 100), new Vector2(100, 100));
                _isPositionTaken[4] = true;
            }
        }

        public void ClickLadybug()
        {
            int clicks = _ladybug.GetClicks();

            if ( /*MUS OVERLAPPER LADYBUG OG MUS KLIKKES ER */ true)
            {
                _ladybug.SetClicks();
            }
        }

        public bool IsLadybugDead(int clicks)
        {
            if (clicks > 20)
                return true;
            return false;
        }

        public void DrawLadybug()
        {
            _ladybug.Draw(_spriteBatch);
        }
    }
}
