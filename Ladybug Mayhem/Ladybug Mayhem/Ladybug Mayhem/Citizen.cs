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

        private Vector2 _position;

        public float _speed;


        public Citizen(ContentManager content, int citizenNumber)
        {
            _sprite = content.Load<Texture2D>("Character Boy");
            _position = new Vector2(-200 - (300 * citizenNumber), 100);
            _speed = 2;
        }

        public void Update()
        {
            _position.X += _speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, _position, Color.White);
        }

        public Rectangle getRectangle()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _sprite.Width, _sprite.Height);
        }
    }
}