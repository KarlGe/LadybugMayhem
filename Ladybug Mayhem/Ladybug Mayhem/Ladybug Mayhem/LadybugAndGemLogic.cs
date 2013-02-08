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
        private List<Rectangle> _positions;
        private List<Ladybug> _ladybugsIsActive, _ladybugsIsNotActive;
        private List<Gem> _gemIsActive, _gemIsNotActive;
        private double _timePassedSpawn;
        private bool _isMousePressed;

        public LadybugAndGemLogic(ContentManager content, SpriteBatch spriteBatch)
        {
            _positions = new List<Rectangle>();
            _ladybugsIsActive = new List<Ladybug>();
            _ladybugsIsNotActive = new List<Ladybug>();
            _gemIsActive = new List<Gem>();
            _gemIsNotActive = new List<Gem>();
            GlobalVars.gems = 0;
            SetPositions(GlobalVars.MAX_LADYBUGS);
            CreateLadybug(content, GlobalVars.MAX_LADYBUGS);
            CreateGems(content);
        }

        public void SetPositions(int numberOfLadybugs)
        {
            int addToPosition = 0;
            for (int i = 0; i < GlobalVars.MAX_LADYBUGS; i++)
            {
                if (i == GlobalVars.MAX_LADYBUGS - 1)
                    _positions.Add(new Rectangle((int)GlobalVars.WINDOW_POS.X, (int)GlobalVars.WINDOW_POS.Y+10,
                                       GlobalVars.LADYBUG_BOX_WIDTH, GlobalVars.LADYBUG_BOX_HEIGHT));
                else
                    _positions.Add(new Rectangle(((int)GlobalVars.FIRST_BROWN_BLOCK_POS.X + addToPosition), 
                                       (int)GlobalVars.FIRST_BROWN_BLOCK_POS.Y+50, GlobalVars.LADYBUG_BOX_WIDTH, GlobalVars.LADYBUG_BOX_HEIGHT));
                addToPosition += 100;
            }
        }

        public void CreateLadybug(ContentManager content, int numberOfLadybugs) 
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                _ladybugsIsNotActive.Add(new Ladybug(content, _positions[i]));
            }
        }

        public void CreateGems(ContentManager content)
        {
            for (int i = 0; i < GlobalVars.GEM_SPRITE_NAME.Length; i++)
            {
                _gemIsNotActive.Add(new Gem(content, new Rectangle(0, 0, 0, 0), GlobalVars.GEM_SPRITE_NAME[i]));
            }
        }

        public void SpawnLadybug(GameTime gameTime)
        {
            for (int i = 0; i < _ladybugsIsNotActive.Count; i++)
                _ladybugsIsNotActive[i].SetTimeDespawn(true, gameTime.ElapsedGameTime.TotalMilliseconds);

            _timePassedSpawn += gameTime.ElapsedGameTime.TotalMilliseconds;
            int index = GlobalVars.RAND.Next(_ladybugsIsNotActive.Count);

            if (_ladybugsIsNotActive.Count > 0 && !_ladybugsIsNotActive[index].IsDead && _timePassedSpawn > GlobalVars.LADYBUG_SPAWN_TIME && 
                _ladybugsIsNotActive[index].GetTimeDespawn() > GlobalVars.LADYBUG_DEAD_TIME)
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
                if (_ladybugsIsActive[i].GetTime() > GlobalVars.LADYBUG_DESPAWN_TIME)
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
                if (!_isMousePressed && CheckMousePress.IsBeingPressed(_ladybugsIsActive[i].GetPosition()))
                {
                    _ladybugsIsActive[i].SetClicks(false);
                    _isMousePressed = true;
                }
            }
        }

        public void IsLadybugDead()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (_ladybugsIsActive[i].GetClicks() >= GlobalVars.LADYBUG_HEALTH)
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

        public void SpawnGem(Rectangle position)
        {
            int index = GlobalVars.RAND.Next(_gemIsNotActive.Count);
            _gemIsNotActive[index].SetPosition(new Rectangle(position.X + 25, position.Y + 25,
                                                   GlobalVars.GEM_WIDTH_HEIGHT, GlobalVars.GEM_WIDTH_HEIGHT));
            _gemIsActive.Add(_gemIsNotActive[index]);
            _gemIsNotActive.RemoveAt(index);
            GlobalVars.MAX_LADYBUGS--;
        }

        public void ClickGem()
        {
            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                if (!_isMousePressed && CheckMousePress.IsBeingPressed(_gemIsActive[i].GetPosition()) && _gemIsActive[i].CanClick())
                {
                    for (int j = 0; j < _ladybugsIsNotActive.Count; j++)
                    {
                        if (_ladybugsIsNotActive[j].GetPosition().Contains(_gemIsActive[i].GetPosition()))
                        {
                            _ladybugsIsNotActive[j].IsDead = false;
                            _ladybugsIsNotActive[j].SetTimeDespawn(false, 0);
                        }
                    }
                    GlobalVars.gems++;
                    _gemIsActive[i].SetCanClick();
                    _gemIsActive[i].SetPosition(new Rectangle((GlobalVars.SCREEN_WIDTH - (GlobalVars.GEM_WIDTH_HEIGHT * GlobalVars.gems)), 0, GlobalVars.GEM_WIDTH_HEIGHT, GlobalVars.GEM_WIDTH_HEIGHT));
                    _isMousePressed = true;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            _isMousePressed = false;
            SpawnLadybug(gameTime);
            ClickLadybug();
            IsLadybugDead();
            DespawnLadybug(gameTime);
            ClickGem();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            for (int i = 0; i <_ladybugsIsActive.Count; i++)
                _ladybugsIsActive[i].Draw(spriteBatch, position);
            for (int i = 0; i < _gemIsActive.Count; i++)
                _gemIsActive[i].Draw(spriteBatch);
        }

        public void Reset()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                _ladybugsIsNotActive.Add(_ladybugsIsActive[i]);
                _ladybugsIsActive.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                _gemIsActive[i].SetCanClick();
                _gemIsNotActive.Add(_gemIsActive[i]);
                _gemIsActive.RemoveAt(i);
                i--;
            }
            GlobalVars.gems = 0;
        }
    }
}
