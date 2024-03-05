using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed.Classes
{
    internal class ExplosionAnimation : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        const int col = 5, row = 5;
        double counter;
        int currentFrame;
        double timePerFrame = 0.1;

        public ExplosionAnimation(Game game, SpriteBatch spriteBatch, Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = game.Content.Load<Texture2D>("Images/explosion");
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            counter += gameTime.ElapsedGameTime.TotalSeconds;
            if (counter >= timePerFrame)
            {
                counter -= timePerFrame;
                currentFrame++;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            int width = texture.Width / col;
            int height = texture.Height / row;
            Rectangle rectangle = new Rectangle(width * (currentFrame % col), height * (currentFrame / col), width, height);
            spriteBatch.Draw(texture, position, rectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
