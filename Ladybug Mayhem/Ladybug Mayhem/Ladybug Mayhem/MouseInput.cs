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
        
        public MouseState mouseStateCurrent, mouseStatePrevious;

        /// <summary>
        /// Mouse class with limited functionality.
        /// </summary>
        public MouseInput()
        {
            mouseStateCurrent = new MouseState();
            mouseStatePrevious = new MouseState();
        }

        #region Update Mouse
        /// <summary>
        /// Updates mouse info. Should be called every update cycle.
        /// </summary>
        public void UpdateMouse()
        {
            mouseStatePrevious = mouseStateCurrent;
            mouseStateCurrent = Mouse.GetState();
        }
        #endregion

        #region LeftButtonPress
        /// <summary>
        /// Checks if left mouse button was clicked.
        /// </summary>
        /// <returns></returns>
        public bool IsLeftButtonPressed()
        {
            if (mouseStateCurrent.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
                return true;
            return false;
        }
        #endregion
    }
}
