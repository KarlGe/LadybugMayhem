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

        private float _speed;


        public Citizen(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("Character Boy");
            _position = new Vector2(-(_sprite.Width), 100);
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
    }
}