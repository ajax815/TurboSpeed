using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed.Classes
{
    internal class EnemyCarLeft : DrawableGameComponent
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

        internal EnemyCarLeft(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 origin, float rotation, float scale, Rectangle rectangle, Color color, Vector2 stage) : base(game)
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

            //Random x coordinate to spawn at
            float randomXLeft = random.Next(170, 360);
            this.position = new Vector2(randomXLeft, -400);

            //Random velocity method
            RandomVelocity();
        }

        public override void Update(GameTime gameTime)
        {
            elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += elapsedSeconds;

            //Assigning random velocities after certain game time
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

            position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;

            if (isRespawning)
            {
                respawnTimer += elapsedSeconds;
                if (respawnTimer >= 1.0f)
                {
                    float randomXLeft = random.Next(170, 360);
                    position = new Vector2(randomXLeft, -400);
                    timer = 0f;
                    isRespawning = false;
                    respawnTimer = 0.0f;
                }

            }
            else
            {
                if (position.Y > stage.Y)
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
            return new Rectangle((int)position.X + 10, (int)position.Y, 30, 50);
        }
    }
}
