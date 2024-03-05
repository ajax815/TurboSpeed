using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSpeed.Classes;
using Microsoft.Xna.Framework.Audio;
using SharpDX.DirectWrite;
using System.Configuration;
using System.Windows.Forms;

namespace TurboSpeed.Scenes
{
    public class PlayScene : GameScene
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        GrassBackground grassBackground1;
        GrassBackground grassBackground2;
        GrassBackground grassBackground3;
        GrassBackground grassBackground4;
        RoadBackground roadBackground;
        Car car;
        Mine mine1;
        Mine mine2;
        Mine mine3;
        Mine mine4;
        Mine mine5;
        EnemyCarLeft enemyCar1;
        EnemyCarLeft enemyCar3;
        EnemyCarLeft enemyCar5;
        EnemyCarLeft enemyCar7;
        EnemyCarLeft enemyCar9;
        EnemyCarRight enemyCar2;
        EnemyCarRight enemyCar4;
        EnemyCarRight enemyCar6;
        EnemyCarRight enemyCar8;
        EnemyCarRight enemyCar10;
        SoundEffect explosionSound;
        float elapsedSeconds;
        float elapsedSeconds2;
        float timer;
        float newTimer;
        CollisionManager collisionManager1;
        CollisionManager collisionManager2;
        CollisionManager collisionManager3;
        CollisionManager collisionManager4;
        CollisionManager collisionManager5;
        GameOver gameOver;
        YouWin youWin;

