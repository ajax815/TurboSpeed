using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using TurboSpeed.Classes;
using TurboSpeed.Scenes;

namespace TurboSpeed
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private MenuScene menuScene;
        private PlayScene playScene;
        private HelpScene helpScene;
        private List<GameScene> GameScenes;
        private Song backgroundMusic;
        Texture2D grassTexture;
        YouWin youWin;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            //Menu load
            menuScene = new MenuScene(this);
            Components.Add(menuScene);
            menuScene.Show();
            //Loading background music
            backgroundMusic = this.Content.Load<Song>("Sounds/TurboSpeed_BGM");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            //declaring keyboard and mouse state
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            
            if (menuScene.Visible)
            {
                //Event for clicking with left mouse button
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    int selectedScene = menuScene.getSelectedIndex();
                    menuScene.Hide();
                    //Switch statement for menu options
                    switch (selectedScene)
                    {
                        case 0:
                            //Play scene begins when selecting "Play"
                            playScene = new PlayScene(this);
                            Components.Add(playScene);
                            playScene.Show();
                            break;

                        case 1:
                            //Help scene is displayed when selecting "Help"
                            helpScene = new HelpScene(this);
                            Components.Add(helpScene);
                            helpScene.Show();
                            break;

                        case 2:
                            //Game closes when selecting "Exit"
                            Exit();
                            break;
                        default: break;
                    }
                    if (menuScene.getSelectedIndex() == -1)
                    {
                        menuScene.Show();
                    }
                }
            }
            else
            {
                //Event for esc key
                if (ks.IsKeyDown(Keys.Escape))
                {
                    if (playScene != null)
                    {
                        playScene.Hide();
                    }
                    if (helpScene != null)
                    {
                        helpScene.Hide();
                    }
                    Texture2D youWinTexture = this.Content.Load<Texture2D>("Images/youWin");
                    youWin = new YouWin(this, _spriteBatch, youWinTexture, new Vector2(100, -130));
                    this.Components.Add(youWin);
                    youWin.Visible = false;
                    menuScene.Show();
                }
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Drawing all assets in the game
            grassTexture = this.Content.Load<Texture2D>("Images/grass");
            _spriteBatch.Begin();
            _spriteBatch.Draw(grassTexture, new Vector2(0, 0), new Rectangle(0, 0, grassTexture.Width, grassTexture.Height), Color.White);
            _spriteBatch.Draw(grassTexture, new Vector2(350, 0), new Rectangle(0, 0, grassTexture.Width, grassTexture.Height), Color.White);
            _spriteBatch.Draw(grassTexture, new Vector2(0, 200), new Rectangle(0, 0, grassTexture.Width, grassTexture.Height), Color.White);
            _spriteBatch.Draw(grassTexture, new Vector2(350, 200), new Rectangle(0, 0, grassTexture.Width, grassTexture.Height), Color.White);
            _spriteBatch.End();
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }
}