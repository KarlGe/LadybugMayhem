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

        private Rectangle _clickableRectangle;

        private int _citizenNumber;
        private int _timeKeeper;
        private int _randomTimeKeeper;
        private int _spriteNumber;

        private float _randomSpeedBoost;
        private float _speed;

        public Citizen(ContentManager content, int citizenNumber)
        {
            _citizenNumber = citizenNumber;
            _spriteNumber = GlobalVars.RAND.Next(GlobalVars.CITIZEN_SPRITE_NAME.Length);
            _sprite = content.Load<Texture2D>(GlobalVars.CITIZEN_SPRITE_NAME[_spriteNumber]);
            _clickableRectangle = new Rectangle(-300, GlobalVars.GROUND_Y_POS,
                GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT);
            _speed = 3;
            _timeKeeper = 0;
            _randomTimeKeeper = 0;
        }

        public void Update(GameTime gameTime)
        {
            _randomTimeKeeper += gameTime.ElapsedGameTime.Milliseconds;
            if (_randomTimeKeeper >= 1000 && _clickableRectangle.X < (0 - _clickableRectangle.Width) && _clickableRectangle.X > -3000)
            {
                _randomSpeedBoost = (float)(GlobalVars.RAND.NextDouble() / 5);
                _speed += _randomSpeedBoost;
                _randomTimeKeeper = 0;
            }
            _timeKeeper += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeKeeper >= 20000 && _clickableRectangle.X < (0-_clickableRectangle.Width) && _clickableRectangle.X > -3000)
            {
                _speed += 1;
                _timeKeeper = 0;
            }
            _clickableRectangle.X += (int)_speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, new Vector2(_clickableRectangle.X, _clickableRectangle.Y), GlobalVars.CITIZEN_SPRITE_RECTANGLE,
                Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.8f+(float)((float)_citizenNumber/100));
        }

        //jeg fikk feilmelding på _spriteBounds.X i Update() dersom jeg ga _spriteBounds en get;-set; ..? Derfor lager jeg denne..
        public Rectangle GetCitizenBox()
        {
            return _clickableRectangle;
        }

        /// <summary>
        /// "Redder" en citizen ved å sende den tilbake til før skjermen
        /// </summary>
        /// <param name="citizenList"></param>
        public void Saved(List<Citizen> citizenList)
        {
            _clickableRectangle.X = -300;
            _clickableRectangle.Y = GlobalVars.GROUND_Y_POS;
        }
    }
}