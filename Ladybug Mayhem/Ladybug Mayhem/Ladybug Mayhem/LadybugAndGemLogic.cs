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
    class LadybugAndGemLogic
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private MouseInput _mouseInput;
        private Vector2[] _positions;
        private List<Ladybug> _ladybugsIsActive, _ladybugsIsNotActive;
        private List<Gem> _gemIsActive, _gemIsNotActive;
        private double _timePassedSpawn;
        private Random _random;
        private List<Texture2D> _gemTextures;

        /// <summary>
        /// Logic class for ladybugs and gems.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spriteBatch"></param>
        public LadybugAndGemLogic(ContentManager content, SpriteBatch spriteBatch, int numberOfLadybugs, int numberOfGems)
        {
            _content = content;
            _random = new Random();
            _mouseInput = new MouseInput();
            _positions = new Vector2[numberOfLadybugs];
            _ladybugsIsActive = new List<Ladybug>();
            _ladybugsIsNotActive = new List<Ladybug>();
            _gemIsActive = new List<Gem>();
            _gemIsNotActive = new List<Gem>();
            _gemTextures = new List<Texture2D>();
            SetPositions(numberOfLadybugs);//, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero);
            LoadGemTextures();

        }

        #region Ladybugs
        public void SetPositions(int numberOfLadybugs) //, Vector2[] positions)
        {
            Vector2 position = new Vector2(100, 100);
            for (int i = 0; i < numberOfLadybugs; i++)
            {
                _positions[i] = position;
                position.X += 100;
            }
        }

        public void CreateLadybug(int numberOfLadybugs) 
        {
            for (int i = 0; i < numberOfLadybugs; i++)
            {
                _ladybugsIsNotActive.Add(new Ladybug(_content, _positions[i]));
            }
 
        }

        public void SpawnLadybug(GameTime gameTime)
        {
            _timePassedSpawn += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_timePassedSpawn > 2000)
            {
                int index = _random.Next(_ladybugsIsNotActive.Count);
                _ladybugsIsActive.Add(_ladybugsIsNotActive[index]);
                _ladybugsIsNotActive[index] = _ladybugsIsNotActive[_ladybugsIsNotActive.Count - 1];
                _ladybugsIsNotActive.RemoveAt(_ladybugsIsNotActive.Count - 1);
                _timePassedSpawn = 0;
            }
        }

        public void DespawnLadybug(GameTime gameTime, int index)
        {
            if (_ladybugsIsActive[index].GetTime() > 5000)
            {
                _ladybugsIsActive[index].SetTime(false, 0);
                _ladybugsIsActive[index].SetClicks(true);
                _ladybugsIsNotActive.Add(_ladybugsIsActive[index]);
                _ladybugsIsActive[index] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);    
            }
        }

        public void ClickLadybug()
        {
            _mouseInput.UpdateMouse();

            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (_mouseInput.IsLeftButtonPressed() && _ladybugsIsActive[i].GetRectangle().Contains(_mouseInput.GetMousePosition()))
                    _ladybugsIsActive[i].SetClicks(false);
            }
        }

        public int IsLadybugDead(int index)
        {
            if (_ladybugsIsActive[index].GetClicks() > 5)
            {
                _ladybugsIsActive[index].SetClicks(true);
                Vector2 position = _ladybugsIsActive[index].GetPosition();
                _ladybugsIsActive[index] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                _ladybugsIsNotActive.Add(_ladybugsIsActive[_ladybugsIsActive.Count - 1]);
                _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);
                
                if (_gemIsNotActive.Count > 0)
                    SpawnGem(position);
                
                return --index;
            }
            return index;
        }

        public void Update(GameTime gameTime)
        {
            SpawnLadybug(gameTime);
            ClickLadybug();
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                i = IsLadybugDead(i);
                if (_ladybugsIsActive.Count > 0)
                {
                    _ladybugsIsActive[i].SetTime(true, gameTime.ElapsedGameTime.TotalMilliseconds);
                    DespawnLadybug(gameTime, i);
                }
            }
        }

        public void DrawLadybug(SpriteBatch spriteBatch, Vector2 position)
        {
            for (int i = 0; i <_ladybugsIsActive.Count; i++)
                _ladybugsIsActive[i].Draw(spriteBatch, position);
            for (int i = 0; i < _gemIsActive.Count; i++)
                _gemIsActive[i].Draw(spriteBatch);
        }
        #endregion

        #region Gems
        public void LoadGemTextures()
        {
            _gemTextures.Add(_content.Load<Texture2D>("Gem Blue"));
            _gemTextures.Add(_content.Load<Texture2D>("Gem Green"));
            _gemTextures.Add(_content.Load<Texture2D>("Gem Orange"));
        }

        public void CreateGems()
        {
            for (int i = 0; i < _gemTextures.Count; i++)
            {
                int random = _random.Next(_gemTextures.Count);
                _gemIsNotActive.Add(new Gem(_content, Vector2.Zero, _gemTextures[random]));
                _gemTextures.RemoveAt(random);
                i--;
            }

        }

        public void SpawnGem(Vector2 position)
        {
            int random = (int)_random.Next(_gemIsNotActive.Count);
            _gemIsActive.Add(_gemIsNotActive[random]);
            _gemIsActive[_gemIsActive.Count - 1].SetPosition(position);
            _gemIsNotActive.RemoveAt(random);
        }

        public void DespawnGem()
        {

        }

        public void ClickGem()
        {
            _mouseInput.UpdateMouse();

            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                if (_mouseInput.IsLeftButtonPressed() && _gemIsActive[i].GetRectangle().Contains(_mouseInput.GetMousePosition()))
                    _gemIsActive[i].SetCanClick();
            }
        }


        #endregion

        #region Winning
        public void AddScore()
        {

        }
        #endregion
    }
}
