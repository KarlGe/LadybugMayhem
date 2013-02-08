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
        private bool _respawnDelay;

        private int _citizenNumber;
        private int _timeoutCounter;
        private int _changeSpeedCounter;
        private int _spriteNumber;

        private float _randomSpeedValue;
        private float _speed;

        private String _sprite;
        private Vector2 _spawnPos;
        private DrawSprite _drawable;


        /// <summary>
        /// Citizens konstruktør
        /// </summary>
        /// <param name="content">Spillets Content-objekt</param>
        /// <param name="citizenNumber">Hvor mange citizens-objekter som er opprettet (inkludert denne)</param>
        public Citizen(ContentManager content, int citizenNumber)
        {
            //Hvor mange citizens-objekter som er opprettet (inkludert denne)
            _citizenNumber = citizenNumber;
            //Velger en tilfeldig sprite utifra en liste
            _spriteNumber = GlobalVars.RAND.Next(GlobalVars.CITIZEN_SPRITE_NAME.Length);
            _sprite = GlobalVars.CITIZEN_SPRITE_NAME[_spriteNumber];

            //En innbyggers utgansgsposisjon
            _spawnPos = new Vector2(-300, GlobalVars.GROUND_Y_POS);
            /*Oppretter objektet som skal tegne innbyggeren. Må ha egen "source" (crop).
            Får en layerDepth basert på _citizenNumber (for å forhindre at flere innbyggere kjemper om samme zIndex)*/
            _drawable = new DrawSprite(content, _sprite,
                new Rectangle((int)_spawnPos.X, (int)_spawnPos.Y, GlobalVars.CITIZEN_BOX_WIDTH, GlobalVars.CITIZEN_BOX_HEIGHT),
                GlobalVars.CITIZEN_SPRITE_RECTANGLE, 0.8f + (float)((float)_citizenNumber / 100));

            _speed = GlobalVars.CITIZEN_INIT_SPEED;
            //Tidtaker
            _timeoutCounter = 0;
            //Tidtaker
            _changeSpeedCounter = 0;
            //Boolean som gir timeout når en innbygger er reddet (klikket på)
            _respawnDelay = false;
        }


        /// <summary>
        /// Må kalles på et sted i spillets Update-metode
        /// </summary>
        /// <param name="gameTime">Spillets GameTime-objekt</param>
        public void Update(GameTime gameTime)
        {
            _changeSpeedCounter += gameTime.ElapsedGameTime.Milliseconds;
            //Endrer innbyggerens fart dersom innbyggeren er utenfor skjermen, og det har gått en viss tid, og nåværende fart er under maksfart
            if (_changeSpeedCounter >= 1000 && _drawable.position.X < (0 - GlobalVars.CITIZEN_BOX_WIDTH) &&
                _speed < GlobalVars.CITIZEN_MAX_SPEED)
            {
                _randomSpeedValue = (float)(GlobalVars.RAND.NextDouble());
                _speed += _randomSpeedValue;
                _randomSpeedValue = (float)(GlobalVars.RAND.NextDouble() / 4);
                _speed -= _randomSpeedValue;
                _changeSpeedCounter = 0;
            }

            _timeoutCounter += gameTime.ElapsedGameTime.Milliseconds;
            //Avslutter en innbyggers timeout en viss tid etter at den er klikket på
            if (_timeoutCounter >= 2000 && _drawable.position.X < (0 - GlobalVars.CITIZEN_BOX_WIDTH) )
            {
                _respawnDelay = false;
            }

            //Oppdaterer innbyggerens posisjon dersom den ikke er satt til timeout
            if (!_respawnDelay) _drawable.position.X += (int)_speed;
        }

        /// <summary>
        /// Må kalles på et sted i spillets Draw-metode
        /// </summary>
        /// <param name="spriteBatch">Spillets SpriteBatch-objekt</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            //Sender info til DrawSprite som tegner innbyggeren
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
        public void Saved()
        {
            //Innbyggerens DrawSprite-objekt får oppdatert x- og y-koordinat
            _drawable.position.X = (int)_spawnPos.X;
            _drawable.position.Y = (int)_spawnPos.Y;

            //Innbyggeren settes på timeout
            _respawnDelay = true;
            _timeoutCounter = 0;
        }
    }
}