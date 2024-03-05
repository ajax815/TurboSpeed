using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed.Classes
{
    internal class EnemyCarRight : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Vector2 origin;
        float rotation;
        float scale;
        Rectangle rectangle;
        Color color;
        Vector2 velocity;
        float elapsedSeconds;
        float timer;
        Random random;
        Vector2 stage;
        bool isRespawning = false;
        float respawnTimer = 0.0f;
        float spawnTimer = 0.0f;

        internal EnemyCarRight(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 origin, float rotation, float scale, Rectangle rectangle, Color color, Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;

            this.origin = origin;
            this.rotation = rotation;
            this.scale = scale;
            this.rectangle = rectangle;
            this.color = color;
            this.stage = stage;

            random = new Random();

            float randomXRight = random.Next(440, 600);
            this.position = new Vector2(randomXRight, 800);

            RandomVelocity();
        }

        public override void Update(GameTime gameTime)
        {
            elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += elapsedSeconds;
            spawnTimer += elapsedSeconds;
            if (spawnTimer >= 4f) 
            {
                position -= velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
            }
            
            if (timer >= 60f)
            {
                RandomVelocity1Minute();
            }
            if (timer >= 120f)
            {
                RandomVelocity2Minutes();
            }
            if (timer >= 180f)
            {
                RandomVelocity3Minutes();
            }
            if (timer >= 240f)
            {
                RandomVelocity4Minutes();
            }

            if (isRespawning)
            {

                respawnTimer += elapsedSeconds;
                if (respawnTimer >= 1.0f)
                {
                    float randomXRight = random.Next(440, 600);
                    position = new Vector2(randomXRight, 600);
                    timer = 0f;
                    isRespawning = false;
                    respawnTimer = 0.0f;
                }

            }
            else
            {
                if (position.Y < 0)
                {
                    isRespawning = true;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, rectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0.0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }


        public void RandomVelocity()
        {
            float minSpeed = 2.0f;
            float maxSpeed = 4.0f;
            float randomSpeed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            velocity = new Vector2(0, randomSpeed);
        }
        public void RandomVelocity1Minute()
        {
            float minSpeed = 4.0f;
            float maxSpeed = 7.0f;
            float randomSpeed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            velocity = new Vector2(0, randomSpeed);
        }
        public void RandomVelocity2Minutes()
        {
            float minSpeed = 7.0f;
            float maxSpeed = 11.0f;
            float randomSpeed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            velocity = new Vector2(0, randomSpeed);
        }
        public void RandomVelocity3Minutes()
        {
            float minSpeed = 11.0f;
            float maxSpeed = 15.0f;
            float randomSpeed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            velocity = new Vector2(0, randomSpeed);
        }
        public void RandomVelocity4Minutes()
        {
            float minSpeed = 15.0f;
            float maxSpeed = 20.0f;
            float randomSpeed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            velocity = new Vector2(0, randomSpeed);
        }
        internal Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, 30, 50);
        }
    }
}
