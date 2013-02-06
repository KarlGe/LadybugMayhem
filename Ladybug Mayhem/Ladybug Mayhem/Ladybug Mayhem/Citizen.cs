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
        private int _citizenNumber;

        private Texture2D _sprite;

        private float _speed;

        private Rectangle _destinationRectangle;

        public Citizen(ContentManager content, int citizenNumber)
        {
            _citizenNumber = citizenNumber;
            _sprite = content.Load<Texture2D>("Character Boy");
            _destinationRectangle = new Rectangle(-200 - (300 * _citizenNumber), (int)GlobalVars.CITIZEN_SPAWN_POS.Y,
                GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT);
            _speed = 3;
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
        public Rectangle GetCitizenBox()
        {
            return _destinationRectangle;
        }

        /// <summary>
        /// "Redder" en citizen ved å sende den tilbake til før skjermen
        /// </summary>
        /// <param name="citizenList"></param>
        public void Saved(Citizen[] citizenList)
        {
            _destinationRectangle.X = (int)GlobalVars.CITIZEN_SPAWN_POS.X;
            _destinationRectangle.Y = (int)GlobalVars.CITIZEN_SPAWN_POS.Y;
        }
    }
}