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
        private Ladybug[] _ladybugs;
        private ContentManager _content;
        private bool[] _isActive;
        private MouseInput _mouseInput;
        private Vector2[] _ladybugPositions;

        //private Vector2 _ladybugPosition01, _ladybugPosition02, _ladybugPosition03, _ladybugPosition04, _ladybugPosition05;

        /// <summary>
        /// Logic class for ladybugs and gems.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spriteBatch"></param>
        public LadybugLevel(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            //_spriteBatch = spriteBatch;
            _random = new Random();
            _mouseInput = new MouseInput();
            _isActive = new bool[5];
            _ladybugPositions = new Vector2[5];
            _ladybugs = new Ladybug[5];

            
        }

        /*
         *
         */

        public void SetLadybugPosition(Vector2 position01, Vector2 position02, Vector2 position03, Vector2 position04, Vector2 position05, )
        {
            _ladybugPositions[0] = new Vector2(100, 100);
            _ladybugPositions[1] = new Vector2(200, 100);
            _ladybugPositions[2] = new Vector2(300, 100);
            _ladybugPositions[3] = new Vector2(400, 100);
            _ladybugPositions[4] = new Vector2(500, 100);
        }

        public void CreateLadybug() 
        {
            
            int testPosition = _random.Next(5);
            //while (!_isActive)
            //{
                
                if (testPosition == 0 && !_isActive[0])
                {
                    _ladybugs[0] = new Ladybug(_content, _ladybugPositions[0]);
                    _isActive[0] = true;
                    
                }
                else if (testPosition == 1 && !_isActive[1])
                {
                    _ladybugs[1] = new Ladybug(_content, _ladybugPositions[1]);
                    _isActive[1] = true;
                    
                }
                else if (testPosition == 2 && !_isActive[2])
                {
                    _ladybugs[2] = new Ladybug(_content, _ladybugPositions[2]);
                    _isActive[2] = true;
                    
                }
                else if (testPosition == 3 && !_isActive[3])
                {
                    _ladybugs[3] = new Ladybug(_content, _ladybugPositions[3]);
                    _isActive[3] = true;
                    
                }
                else if (testPosition == 4 && !_isActive[4])
                {
                    _ladybugs[4] = new Ladybug(_content, _ladybugPositions[4]);
                    _isActive[4] = true;
                    
                }
            //}
        }

        public void ClickLadybug()
        {
            //int clicks = _ladybug.GetClicks();
            //Rectangle rectangle = _ladybug.GetTexture().Bounds;
            _mouseInput.UpdateMouse();

            for (int i = 0; i < _ladybugs.Length; i++)
            {
                if (_ladybugs[i].GetIsActive() && _mouseInput.IsLeftButtonPressed() && _ladybugs[i].GetRectangle().Contains(_mouseInput.GetMousePosition()))
                    _ladybugs[i].SetClicks();
            }
        }

        public bool IsLadybugDead(int clicks)
        {
            if (clicks > 20)
                return true;
            return false;
        }

        public void DrawLadybug(SpriteBatch spriteBatch)
        {
            _ladybug.Draw(spriteBatch);
        }
    }
}
