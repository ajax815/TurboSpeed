using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurboSpeed
{
    internal class RoadBackground : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position1, position2;
        Vector2 velocity;
        float elapsedSeconds;
        float timer = 0f;

        internal RoadBackground(Game game, SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Vector2 position, Vector2 velocity) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.rectangle = rectangle;
            this.position1 = position;
            this.position2 = new Vector2(position1.X, position1.Y + rectangle.Height);
            this.velocity = velocity;
        }

        public override void Update(GameTime gameTime)
        {
            elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += elapsedSeconds;

            if (timer >= 60f)
            {
                if (velocity.Y == 0)
                {
                    velocity = new Vector2(0, 0);
                    timer = 0f;
                }
                else
                {
                    velocity += new Vector2(0, 1.0f);
                    timer = 0f;
                }
            }

            Vector2 changedVelocity = velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;

            this.position1 += changedVelocity;
            this.position2 += changedVelocity;

            if (position1.Y > Game.GraphicsDevice.Viewport.Height)
            {
                position1.Y = position2.Y - rectangle.Height;
            }
            if (position2.Y > Game.GraphicsDevice.Viewport.Height)
            {
                position2.Y = position1.Y - rectangle.Height;
            }
           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position1, rectangle, Color.White);
            spriteBatch.Draw(texture, position2, rectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
