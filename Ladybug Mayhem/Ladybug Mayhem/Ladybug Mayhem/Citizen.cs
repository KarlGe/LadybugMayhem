using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ikke default
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace Ladybug_Mayhem
{
    public class Citizen
    {
        private Texture2D _sprite;

        private float _speed;

        private Rectangle _destinationRectangle;

        public Citizen(ContentManager content, int citizenNumber)
        {
            _sprite = content.Load<Texture2D>("Character Boy");
            _destinationRectangle = new Rectangle(-200 - (300 * citizenNumber), 100,
                GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT);
            _speed = 2;
        }

        public void Update()
        {
            _destinationRectangle.X += (int)_speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, new Vector2(_destinationRectangle.X, _destinationRectangle.Y), GlobalVars.CITIZEN_SOURCE_RECTANLGE,
                Color.White);
        }

        //jeg fikk feilmelding på _spriteBounds.X i Update() dersom jeg ga _spriteBounds en get;-set; ..? Derfor lager jeg denne..
        public Rectangle getCitizenBox()
        {
            return _destinationRectangle;
        }
    }
}