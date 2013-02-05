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

        private Rectangle _destinationRectangle;

        private int _citizenNumber;
        private int _timeKeeper;
        private int _spriteNumber;

        private float _speed;

        public Citizen(ContentManager content, int citizenNumber)
        {
            _citizenNumber = citizenNumber;
            _spriteNumber = GlobalVars.RAND.Next(GlobalVars.CITIZEN_SPRITE_NAME.Length);
            _sprite = content.Load<Texture2D>(GlobalVars.CITIZEN_SPRITE_NAME[_spriteNumber]);
            _destinationRectangle = new Rectangle(-300, (int)GlobalVars.CITIZEN_SPAWN_POS.Y,
                GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT);
            _speed = 3;
            _timeKeeper = 0;
        }

        public void Update(GameTime gameTime)
        {
            _timeKeeper += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeKeeper >= 500 && _destinationRectangle.X < (0-_destinationRectangle.Width) && _destinationRectangle.X > -3000)
            {
                _speed += 0.1f;
                _timeKeeper = 0;
            }
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
        public void Saved(List<Citizen> citizenList)
        {
            _destinationRectangle.X = (int)GlobalVars.CITIZEN_SPAWN_POS.X;
            _destinationRectangle.Y = (int)GlobalVars.CITIZEN_SPAWN_POS.Y;
        }
    }
}