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
        //private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Vector2[] _positions;
        private Vector2 _addToGemPosition;
        private List<Ladybug> _ladybugsIsActive, _ladybugsIsNotActive, _ladybugsIsDead;
        private List<Gem> _gemIsActive, _gemIsNotActive;
        private double _timePassedSpawn;
        private List<Texture2D> _gemTextures;

        public LadybugAndGemLogic(ContentManager content, SpriteBatch spriteBatch, int numberOfLadybugs, int numberOfGems)
        {
            _content = content;
            _positions = new Vector2[numberOfLadybugs];
            _ladybugsIsActive = new List<Ladybug>();
            _ladybugsIsNotActive = new List<Ladybug>();
            _ladybugsIsDead = new List<Ladybug>();
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
            _addToGemPosition = new Vector2(0, 0);
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
            for (int i = 0; i < _ladybugsIsNotActive.Count; i++)
                _ladybugsIsNotActive[i].SetTimeDespawn(true, gameTime.ElapsedGameTime.TotalMilliseconds);
            _timePassedSpawn += gameTime.ElapsedGameTime.TotalMilliseconds;
            int index = GlobalVars.RAND.Next(_ladybugsIsNotActive.Count);
            if (_ladybugsIsNotActive.Count > 0 && !_ladybugsIsNotActive[index].IsDead && _timePassedSpawn > 2000 && _ladybugsIsNotActive[index].GetTimeDespawn() > 2000)
            {
                
                _ladybugsIsActive.Add(_ladybugsIsNotActive[index]);
                _ladybugsIsNotActive[index] = _ladybugsIsNotActive[_ladybugsIsNotActive.Count - 1];
                _ladybugsIsNotActive.RemoveAt(_ladybugsIsNotActive.Count - 1);
                _timePassedSpawn = 0;
            }
        }

        public void DespawnLadybug(GameTime gameTime)
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                _ladybugsIsActive[i].SetTime(true, gameTime.ElapsedGameTime.TotalMilliseconds);
                if (_ladybugsIsActive[i].GetTime() > 5000)
                {
                    _ladybugsIsActive[i].SetTime(false, 0);
                    _ladybugsIsActive[i].SetTimeDespawn(false, 0);
                    _ladybugsIsActive[i].SetClicks(true);
                    _ladybugsIsNotActive.Add(_ladybugsIsActive[i]);
                    _ladybugsIsActive[i] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                    _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);
                }
            }
        }

        public void ClickLadybug()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (CheckMousePress.IsBeingPressed(_ladybugsIsActive[i].GetRectangle()))
                    _ladybugsIsActive[i].SetClicks(false);
            }
        }

        public void IsLadybugDead()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (_ladybugsIsActive[i].GetClicks() >= 1)
                {
                    _ladybugsIsActive[i].SetClicks(true);
                    if (_gemIsNotActive.Count > 0)
                    {
                        SpawnGem(_ladybugsIsActive[i].GetPosition());
                        _ladybugsIsActive[i].IsDead = true;
                    }
                    _ladybugsIsNotActive.Add(_ladybugsIsActive[i]);
                    _ladybugsIsActive[i] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                    _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);

                    
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            SpawnLadybug(gameTime);
            ClickLadybug();
            IsLadybugDead();
            DespawnLadybug(gameTime);
            ClickGem();
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
            for (int i = 0; i < GlobalVars.GEM_SPRITE_NAME.Length; i++)
            {
                _gemIsNotActive.Add(new Gem(_content, Vector2.Zero, GlobalVars.GEM_SPRITE_NAME[i]));

            }

        }

        public void SpawnGem(Vector2 position)
        {
            int index = GlobalVars.RAND.Next(_gemIsNotActive.Count);
            _gemIsNotActive[index].SetRectangle(position);
            _gemIsNotActive[index].SetPosition(position);
            _gemIsActive.Add(_gemIsNotActive[index]);
            _gemIsNotActive.RemoveAt(index);
            
        }

        public void ClickGem()
        {
            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                if (CheckMousePress.IsBeingPressed(_gemIsActive[i].GetRectangle()) && _gemIsActive[i].CanClick())
                {
                    for (int j = 0; j < _ladybugsIsNotActive.Count; j++)
                    {
                        if (_ladybugsIsNotActive[j].GetPosition() == _gemIsActive[i].GetPosition())
                        {
                            _ladybugsIsNotActive[j].IsDead = false;
                            _ladybugsIsNotActive[j].SetTimeDespawn(false, 0);
                        }
                    }
                    _gemIsActive[i].SetCanClick();
                    _gemIsActive[i].SetPosition(new Vector2(0, GlobalVars.SCREEN_WIDTH) - _addToGemPosition);
                    _addToGemPosition += new Vector2(0, -100);
                    
                }
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
