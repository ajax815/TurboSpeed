using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace TurboSpeed.Scenes
{
    public class HelpScene : GameScene
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        Texture2D helpTexture1;
        Texture2D helpTexture2;
        Texture2D helpTexture3;
        Texture2D helpTexture4;
        Texture2D roadTexture;
        Texture2D arrowKeysTexture;
        Texture2D carTexture;
        Texture2D enemyTexture1;
        Texture2D enemyTexture2;
        Texture2D enemyTexture3;
        Texture2D enemyTexture4;
        Texture2D mineTexture;

        //Scene for the help option
        public HelpScene(Game game) : base(game) 
        {
            Game1 game1 = (Game1)game;
            spriteBatch = game1._spriteBatch;
            graphics = game1._graphics;

            roadTexture = game1.Content.Load<Texture2D>("Images/RoadBackground1");
            carTexture = game1.Content.Load<Texture2D>("Images/PlayerCar");
            helpTexture1 = game1.Content.Load<Texture2D>("Images/HelpBubble1");
            helpTexture2 = game1.Content.Load<Texture2D>("Images/HelpBubble2");
            helpTexture3 = game1.Content.Load<Texture2D>("Images/HelpBubble3");
            helpTexture4 = game1.Content.Load<Texture2D>("Images/HelpBubble4");
            arrowKeysTexture = game1.Content.Load<Texture2D>("Images/ArrowKeys");
            enemyTexture1 = game1.Content.Load<Texture2D>("Images/EnemyCar1");
            enemyTexture2 = game1.Content.Load<Texture2D>("Images/EnemyCar2");
            enemyTexture3 = game1.Content.Load<Texture2D>("Images/EnemyCar3");
            enemyTexture4 = game1.Content.Load<Texture2D>("Images/EnemyCar4");
            mineTexture = game1.Content.Load<Texture2D>("Images/mine");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //Draw road
            spriteBatch.Draw(roadTexture, new Vector2(150, graphics.PreferredBackBufferHeight + (roadTexture.Height - 960)), new Rectangle(0, 0, roadTexture.Width, roadTexture.Height), Color.White);
            //Draw player car
            spriteBatch.Draw(carTexture, new Vector2(graphics.PreferredBackBufferWidth / 2 + 50, graphics.PreferredBackBufferHeight - 50), new Rectangle(0, 0, carTexture.Width, carTexture.Height), Color.White, 0.0f, new Vector2(carTexture.Width / 2, carTexture.Height / 2), 0.1f, SpriteEffects.None, 0.0f);
            //Draw enemy cars
            spriteBatch.Draw(enemyTexture1, new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 250), new Rectangle(0, 0, enemyTexture1.Width, enemyTexture1.Height), Color.White, 4.7f, new Vector2(enemyTexture1.Width / 2, enemyTexture1.Height / 2), 0.13f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(enemyTexture2, new Vector2(graphics.PreferredBackBufferWidth / 2 + 50, graphics.PreferredBackBufferHeight - 320), new Rectangle(0, 0, enemyTexture2.Width, enemyTexture2.Height), Color.White, 0.0f, new Vector2(enemyTexture2.Width / 2, enemyTexture2.Height / 2), 0.1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(enemyTexture3, new Vector2(graphics.PreferredBackBufferWidth / 2 + 180, graphics.PreferredBackBufferHeight - 400), new Rectangle(0, 0, enemyTexture3.Width, enemyTexture3.Height), Color.White, 0.0f, new Vector2(enemyTexture3.Width / 2, enemyTexture3.Height / 2), 0.1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(enemyTexture4, new Vector2(graphics.PreferredBackBufferWidth / 2 - 80, graphics.PreferredBackBufferHeight - 150), new Rectangle(0, 0, enemyTexture4.Width, enemyTexture4.Height), Color.White, 4.7f, new Vector2(enemyTexture4.Width / 2, enemyTexture4.Height / 2), 0.18f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(mineTexture, new Vector2(graphics.PreferredBackBufferWidth / 2 - 190, graphics.PreferredBackBufferHeight - 120), new Rectangle(0, 0, enemyTexture4.Width, enemyTexture4.Height), Color.White, 0.0f, new Vector2(enemyTexture4.Width / 2, enemyTexture4.Height / 2), 0.11f, SpriteEffects.None, 0.0f);
            //Draw help bubbles and icons
            //Draw help bubbles and icons
            spriteBatch.Draw(helpTexture1, new Vector2(graphics.PreferredBackBufferWidth + 20, graphics.PreferredBackBufferHeight - 150), new Rectangle(0, 0, helpTexture1.Width, helpTexture1.Height), Color.White, 0.0f, new Vector2(helpTexture1.Width, helpTexture1.Height), 0.3f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(helpTexture2, new Vector2(graphics.PreferredBackBufferWidth - 220, graphics.PreferredBackBufferHeight - 90), new Rectangle(0, 0, helpTexture1.Width, helpTexture1.Height), Color.White, 0.0f, new Vector2(helpTexture1.Width, helpTexture1.Height), 0.3f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(arrowKeysTexture, new Vector2(graphics.PreferredBackBufferWidth - 10, graphics.PreferredBackBufferHeight - 20), new Rectangle(0, 0, arrowKeysTexture.Width, arrowKeysTexture.Height), Color.White, 0.0f, new Vector2(arrowKeysTexture.Width, arrowKeysTexture.Height), 0.13f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(helpTexture3, new Vector2(graphics.PreferredBackBufferWidth - 460, graphics.PreferredBackBufferHeight - 290), new Rectangle(0, 0, helpTexture1.Width, helpTexture1.Height), Color.White, 0.0f, new Vector2(helpTexture1.Width, helpTexture1.Height), 0.3f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(helpTexture4, new Vector2(graphics.PreferredBackBufferWidth - 660, graphics.PreferredBackBufferHeight - 70), new Rectangle(0, 0, helpTexture4.Width, helpTexture4.Height), Color.White, 0.0f, new Vector2(helpTexture1.Width, helpTexture1.Height), 0.25f, SpriteEffects.None, 0.0f);

            spriteBatch.End();
            base.Draw(gameTime); 
        }
    }
}