        public PlayScene(Game game) : base(game)
        {
            Game1 game1 = (Game1)game;
            spriteBatch = game1._spriteBatch;
            graphics = game1._graphics;

            //Veclocity for the background
            Vector2 backgroundVelocity = new Vector2(0, 1);

            //Stage for the cars
            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //Explosion sound effect
            explosionSound = game1.Content.Load<SoundEffect>("Sounds/CarExplosion1");

            //Grass background load
            Texture2D grassTexture = game1.Content.Load<Texture2D>("Images/grass");
            Rectangle grassRectangle = new Rectangle(0, 0, grassTexture.Width, grassTexture.Height);
            Vector2 grassPosition = new Vector2(0, graphics.PreferredBackBufferHeight + (grassTexture.Height - 200));
            Vector2 grassPosition2 = new Vector2(0, graphics.PreferredBackBufferHeight + (grassTexture.Height + 300));
            Vector2 grassPosition3 = new Vector2(350, graphics.PreferredBackBufferHeight + (grassTexture.Height - 200));
            Vector2 grassPosition4 = new Vector2(350, graphics.PreferredBackBufferHeight + (grassTexture.Height + 300));
            grassBackground1 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition, backgroundVelocity);
            grassBackground2 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition2, backgroundVelocity);
            grassBackground3 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition3, backgroundVelocity);
            grassBackground4 = new GrassBackground(game1, spriteBatch, grassTexture, grassRectangle, grassPosition4, backgroundVelocity);
            this.Components.Add(grassBackground1);
            this.Components.Add(grassBackground2);
            this.Components.Add(grassBackground3);
            this.Components.Add(grassBackground4);

            //Road background load
            Texture2D roadTexture = game1.Content.Load<Texture2D>("Images/RoadBackground1");
            Rectangle roadRectangle = new Rectangle(0, 0, roadTexture.Width, roadTexture.Height);
            Vector2 roadPosition = new Vector2(150, graphics.PreferredBackBufferHeight + (roadTexture.Height - 960));
            roadBackground = new RoadBackground(game1, spriteBatch, roadTexture, roadRectangle, roadPosition, backgroundVelocity);
            this.Components.Add(roadBackground);

            //Mine load
            Texture2D mineTexture = game1.Content.Load<Texture2D>("Images/mine");
            Vector2 minePosition1 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight);
            Rectangle mineRectangle1 = new Rectangle(0, 0, mineTexture.Width, mineTexture.Height);
            Vector2 mineOrigin1 = new Vector2(mineTexture.Width / 2, mineTexture.Height / 3);
            mine1 = new Mine(game1, spriteBatch, mineTexture, minePosition1, mineOrigin1, 0.0f, 0.11f, mineRectangle1, Color.White, stage);
            this.Components.Add(mine1);
            mine2 = new Mine(game1, spriteBatch, mineTexture, minePosition1, mineOrigin1, 0.0f, 0.11f, mineRectangle1, Color.White, stage);
            this.Components.Add(mine2);
            mine3 = new Mine(game1, spriteBatch, mineTexture, minePosition1, mineOrigin1, 0.0f, 0.11f, mineRectangle1, Color.White, stage);
            this.Components.Add(mine3);
            mine4 = new Mine(game1, spriteBatch, mineTexture, minePosition1, mineOrigin1, 0.0f, 0.11f, mineRectangle1, Color.White, stage);
            this.Components.Add(mine4);
            mine5 = new Mine(game1, spriteBatch, mineTexture, minePosition1, mineOrigin1, 0.0f, 0.11f, mineRectangle1, Color.White, stage);
            this.Components.Add(mine5);

            //Enemy car load
            Texture2D enemyTexture1 = game1.Content.Load<Texture2D>("Images/EnemyCar1");
            Vector2 enemyPosition1 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            Rectangle enemyRectangle1 = new Rectangle(0, 0, enemyTexture1.Width, enemyTexture1.Height);
            Vector2 enemyOrigin1 = new Vector2(enemyTexture1.Width / 2, enemyTexture1.Height / 2);
            enemyCar1 = new EnemyCarLeft(game1, spriteBatch, enemyTexture1, enemyPosition1, enemyOrigin1, 4.7f, 0.12f, enemyRectangle1, Color.White, stage);
            this.Components.Add(enemyCar1);

            Texture2D enemyTexture2 = game1.Content.Load<Texture2D>("Images/EnemyCar2");
            Vector2 enemyPosition2 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            Rectangle enemyRectangle2 = new Rectangle(0, 0, enemyTexture2.Width, enemyTexture2.Height);
            Vector2 enemyOrigin2 = new Vector2(enemyTexture2.Width / 2, enemyTexture2.Height / 2);
            enemyCar3 = new EnemyCarLeft(game1, spriteBatch, enemyTexture2, enemyPosition2, enemyOrigin2, 3.15f, 0.11f, enemyRectangle2, Color.White, stage);
            this.Components.Add(enemyCar3);

            Texture2D enemyTexture3 = game1.Content.Load<Texture2D>("Images/EnemyCar3");
            Vector2 enemyPosition3 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            Rectangle enemyRectangle3 = new Rectangle(0, 0, enemyTexture3.Width, enemyTexture3.Height);
            Vector2 enemyOrigin3 = new Vector2(enemyTexture3.Width / 2, enemyTexture3.Height / 2);
            enemyCar5 = new EnemyCarLeft(game1, spriteBatch, enemyTexture3, enemyPosition3, enemyOrigin3, 3.15f, 0.11f, enemyRectangle3, Color.White, stage);
            this.Components.Add(enemyCar5);

            Texture2D enemyTexture4 = game1.Content.Load<Texture2D>("Images/EnemyCar4");
            Vector2 enemyPosition4 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            Rectangle enemyRectangle4 = new Rectangle(0, 0, enemyTexture4.Width, enemyTexture4.Height);
            Vector2 enemyOrigin4 = new Vector2(enemyTexture4.Width / 2, enemyTexture4.Height / 2);
            enemyCar7 = new EnemyCarLeft(game1, spriteBatch, enemyTexture4, enemyPosition4, enemyOrigin4, 4.7f, 0.18f, enemyRectangle4, Color.White, stage);
            this.Components.Add(enemyCar7);

            Vector2 enemyPosition5 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar2 = new EnemyCarRight(game1, spriteBatch, enemyTexture1, enemyPosition5, enemyOrigin1, 1.57f, 0.12f, enemyRectangle1, Color.White, stage);
            this.Components.Add(enemyCar2);

            Vector2 enemyPosition6 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar4 = new EnemyCarRight(game1, spriteBatch, enemyTexture2, enemyPosition6, enemyOrigin1, 0.0f, 0.11f, enemyRectangle2, Color.White, stage);
            this.Components.Add(enemyCar4);

            Vector2 enemyPosition7 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar6 = new EnemyCarRight(game1, spriteBatch, enemyTexture3, enemyPosition7, enemyOrigin1, 0.0f, 0.11f, enemyRectangle3, Color.White, stage);
            this.Components.Add(enemyCar6);

            Vector2 enemyPosition8 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar8 = new EnemyCarRight(game1, spriteBatch, enemyTexture4, enemyPosition8, enemyOrigin1, 1.57f, 0.18f, enemyRectangle4, Color.White, stage);
            this.Components.Add(enemyCar8);

            Vector2 enemyPosition9 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar9 = new EnemyCarLeft(game1, spriteBatch, enemyTexture1, enemyPosition9, enemyOrigin1, 4.7f, 0.12f, enemyRectangle1, Color.White, stage);
            this.Components.Add(enemyCar9);

            Vector2 enemyPosition10 = new Vector2(graphics.PreferredBackBufferWidth / 2 - 200, graphics.PreferredBackBufferHeight - 700);
            enemyCar10 = new EnemyCarRight(game1, spriteBatch, enemyTexture1, enemyPosition10, enemyOrigin1, 1.57f, 0.12f, enemyRectangle1, Color.White, stage);
            this.Components.Add(enemyCar10);

            //Player car Load
            Texture2D carTexture = game1.Content.Load<Texture2D>("Images/PlayerCar");
            Vector2 carPosition = new Vector2(graphics.PreferredBackBufferWidth / 2 + 50, graphics.PreferredBackBufferHeight - 100);
            Vector2 carOrigin = new Vector2(carTexture.Width / 2, carTexture.Height / 2);
            Rectangle carRectangle = new Rectangle(0, 0, carTexture.Width, carTexture.Height);
            Vector2 velocityX = new Vector2(3, 0);
            Vector2 velocityY = new Vector2(0, 3);
            car = new Car(game1, spriteBatch, carTexture, carPosition, carOrigin, 0.0f, 0.1f, carRectangle, Color.White, stage, velocityX, velocityY);
            this.Components.Add(car);

            //Collision manager load
            collisionManager1 = new CollisionManager(game1, car, enemyCar1, enemyCar2, mine1, explosionSound);
            collisionManager2 = new CollisionManager(game1, car, enemyCar3, enemyCar4, mine2, explosionSound);
            collisionManager3 = new CollisionManager(game1, car, enemyCar5, enemyCar6, mine3, explosionSound);
            collisionManager4 = new CollisionManager(game1, car, enemyCar7, enemyCar8, mine4, explosionSound);
            collisionManager5 = new CollisionManager(game1, car, enemyCar9, enemyCar10, mine5, explosionSound);
            this.Components.Add(collisionManager1);
            this.Components.Add(collisionManager2);
            this.Components.Add(collisionManager3);
            this.Components.Add(collisionManager4);

            //All enemy cars are invisible and disabled until a certain game time
            enemyCar3.Visible = false;
            enemyCar3.Enabled = false;
            enemyCar4.Visible = false;
            enemyCar4.Enabled = false;
            enemyCar5.Visible = false;
            enemyCar5.Enabled = false;
            enemyCar6.Visible = false;
            enemyCar6.Enabled = false;
            enemyCar7.Visible = false;
            enemyCar7.Enabled = false;
            enemyCar8.Visible = false;
            enemyCar8.Enabled = false;
            enemyCar9.Visible = false;
            enemyCar9.Enabled = false;
            enemyCar10.Visible = false;
            enemyCar10.Enabled = false;

            //Same goes with the mines
            mine1.Visible = false;
            mine1.Enabled = false;
            mine2.Visible = false;
            mine2.Enabled = false;
            mine3.Visible = false;
            mine3.Enabled = false;
            mine4.Visible = false;
            mine4.Enabled = false;
            mine5.Visible = false;
            mine5.Enabled = false;


            //Load for "Game over" message
            Texture2D gameOverTexture = game1.Content.Load<Texture2D>("Images/gameOver");
            gameOver = new GameOver(game1, spriteBatch, gameOverTexture, new Vector2(100, 100));
            this.Components.Add(gameOver);
            gameOver.Visible = false;
        }
        public override void Update(GameTime gameTime)
        {
            //Making everything visible and enabled after certain game time has passed
            //ChangeVelocity methods are used to make the mines go with the background movement
            elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += elapsedSeconds;
            if (timer >= 30f)
            {
                enemyCar3.Visible = true;
                enemyCar3.Enabled = true;
                enemyCar4.Visible = true;
                enemyCar4.Enabled = true;
                mine1.Visible = true;
                mine1.Enabled = true;
            }
            if (timer >= 60f)
            {
                enemyCar5.Visible = true;
                enemyCar5.Enabled = true;
                enemyCar6.Visible = true;
                enemyCar6.Enabled = true;
                mine2.Visible = true;
                mine2.Enabled = true;
                mine1.ChangeVelocity1();
                mine2.ChangeVelocity1();
            }
            if (timer >= 90f)
            {
                enemyCar7.Visible = true;
                enemyCar7.Enabled = true;
                enemyCar8.Visible = true;
                enemyCar8.Enabled = true;
                mine3.Visible = true;
                mine3.Enabled = true;
                mine3.ChangeVelocity1();
            }
            if (timer >= 120f)
            {
                enemyCar9.Visible = true;
                enemyCar9.Enabled = true;
                enemyCar10.Visible = true;
                enemyCar10.Enabled = true;
                mine4.Visible = true;
                mine4.Enabled = true;
                mine1.ChangeVelocity2();
                mine2.ChangeVelocity2();
                mine3.ChangeVelocity2();
                mine4.ChangeVelocity2();
            }
            if (timer >= 180f)
            {
                mine5.Visible = true;
                mine5.Enabled = true;
                mine1.ChangeVelocity3();
                mine2.ChangeVelocity3();
                mine3.ChangeVelocity3();
                mine4.ChangeVelocity3();
                mine5.ChangeVelocity3();
            }
            if (timer >= 240f)
            {
                mine1.ChangeVelocity4();
                mine2.ChangeVelocity4();
                mine3.ChangeVelocity4();
                mine4.ChangeVelocity4();
                mine5.ChangeVelocity4();
            }
            if (timer >= 300f && car.Visible == true)
            {
                //Hiding this scene after game has been won
                this.Hide();
            }

            //Condition for game over
            if (car.Visible == false)
            {
                elapsedSeconds2 = (float)gameTime.ElapsedGameTime.TotalSeconds;
                newTimer += elapsedSeconds2;
                if (newTimer >= 3)
                {
                    gameOver.Visible = true;
                }
            }
            base.Update(gameTime);
        }

    }
}
