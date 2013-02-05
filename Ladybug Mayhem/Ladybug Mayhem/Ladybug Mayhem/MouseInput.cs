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
    public class MouseInput
    {
        
        private MouseState _mouseStateCurrent, _mouseStatePrevious;
        private Point _mousePosition;

        /// <summary>
        /// Mouse class with limited functionality.
        /// </summary>
        public MouseInput()
        {
            _mouseStateCurrent = new MouseState();
            _mouseStatePrevious = new MouseState();
            _mousePosition = new Point(_mouseStateCurrent.X, _mouseStateCurrent.Y);
        }

        #region Update Mouse
        /// <summary>
        /// Updates mouse info. Should be called every update cycle.
        /// </summary>
        public void UpdateMouse()
        {
            _mouseStatePrevious = _mouseStateCurrent;
            _mouseStateCurrent = Mouse.GetState();
            _mousePosition.X = _mouseStateCurrent.X;
            _mousePosition.Y = _mouseStateCurrent.Y;
        }
        #endregion

        #region Left Button Click
        /// <summary>
        /// Checks if left mouse button was clicked.
        /// </summary>
        /// <returns></returns>
        public bool IsLeftButtonPressed()
        {
            if (_mouseStateCurrent.LeftButton == ButtonState.Pressed && _mouseStatePrevious.LeftButton == ButtonState.Released)
                return true;
            return false;
        }
        #endregion

        #region Get Mouse position
        /// <summary>
        /// Returns position of mouse.
        /// </summary>
        /// <returns></returns>
        public Point GetMousePosition()
        {
            return _mousePosition;
        }
        #endregion
    }
}
