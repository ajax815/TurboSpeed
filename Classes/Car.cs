using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed.Classes
{
    internal class Car : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Vector2 origin;
        float rotation;
        float scale;
        Rectangle rectangle;
        Color color;
        Vector2 stage;
        Vector2 velocityX, velocityY;


        internal Car(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 origin, float rotation, float scale, Rectangle rectangle, Color color, Vector2 stage, Vector2 velocityX, Vector2 velocityY) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.origin = origin;
            this.rotation = rotation;
            this.scale = scale;
            this.rectangle = rectangle;
            this.color = color;
            this.stage = stage;
            this.velocityX = velocityX;
            this.velocityY = velocityY;
        }
        
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            //Movement controls for the car
            if (ks.IsKeyDown(Keys.Left))
            {
                position -= velocityX * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += velocityX * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position -= velocityY * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position += velocityY * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
            }
            if (position.Y > stage.Y)
            {
                position.Y = stage.Y - 1;
            }
            if (position.X > stage.X - 190)
            {
                position.X = stage.X - 190;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X < 170)
            {
                position.X = 170;
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
        //Method to get the bounds for collision
        internal Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width / 10, texture.Height / 10);
        }
        //Method to get position for explosion animation
        internal Vector2 getPosition()
        {
            return position;
        }
        //method to remove car once collision occurs
        internal void RemoveCar()
        {
            Enabled = false;
            Visible = false;
            position.X = 0;
            position.Y = 0;
            velocityX.X = 0;
            velocityY.Y = 0;
        }
    }
}
