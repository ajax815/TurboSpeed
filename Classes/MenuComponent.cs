using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSpeed
{
    internal class MenuComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont regularFont, highlightedFont;
        Vector2 position;
        string[] items;
        Color regularColor, highlightedColor;
        public int selectedIndex = 0;

        internal MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont regularFont, SpriteFont highlightedFont, Vector2 position, string[] items, Color regularColor, Color highlightedColor) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightedFont = highlightedFont;
            this.position = position;
            this.items = items;
            this.regularColor = regularColor;
            this.highlightedColor = highlightedColor;
        }

        public override void Update(GameTime gameTime)
        {
            //User clicks on menu items to play the game or to open the help menu
            MouseState ms = Mouse.GetState();
            Rectangle mouse = new Rectangle(ms.X, ms.Y, 1, 1);

            for (int i = 0; i < items.Length; i++)
            {
                Rectangle menuItem = new Rectangle((int)position.X, (int)position.Y + highlightedFont.LineSpacing * i, (int)highlightedFont.MeasureString(items[i]).X, (int)highlightedFont.MeasureString(items[i]).Y);

                if (mouse.Intersects(menuItem))
                {
                    selectedIndex = i;
                    break;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < items.Length; i++)
            {
                if (i == selectedIndex)
                {
                    spriteBatch.DrawString(highlightedFont, items[i], new Vector2(position.X, position.Y + highlightedFont.LineSpacing * i), highlightedColor);
                }
                else
                {
                    spriteBatch.DrawString(regularFont, items[i], new Vector2(position.X, position.Y + highlightedFont.LineSpacing * i), regularColor);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
