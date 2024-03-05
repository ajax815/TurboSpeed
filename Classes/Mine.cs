using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed.Classes
{
    internal class Mine : DrawableGameComponent
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

        internal Mine(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 origin, float rotation, float scale, Rectangle rectangle, Color color, Vector2 stage) : base(game)
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

            float randomXLeft = random.Next(170, 360);
            this.position = new Vector2(randomXLeft, - 400);

            this.velocity = new Vector2(0, 1);
        }

        public override void Update(GameTime gameTime)
        {
            elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += elapsedSeconds;
            if (timer >= 60f)
            {
                velocity += new Vector2(0, 1.0f);
                timer = 0f;
            }

            position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;

            if (isRespawning)
            {
                respawnTimer += elapsedSeconds;
                if (respawnTimer >= 1.0f)
                {
                    float randomXLeft = random.Next(170, 600);
                    position = new Vector2(randomXLeft, -400);
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
        internal Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, 30, 50);
        }
        internal void RemoveMine()
        {
            Enabled = false;
            Visible = false;
        }
        public void ChangeVelocity1()
        {
            velocity = new Vector2(0, 2.0f);
        }
        public void ChangeVelocity2()
        {
            velocity = new Vector2(0, 3.0f);
        }
        public void ChangeVelocity3()
        {
            velocity = new Vector2(0, 4.0f);
        }
        public void ChangeVelocity4()
        {
            velocity = new Vector2(0, 5.0f);
        }
    }
}
