using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSpeed.Classes;

namespace TurboSpeed.Scenes
{
    public class MenuScene : GameScene
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        MenuComponent menu;
        GrassBackground grassBackground1;
        GrassBackground grassBackground2;
        Car car;

        public int getSelectedIndex()
        {
            return menu.selectedIndex;
        }

        //Scene for loading the main menu
        public MenuScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            spriteBatch = game1._spriteBatch;
            graphics = game1._graphics;

            Vector2 backgroundVelocity = new Vector2(0, 0);

            //Loading all the sprites into the menu
            Texture2D grassTexture = game1.Content.Load<Texture2D>("Images/grass");
            Rectangle grassRectangle = new Rectangle(0, 0, grassTexture.Width, grassTexture.Height);
            Vector2 grassPosition = new Vector2(0, graphics.PreferredBackBufferHeight + (grassTexture.Height - 200));
            Vector2 grassPosition2 = new Vector2(350, graphics.PreferredBackBufferHeight + (grassTexture.Height - 200));
            grassBackground1 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition, backgroundVelocity);
            grassBackground2 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition2, backgroundVelocity);
            this.Components.Add(grassBackground1);
            this.Components.Add(grassBackground2);
            
            SpriteFont regularFont = game1.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightedFont = game1.Content.Load<SpriteFont>("Fonts/highlightedFont");
            Vector2 position = new Vector2(100, 100);
            string[] items = new string[] { "Play", "Help", "Exit" };
            menu = new MenuComponent(game1, spriteBatch, regularFont, highlightedFont, position, items, Color.Black, Color.Red);
            this.Components.Add(menu);

            Texture2D carTexture = game1.Content.Load<Texture2D>("Images/PlayerCar");
            Vector2 carPosition = new Vector2(graphics.PreferredBackBufferWidth - 250, graphics.PreferredBackBufferHeight / 2);
            Vector2 carOrigin = new Vector2(carTexture.Width / 2, carTexture.Height / 2);
            Rectangle carRectangle = new Rectangle(0, 0, carTexture.Width, carTexture.Height);
            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Vector2 velocityX = new Vector2(0, 0);
            Vector2 velocityY = new Vector2(0, 0);
            car = new Car(game1, spriteBatch, carTexture, carPosition, carOrigin, 0.0f, 0.45f, carRectangle, Color.White, stage, velocityX, velocityY);
            this.Components.Add(car);
        }
    }
}
