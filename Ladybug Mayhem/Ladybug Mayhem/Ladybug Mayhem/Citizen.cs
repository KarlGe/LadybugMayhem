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
        private int _timeKeeper;
        private int _randomTimeKeeper;
        private int _spriteNumber;

        private float _randomSpeedBoost;
        private float _speed;
        private float _maxSpeed;
        private bool _delayed = false;

        private String _sprite;
        private Vector2 _spawnPos;
        private DrawSprite _drawable;

        public Citizen(ContentManager content, int citizenNumber)
        {
            _citizenNumber = citizenNumber;
            _spriteNumber = GlobalVars.RAND.Next(GlobalVars.CITIZEN_SPRITE_NAME.Length);
            _sprite = GlobalVars.CITIZEN_SPRITE_NAME[_spriteNumber];
            _spawnPos = new Vector2(-300, GlobalVars.GROUND_Y_POS);
            _drawable = new DrawSprite(content, _sprite,
                new Rectangle((int)_spawnPos.X, (int)_spawnPos.Y, GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT),
                GlobalVars.CITIZEN_SPRITE_RECTANGLE, 0.8f + (float)((float)_citizenNumber / 100));
            _speed = 3;
            _maxSpeed = 12;
            _timeKeeper = 0;
            _randomTimeKeeper = 0;
        }

        public void Update(GameTime gameTime)
        {
            _randomTimeKeeper += gameTime.ElapsedGameTime.Milliseconds;
            if (_randomTimeKeeper >= 1000 && _drawable.position.X < (0 - GlobalVars.CITIZEN_BOX_WIDTH) &&
                _drawable.position.X > -3000 && _speed < _maxSpeed)
            {
                _randomSpeedBoost = (float)(GlobalVars.RAND.NextDouble());
                _speed += _randomSpeedBoost;
                _randomTimeKeeper = 0;
            }
            _timeKeeper += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeKeeper >= 2000 && _drawable.position.X < (0 - GlobalVars.CITIZEN_BOX_WIDTH) )
            {
                _delayed = false;
            }
            if (!_delayed) _drawable.position.X += (int)_speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _drawable.Draw(spriteBatch);
        }

        //jeg fikk feilmelding på _spriteBounds.X i Update() dersom jeg ga _spriteBounds en get;-set; ..? Derfor lager jeg denne..
        public Rectangle GetCitizenBox()
        {
            return _drawable.position;
        }

        /// <summary>
        /// "Redder" en citizen ved å sende den tilbake til før skjermen
        /// </summary>
        /// <param name="citizenList"></param>
        public void Saved(List<Citizen> citizenList)
        {
            _drawable.position.X = (int)_spawnPos.X;
            _drawable.position.Y = (int)_spawnPos.Y;
            _delayed = true;
            _timeKeeper = 0;
        }
    }
}