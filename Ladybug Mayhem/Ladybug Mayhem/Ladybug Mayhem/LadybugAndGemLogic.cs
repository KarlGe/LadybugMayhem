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
        private List<Rectangle> _positions, _positionsTaken;
        private List<Ladybug> _ladybugsIsActive, _ladybugsIsNotActive;
        private List<Gem> _gemIsActive, _gemIsNotActive;
        private double _timePassedSpawn;
        private bool _isMousePressed;

        /// <summary>
        /// Does all logic for ladybugs and gems in level.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spriteBatch"></param>
        public LadybugAndGemLogic(ContentManager content, SpriteBatch spriteBatch)
        {
            _positions = new List<Rectangle>();
            _positionsTaken = new List<Rectangle>();
            _ladybugsIsActive = new List<Ladybug>();
            _ladybugsIsNotActive = new List<Ladybug>();
            _gemIsActive = new List<Gem>();
            _gemIsNotActive = new List<Gem>();
            GlobalVars.gems = 0;
            SetPositions();
            CreateLadybug(content);
            CreateGems(content);
        }

        private void SetPositions()
        {
            int addToPosition = 0;
            for (int i = 0; i < GlobalVars.MAX_LADYBUG_SPAWN_POINTS; i++)
            {
                if (i == GlobalVars.MAX_LADYBUG_SPAWN_POINTS - 1)
                    _positions.Add(new Rectangle((int)GlobalVars.WINDOW_POS.X, (int)GlobalVars.WINDOW_POS.Y+10,
                                       GlobalVars.LADYBUG_BOX_WIDTH, GlobalVars.LADYBUG_BOX_HEIGHT));
                else
                    _positions.Add(new Rectangle(((int)GlobalVars.FIRST_BROWN_BLOCK_POS.X + addToPosition), 
                                       (int)GlobalVars.FIRST_BROWN_BLOCK_POS.Y+50, GlobalVars.LADYBUG_BOX_WIDTH, GlobalVars.LADYBUG_BOX_HEIGHT));
                addToPosition += 100;
            }
        }

        private void CreateLadybug(ContentManager content) 
        {
            for (int i = 0; i < GlobalVars.MAX_LADYBUGS; i++)
            {
                _ladybugsIsNotActive.Add(new Ladybug(content));
            }
        }

        private void CreateGems(ContentManager content)
        {
            for (int i = 0; i < GlobalVars.GEM_SPRITE_NAME.Length; i++)
            {
                _gemIsNotActive.Add(new Gem(content, GlobalVars.GEM_SPRITE_NAME[i]));
            }
        }

        /// <summary>
        /// Spawns ladybug if enough time has passed and conditions are met.
        /// Also sets the position where it spawns as busy.
        /// </summary>
        /// <param name="gameTime"></param>
        private void SpawnLadybug(GameTime gameTime)
        {
            int index = GlobalVars.RAND.Next(_positions.Count);
            _timePassedSpawn += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_timePassedSpawn > GlobalVars.LADYBUG_SPAWN_TIME)
            {
                for (int i = 0; i < _ladybugsIsNotActive.Count; i++)
                {
                    _ladybugsIsNotActive[i].SetTimeDespawn(true, gameTime.ElapsedGameTime.TotalMilliseconds);

                    if (!_ladybugsIsNotActive[i].IsDead && _ladybugsIsNotActive[i].GetTimeDespawn() > GlobalVars.LADYBUG_DEAD_TIME)
                    {
                        _ladybugsIsNotActive[i].Position = _positions[index];
                        _ladybugsIsActive.Add(_ladybugsIsNotActive[i]);
                        _ladybugsIsNotActive.RemoveAt(i);

                        _positionsTaken.Add(_positions[index]);
                        _positions.RemoveAt(index);

                        _timePassedSpawn = 0;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Despawns ladybug if it has been alive too long.
        /// Also frees up position so a new ladybug can spawn there.
        /// </summary>
        /// <param name="gameTime"></param>
        private void DespawnLadybug(GameTime gameTime)
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                _ladybugsIsActive[i].SetTime(true, gameTime.ElapsedGameTime.TotalMilliseconds);
                if (_ladybugsIsActive[i].GetTime() > GlobalVars.LADYBUG_DESPAWN_TIME)
                {
                    _ladybugsIsActive[i].SetTime(false, 0);
                    _ladybugsIsActive[i].SetTimeDespawn(false, 0);
                    _ladybugsIsActive[i].SetClicks(true);

                    for (int j = 0; j < _positionsTaken.Count; j++)
                    {
                        if (_ladybugsIsActive[i].Position == _positionsTaken[j])
                        {
                            _positions.Add(_positionsTaken[j]);
                            _positionsTaken.RemoveAt(j);
                        }
                    }
                    _ladybugsIsNotActive.Add(_ladybugsIsActive[i]);
                    _ladybugsIsActive[i] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                    _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);
                }
            }
        }

        private void ClickLadybug()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (!_isMousePressed && CheckMousePress.IsBeingPressed(_ladybugsIsActive[i].Position))
                {
                    // Adds click.
                    _ladybugsIsActive[i].SetClicks(false);
                    _isMousePressed = true;
                }
            }
        }

        /// <summary>
        /// Checks if ladybug has lost all health, and sets it to dead.
        /// If dead, calls SpawnGem().
        /// </summary>
        private void IsLadybugDead()
        {
            for (int i = 0; i < _ladybugsIsActive.Count; i++)
            {
                if (_ladybugsIsActive[i].GetClicks() >= GlobalVars.LADYBUG_HEALTH)
                {
                    //For å hindre at spilleren lar gems ligge, og dermed unngår at farten øker
                    if(GlobalVars.bugs_killed < 2)
                        GlobalVars.bugs_killed++;

                    _ladybugsIsActive[i].SetClicks(true);
                    if (_gemIsNotActive.Count > 0)
                    {
                        SpawnGem(_ladybugsIsActive[i].Position);
                        _ladybugsIsActive[i].IsDead = true;
                    }
                    _ladybugsIsNotActive.Add(_ladybugsIsActive[i]);
                    _ladybugsIsActive[i] = _ladybugsIsActive[_ladybugsIsActive.Count - 1];
                    _ladybugsIsActive.RemoveAt(_ladybugsIsActive.Count - 1);
                }
            }
        }

        /// <summary>
        /// Spawns a gem if ladybug is killed, in position
        /// where ladybug was killed.
        /// </summary>
        /// <param name="position"></param>
        private void SpawnGem(Rectangle position)
        {
            int index = GlobalVars.RAND.Next(_gemIsNotActive.Count);
            _gemIsNotActive[index].Position = new Rectangle(position.X + 25, position.Y + 25,
                                                    GlobalVars.GEM_WIDTH_HEIGHT, GlobalVars.GEM_WIDTH_HEIGHT);
            _gemIsActive.Add(_gemIsNotActive[index]);
            _gemIsNotActive.RemoveAt(index);
        }

        /// <summary>
        /// Checks if gem is clicked, and moves it into score screen if it is
        /// while setting clickable to false.
        /// Also frees up position where gem was so ladybugs can spawn there again.
        /// </summary>
        private void ClickGem()
        {
            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                if (!_isMousePressed && CheckMousePress.IsBeingPressed(_gemIsActive[i].Position) && _gemIsActive[i].CanClick())
                {
                    for (int j = 0; j < _positionsTaken.Count; j++)
                    {
                        if (_positionsTaken[j].Contains(_gemIsActive[i].Position))
                        {
                            _positions.Add(_positionsTaken[j]);
                            _positionsTaken.RemoveAt(j);
                        }
                    }
                    GlobalVars.gems++;
                    _gemIsActive[i].SetCanClick();
                    _gemIsActive[i].Position = new Rectangle((GlobalVars.SCREEN_WIDTH - (GlobalVars.GEM_WIDTH_HEIGHT * GlobalVars.gems)), 0, GlobalVars.GEM_WIDTH_HEIGHT, GlobalVars.GEM_WIDTH_HEIGHT);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <_ladybugsIsActive.Count; i++)
                _ladybugsIsActive[i].Draw(spriteBatch);
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

            for (int i = 0; i < _ladybugsIsNotActive.Count; i++)
            {
                _ladybugsIsNotActive[i].IsDead = false;
                _ladybugsIsNotActive[i].SetTime(false, 0);
                _ladybugsIsNotActive[i].SetTimeDespawn(false, 0);
                _ladybugsIsNotActive[i].SetClicks(true);
            }

            for (int i = 0; i < _gemIsActive.Count; i++)
            {
                if(!_gemIsActive[i].CanClick())
                    _gemIsActive[i].SetCanClick();
                _gemIsNotActive.Add(_gemIsActive[i]);
                _gemIsActive.RemoveAt(i);
                i--;
            }
            GlobalVars.gems = 0;
            GlobalVars.bugs_killed = 0;
        }
    }
}
