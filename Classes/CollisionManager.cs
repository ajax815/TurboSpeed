using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using TurboSpeed.Scenes;

namespace TurboSpeed.Classes
{
    internal class CollisionManager : DrawableGameComponent
    {
        Car car;
        EnemyCarLeft enemyLeft;
        EnemyCarRight enemyRight;
        Mine mine;
        SoundEffect sound;
        bool isCollide = true;
        Game1 game1;
        ExplosionAnimation explosionAnimation;
        SpriteBatch spriteBatch;

        internal CollisionManager(Game game, Car car, EnemyCarLeft enemyLeft, EnemyCarRight enemyRight, Mine mine, SoundEffect sound) : base(game)
        {
            this.car = car;
            this.enemyLeft = enemyLeft;
            this.enemyRight = enemyRight;
            this.mine = mine;
            this.sound= sound;
            game1 = (Game1)game;
            spriteBatch = game1._spriteBatch;
        }

        public override void Update(GameTime gameTime)
        {
            //condition for collisions
            if (car.getBounds().Intersects(enemyLeft.getBounds()) || car.getBounds().Intersects(enemyRight.getBounds()) || car.getBounds().Intersects(mine.getBounds()))
            {
                mine.RemoveMine();
                if (isCollide)
                {
                    explosionAnimation = new ExplosionAnimation(game1, spriteBatch, car.getPosition());
                    game1.Components.Add(explosionAnimation);
                    sound.Play();
                    car.RemoveCar();
                    
                }
                isCollide = false;
            }
            base.Update(gameTime);
        }
    }
}
